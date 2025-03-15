using System;
using System.IO;

namespace AlLiberali.Blend2NET;

public sealed partial class FileStream : Stream, IDisposable, IBlendObject {
	private BLFileCore self;
	private Boolean isDisposed;
	private readonly Boolean canRead;
	private readonly Boolean canWrite;
	public Boolean IsOpen { get => self.handle != (IntPtr) (-1); }
	public override Int64 Position {
		get {
			return Seek(0, SeekOrigin.Current);
		}
		set {
			Seek(value, SeekOrigin.Begin);
		}
	}
	public override Boolean CanRead => canRead;
	public override Boolean CanWrite => canWrite;
	public override Boolean CanSeek => true;
	public Boolean IsRegular  => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_REGULAR);
	public Boolean IsDirectory => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_DIRECTORY);
	public Boolean IsSymlink => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_SYMLINK);
	public Boolean IsCharacterDevice => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_CHAR_DEVICE);
	public Boolean IsBlockDevice => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_BLOCK_DEVICE);
	public Boolean IsFIFO => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_FIFO);
	public Boolean IsSocket => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_SOCKET);
	public Boolean IsHidden => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_HIDDEN);
	public Boolean IsArchive => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_ARCHIVE);
	public Boolean IsSystem => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_SYSTEM);
	public Boolean IsExecutable => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_EXECUTABLE);
	public Boolean IsValid => CheckFileInfoFlag(BLFileInfoFlags.BL_FILE_INFO_VALID);
	/// <summary>
	/// Returns a tuple of 3 tuples and 2 booleans of permissions in a UNIX fashion.
	/// </summary>
	/// <example><c>var canGroupWrite = Permissions.Group.Write</c></example>
	public ((Boolean Read, Boolean Write, Boolean Execute) World, (Boolean Read, Boolean Write, Boolean Execute) Group, (Boolean Read, Boolean Write, Boolean Execute) Owner, Boolean SUID, Boolean SGID) Permissions {
		get {
			if (!IsOpen)
				throw new InvalidOperationException("Property access attempted on a file not open");
			var err = blFileGetInfo(ref self, out BLFileInfo info);
			var ret = (
					(
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_OTHER_R) != 0,
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_OTHER_W) != 0,
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_OTHER_X) != 0
					),
					(
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_GROUP_R) != 0,
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_GROUP_W) != 0,
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_GROUP_X) != 0
					),
					(
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_OWNER_R) != 0,
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_OWNER_W) != 0,
						(info.flags & BLFileInfoFlags.BL_FILE_INFO_OWNER_X) != 0
					),
					(info.flags & BLFileInfoFlags.BL_FILE_INFO_SUID) != 0,
					(info.flags & BLFileInfoFlags.BL_FILE_INFO_SGID) != 0
				);
			return err == BLResult.BL_SUCCESS
				? ret
				: throw new BlendException(err);
		}
	}
	/// <summary>
	/// When was the file last modified in UTC
	/// </summary>
	public DateTime Modified {
		get {
			if (!IsOpen)
				throw new InvalidOperationException("Property access attempted on a file not open");
			var err = blFileGetInfo(ref self, out BLFileInfo info);
			return err == BLResult.BL_SUCCESS
				? DateTimeOffset.FromUnixTimeMilliseconds(info.modifiedTime / 1000).UtcDateTime
				: throw new BlendException(err);
		}
	}
	/// <inheritdoc/>
	/// <exception cref="InvalidOperationException">When file is not open</exception>
	/// <exception cref="BlendException">When the native bits fail.  It includes a message citing the Blend2D error code.</exception>
	public override Int64 Length {
		get {
			if (!IsOpen)
				throw new InvalidOperationException("Property access attempted on a file not open");
			var err = blFileGetSize(ref self, out UInt64 ret);
			return err == BLResult.BL_SUCCESS
				? (Int64) ret
				: throw new BlendException(err);
		}
	}
	/// <param name="fileName"></param>
	/// <param name="flags"></param>
	/// <exception cref="BlendException">When the file cant be opened. It includes a message citing the Blend2D error code</exception>
	public FileStream(string fileName, BLFileOpenFlags flags) {
		canRead = (flags & BLFileOpenFlags.BL_FILE_OPEN_READ) != 0;
		canWrite = (flags & BLFileOpenFlags.BL_FILE_OPEN_WRITE) != 0;
		var err = blFileInit(ref self);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		err = blFileOpen(ref self, fileName, flags);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	~FileStream() {
		Dispose();
	}
	protected override void Dispose(Boolean disposing) {
		if (isDisposed)
			return;
		blFileClose(ref self);
		isDisposed = true;
		base.Dispose(disposing);
	}
	/// <inheritdoc/>
	/// <exception cref="InvalidOperationException">When file is not open</exception>
	/// <exception cref="BlendException">When the native bits fail.  It includes a message citing the Blend2D error code.</exception>
	public override Int64 Seek(Int64 offset, SeekOrigin origin) {
		if (!IsOpen)
			throw new InvalidOperationException("Seeking attempted on a file not open");
		if (isDisposed)
			throw new ObjectDisposedException("FileStream");
		var err = blFileSeek(ref self, (UInt64) offset, (BLFileSeekType) origin, out UInt64 newPosition);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		return (Int64) newPosition;
	}
	public override void Flush() { }
	/// <summary>
	/// Truncates the file to the given maximum size <paramref name="value"/>.
	/// Additionally it seeks to the newly set <paramref name="value"/>, which will be the EOF,
	/// if the file position is after is after that of the new EOF.
	/// </summary>
	/// <param name="value">The size of the file in bytes</param>
	/// <exception cref="InvalidOperationException">When file is not open</exception>
	/// <exception cref="BlendException">When the native bits fail.  It includes a message citing the Blend2D error code.</exception>
	public override void SetLength(Int64 value) {
		if (!IsOpen)
			throw new InvalidOperationException("Truncation attempted on a file not open");
		var err = blFileTruncate(ref self, value);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	/// <inheritdoc/>
	/// <exception cref="BlendException">When the native bits fail.  It includes a message citing the Blend2D error code.</exception>
	public override Int32 Read(Byte[] buffer, Int32 offset, Int32 count) {
		if (offset + count > buffer.Length)
			throw new ArgumentException("offset + count > buffer.Length");
		if (buffer == null)
			throw new ArgumentNullException(nameof(buffer));
		if (offset < 0)
			throw new ArgumentOutOfRangeException(nameof(offset));
		if (count < 0)
			throw new ArgumentOutOfRangeException(nameof(count));
		if (isDisposed)
			throw new ObjectDisposedException("FileStream");
		Span<byte> bytes = stackalloc byte[count];
		BLResult err;
		UIntPtr ret = UIntPtr.Zero;
		unsafe {
			fixed (byte* p = bytes)
				err = blFileRead(ref self, p, (UIntPtr) count, out ret);
		}
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		bytes.CopyTo(buffer.AsSpan(offset, count));
		return (Int32) ret;
	}
	public override void Write(Byte[] buffer, Int32 offset, Int32 count) {
		if (offset + count > buffer.Length)
			throw new ArgumentException("offset + count > buffer.Length");
		if (buffer == null)
			throw new ArgumentNullException(nameof(buffer));
		if (offset < 0)
			throw new ArgumentOutOfRangeException(nameof(offset));
		if (count < 0)
			throw new ArgumentOutOfRangeException(nameof(count));
		if (isDisposed)
			throw new ObjectDisposedException("FileStream");
		Span<byte> bytes = stackalloc byte[count];
		BLResult err;
		buffer.AsSpan().CopyTo(bytes);
		unsafe {
			fixed (byte* p = bytes)
				err = blFileWrite(ref self, p, (UIntPtr) count, out _);
		}
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	private Boolean CheckFileInfoFlag(BLFileInfoFlags f) {
		if (!IsOpen)
			throw new InvalidOperationException("Property access attempted on a file not open");
		var err = blFileGetInfo(ref self, out BLFileInfo info);
		return err == BLResult.BL_SUCCESS
			? (info.flags & f) != 0
			: throw new BlendException(err);
	}

	IBlendStruct IBlendObject.Thyself() => self;
	R IBlendObject.Apply<R>(Func<IBlendStruct, R> func) => func(self);
}

using System;
using System.IO;
using System.Runtime.InteropServices;
using static AlLiberali.Blend2NET.Common;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA1401
#pragma warning disable CA1707
#pragma warning disable CA1711
#pragma warning disable CA2101

public sealed partial class FileStream : Stream, IDisposable {
	/// <summary>
	/// File information flags, used by <see cref="BLFileInfo"/>.
	/// </summary>
	public enum BLFileInfoFlags : UInt32 {
		/// <summary>
		/// File owner has read permission (compatible with 0400 octal notation).
		/// </summary>
		BL_FILE_INFO_OWNER_R = 0x00000100u,
		/// <summary>
		/// File owner has write permission (compatible with 0200 octal notation).
		/// </summary>
		BL_FILE_INFO_OWNER_W = 0x00000080u,
		/// <summary>
		/// File owner has execute permission (compatible with 0100 octal notation).
		/// </summary>
		BL_FILE_INFO_OWNER_X = 0x00000040u,
		/// <summary>
		/// A combination of <see cref="BL_FILE_INFO_OWNER_R"/>, <see cref="BL_FILE_INFO_OWNER_W"/>, and <see cref="BL_FILE_INFO_OWNER_X"/>.
		/// </summary>
		BL_FILE_INFO_OWNER_MASK = 0x000001C0u,

		/// <summary>
		/// File group owner has read permission (compatible with 040 octal notation).
		/// </summary>
		BL_FILE_INFO_GROUP_R = 0x00000020u,
		/// <summary>
		/// File group owner has write permission (compatible with 020 octal notation).
		/// </summary>
		BL_FILE_INFO_GROUP_W = 0x00000010u,
		/// <summary>
		/// File group owner has execute permission (compatible with 010 octal notation).
		/// </summary>
		BL_FILE_INFO_GROUP_X = 0x00000008u,
		/// <summary>
		/// A combination of <see cref="BL_FILE_INFO_GROUP_R"/>, <see cref="BL_FILE_INFO_GROUP_W"/>, and <see cref="BL_FILE_INFO_GROUP_X"/>.
		/// </summary>
		BL_FILE_INFO_GROUP_MASK = 0x00000038u,

		/// <summary>
		/// Other users have read permission (compatible with 04 octal notation).
		/// </summary>
		BL_FILE_INFO_OTHER_R = 0x00000004u,
		/// <summary>
		/// Other users have write permission (compatible with 02 octal notation).
		/// </summary>
		BL_FILE_INFO_OTHER_W = 0x00000002u,
		/// <summary>
		/// Other users have execute permission (compatible with 01 octal notation).
		/// </summary>
		BL_FILE_INFO_OTHER_X = 0x00000001u,
		/// <summary>
		/// A combination of <see cref="BL_FILE_INFO_OTHER_R"/>, <see cref="BL_FILE_INFO_OTHER_W"/>, and <see cref="BL_FILE_INFO_OTHER_X"/>.
		/// </summary>
		BL_FILE_INFO_OTHER_MASK = 0x00000007u,

		/// <summary>
		/// Set user ID to file owner user ID on execution (compatible with 04000 octal notation).
		/// </summary>
		BL_FILE_INFO_SUID = 0x00000800u,
		/// <summary>
		/// Set group ID to file's user group ID on execution (compatible with 02000 octal notation).
		/// </summary>
		BL_FILE_INFO_SGID = 0x00000400u,

		/// <summary>
		/// A combination of all file permission bits.
		/// </summary>
		BL_FILE_INFO_PERMISSIONS_MASK = 0x00000FFFu,

		/// <summary>
		/// A flag specifying that this is a regular file.
		/// </summary>
		BL_FILE_INFO_REGULAR = 0x00010000u,
		/// <summary>
		/// A flag specifying that this is a directory.
		/// </summary>
		BL_FILE_INFO_DIRECTORY = 0x00020000u,
		/// <summary>
		/// A flag specifying that this is a symbolic link.
		/// </summary>
		BL_FILE_INFO_SYMLINK = 0x00040000u,

		/// <summary>
		/// A flag describing a character device.
		/// </summary>
		BL_FILE_INFO_CHAR_DEVICE = 0x00100000u,
		/// <summary>
		/// A flag describing a block device.
		/// </summary>
		BL_FILE_INFO_BLOCK_DEVICE = 0x00200000u,
		/// <summary>
		/// A flag describing a FIFO (named pipe).
		/// </summary>
		BL_FILE_INFO_FIFO = 0x00400000u,
		/// <summary>
		/// A flag describing a socket.
		/// </summary>
		BL_FILE_INFO_SOCKET = 0x00800000u,

		/// <summary>
		/// A flag describing a hidden file (Windows only).
		/// </summary>
		BL_FILE_INFO_HIDDEN = 0x01000000u,
		/// <summary>
		/// A flag describing a hidden file (Windows only).
		/// </summary>
		BL_FILE_INFO_EXECUTABLE = 0x02000000u,
		/// <summary>
		/// A flag describing an archive (Windows only).
		/// </summary>
		BL_FILE_INFO_ARCHIVE = 0x04000000u,
		/// <summary>
		/// A flag describing a system file (Windows only).
		/// </summary>
		BL_FILE_INFO_SYSTEM = 0x08000000u,

		/// <summary>
		/// File information is valid (the request succeeded).
		/// </summary>
		BL_FILE_INFO_VALID = 0x80000000u
	}
	/// <summary>
	/// File open flags, see <see cref="Open(string, BLFileOpenFlags)"/>.
	/// </summary>
	public enum BLFileOpenFlags : UInt32 {
		/// <summary>
		/// No flags.
		/// </summary>
		BL_FILE_OPEN_NO_FLAGS = 0u,

		/// <summary>
		/// Opens the file for reading.
		/// </summary>
		/// <remarks>
		/// The following system flags are used when opening the file: O_RDONLY (Posix), GENERIC_READ (Windows)
		/// </remarks>
		BL_FILE_OPEN_READ = 0x00000001u,

		/// <summary>
		/// Opens the file for writing:
		/// </summary>
		/// <remarks>
		/// The following system flags are used when opening the file: O_WRONLY (Posix), GENERIC_WRITE (Windows)
		/// </remarks>
		BL_FILE_OPEN_WRITE = 0x00000002u,

		/// <summary>
		/// Opens the file for reading and writing.
		/// </summary>
		/// <remarks>
		/// The following system flags are used when opening the file: O_RDWR (Posix), GENERIC_READ | GENERIC_WRITE (Windows)
		/// </remarks>
		BL_FILE_OPEN_RW = 0x00000003u,

		/// <summary>
		/// Creates the file if it doesn't exist or opens it if it does.
		/// </summary>
		/// <remarks>
		/// The following system flags are used when opening the file: O_CREAT (Posix), CREATE_ALWAYS or OPEN_ALWAYS depending on other flags (Windows)
		/// </remarks>
		BL_FILE_OPEN_CREATE = 0x00000004u,

		/// <summary>
		/// Opens the file for deleting or renaming (Windows).
		/// </summary>
		/// <remarks>
		/// Adds DELETE flag when opening the file to ACCESS_MASK.
		/// </remarks>
		BL_FILE_OPEN_DELETE = 0x00000008u,

		/// <summary>
		/// Truncates the file.
		/// </summary>
		/// <remarks>
		/// The following system flags are used when opening the file: O_TRUNC (Posix), TRUNCATE_EXISTING (Windows)
		/// </remarks>
		BL_FILE_OPEN_TRUNCATE = 0x00000010u,

		/// <summary>
		/// Opens the file for reading in exclusive mode (Windows).
		/// </summary>
		/// <remarks>
		/// Exclusive mode means to not specify the FILE_SHARE_READ option.
		/// </remarks>
		BL_FILE_OPEN_READ_EXCLUSIVE = 0x10000000u,

		/// <summary>
		/// Opens the file for writing in exclusive mode (Windows).
		/// </summary>
		/// <remarks>
		/// Exclusive mode means to not specify the FILE_SHARE_WRITE option.
		/// </remarks>
		BL_FILE_OPEN_WRITE_EXCLUSIVE = 0x20000000u,

		/// <summary>
		/// Opens the file for both reading and writing (Windows).
		/// </summary>
		/// <remarks>
		/// This is a combination of both BL_FILE_OPEN_READ_EXCLUSIVE and BL_FILE_OPEN_WRITE_EXCLUSIVE.
		/// </remarks>
		BL_FILE_OPEN_RW_EXCLUSIVE = 0x30000000u,

		/// <summary>
		/// Creates the file in exclusive mode - fails if the file already exists.
		/// </summary>
		/// <remarks>
		/// The following system flags are used when opening the file: O_EXCL (Posix), CREATE_NEW (Windows)
		/// </remarks>
		BL_FILE_OPEN_CREATE_EXCLUSIVE = 0x40000000u,

		/// <summary>
		/// Opens the file for deleting or renaming in exclusive mode (Windows).
		/// </summary>
		/// <remarks>
		/// Exclusive mode means to not specify the FILE_SHARE_DELETE option.
		/// </remarks>
		BL_FILE_OPEN_DELETE_EXCLUSIVE = 0x80000000u
	}
	/// <summary>
	/// File seek mode, see <see cref="Seek(long, SeekMode, out long)"/>.
	/// </summary>
	/// <remarks>
	/// Seek constants should be compatible with constants used by both POSIX and Windows API.
	/// </remarks>
	public enum BLFileSeekType : UInt32 {
		/// <summary>
		/// Seek from the beginning of the file (SEEK_SET).
		/// </summary>
		BL_FILE_SEEK_SET = 0,
		/// <summary>
		/// Seek from the current position (SEEK_CUR).
		/// </summary>
		BL_FILE_SEEK_CUR = 1,
		/// <summary>
		/// Seek from the end of the file (SEEK_END).
		/// </summary>
		BL_FILE_SEEK_END = 2,

		/// <summary>
		/// Maximum value of `BLFileSeekType`.
		/// </summary>
		BL_FILE_SEEK_MAX_VALUE = 3
	}
	/// <summary>
	/// File read flags used by \ref BLFileSystem::readFile().
	/// </summary>
	public enum BLFileReadFlags : UInt32 {
		/// <summary>
		/// No flags.
		/// </summary>
		BL_FILE_READ_NO_FLAGS = 0u,

		/// <summary>
		/// Use memory mapping to read the content of the file.
		/// </summary>
		/// <remarks>
		/// The destination buffer BLArray would be configured to use the memory mapped buffer instead of allocating its own.
		/// </remarks>
		BL_FILE_READ_MMAP_ENABLED = 0x00000001u,

		/// <summary>
		/// Avoid memory mapping of small files.
		/// </summary>
		/// <remarks>
		/// The size of small file is determined by Blend2D, however, you should expect it to be 16kB or 64kB depending on host operating system.
		/// </remarks>
		BL_FILE_READ_MMAP_AVOID_SMALL = 0x00000002u,

		/// <summary>
		/// Do not fallback to regular read if memory mapping fails. It's worth noting that memory mapping would fail for
		/// files stored on filesystem that is not local (like a mounted network filesystem, etc...).
		/// </summary>
		BL_FILE_READ_MMAP_NO_FALLBACK = 0x00000008u
	}

	/// <summary>
	/// A thin abstraction over a native OS file IO [C API].
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct BLFileCore {
		internal IntPtr handle;
	}
	/// <summary>
	/// File information.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct BLFileInfo {
		internal UInt64 size;
		/// <summary>
		/// in microseconds
		/// </summary>
		internal Int64 modifiedTime;
		internal BLFileInfoFlags flags;
		internal UInt32 uid;
		internal UInt32 gid;
		private readonly UInt32 reserved0;
		private readonly UInt64 reserved1;
		private readonly UInt64 reserved2;
	}
	[DllImport("blend2d")]
	public static extern BLResult blFileInit(ref BLFileCore self);
	[DllImport("blend2d")]
	public static extern BLResult blFileReset(ref BLFileCore self);
	[DllImport("blend2d", CharSet = CharSet.Ansi)]
	public static extern BLResult blFileOpen(ref BLFileCore self, String fileName, BLFileOpenFlags openFlags);
	[DllImport("blend2d")]
	public static extern BLResult blFileClose(ref BLFileCore self);
	[DllImport("blend2d")]
	public static extern BLResult blFileSeek(ref BLFileCore self, UInt64 offset, BLFileSeekType seekType, out UInt64 positionOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileRead(ref BLFileCore self, [Out] byte* buffer, UIntPtr n, out UIntPtr bytesReadOut); // TODO Document data buffer, fixed, unsafe
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileWrite(ref BLFileCore self, byte* buffer, UIntPtr n, out UIntPtr bytesWrittenOut); // TODO Document data buffer, fixed, unsafe
	[DllImport("blend2d")]
	public static extern BLResult blFileTruncate(ref BLFileCore self, Int64 maxSize);
	[DllImport("blend2d")]
	public static extern BLResult blFileGetInfo(ref BLFileCore self, out BLFileInfo infoOut);
	[DllImport("blend2d")]
	public static extern BLResult blFileGetSize(ref BLFileCore self, out UInt64 fileSizeOut);
	[DllImport("blend2d", CharSet = CharSet.Ansi)]
	public static extern BLResult blFileSystemGetInfo(String fileName, out BLFileInfo infoOut);
	[DllImport("blend2d", CharSet = CharSet.Ansi)]
	public static extern BLResult blFileSystemReadFile(String fileName, ref byte[] dst, UIntPtr maxSize, BLFileReadFlags readFlags); // TODO BLArray not byte[]
	[DllImport("blend2d", CharSet = CharSet.Ansi)]
	public unsafe static extern BLResult blFileSystemWriteFile(String fileName, byte[] data, UIntPtr size, out UIntPtr bytesWrittenOut); // TODO Document data buffer, fixed, unsafe
}

#pragma warning disable CA2101
#pragma warning restore CA1711
#pragma warning restore CA1707
#pragma warning restore CA1401
#pragma warning restore IDE1006
#pragma warning restore IDE0079
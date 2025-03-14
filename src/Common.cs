using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

[module: DefaultCharSet(CharSet.Ansi)]

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA1051
#pragma warning disable CA1069
#pragma warning disable CA1707
#pragma warning disable CA1711
#pragma warning disable CA2101

public static class Common {
	static Common() {
		// Try QuestPDF. It's a good library
		var arch = RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant();
		string? rid = null;
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			rid = $"win-{arch}";
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			rid = $"linux-{arch}";
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			rid = $"osx-{arch}";
		if (rid == null)
			throw new PlatformNotSupportedException();
		String?[] locations = [
			AppDomain.CurrentDomain.RelativeSearchPath,
			AppDomain.CurrentDomain.BaseDirectory,
			Environment.CurrentDirectory,
			AppContext.BaseDirectory,
			Directory.GetCurrentDirectory(),
			new FileInfo(typeof(Common).Assembly.Location).Directory?.FullName
		];
		var location = locations
			.Where(l => !String.IsNullOrEmpty(l))
			.Select(l => Path.Combine(l, "runtimes", rid, "native"))
			.Where(Directory.Exists)
			.FirstOrDefault();
		if (location == default)
			return;
		var target = new DirectoryInfo(location).Parent.Parent.Parent.FullName;
		foreach (var file in Directory.GetFiles(location)) {
			var targetFile = Path.Combine(target, Path.GetFileName(file));
			if (!System.IO.File.Exists(targetFile) || System.IO.File.GetLastWriteTime(file) > System.IO.File.GetLastWriteTime(targetFile))
				System.IO.File.Copy(file, targetFile, true);
		}
	}
	internal class BlendException(BLResult code) : ExternalException($"BLResultCode: {code} ({(int) code})", (int) code) {
	}
	/// <summary>
	/// Blend2D result code.
	/// </summary>
	public enum BLResult : UInt32 {
		/// <summary>
		/// Successful result code.
		/// </summary>
		BL_SUCCESS = 0,
		BL_ERROR_START_INDEX = 0x00010000u,
		/// <summary>
		/// Out of memory                 [ENOMEM].
		/// </summary>
		BL_ERROR_OUT_OF_MEMORY = 0x00010000u,
		/// <summary>
		///  Invalid value/argument        [EINVAL].
		/// </summary>
		BL_ERROR_INVALID_VALUE,
		/// <summary>
		///  Invalid state                 [EFAULT].
		/// </summary>
		BL_ERROR_INVALID_STATE,
		/// <summary>
		///  Invalid handle or file.       [EBADF].
		/// </summary>
		BL_ERROR_INVALID_HANDLE,
		/// <summary>
		///  Invalid conversion.
		/// </summary>
		BL_ERROR_INVALID_CONVERSION,
		/// <summary>
		///  Overflow or value too large   [EOVERFLOW].
		/// </summary>
		BL_ERROR_OVERFLOW,
		/// <summary>
		///  Object not initialized.
		/// </summary>
		BL_ERROR_NOT_INITIALIZED,
		/// <summary>
		///  Not implemented               [ENOSYS].
		/// </summary>
		BL_ERROR_NOT_IMPLEMENTED,
		/// <summary>
		///  Operation not permitted       [EPERM].
		/// </summary>
		BL_ERROR_NOT_PERMITTED,
		/// <summary>
		///  IO error                      [EIO].
		/// </summary>
		BL_ERROR_IO,
		/// <summary>
		///  Device or resource busy       [EBUSY].
		/// </summary>
		BL_ERROR_BUSY,
		/// <summary>
		///  Operation interrupted         [EINTR].
		/// </summary>
		BL_ERROR_INTERRUPTED,
		/// <summary>
		///  Try again                     [EAGAIN].
		/// </summary>
		BL_ERROR_TRY_AGAIN,
		/// <summary>
		///  Timed out                     [ETIMEDOUT].
		/// </summary>
		BL_ERROR_TIMED_OUT,
		/// <summary>
		///  Broken pipe                   [EPIPE].
		/// </summary>
		BL_ERROR_BROKEN_PIPE,
		/// <summary>
		///  File is not seekable          [ESPIPE].
		/// </summary>
		BL_ERROR_INVALID_SEEK,
		/// <summary>
		///  Too many levels of symlinks   [ELOOP].
		/// </summary>
		BL_ERROR_SYMLINK_LOOP,
		/// <summary>
		///  File is too large             [EFBIG].
		/// </summary>
		BL_ERROR_FILE_TOO_LARGE,
		/// <summary>
		///  File/directory already exists [EEXIST].
		/// </summary>
		BL_ERROR_ALREADY_EXISTS,
		/// <summary>
		///  Access denied                 [EACCES].
		/// </summary>
		BL_ERROR_ACCESS_DENIED,
		/// <summary>
		///  Media changed                 [Windows::ERROR_MEDIA_CHANGED].
		/// </summary>
		BL_ERROR_MEDIA_CHANGED,
		/// <summary>
		///  The file/FS is read-only      [EROFS].
		/// </summary>
		BL_ERROR_READ_ONLY_FS,
		/// <summary>
		///  Device doesn't exist          [ENXIO].
		/// </summary>
		BL_ERROR_NO_DEVICE,
		/// <summary>
		///  Not found, no entry (fs)      [ENOENT].
		/// </summary>
		BL_ERROR_NO_ENTRY,
		/// <summary>
		///  No media in drive/device      [ENOMEDIUM].
		/// </summary>
		BL_ERROR_NO_MEDIA,
		/// <summary>
		///  No more data / end of file    [ENODATA].
		/// </summary>
		BL_ERROR_NO_MORE_DATA,
		/// <summary>
		///  No more files                 [ENMFILE].
		/// </summary>
		BL_ERROR_NO_MORE_FILES,
		/// <summary>
		///  No space left on device       [ENOSPC].
		/// </summary>
		BL_ERROR_NO_SPACE_LEFT,
		/// <summary>
		///  Directory is not empty        [ENOTEMPTY].
		/// </summary>
		BL_ERROR_NOT_EMPTY,
		/// <summary>
		///  Not a file                    [EISDIR].
		/// </summary>
		BL_ERROR_NOT_FILE,
		/// <summary>
		///  Not a directory               [ENOTDIR].
		/// </summary>
		BL_ERROR_NOT_DIRECTORY,
		/// <summary>
		///  Not same device               [EXDEV].
		/// </summary>
		BL_ERROR_NOT_SAME_DEVICE,
		/// <summary>
		///  Not a block device            [ENOTBLK].
		/// </summary>
		BL_ERROR_NOT_BLOCK_DEVICE,
		/// <summary>
		///  File/path name is invalid     [n/a].
		/// </summary>
		BL_ERROR_INVALID_FILE_NAME,
		/// <summary>
		///  File/path name is too long    [ENAMETOOLONG].
		/// </summary>
		BL_ERROR_FILE_NAME_TOO_LONG,
		/// <summary>
		///  Too many open files           [EMFILE].
		/// </summary>
		BL_ERROR_TOO_MANY_OPEN_FILES,
		/// <summary>
		///  Too many open files by OS     [ENFILE].
		/// </summary>
		BL_ERROR_TOO_MANY_OPEN_FILES_BY_OS,
		/// <summary>
		///  Too many symbolic links on FS [EMLINK].
		/// </summary>
		BL_ERROR_TOO_MANY_LINKS,
		/// <summary>
		///  Too many threads              [EAGAIN].
		/// </summary>
		BL_ERROR_TOO_MANY_THREADS,
		/// <summary>
		///  Thread pool is exhausted and couldn't acquire the requested thread count.
		/// </summary>
		BL_ERROR_THREAD_POOL_EXHAUSTED,
		/// <summary>
		///  File is empty (not specific to any OS error).
		/// </summary>
		BL_ERROR_FILE_EMPTY,
		/// <summary>
		///  File open failed              [Windows::ERROR_OPEN_FAILED].
		/// </summary>
		BL_ERROR_OPEN_FAILED,
		/// <summary>
		///  Not a root device/directory   [Windows::ERROR_DIR_NOT_ROOT].
		/// </summary>
		BL_ERROR_NOT_ROOT_DEVICE,
		/// <summary>
		///  Unknown system error that failed to translate to Blend2D result code.
		/// </summary>
		BL_ERROR_UNKNOWN_SYSTEM_ERROR,
		/// <summary>
		///  Invalid data alignment.
		/// </summary>
		BL_ERROR_INVALID_ALIGNMENT,
		/// <summary>
		///  Invalid data signature or header.
		/// </summary>
		BL_ERROR_INVALID_SIGNATURE,
		/// <summary>
		///  Invalid or corrupted data.
		/// </summary>
		BL_ERROR_INVALID_DATA,
		/// <summary>
		///  Invalid string (invalid data of either UTF8, UTF16, or UTF32).
		/// </summary>
		BL_ERROR_INVALID_STRING,
		/// <summary>
		///  Invalid key or property.
		/// </summary>
		BL_ERROR_INVALID_KEY,
		/// <summary>
		///  Truncated data (more data required than memory/stream provides).
		/// </summary>
		BL_ERROR_DATA_TRUNCATED,
		/// <summary>
		///  Input data too large to be processed.
		/// </summary>
		BL_ERROR_DATA_TOO_LARGE,
		/// <summary>
		///  Decompression failed due to invalid data (RLE, Huffman, etc).
		/// </summary>
		BL_ERROR_DECOMPRESSION_FAILED,
		/// <summary>
		///  Invalid geometry (invalid path data or shape).
		/// </summary>
		BL_ERROR_INVALID_GEOMETRY,
		/// <summary>
		///  Returned when there is no matching vertex in path data.
		/// </summary>
		BL_ERROR_NO_MATCHING_VERTEX,
		/// <summary>
		///  Invalid create flags (BLContext).
		/// </summary>
		BL_ERROR_INVALID_CREATE_FLAGS,
		/// <summary>
		///  No matching cookie (BLContext).
		/// </summary>
		BL_ERROR_NO_MATCHING_COOKIE,
		/// <summary>
		///  No states to restore (BLContext).
		/// </summary>
		BL_ERROR_NO_STATES_TO_RESTORE,
		/// <summary>
		///  Cannot save state as the number of saved states reached the limit (BLContext).
		/// </summary>
		BL_ERROR_TOO_MANY_SAVED_STATES,
		/// <summary>
		///  The size of the image is too large.
		/// </summary>
		BL_ERROR_IMAGE_TOO_LARGE,
		/// <summary>
		///  Image codec for a required format doesn't exist.
		/// </summary>
		BL_ERROR_IMAGE_NO_MATCHING_CODEC,
		/// <summary>
		///  Unknown or invalid file format that cannot be read.
		/// </summary>
		BL_ERROR_IMAGE_UNKNOWN_FILE_FORMAT,
		/// <summary>
		///  Image codec doesn't support reading the file format.
		/// </summary>
		BL_ERROR_IMAGE_DECODER_NOT_PROVIDED,
		/// <summary>
		///  Image codec doesn't support writing the file format.
		/// </summary>
		BL_ERROR_IMAGE_ENCODER_NOT_PROVIDED,
		/// <summary>
		///  Multiple IHDR chunks are not allowed (PNG).
		/// </summary>
		BL_ERROR_PNG_MULTIPLE_IHDR,
		/// <summary>
		///  Invalid IDAT chunk (PNG).
		/// </summary>
		BL_ERROR_PNG_INVALID_IDAT,
		/// <summary>
		///  Invalid IEND chunk (PNG).
		/// </summary>
		BL_ERROR_PNG_INVALID_IEND,
		/// <summary>
		///  Invalid PLTE chunk (PNG).
		/// </summary>
		BL_ERROR_PNG_INVALID_PLTE,
		/// <summary>
		///  Invalid tRNS chunk (PNG).
		/// </summary>
		BL_ERROR_PNG_INVALID_TRNS,
		/// <summary>
		///  Invalid filter type (PNG).
		/// </summary>
		BL_ERROR_PNG_INVALID_FILTER,
		/// <summary>
		///  Unsupported feature (JPEG).
		/// </summary>
		BL_ERROR_JPEG_UNSUPPORTED_FEATURE,
		/// <summary>
		///  Invalid SOS marker or header (JPEG).
		/// </summary>
		BL_ERROR_JPEG_INVALID_SOS,
		/// <summary>
		///  Invalid SOF marker (JPEG).
		/// </summary>
		BL_ERROR_JPEG_INVALID_SOF,
		/// <summary>
		///  Multiple SOF markers (JPEG).
		/// </summary>
		BL_ERROR_JPEG_MULTIPLE_SOF,
		/// <summary>
		///  Unsupported SOF marker (JPEG).
		/// </summary>
		BL_ERROR_JPEG_UNSUPPORTED_SOF,
		/// <summary>
		///  Font doesn't have any data as it's not initialized.
		/// </summary>
		BL_ERROR_FONT_NOT_INITIALIZED,
		/// <summary>
		///  Font or font face was not matched (BLFontManager).
		/// </summary>
		BL_ERROR_FONT_NO_MATCH,
		/// <summary>
		///  Font has no character to glyph mapping data.
		/// </summary>
		BL_ERROR_FONT_NO_CHARACTER_MAPPING,
		/// <summary>
		///  Font has missing an important table.
		/// </summary>
		BL_ERROR_FONT_MISSING_IMPORTANT_TABLE,
		/// <summary>
		///  Font feature is not available.
		/// </summary>
		BL_ERROR_FONT_FEATURE_NOT_AVAILABLE,
		/// <summary>
		///  Font has an invalid CFF data.
		/// </summary>
		BL_ERROR_FONT_CFF_INVALID_DATA,
		/// <summary>
		///  Font program terminated because the execution reached the limit.
		/// </summary>
		BL_ERROR_FONT_PROGRAM_TERMINATED,
		/// <summary>
		///  Glyph substitution requires too much space and was terminated.
		/// </summary>
		BL_ERROR_GLYPH_SUBSTITUTION_TOO_LARGE,
		/// <summary>
		/// Invalid glyph identifier.
		/// </summary>
		BL_ERROR_INVALID_GLYPH
	}
}
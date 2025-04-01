using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlLiberali.Blend2NET;
internal static class Loader {
	static Loader() {
		// Try QuestPDF. It's a good library
		String arch = RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant();
		String? rid = null;
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			rid = $"win-{arch}";
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			rid = $"linux-{arch}";
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			rid = $"osx-{arch}";
		if (rid == null)
			throw new PlatformNotSupportedException();
		String[] locations = [
			AppDomain.CurrentDomain.RelativeSearchPath,
			AppDomain.CurrentDomain.BaseDirectory,
			Environment.CurrentDirectory,
			AppContext.BaseDirectory,
			Directory.GetCurrentDirectory(),
			new FileInfo(typeof(Loader).Assembly.Location).Directory.FullName
		];
		String location = locations
			.Where(l => !String.IsNullOrEmpty(l))
			.Select(l => Path.Combine(l, "runtimes", rid, "native"))
			.FirstOrDefault(Directory.Exists);
		if (location == default)
			return;
		String target = new DirectoryInfo(location).Parent.Parent.Parent.FullName;
		foreach (String file in Directory.GetFiles(location)) {
			String targetFile = Path.Combine(target, Path.GetFileName(file));
			if (!File.Exists(targetFile) || File.GetLastWriteTime(file) > File.GetLastWriteTime(targetFile))
				File.Copy(file, targetFile, true);
		}
	}
}
#if !NET7_0_OR_GREATER
/// <inheritdoc/>
public class ObjectDisposedException(String objectName) : System.ObjectDisposedException(objectName) {
	// The following method licensed to anyone by the .NET Foundation under the MIT Licence.
	/// <summary>Throws an <see cref="ObjectDisposedException"/> if the specified <paramref name="condition"/> is <see langword="true"/>.</summary>
	/// <param name="condition">The condition to evaluate.</param>
	/// <param name="instance">The object whose type's full name should be included in any resulting <see cref="ObjectDisposedException"/>.</param>
	/// <exception cref="ObjectDisposedException">The <paramref name="condition"/> is <see langword="true"/>.</exception>
	public static void ThrowIf(bool condition, Object instance) {
		if (condition) {
			throw new ObjectDisposedException(nameof(instance));
		}
	}
}
#endif
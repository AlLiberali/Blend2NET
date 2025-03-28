using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using static AlLiberali.Blend2NET.PInvoke;

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
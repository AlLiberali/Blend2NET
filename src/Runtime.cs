using System;
using System.Runtime.InteropServices;
using System.Threading;
using size_t = System.IntPtr;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA1069
#pragma warning disable CA1401
#pragma warning disable CA1707
#pragma warning disable CA1711

public static class Runtime {
	/// <summary>
	/// Type of runtime information that can be queried through the various <see cref="blRuntimeQueryInfo"/> overloads.
	/// </summary>
	public enum BLRuntimeInfoType : UInt32 {
		/// <summary>
		/// Blend2D build information.
		/// </summary>
		BL_RUNTIME_INFO_TYPE_BUILD = 0,
		/// <summary>
		/// System information (includes CPU architecture, features, core count, etc...).
		/// </summary>
		BL_RUNTIME_INFO_TYPE_SYSTEM = 1,
		/// <summary>
		/// Resources information (includes Blend2D memory consumption)
		/// </summary>
		BL_RUNTIME_INFO_TYPE_RESOURCE = 2
	}
	/// <summary>
	/// Blend2D runtime build type.
	/// </summary>
	public enum BLRuntimeBuildType : UInt32 {
		/// <summary>
		/// Describes a Blend2D debug build.
		/// </summary>
		BL_RUNTIME_BUILD_TYPE_DEBUG = 0,
		/// <summary>
		/// Describes a Blend2D release build.
		/// </summary>
		BL_RUNTIME_BUILD_TYPE_RELEASE = 1
	}
	/// <summary>
	/// CPU architecture that can be queried by <see cref="blRuntimeQueryInfo(BLRuntimeInfoType, out BLRuntimeSystemInfo)"/>.
	/// </summary>
	public enum BLRuntimeCpuArch : UInt32 {
		/// <summary>
		/// Unknown architecture.
		/// </summary>
		BL_RUNTIME_CPU_ARCH_UNKNOWN = 0,
		/// <summary>
		/// 32-bit or 64-bit X86 architecture.
		/// </summary>
		BL_RUNTIME_CPU_ARCH_X86 = 1,
		/// <summary>
		/// 32-bit or 64-bit ARM architecture.
		/// </summary>
		BL_RUNTIME_CPU_ARCH_ARM = 2,
		/// <summary>
		/// 32-bit or 64-bit MIPS architecture.
		/// </summary>
		BL_RUNTIME_CPU_ARCH_MIPS = 3
	}
	/// <summary>
	/// CPU features Blend2D supports.
	/// </summary>
	public enum BLRuntimeCpuFeatures : UInt32 {
		BL_RUNTIME_CPU_FEATURE_X86_SSE2 = 0x00000001u,
		BL_RUNTIME_CPU_FEATURE_X86_SSE3 = 0x00000002u,
		BL_RUNTIME_CPU_FEATURE_X86_SSSE3 = 0x00000004u,
		BL_RUNTIME_CPU_FEATURE_X86_SSE4_1 = 0x00000008u,
		BL_RUNTIME_CPU_FEATURE_X86_SSE4_2 = 0x00000010u,
		BL_RUNTIME_CPU_FEATURE_X86_AVX = 0x00000020u,
		BL_RUNTIME_CPU_FEATURE_X86_AVX2 = 0x00000040u,
		BL_RUNTIME_CPU_FEATURE_X86_AVX512 = 0x00000080u,
		BL_RUNTIME_CPU_FEATURE_ARM_ASIMD = 0x00000001u,
		BL_RUNTIME_CPU_FEATURE_ARM_CRC32 = 0x00000002u,
		BL_RUNTIME_CPU_FEATURE_ARM_PMULL = 0x00000004u
	}
	/// <summary>
	/// Runtime cleanup flags that can be used through <see cref="blRuntimeCleanup(BLRuntimeCleanupFlags)"/>.
	/// </summary>
	public enum BLRuntimeCleanupFlags : UInt32 {
		//! No flags.
		BL_RUNTIME_CLEANUP_NO_FLAGS = 0u,
		//! Cleanup object memory pool.
		BL_RUNTIME_CLEANUP_OBJECT_POOL = 0x00000001u,
		//! Cleanup zeroed memory pool.
		BL_RUNTIME_CLEANUP_ZEROED_POOL = 0x00000002u,
		//! Cleanup thread pool (would join unused threads).
		BL_RUNTIME_CLEANUP_THREAD_POOL = 0x00000010u,

		//! Cleanup everything.
		BL_RUNTIME_CLEANUP_EVERYTHING = 0xFFFFFFFFu
	}

	/// <summary>
	/// Blend2D build information.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public readonly struct BLRuntimeBuildInfo {
		/// <summary>
		/// Major version number.
		/// </summary>
		public readonly UInt32 majorVersion;
		/// <summary>
		/// Minor version number.
		/// </summary>
		public readonly UInt32 minorVersion;
		/// <summary>
		/// Patch version number.
		/// </summary>
		public readonly UInt32 patchVersion;
		/// <summary>
		/// Blend2D build type.
		/// </summary>
		public readonly BLRuntimeBuildType buildType;
		/// <summary>
		/// Baseline CPU features, see <see cref="BLRuntimeCpuFeatures"/>.
		/// </summary>
		/// <remarks>
		/// These features describe CPU features that were detected at compile-time. Baseline features are used to compile
		/// all source files so they represent the minimum feature-set the target CPU must support to run Blend2D.
		/// </remarks>
		public readonly UInt32 baselineCpuFeatures;
		/// <summary>
		/// Supported CPU features, see <see cref="BLRuntimeCpuFeatures"/>.
		/// </summary>
		/// <remarks>
		/// These features do not represent the features that the host CPU must support, instead, they represent all features
		/// that Blend2D can take advantage of in C++ code that uses instruction intrinsics. For example if AVX2 is part of
		/// `supportedCpuFeatures` it means that Blend2D can take advantage of it if there is a specialized code-path.
		/// </remarks>
		public readonly UInt32 supportedCpuFeatures;
		/// <summary>
		/// Maximum size of an image (both width and height).
		/// </summary>
		public readonly UInt32 maxImageSize;
		/// <summary>
		/// Maximum number of threads for asynchronous operations, including rendering.
		/// </summary>
		public readonly UInt32 maxThreadCount;
		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		private readonly UInt32 reserved0;
		/// <summary>
		/// Reserved, must be zero
		/// </summary>
		private readonly UInt32 reserved1;
		/// <summary>
		/// Identification of the C++ compiler used to build Blend2D.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public readonly string compilerInfo;
	}

	/// <summary>
	/// System information queried by the runtime.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public readonly struct BLRuntimeSystemInfo {
		/// <summary>
		/// Host CPU architecture, see <see cref="BLRuntimeCpuArch"/>.
		/// </summary>
		public readonly UInt32 cpuArch;
		/// <summary>
		/// Host CPU features, see <see cref="BLRuntimeCpuFeatures"/>.
		/// </summary>
		public readonly UInt32 cpuFeatures;
		/// <summary>
		/// Number of cores of the host CPU/CPUs.
		/// </summary>
		public readonly UInt32 coreCount;
		/// <summary>
		/// Number of threads of the host CPU/CPUs.
		/// </summary>
		public readonly UInt32 threadCount;
		/// <summary>
		/// Minimum stack size of a worker thread used by Blend2D.
		/// </summary>
		public readonly UInt32 threadStackSize;
		/// <summary>
		/// Removed field.
		/// </summary>
		private readonly UInt32 removed;
		/// <summary>
		/// Allocation granularity of virtual memory (includes thread's stack).
		/// </summary>
		public readonly UInt32 allocationGranularity;
		/// <summary>
		/// Reserved for future use.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U4, SizeConst = 5)]
		private readonly UInt32[] reserved;
		/// <summary>
		/// Host CPU vendor string such "AMD", "APPLE", "INTEL", "SAMSUNG", etc...
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public readonly string cpuVendor;
		/// <summary>
		/// Host CPU brand string or empty string if not detected properly.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public readonly string cpuBrand;
	}

	/// <summary>
	/// Provides information about resources allocated by Blend2D.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BLRuntimeResourceInfo {
		/// <summary>
		/// Virtual memory used at this time.
		/// </summary>
		public readonly size_t vmUsed;
		/// <summary>
		/// Virtual memory reserved (allocated internally).
		/// </summary>
		public readonly size_t vmReserved;
		/// <summary>
		/// Overhead required to manage virtual memory allocations.
		/// </summary>
		public readonly size_t vmOverhead;
		/// <summary>
		/// Number of blocks of virtual memory allocated.
		/// </summary>
		public readonly size_t vmBlockCount;
		/// <summary>
		/// Zeroed memory used at this time.
		/// </summary>
		public readonly size_t zmUsed;
		/// <summary>
		/// Zeroed memory reserved (allocated internally).
		/// </summary>
		public readonly size_t zmReserved;
		/// <summary>
		/// Overhead required to manage zeroed memory allocations.
		/// </summary>
		public readonly size_t zmOverhead;
		/// <summary>
		/// Number of blocks of zeroed memory allocated.
		/// </summary>
		public readonly size_t zmBlockCount;
		/// <summary>
		/// Count of dynamic pipelines created and cached.
		/// </summary>
		public readonly size_t dynamicPipelineCount;
	}
	[DllImport("blend2d")]
	public static extern BLResult blRuntimeCleanup(BLRuntimeCleanupFlags cleanupFlags);
	[DllImport("blend2d")]
	public static extern BLResult blRuntimeQueryInfo(BLRuntimeInfoType infoType, out BLRuntimeBuildInfo infoOut);
	[DllImport("blend2d")]
	public static extern BLResult blRuntimeQueryInfo(BLRuntimeInfoType infoType, out BLRuntimeSystemInfo infoOut);
	[DllImport("blend2d")]
	public static extern BLResult blRuntimeQueryInfo(BLRuntimeInfoType infoType, out BLRuntimeResourceInfo infoOut);
	private static readonly BLRuntimeBuildInfo build;
	private static BLRuntimeSystemInfo system;
	static Runtime() {
		var err = blRuntimeQueryInfo(BLRuntimeInfoType.BL_RUNTIME_INFO_TYPE_BUILD, out build);
#if DEBUG
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
#endif
		err = blRuntimeQueryInfo(BLRuntimeInfoType.BL_RUNTIME_INFO_TYPE_SYSTEM, out system);
#if DEBUG
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
#endif
		GC.RegisterForFullGCNotification(32, 32);
		ThreadPool.QueueUserWorkItem(static state => {
			while (true) {
				GC.WaitForPendingFinalizers();
				if (GC.WaitForFullGCApproach() != GCNotificationStatus.Succeeded)
					continue;
				Cleanup();
			}
		});
	}
	public static (UInt32 Major, UInt32 Minor, UInt32 Patch) Version => (build.majorVersion, build.minorVersion, build.patchVersion);
	public static Boolean IsSharedLibraryReleaseBuild => build.buildType == BLRuntimeBuildType.BL_RUNTIME_BUILD_TYPE_RELEASE;
	public static void Cleanup() => blRuntimeCleanup(BLRuntimeCleanupFlags.BL_RUNTIME_CLEANUP_EVERYTHING);
	public static class System {
		public static UInt32 CoreCount {
			get => system.coreCount;
		}
	}
}

using AlLiberali.Blend2NET.Geometry;
using System;
using System.Runtime.InteropServices;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable CA1051
#pragma warning disable CA1707
#pragma warning disable CA1711

public sealed partial class Context : IBlendObject<Context, Context.BLContextCore>, IDisposable {
	/// <summary>
	/// Rendering context type.
	/// </summary>
	public enum BLContextType : UInt32 {
		/// <summary>
		/// No rendering context.
		/// </summary>
		BL_CONTEXT_TYPE_NONE = 0,
		/// <summary>
		/// Dummy rendering context.
		/// </summary>
		BL_CONTEXT_TYPE_DUMMY = 1,
		/// <summary>
		/// Software-accelerated rendering context.
		/// </summary>
		BL_CONTEXT_TYPE_RASTER = 3
	}
	/// <summary>
	/// Rendering context hint.
	/// </summary>
	public enum BLContextHint : UInt32 {
		/// <summary>
		/// Rendering quality.
		/// </summary>
		BL_CONTEXT_HINT_RENDERING_QUALITY = 0,
		/// <summary>
		/// Gradient quality.
		/// </summary>
		BL_CONTEXT_HINT_GRADIENT_QUALITY = 1,
		/// <summary>
		/// Pattern quality.
		/// </summary>
		BL_CONTEXT_HINT_PATTERN_QUALITY = 2
	}
	/// <summary>
	/// Describes a rendering context style slot - fill or stroke.
	/// </summary>
	public enum BLContextStyleSlot : UInt32 {
		/// <summary>
		/// Fill operation style slot.
		/// </summary>
		BL_CONTEXT_STYLE_SLOT_FILL = 0,
		/// <summary>
		/// Stroke operation style slot.
		/// </summary>
		BL_CONTEXT_STYLE_SLOT_STROKE = 1
	}
	// TODO Uncomment when Text is done
	/*
	//! The type of a text rendering operation.
	//!
	//! This value specifies the type of the parameter passed to the text rendering API.
	//!
	//! \note In most cases this should not be required to use by Blend2D users. The C API provides functions that
	//! wrap all of the text operations and C++ API provides functions that use `BLContextRenderTextOp` internally.
	public enum BLContextRenderTextOp : UInt32 {
		//! UTF-8 text rendering operation - UTF-8 string passed as \ref BLStringView or \ref BLArrayView<uint8_t>.
		BL_CONTEXT_RENDER_TEXT_OP_UTF8 = BL_TEXT_ENCODING_UTF8,
		//! UTF-16 text rendering operation - UTF-16 string passed as \ref BLArrayView<uint16_t>.
		BL_CONTEXT_RENDER_TEXT_OP_UTF16 = BL_TEXT_ENCODING_UTF16,
		//! UTF-32 text rendering operation - UTF-32 string passed as \ref BLArrayView<UInt32>.
		BL_CONTEXT_RENDER_TEXT_OP_UTF32 = BL_TEXT_ENCODING_UTF32,
		//! LATIN1 text rendering operation - LATIN1 string is passed as \ref BLStringView or \ref BLArrayView<uint8_t>.
		BL_CONTEXT_RENDER_TEXT_OP_LATIN1 = BL_TEXT_ENCODING_LATIN1,
		//! `wchar_t` text rendering operation - wchar_t string is passed as \ref BLArrayView<wchar_t>.
		BL_CONTEXT_RENDER_TEXT_OP_WCHAR = BL_TEXT_ENCODING_WCHAR,
		//! Glyph run text rendering operation - the \ref BLGlyphRun parameter is passed.
		BL_CONTEXT_RENDER_TEXT_OP_GLYPH_RUN = 4
	}
	*/
	/// <summary>
	/// Rendering context flush flags, used by \ref BLContext::flush().
	/// </summary>
	public enum BLContextFlushFlags : UInt32 {
		BL_CONTEXT_FLUSH_NO_FLAGS = 0u,
		/// <summary>
		/// Flushes the command queue and waits for its completion (will block until done).
		/// </summary>
		BL_CONTEXT_FLUSH_SYNC = 0x80000000u
	}
	/// <summary>
	/// Rendering context creation flags.
	/// </summary>
	public enum BLContextCreateFlags : UInt32 {
		/// <summary>
		/// No flags.
		/// </summary>
		BL_CONTEXT_CREATE_NO_FLAGS = 0u,
		/// <summary>
		/// Disables JIT pipeline generator.
		/// </summary>
		BL_CONTEXT_CREATE_FLAG_DISABLE_JIT = 0x00000001u,
		/// <summary>
		/// Fallbacks to a synchronous rendering in case that the rendering engine wasn't able to acquire threads. This
		/// flag only makes sense when the asynchronous mode was specified by having `threadCount` greater than 0. If the
		/// rendering context fails to acquire at least one thread it would fallback to synchronous mode with no worker
		/// threads.
		/// </summary>
		/// <remarks>
		/// If this flag is specified with `threadCount == 1` it means to immediately fallback to synchronous
		/// rendering. It's only practical to use this flag with 2 or more requested threads.
		/// </remarks>
		BL_CONTEXT_CREATE_FLAG_FALLBACK_TO_SYNC = 0x00100000u,
		/// <summary>
		/// If this flag is specified and asynchronous rendering is enabled then the context would create its own isolated
		/// thread-pool, which is useful for debugging purposes.
		/// </summary>
		/// <remarks>
		/// Do not use this flag in production as rendering contexts with isolated thread-pool have to create and destroy all
		/// threads they use. This flag is only useful for testing, debugging, and isolated benchmarking.
		/// </remarks>
		BL_CONTEXT_CREATE_FLAG_ISOLATED_THREAD_POOL = 0x01000000u,
		/// <summary>
		/// If this flag is specified and JIT pipeline generation enabled then the rendering context would create its own
		/// isolated JIT runtime. which is useful for debugging purposes. This flag will be ignored if JIT pipeline
		/// compilation is either not supported or was disabled by other flags.
		/// </summary>
		/// <remarks>
		/// Do not use this flag in production as rendering contexts with isolated JIT runtime do not use global pipeline
		/// cache, that's it, after the rendering context is destroyed the JIT runtime is destroyed with it with all
		/// compiled pipelines. This flag is only useful for testing, debugging, and isolated benchmarking.
		/// </remarks>
		BL_CONTEXT_CREATE_FLAG_ISOLATED_JIT_RUNTIME = 0x02000000u,
		/// <summary>
		/// Enables logging to stderr of isolated runtime.
		/// </summary>
		/// <remarks>
		/// Must be used with \ref BL_CONTEXT_CREATE_FLAG_ISOLATED_JIT_RUNTIME otherwise it would have no effect.
		/// </remarks>
		BL_CONTEXT_CREATE_FLAG_ISOLATED_JIT_LOGGING = 0x04000000u,
		/// <summary>
		/// Override CPU features when creating isolated context.
		/// </summary>
		BL_CONTEXT_CREATE_FLAG_OVERRIDE_CPU_FEATURES = 0x08000000u
	}
	/// <summary>
	/// Error flags that are accumulated during the rendering context lifetime and that can be queried through
	/// \ref BLContext::accumulatedErrorFlags(). The reason why these flags exist is that errors can happen during
	/// asynchronous rendering, and there is no way the user can catch these errors.
	/// </summary>
	public enum BLContextErrorFlags : UInt32 {
		/// <summary>
		/// No flags.
		/// </summary>
		BL_CONTEXT_ERROR_NO_FLAGS = 0u,
		/// <summary>
		/// The rendering context returned or encountered \ref BL_ERROR_INVALID_VALUE, which is mostly related to
		/// the function argument handling. It's very likely some argument was wrong when calling \ref BLContext API.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_INVALID_VALUE = 0x00000001u,
		/// <summary>
		/// Invalid state describes something wrong, for example a pipeline compilation error.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_INVALID_STATE = 0x00000002u,
		/// <summary>
		/// The rendering context has encountered invalid geometry.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_INVALID_GEOMETRY = 0x00000004u,
		/// <summary>
		/// The rendering context has encountered invalid glyph.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_INVALID_GLYPH = 0x00000008u,
		/// <summary>
		/// The rendering context has encountered invalid or uninitialized font.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_INVALID_FONT = 0x00000010u,
		/// <summary>
		/// Thread pool was exhausted and couldn't acquire the requested number of threads.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_THREAD_POOL_EXHAUSTED = 0x20000000u,
		/// <summary>
		/// Out of memory condition.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_OUT_OF_MEMORY = 0x40000000u,
		/// <summary>
		/// Unknown error, which we don't have flag for.
		/// </summary>
		BL_CONTEXT_ERROR_FLAG_UNKNOWN_ERROR = 0x80000000u
	}
	/// <summary>
	/// Specifies the behavior of \ref BLContext::swapStyles() operation.
	/// </summary>
	public enum BLContextStyleSwapMode : UInt32 {
		/// <summary>
		/// Swap only fill and stroke styles without affecting fill and stroke alpha.
		/// </summary>
		BL_CONTEXT_STYLE_SWAP_MODE_STYLES = 0,
		/// <summary>
		/// Swap both fill and stroke styles and their alpha values.
		/// </summary>
		BL_CONTEXT_STYLE_SWAP_MODE_STYLES_WITH_ALPHA = 1
	}
	/// <summary>
	/// Specifies how style transformation matrix is combined with the rendering context transformation matrix,
	/// used by <see cref="blContextSetFillStyleWithMode(ref BLContextCore, ref BLUnknown, BLContextStyleTransformMode)"/>
	/// and <see cref="blContextSetStrokeStyleWithMode(ref BLContextCore, ref BLUnknown, BLContextStyleTransformMode)"/>
	/// </summary>
	public enum BLContextStyleTransformMode : UInt32 {
		/// <summary>
		/// Style transformation matrix should be transformed with the rendering context user and meta matrix (default).
		/// </summary>
		/// <remarks>
		/// This transformation mode is identical to how user geometry is transformed and it's the default
		/// transformation and most likely the behavior expected in most cases.
		/// </remarks>
		BL_CONTEXT_STYLE_TRANSFORM_MODE_USER = 0,
		/// <summary>
		/// Style transformation matrix should be transformed with the rendering context meta matrix.
		/// </summary>
		BL_CONTEXT_STYLE_TRANSFORM_MODE_META = 1,
		/// <summary>
		/// Style transformation matrix is considered absolute, and is not combined with a rendering context transform.
		/// </summary>
		BL_CONTEXT_STYLE_TRANSFORM_MODE_NONE = 2
	}
	/// <summary>
	/// Clip mode.
	/// </summary>
	public enum BLClipMode : UInt32 {
		/// <summary>
		/// Clipping to a rectangle that is aligned to the pixel grid.
		/// </summary>
		BL_CLIP_MODE_ALIGNED_RECT = 0,
		/// <summary>
		/// Clipping to a rectangle that is not aligned to pixel grid.
		/// </summary>
		BL_CLIP_MODE_UNALIGNED_RECT = 1,
		/// <summary>
		/// Clipping to a non-rectangular area that is defined by using mask.
		/// </summary>
		BL_CLIP_MODE_MASK = 2,
		/// <summary>
		/// Count of clip modes.
		/// </summary>
		BL_CLIP_MODE_COUNT = 3
	}
	/// <summary>
	/// Composition & blending operator.
	/// </summary>
	public enum BLCompOp : UInt32 {
		/// <summary>
		/// Source-over [default].
		/// </summary>
		BL_COMP_OP_SRC_OVER = 0,
		/// <summary>
		/// Source-copy.
		/// </summary>
		BL_COMP_OP_SRC_COPY = 1,
		/// <summary>
		/// Source-in.
		/// </summary>
		BL_COMP_OP_SRC_IN = 2,
		/// <summary>
		/// Source-out.
		/// </summary>
		BL_COMP_OP_SRC_OUT = 3,
		/// <summary>
		/// Source-atop.
		/// </summary>
		BL_COMP_OP_SRC_ATOP = 4,
		/// <summary>
		/// Destination-over.
		/// </summary>
		BL_COMP_OP_DST_OVER = 5,
		/// <summary>
		/// Destination-copy [nop].
		/// </summary>
		BL_COMP_OP_DST_COPY = 6,
		/// <summary>
		/// Destination-in.
		/// </summary>
		BL_COMP_OP_DST_IN = 7,
		/// <summary>
		/// Destination-out.
		/// </summary>
		BL_COMP_OP_DST_OUT = 8,
		/// <summary>
		/// Destination-atop.
		/// </summary>
		BL_COMP_OP_DST_ATOP = 9,
		/// <summary>
		/// Xor.
		/// </summary>
		BL_COMP_OP_XOR = 10,
		/// <summary>
		/// Clear.
		/// </summary>
		BL_COMP_OP_CLEAR = 11,
		/// <summary>
		/// Plus.
		/// </summary>
		BL_COMP_OP_PLUS = 12,
		/// <summary>
		/// Minus.
		/// </summary>
		BL_COMP_OP_MINUS = 13,
		/// <summary>
		/// Modulate.
		/// </summary>
		BL_COMP_OP_MODULATE = 14,
		/// <summary>
		/// Multiply.
		/// </summary>
		BL_COMP_OP_MULTIPLY = 15,
		/// <summary>
		/// Screen.
		/// </summary>
		BL_COMP_OP_SCREEN = 16,
		/// <summary>
		/// Overlay.
		/// </summary>
		BL_COMP_OP_OVERLAY = 17,
		/// <summary>
		/// Darken.
		/// </summary>
		BL_COMP_OP_DARKEN = 18,
		/// <summary>
		/// Lighten.
		/// </summary>
		BL_COMP_OP_LIGHTEN = 19,
		/// <summary>
		/// Color dodge.
		/// </summary>
		BL_COMP_OP_COLOR_DODGE = 20,
		/// <summary>
		/// Color burn.
		/// </summary>
		BL_COMP_OP_COLOR_BURN = 21,
		/// <summary>
		/// Linear burn.
		/// </summary>
		BL_COMP_OP_LINEAR_BURN = 22,
		/// <summary>
		/// Linear light.
		/// </summary>
		BL_COMP_OP_LINEAR_LIGHT = 23,
		/// <summary>
		/// Pin light.
		/// </summary>
		BL_COMP_OP_PIN_LIGHT = 24,
		/// <summary>
		/// Hard-light.
		/// </summary>
		BL_COMP_OP_HARD_LIGHT = 25,
		/// <summary>
		/// Soft-light.
		/// </summary>
		BL_COMP_OP_SOFT_LIGHT = 26,
		/// <summary>
		/// Difference.
		/// </summary>
		BL_COMP_OP_DIFFERENCE = 27,
		/// <summary>
		/// Exclusion.
		/// </summary>
		BL_COMP_OP_EXCLUSION = 28
	}
	/// <summary>
	/// Rendering quality.
	/// </summary>
	public enum BLRenderingQuality : UInt32 {
		/// <summary>
		/// Render using anti-aliasing.
		/// </summary>
		BL_RENDERING_QUALITY_ANTIALIAS = 0
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct BLContextCore : IBlendStruct<BLContextCore> {
		internal IntPtr impl;
		private readonly IntPtr internals;
		public readonly Boolean Equals(BLContextCore other) => impl == other.impl && internals == other.internals;
		public override readonly Boolean Equals(object obj) => obj is BLContextCore other && Equals(other);
		public static Boolean operator ==(BLContextCore left, BLContextCore right) => left.Equals(right);
		public static Boolean operator !=(BLContextCore left, BLContextCore right) => !(left == right);
		public override readonly Int32 GetHashCode() => (Int32) impl;
	}
	/// <summary>
	/// Information that can be used to customize the rendering context.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct BLContextCreateInfo {
		/// <summary>
		/// Create flags, see <see cref="BLContextCreateFlags"/>.
		/// </summary>
		public UInt32 flags;
		/// <summary>
		/// Number of worker threads to use for asynchronous rendering, if non-zero.
		/// </summary>
		/// <remarks>
		/// If `threadCount` is zero it means to initialize the context for synchronous rendering. This means that every
		/// operation will take effect immediately. If `threadCount` is `1` it means that the rendering will be asynchronous,
		/// but no thread would be acquired from a thread-pool, because the user thread will be used as a worker. And
		/// finally, if `threadCount` is greater than `1` then total of `threadCount - 1` threads will be acquired from
		/// thread-pool and used as additional workers.
		/// </remarks>
		public UInt32 threadCount;
		/// <summary>
		/// CPU features to use in isolated JIT runtime (if supported), only used when `flags` contains <see cref="BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_OVERRIDE_CPU_FEATURES"/>
		/// </summary>
		public UInt32 cpuFeatures;
		/// <summary>
		/// Maximum number of commands to be queued. If this parameter is zero the queue size will be determined automatically.
		/// </summary>
		/// <remarks>
		/// TODO: To be documented, has no effect at the moment.
		/// </remarks>
		public UInt32 commandQueueLimit;
		/// <summary>
		/// Maximum number of saved states.
		/// </summary>
		/// <remarks>
		/// Zero value tells the rendering engine to use the default saved state limit, which currently defaults
		/// to 4096 states. This option allows to even increase or decrease the limit, depending on the use case.
		/// </remarks>
		public UInt32 savedStateLimit;
		/// <summary>
		/// Pixel origin is an offset in pixel units that can be used as an origin for fetchers and effects that use a pixel
		/// X/Y coordinate in the calculation. One example of using pixel origin is dithering, where it's used to shift the
		/// dithering matrix.
		/// </summary>
		public BLPointI pixelOrigin;
		private readonly UInt32 reserved;
	}
	/// <summary>
	/// Holds an arbitrary 128-bit value (cookie) that can be used to match other cookies. Blend2D uses cookies in places
	/// where it allows to "lock" some state that can only be unlocked by a matching cookie. Please don't confuse cookies
	/// with a security of any kind, it's just an arbitrary data that must match to proceed with a certain operation.
	/// Cookies can be used with <see cref="blContextSave(ref BLContextCore, ref BLContextCookie)"/> and <see cref="blContextRestore(ref BLContextCore, ref BLContextCookie)"/>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct BLContextCookie {
		internal UInt64 data0;
		internal UInt64 data1;
	}
	/// <summary>
	/// Rendering context hints.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct BLContextHints {
		public byte quality;
		[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U8, SizeConst = 8)]
		public byte[] hints;
	}
}

using System;
using System.IO;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Blend2D raster image
/// </summary>
public sealed class Image : BlendObject<BLImageCore> {
	/// <summary>
	/// Width of the image
	/// </summary>
	public UInt32 Width {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetWidth();
		}
	}
	/// <summary>
	/// Height of the image
	/// </summary>
	public UInt32 Height {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetHeight();
		}
	}
	/// <summary>
	/// Pixel format of the image
	/// <para/>
	/// Note that setting this can be lossy if you convert from a wider channel format to a narrower one
	/// </summary>
	public BLFormat Format {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetFormat();
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			core.Convert(value);
		}
	}
	/// <summary>
	/// Instantiates an empty image of <see cref="BLFormat.BL_FORMAT_NONE"/> pixel format
	/// </summary>
	public Image() {
		core.Initialise();
	}
	/// <summary>
	/// Instantiates an empty <paramref name="width"/> by <paramref name="height"/>
	/// image of <paramref name="format"/> pixel format.
	/// </summary>
	/// <param name="width">Width of the image</param>
	/// <param name="height">Height of the image</param>
	/// <param name="format">Pixel format of the image</param>
	public Image(UInt32 width, UInt32 height, BLFormat format) {
		core.Initialise(width, height, format);
	}
	/// <summary>
	/// A weak copy of <paramref name="other"/> when <paramref name="move"/> is <see langword="false"/>;
	/// <paramref name="other"/> reset and its members move to this new instance otherwise.
	/// </summary>
	/// <param name="other">The other object instance to be weakly copied or reset</param>
	/// <param name="move">Whether to move or to weakly copy</param>
	public Image(Image other, Boolean move = false) {
		if (move)
			core.MoveInitialise(ref other.core);
		else
			core.WeakCopyInitialise(ref other.core);
	}
	/// <summary>
	/// Instantiates an image reading it from the input stream and decoded using builtin codecs
	/// </summary>
	/// <param name="inputStream">Readable stream of an image</param>
	/// <exception cref="ArgumentException">When reading the image off the stream fails</exception>
	public Image(Stream inputStream) {
		BLResult err = core.Initialise(inputStream);
		if (err != BLResult.BL_SUCCESS)
			throw new ArgumentException(err == BLResult.BL_ERROR_INVALID_KEY
				? "Stream isn't readable"
				: $"Internal trouble reading data within stream by the Blend2D native procedure called. Result code {err} ({(Int32) err})",
				nameof(inputStream));
	}
	/// <summary>
	/// Instantiates an image reading it from the <paramref name="filePath"/> and decoded using builtin codecs
	/// </summary>
	/// <param name="filePath">Path to image file</param>
	/// <exception cref="IOException">When it can't be read</exception>
	public Image(String filePath) {
		if (core.Initialise(filePath) != BLResult.BL_SUCCESS)
			throw new IOException($"Reading file at {filePath} failed");
	}
	/// <inheritdoc cref="ICloneable.Clone"/>
	public Image Clone() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		Image ret = new();
		core.DeepCopy(ref ret.core);
		return ret;
	}
	/// <summary>
	/// Scales the image using <paramref name="filter"/> method by <c>Abs(<paramref name="fraction"/>)</c> times
	/// </summary>
	/// <param name="fraction">Scaling factor</param>
	/// <param name="filter">Scaling method</param>
	public void Scale(Double fraction, BLImageScaleFilter filter = BLImageScaleFilter.BL_IMAGE_SCALE_FILTER_LANCZOS) => Scale((UInt32) (Math.Abs(fraction) * Width), (UInt32) (Height * Math.Abs(fraction)), filter);
	/// <summary>
	/// Scales the image using <paramref name="filter"/> method into <paramref name="width"/> by <paramref name="height"/>
	/// </summary>
	/// <param name="width">Target width</param>
	/// <param name="height">Target height</param>
	/// <param name="filter">Scaling method</param>
	public void Scale(UInt32 width, UInt32 height, BLImageScaleFilter filter = BLImageScaleFilter.BL_IMAGE_SCALE_FILTER_LANCZOS) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLImageCore temp = default;
		temp.Initialise(width, height, core.GetFormat());
		if (temp.Scale(ref core, (Int32) width, (Int32) height, filter) != BLResult.BL_SUCCESS)
			return;
		core.Destroy();
		core = temp;
	}
	/// <summary>
	/// Saves image to <paramref name="filePath"/>; Its encoding format determined by its extension
	/// </summary>
	/// <param name="filePath"></param>
	public void Save(String filePath) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		core.WriteToFile(filePath);
	}
	/// <summary>
	/// Saves image to <paramref name="filePath"/>; <paramref name="encoding"/> as its format
	/// </summary>
	/// <param name="filePath"></param>
	/// <param name="encoding"></param>
	public void Save(String filePath, ImageEncoding encoding) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLArrayCore builtins = default;
		builtins.PopulateWithBuiltinImageCodecs();
		BLImageCodecCore codec = default;
		codec.FindByName(encoding switch {
			ImageEncoding.BMP => "bmp",
			ImageEncoding.JPEG => "jpg",
			ImageEncoding.PNG => "png",
			ImageEncoding.QOI => "qoi",
			_ => ""
		}, ref builtins);
		core.WriteToFile(filePath);
	}
	/// <summary>
	/// Encodings supported by <see cref="Save(string, ImageEncoding)"/>
	/// </summary>
	public enum ImageEncoding {
		/// <summary>
		/// Bitmap
		/// </summary>
		BMP,
		/// <summary>
		/// Joint Photographic Expert Group
		/// </summary>
		JPEG,
		/// <summary>
		/// Portable Network Graphics
		/// </summary>
		PNG,
		/// <summary>
		/// Quite OK Image
		/// </summary>
		QOI
	}
	/// <summary>
	/// Creates a pattern styling using this image; Initially set to include the entire area of the image.
	/// </summary>
	public Pattern CreatePattern() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		Pattern p = new(this);
		dependentDisposables.Add(p);
		return p;
	}
	/// <summary>
	/// Begins creation of a drawing context atop the image.
	/// </summary>
	public ImageContextBuilder CreateContext() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		return new(this);
	}
	/// <summary>
	/// Builder pattern implementation for the creation of <see cref="Context"/>s atop an <see cref="Image"/>
	/// </summary>
	public sealed class ImageContextBuilder {
		internal ImageContextBuilder(Image img) {
			image = img;
		}
		private readonly Image image;
		private BLContextCreateInfo info;
		/// <summary>
		/// <paramref name="tc"/> can be:
		/// <list type="bullet">
		/// <item>0 which makes render calls synchronous and thus blocking</item>
		/// <item>1 which makes render calls asynchronous but no thread will be acquired from the pool thus using user's thread</item>
		/// <item>2 and greater which acquires <c><paramref name="tc"/> - 1</c> threads from the pool as additional asynchronous workers</item>
		/// </list>
		/// </summary>
		/// <param name="tc">Number of worker threads</param>
		public ImageContextBuilder WithThreadCount(UInt32 tc) {
			info.threadCount = tc;
			return this;
		}
#pragma warning disable IDE0051
		/// <summary>
		/// To be implemented by Blend2D
		/// </summary>
		/// <param name="ql"></param>
		private ImageContextBuilder WithCommandQueueLimit(UInt32 ql) {
			info.commandQueueLimit = ql;
			return this;
		}
#pragma warning restore IDE0051
		/// <summary>
		/// Maximum number of saved states within the context. Zero is default which currently translates to 4096
		/// </summary>
		/// <param name="sl">New limit</param>
		public ImageContextBuilder WithSavedStateLimit(UInt32 sl) {
			info.savedStateLimit = sl;
			return this;
		}
		/// <summary>
		/// Origin offset in pixels. Affects operations that use coordinates in their calculations.
		/// <para/>
		/// One such operation is dithering, an intentional noise introduced to break up colour banding and such.
		/// </summary>
		/// <param name="x">X of origin</param>
		/// <param name="y">Y of origin</param>
		public ImageContextBuilder WithOrigin(Int32 x, Int32 y) {
			(info.pixelOrigin.x, info.pixelOrigin.y) = (x, y);
			return this;
		}
		/// <summary>
		/// Overrides the ISA extensions used in the JIT Pipeline compiler output with those specified
		/// </summary>
		/// <param name="cpuFeatures">The feature(s) you want</param>
		public ImageContextBuilder AddCpuFeatures(BLRuntimeCpuFeatures cpuFeatures) {
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_OVERRIDE_CPU_FEATURES;
			info.cpuFeatures |= cpuFeatures;
			return this;
		}
		/// <summary>
		/// Overrides the ISA extensions used in the JIT Pipeline compiler output with those specified
		/// over a x86 runtime
		/// </summary>
		/// <param name="cpuFeatures">The feature(s) you want</param>
		public ImageContextBuilder AddCpuFeaturesIfx86(BLRuntimeCpuFeatures cpuFeatures) {
			BLRuntimeSystemInfo system = default;
			system.QueryInfo();
			if (system.cpuArch != BLRuntimeCpuArch.BL_RUNTIME_CPU_ARCH_X86)
				return this;
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_OVERRIDE_CPU_FEATURES;
			info.cpuFeatures |= cpuFeatures;
			return this;
		}
		/// <summary>
		/// Overrides the ISA extensions used in the JIT Pipeline compiler output with those specified
		/// over an ARM runtime
		/// </summary>
		/// <param name="cpuFeatures">The feature(s) you want</param>
		public ImageContextBuilder AddCpuFeaturesIfARM(BLRuntimeCpuFeatures cpuFeatures) {
			BLRuntimeSystemInfo system = default;
			system.QueryInfo();
			if (system.cpuArch != BLRuntimeCpuArch.BL_RUNTIME_CPU_ARCH_ARM)
				return this;
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_OVERRIDE_CPU_FEATURES;
			info.cpuFeatures |= cpuFeatures;
			return this;
		}
		/// <summary>
		/// Disables runtime Just In Time compilation of rendering pipelines
		/// </summary>
		public ImageContextBuilder DisableJIT() {
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_DISABLE_JIT;
			return this;
		}
		/// <summary>
		/// Allows the runtime to fallback to synchronous rendering calls if it fails to acquire means of asynchrony
		/// </summary>
		public ImageContextBuilder FallbackToSynchrony() {
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_FALLBACK_TO_SYNC;
			return this;
		}
		/// <summary>
		/// Makes an asynchronous context establish its own thread pool, not shared by the rest of the runtime.
		/// <para/>
		/// Doing so adds unnecessary overhead. Avoid production use.
		/// </summary>
		public ImageContextBuilder ThreadPoolIsolation() {
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_ISOLATED_THREAD_POOL;
			return this;
		}
		/// <summary>
		/// Makes JIT Pipeline compilation of the context create an isolated JIT instance.
		/// <para/>
		/// The isolated instance wouldn't use the global JIT cache nor does it contribute to it. Avoid production use.
		/// </summary>
		public ImageContextBuilder JITPipelineIsolation() {
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_ISOLATED_JIT_RUNTIME;
			return this;
		}
		/// <summary>
		/// Calls <see cref="JITPipelineIsolation"/> and allows logging of the isolated runtime to its own standard error output. Avoid prodution use.
		/// </summary>
		public ImageContextBuilder JITLoggingIsolation() {
			info.flags |= BLContextCreateFlags.BL_CONTEXT_CREATE_FLAG_ISOLATED_JIT_LOGGING;
			return JITPipelineIsolation();
		}
		/// <summary>
		/// Builds a context atop the image using appropriate parameters as specified.
		/// <para/>
		/// The instance returned is registered to be disposed of along with the image it's bulit upon
		/// thus you need not to dispose of it yourself. It is destroyed when the image is.
		/// </summary>
		/// <returns>Context built to draw upon the image</returns>
		public Context Build() {
			Context ctx = new();
			unsafe {
				fixed (BLContextCore* pctx = &ctx.core)
				fixed (BLImageCore* pimg = &image.core)
				fixed (BLContextCreateInfo* pinfo = &info)
					blContextInitAs(pctx, pimg, pinfo);
			}
			image.dependentDisposables.Add(ctx);
			return ctx;
		}
	}
}
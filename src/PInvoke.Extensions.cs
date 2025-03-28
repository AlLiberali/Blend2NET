using System;
using System.Runtime.InteropServices;

namespace AlLiberali.Blend2NET;

public static partial class PInvoke {
	/// <summary>
	/// <para>
	/// Generic initialisation method for BL*Core types that need initialisation
	/// and can be initialised without extra arguments
	/// </para>
	/// These types implment the <see cref="IGenericInitialisable"/> interface.
	/// This is a little shortcut I took to avoid writing extension methods for each of them.
	/// I'm sorry.
	/// </summary>
	/// <typeparam name="T">The type of struct to be initialised</typeparam>
	/// <param name="core">The struct to be initialised</param>
	/// <returns>The status code returned by the relevant initialisation native procedure</returns>
	/// <exception cref="InvalidOperationException">When an unsupported type is passed to be initialised</exception>
	public static BLResult Initialise<T>(this ref T core) where T : unmanaged, IGenericInitialisable {
		unsafe {
			fixed (T* pcore = &core)
				return core switch {
					BLFileCore _ => blFileInit((BLFileCore*) pcore),
					BLBitArrayCore _ => blBitArrayInit((BLBitArrayCore*) pcore),
					BLBitSetCore _ => blBitSetInit((BLBitSetCore*) pcore),
					BLStringCore _ => blStringInit((BLStringCore*) pcore),
					BLFontDataCore _ => blFontDataInit((BLFontDataCore*) pcore),
					BLGlyphBufferCore _ => blGlyphBufferInit((BLGlyphBufferCore*) pcore),
					BLPathCore _ => blPathInit((BLPathCore*) pcore),
					BLStrokeOptionsCore _ => blStrokeOptionsInit((BLStrokeOptionsCore*) pcore),
					BLFontFaceCore _ => blFontFaceInit((BLFontFaceCore*) pcore),
					BLFontFeatureSettingsCore _ => blFontFeatureSettingsInit((BLFontFeatureSettingsCore*) pcore),
					BLFontVariationSettingsCore _ => blFontVariationSettingsInit((BLFontVariationSettingsCore*) pcore),
					BLFontCore _ => blFontInit((BLFontCore*) pcore),
					BLGradientCore _ => blGradientInit((BLGradientCore*) pcore),
					BLImageCodecCore _ => blImageCodecInit((BLImageCodecCore*) pcore),
					BLImageCore _ => blImageInit((BLImageCore*) pcore),
					BLPatternCore _ => blPatternInit((BLPatternCore*) pcore),
					BLContextCore _ => blContextInit((BLContextCore*) pcore),
					BLFontManagerCore _ => blFontManagerInit((BLFontManagerCore*) pcore),
					BLImageDecoderCore _ => blImageDecoderInit((BLImageDecoderCore*) pcore),
					BLImageEncoderCore _ => blImageEncoderInit((BLImageEncoderCore*) pcore),
					BLPixelConverterCore _ => blPixelConverterInit((BLPixelConverterCore*) pcore),
					_ => throw new InvalidOperationException()
				};
		}
	}
	/// <summary>
	/// <para>
	/// Generic resetting method for BL*Core types that
	/// can be reset without extra arguments
	/// </para>
	/// These types implment the <see cref="IGenericResettable"/> interface.
	/// This is a little shortcut I took to avoid writing extension methods for each of them.
	/// I'm sorry.
	/// </summary>
	/// <typeparam name="T">The type of struct to be reset</typeparam>
	/// <param name="core">The struct to be reset</param>
	/// <returns>The status code returned by the relevant resetting native procedure</returns>
	/// <exception cref="InvalidOperationException">When an unsupported type is passed to be reset</exception>
	public static BLResult Reset<T>(this ref T core) where T : unmanaged, IGenericResettable {
		unsafe {
			fixed (T* pcore = &core)
				return core switch {
					BLArrayCore _ => blArrayReset((BLArrayCore*) pcore),
					BLBitArrayCore _ => blBitArrayReset((BLBitArrayCore*) pcore),
					BLBitSetCore _ => blBitSetReset((BLBitSetCore*) pcore),
					BLStringCore _ => blStringReset((BLStringCore*) pcore),
					BLFontDataCore _ => blFontDataReset((BLFontDataCore*) pcore),
					BLGlyphBufferCore _ => blGlyphBufferReset((BLGlyphBufferCore*) pcore),
					BLPathCore _ => blPathReset((BLPathCore*) pcore),
					BLStrokeOptionsCore _ => blStrokeOptionsReset((BLStrokeOptionsCore*) pcore),
					BLFontFaceCore _ => blFontFaceReset((BLFontFaceCore*) pcore),
					BLFontFeatureSettingsCore _ => blFontFeatureSettingsReset((BLFontFeatureSettingsCore*) pcore),
					BLFontVariationSettingsCore _ => blFontVariationSettingsReset((BLFontVariationSettingsCore*) pcore),
					BLFontCore _ => blFontReset((BLFontCore*) pcore),
					BLGradientCore _ => blGradientReset((BLGradientCore*) pcore),
					BLImageCodecCore _ => blImageCodecReset((BLImageCodecCore*) pcore),
					BLImageCore _ => blImageReset((BLImageCore*) pcore),
					BLPatternCore _ => blPatternReset((BLPatternCore*) pcore),
					BLContextCore _ => blContextReset((BLContextCore*) pcore),
					BLFontManagerCore _ => blFontManagerReset((BLFontManagerCore*) pcore),
					BLImageDecoderCore _ => blImageDecoderReset((BLImageDecoderCore*) pcore),
					BLImageEncoderCore _ => blImageEncoderReset((BLImageEncoderCore*) pcore),
					BLPixelConverterCore _ => blPixelConverterReset((BLPixelConverterCore*) pcore),
					_ => throw new InvalidOperationException()
				};
		}
	}
	/// <summary>
	/// <para>
	/// Generic destruction method for BL*Core types that allocate resources
	/// </para>
	/// These types implment the <see cref="IGenericMoveInitialisableAndDestroyable"/> interface.
	/// This is a little shortcut I took to avoid writing extension methods for each of them.
	/// I'm sorry.
	/// </summary>
	/// <typeparam name="T">The type of struct to be destroyed</typeparam>
	/// <param name="core">The struct to be destroyed</param>
	/// <returns>The status code returned by the relevant destruction native procedure</returns>
	/// <exception cref="InvalidOperationException">When an unsupported type is passed to be initialised</exception>
	public static BLResult Destroy<T>(this ref T core) where T : unmanaged, IGenericMoveInitialisableAndDestroyable {
		unsafe {
			fixed (T* pcore = &core)
				return core switch {
					BLArrayCore _ => blArrayDestroy((BLArrayCore*) pcore),
					BLBitArrayCore _ => blBitArrayDestroy((BLBitArrayCore*) pcore),
					BLBitSetCore _ => blBitSetDestroy((BLBitSetCore*) pcore),
					BLStringCore _ => blStringDestroy((BLStringCore*) pcore),
					BLFontDataCore _ => blFontDataDestroy((BLFontDataCore*) pcore),
					BLGlyphBufferCore _ => blGlyphBufferDestroy((BLGlyphBufferCore*) pcore),
					BLPathCore _ => blPathDestroy((BLPathCore*) pcore),
					BLStrokeOptionsCore _ => blStrokeOptionsDestroy((BLStrokeOptionsCore*) pcore),
					BLFontFaceCore _ => blFontFaceDestroy((BLFontFaceCore*) pcore),
					BLFontFeatureSettingsCore _ => blFontFeatureSettingsDestroy((BLFontFeatureSettingsCore*) pcore),
					BLFontVariationSettingsCore _ => blFontVariationSettingsDestroy((BLFontVariationSettingsCore*) pcore),
					BLFontCore _ => blFontDestroy((BLFontCore*) pcore),
					BLGradientCore _ => blGradientDestroy((BLGradientCore*) pcore),
					BLImageCodecCore _ => blImageCodecDestroy((BLImageCodecCore*) pcore),
					BLImageCore _ => blImageDestroy((BLImageCore*) pcore),
					BLPatternCore _ => blPatternDestroy((BLPatternCore*) pcore),
					BLContextCore _ => blContextDestroy((BLContextCore*) pcore),
					BLFontManagerCore _ => blFontManagerDestroy((BLFontManagerCore*) pcore),
					BLImageDecoderCore _ => blImageDecoderDestroy((BLImageDecoderCore*) pcore),
					BLImageEncoderCore _ => blImageEncoderDestroy((BLImageEncoderCore*) pcore),
					_ => throw new InvalidOperationException()
				};
		}
	}
	/// <summary>
	/// <para>
	/// Generic initialisation method for BL*Core types that need initialisation
	/// and can be initialised through moving data over from some other instance.
	/// This will reset the other instance to a default state.
	/// </para>
	/// These types implment the <see cref="IGenericMoveInitialisableAndDestroyable"/> interface.
	/// This is a little shortcut I took to avoid writing extension methods for each of them.
	/// I'm sorry.
	/// </summary>
	/// <typeparam name="T">The type of struct to be initialised</typeparam>
	/// <param name="core">The struct to be moved into</param>
	/// <param name="other">The struct to be reset</param>
	/// <returns>The status code returned by the relevant initialisation native procedure</returns>
	/// <exception cref="InvalidOperationException">When an unsupported type is passed to be initialised</exception>
	public static BLResult MoveInitialise<T>(this ref T core, ref T other) where T : unmanaged, IGenericMoveInitialisableAndDestroyable {
		unsafe {
			fixed (T* pcore = &core)
			fixed (T* pother = &other)
				return core switch {
					BLArrayCore _ => blArrayInitMove((BLArrayCore*) pcore, (BLArrayCore*) pother),
					BLBitArrayCore _ => blBitArrayInitMove((BLBitArrayCore*) pcore, (BLBitArrayCore*) pother),
					BLBitSetCore _ => blBitSetInitMove((BLBitSetCore*) pcore, (BLBitSetCore*) pother),
					BLStringCore _ => blStringInitMove((BLStringCore*) pcore, (BLStringCore*) pother),
					BLFontDataCore _ => blFontDataInitMove((BLFontDataCore*) pcore, (BLFontDataCore*) pother),
					BLGlyphBufferCore _ => blGlyphBufferInitMove((BLGlyphBufferCore*) pcore, (BLGlyphBufferCore*) pother),
					BLPathCore _ => blPathInitMove((BLPathCore*) pcore, (BLPathCore*) pother),
					BLStrokeOptionsCore _ => blStrokeOptionsInitMove((BLStrokeOptionsCore*) pcore, (BLStrokeOptionsCore*) pother),
					BLFontFaceCore _ => blFontFaceInitMove((BLFontFaceCore*) pcore, (BLFontFaceCore*) pother),
					BLFontFeatureSettingsCore _ => blFontFeatureSettingsInitMove((BLFontFeatureSettingsCore*) pcore, (BLFontFeatureSettingsCore*) pother),
					BLFontVariationSettingsCore _ => blFontVariationSettingsInitMove((BLFontVariationSettingsCore*) pcore, (BLFontVariationSettingsCore*) pother),
					BLFontCore _ => blFontInitMove((BLFontCore*) pcore, (BLFontCore*) pother),
					BLGradientCore _ => blGradientInitMove((BLGradientCore*) pcore, (BLGradientCore*) pother),
					BLImageCodecCore _ => blImageCodecInitMove((BLImageCodecCore*) pcore, (BLImageCodecCore*) pother),
					BLImageCore _ => blImageInitMove((BLImageCore*) pcore, (BLImageCore*) pother),
					BLPatternCore _ => blPatternInitMove((BLPatternCore*) pcore, (BLPatternCore*) pother),
					BLContextCore _ => blContextInitMove((BLContextCore*) pcore, (BLContextCore*) pother),
					BLFontManagerCore _ => blFontManagerInitMove((BLFontManagerCore*) pcore, (BLFontManagerCore*) pother),
					BLImageDecoderCore _ => blImageDecoderInitMove((BLImageDecoderCore*) pcore, (BLImageDecoderCore*) pother),
					BLImageEncoderCore _ => blImageEncoderInitMove((BLImageEncoderCore*) pcore, (BLImageEncoderCore*) pother),
					_ => throw new InvalidOperationException()
				};
		}
	}
	/// <summary>
	/// <para>
	/// Generic initialisation method for BL*Core types that need initialisation
	/// and can be initialised through weakly copying of data over from some other instance.
	/// This will essentially duplicate handles to the same data.
	/// </para>
	/// These types implment the <see cref="IGenericWeakInitialisable"/> interface.
	/// This is a little shortcut I took to avoid writing extension methods for each of them.
	/// I'm sorry.
	/// </summary>
	/// <typeparam name="T">The type of struct to be initialised</typeparam>
	/// <param name="core">The struct to be copied into</param>
	/// <param name="other">The original struct</param>
	/// <returns>The status code returned by the relevant initialisation native procedure</returns>
	/// <exception cref="InvalidOperationException">When an unsupported type is passed to be initialised</exception>
	public static BLResult WeakCopyInitialise<T>(this ref T core, ref T other) where T : unmanaged, IGenericWeakInitialisable {
		unsafe {
			fixed (T* pcore = &core)
			fixed (T* pother = &other)
				return core switch {
					BLArrayCore _ => blArrayInitWeak((BLArrayCore*) pcore, (BLArrayCore*) pother),
					BLBitArrayCore _ => blBitArrayInitWeak((BLBitArrayCore*) pcore, (BLBitArrayCore*) pother),
					BLBitSetCore _ => blBitSetInitWeak((BLBitSetCore*) pcore, (BLBitSetCore*) pother),
					BLStringCore _ => blStringInitWeak((BLStringCore*) pcore, (BLStringCore*) pother),
					BLFontDataCore _ => blFontDataInitWeak((BLFontDataCore*) pcore, (BLFontDataCore*) pother),
					BLPathCore _ => blPathInitWeak((BLPathCore*) pcore, (BLPathCore*) pother),
					BLStrokeOptionsCore _ => blStrokeOptionsInitWeak((BLStrokeOptionsCore*) pcore, (BLStrokeOptionsCore*) pother),
					BLFontFaceCore _ => blFontFaceInitWeak((BLFontFaceCore*) pcore, (BLFontFaceCore*) pother),
					BLFontFeatureSettingsCore _ => blFontFeatureSettingsInitWeak((BLFontFeatureSettingsCore*) pcore, (BLFontFeatureSettingsCore*) pother),
					BLFontVariationSettingsCore _ => blFontVariationSettingsInitWeak((BLFontVariationSettingsCore*) pcore, (BLFontVariationSettingsCore*) pother),
					BLFontCore _ => blFontInitWeak((BLFontCore*) pcore, (BLFontCore*) pother),
					BLGradientCore _ => blGradientInitWeak((BLGradientCore*) pcore, (BLGradientCore*) pother),
					BLImageCodecCore _ => blImageCodecInitWeak((BLImageCodecCore*) pcore, (BLImageCodecCore*) pother),
					BLImageCore _ => blImageInitWeak((BLImageCore*) pcore, (BLImageCore*) pother),
					BLPatternCore _ => blPatternInitWeak((BLPatternCore*) pcore, (BLPatternCore*) pother),
					BLContextCore _ => blContextInitWeak((BLContextCore*) pcore, (BLContextCore*) pother),
					BLFontManagerCore _ => blFontManagerInitWeak((BLFontManagerCore*) pcore, (BLFontManagerCore*) pother),
					BLImageDecoderCore _ => blImageDecoderInitWeak((BLImageDecoderCore*) pcore, (BLImageDecoderCore*) pother),
					BLImageEncoderCore _ => blImageEncoderInitWeak((BLImageEncoderCore*) pcore, (BLImageEncoderCore*) pother),
					BLPixelConverterCore _ => blPixelConverterInitWeak((BLPixelConverterCore*) pcore, (BLPixelConverterCore*) pother),
					_ => throw new InvalidOperationException()
				};
		}
	}
	/// <summary>
	/// <para>
	/// Generic assignment method for BL*Core types that support being
	/// weakly copied into some other, initialised, instance; Releasing previously
	/// held resources within the lost instance.
	/// </para>
	/// These types implment the <see cref="IGenericWeakCopyable"/> interface.
	/// This is a little shortcut I took to avoid writing extension methods for each of them.
	/// I'm sorry.
	/// </summary>
	/// <typeparam name="T">The type of struct to be copied</typeparam>
	/// <param name="core">The struct to be copied into</param>
	/// <param name="other">The original struct</param>
	/// <returns>The status code returned by the relevant assignment native procedure</returns>
	/// <exception cref="InvalidOperationException">When an unsupported type is passed to be initialised</exception>
	public static BLResult WeakCopy<T>(this ref T core, ref T other) where T : unmanaged, IGenericWeakCopyable {
		unsafe {
			fixed (T* pcore = &core)
			fixed (T* pother = &other)
				return core switch {
					BLArrayCore _ => blArrayAssignWeak((BLArrayCore*) pcore, (BLArrayCore*) pother),
					BLBitArrayCore _ => blBitArrayAssignWeak((BLBitArrayCore*) pcore, (BLBitArrayCore*) pother),
					BLBitSetCore _ => blBitSetAssignWeak((BLBitSetCore*) pcore, (BLBitSetCore*) pother),
					BLStringCore _ => blStringAssignWeak((BLStringCore*) pcore, (BLStringCore*) pother),
					BLFontDataCore _ => blFontDataAssignWeak((BLFontDataCore*) pcore, (BLFontDataCore*) pother),
					BLPathCore _ => blPathAssignWeak((BLPathCore*) pcore, (BLPathCore*) pother),
					BLStrokeOptionsCore _ => blStrokeOptionsAssignWeak((BLStrokeOptionsCore*) pcore, (BLStrokeOptionsCore*) pother),
					BLFontFaceCore _ => blFontFaceAssignWeak((BLFontFaceCore*) pcore, (BLFontFaceCore*) pother),
					BLFontFeatureSettingsCore _ => blFontFeatureSettingsAssignWeak((BLFontFeatureSettingsCore*) pcore, (BLFontFeatureSettingsCore*) pother),
					BLFontVariationSettingsCore _ => blFontVariationSettingsAssignWeak((BLFontVariationSettingsCore*) pcore, (BLFontVariationSettingsCore*) pother),
					BLFontCore _ => blFontAssignWeak((BLFontCore*) pcore, (BLFontCore*) pother),
					BLGradientCore _ => blGradientAssignWeak((BLGradientCore*) pcore, (BLGradientCore*) pother),
					BLImageCodecCore _ => blImageCodecAssignWeak((BLImageCodecCore*) pcore, (BLImageCodecCore*) pother),
					BLImageCore _ => blImageAssignWeak((BLImageCore*) pcore, (BLImageCore*) pother),
					BLPatternCore _ => blPatternAssignWeak((BLPatternCore*) pcore, (BLPatternCore*) pother),
					BLContextCore _ => blContextAssignWeak((BLContextCore*) pcore, (BLContextCore*) pother),
					BLFontManagerCore _ => blFontManagerAssignWeak((BLFontManagerCore*) pcore, (BLFontManagerCore*) pother),
					BLImageDecoderCore _ => blImageDecoderAssignWeak((BLImageDecoderCore*) pcore, (BLImageDecoderCore*) pother),
					BLImageEncoderCore _ => blImageEncoderAssignWeak((BLImageEncoderCore*) pcore, (BLImageEncoderCore*) pother),
					BLPixelConverterCore _ => blPixelConverterAssign((BLPixelConverterCore*) pcore, (BLPixelConverterCore*) pother),
					_ => throw new InvalidOperationException()
				};
		}
	}
	/// <summary>
	/// <para>
	/// Generic assignment method for BL*Core types that support being
	/// deeply copied into some other, initialised, instance; Releasing previously
	/// held resources within the lost instance.
	/// </para>
	/// These types implment the <see cref="IGenericDeepCopyable"/> interface.
	/// This is a little shortcut I took to avoid writing extension methods for each of them.
	/// I'm sorry.
	/// </summary>
	/// <typeparam name="T">The type of struct to be copied</typeparam>
	/// <param name="core">The struct to be copied into</param>
	/// <param name="other">The original struct</param>
	/// <returns>The status code returned by the relevant assignment native procedure</returns>
	/// <exception cref="InvalidOperationException">When an unsupported type is passed to be initialised</exception>
	public static BLResult DeepCopy<T>(this ref T core, ref T other) where T : unmanaged, IGenericDeepCopyable {
		unsafe {
			fixed (T* pcore = &core)
			fixed (T* pother = &other)
				return core switch {
					BLArrayCore _ => blArrayAssignDeep((BLArrayCore*) pcore, (BLArrayCore*) pother),
					BLBitSetCore _ => blBitSetAssignDeep((BLBitSetCore*) pcore, (BLBitSetCore*) pother),
					BLStringCore _ => blStringAssignDeep((BLStringCore*) pcore, (BLStringCore*) pother),
					BLPathCore _ => blPathAssignDeep((BLPathCore*) pcore, (BLPathCore*) pother),
					BLImageCore _ => blImageAssignDeep((BLImageCore*) pcore, (BLImageCore*) pother),
					BLPatternCore _ => blPatternAssignDeep((BLPatternCore*) pcore, (BLPatternCore*) pother),
					_ => throw new InvalidOperationException()
				};
		}
	}
	/// <summary>
	/// Initialises the converter into a valid state, ready to be used to convert betwixt the relevant formats.
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="destination">Output format to be used by the converter</param>
	/// <param name="source">Input format to be used by the converter</param>
	/// <param name="createFlags">Converter creation options</param>
	/// <returns>
	/// The status code returned by either <see cref="blFormatInfoQuery"/> or
	/// <see cref="blPixelConverterCreate"/> native procedures. The former of which relates to the
	/// <paramref name="destination"/> and <paramref name="source"/> parameters passed to this method
	/// </returns>
	public static BLResult Initialise(this ref BLPixelConverterCore core, BLFormat destination, BLFormat source, BLPixelConverterCreateFlags createFlags) {
		BLResult err;
		core.Initialise();
		unsafe {
			BLFormatInfo* dst = stackalloc BLFormatInfo[1];
			BLFormatInfo* src = stackalloc BLFormatInfo[1];
			err = dst->QueryInfo(destination);
			if (err != BLResult.BL_SUCCESS)
				return err;
			err = src->QueryInfo(source);
			if (err != BLResult.BL_SUCCESS)
				return err;
			fixed (BLPixelConverterCore* pcore = &core)
				return blPixelConverterCreate(pcore, dst, src, createFlags);
		}
	}
	/// <summary>
	/// Initialises the converter into a valid state, ready to be used to convert betwixt the relevant formats.
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="destination">Output format to be used by the converter</param>
	/// <param name="source">Input format to be used by the converter</param>
	/// <param name="createFlags">Converter creation options</param>
	/// <returns>
	/// The status code returned by either <see cref="blFormatInfoQuery"/> or
	/// <see cref="blPixelConverterCreate"/> native procedures. The former of which relates to the
	/// <paramref name="destination"/> and <paramref name="source"/> parameters passed to this method
	/// </returns>
	public static BLResult Initialise(this ref BLPixelConverterCore core, ref BLFormatInfo destination, ref BLFormatInfo source, BLPixelConverterCreateFlags createFlags) {
		core.Initialise();
		unsafe {
			fixed (BLPixelConverterCore* pcore = &core)
			fixed (BLFormatInfo *dst = &destination)
			fixed (BLFormatInfo *src = &source)
				return blPixelConverterCreate(pcore, dst, src, createFlags);
		}
	}
	/// <summary>
	/// Converts the source pixels' format as specified during the converter's initialisation
	/// and outputs the result into destination
	/// <para>
	/// Note that this method doesn't set the <see cref="BLImageData.format"/> and <see cref="BLImageData.flags"/>
	/// fields within <paramref name="destination"/> to its appropriate values and thus requires further work on your end.
	/// </para>
	/// </summary>
	/// <param name="core">The initialised converter</param>
	/// <param name="destination"></param>
	/// <param name="source"></param>
	/// <param name="origin">Coordinates to the starting position</param>
	/// <param name="gap">TODO</param>
	/// <returns>The status code returned by the <see cref="blPixelConverterConvert"/> native procedure</returns>
	public static BLResult Convert(this ref BLPixelConverterCore core, ref BLImageData destination, ref BLImageData source, BLPointI? origin = null, UInt32 gap = 0) {
		destination.size = source.size;
		unsafe {
			BLPixelConverterOptions* options = stackalloc BLPixelConverterOptions[1];
			options->origin = origin ?? default;
			options->gap = (IntPtr) gap;
			fixed (BLPixelConverterCore* pcore = &core)
				return blPixelConverterConvert(pcore, destination.pixelData, destination.stride, source.pixelData, source.stride, (UInt32) source.size.w, (UInt32) source.size.h, options);
		}
	}
	/// <summary>
	/// Resets the PRNG with the given seed
	/// </summary>
	/// <param name="random">The struct holding the current state of the PRNG generator</param>
	/// <param name="seed">The seed</param>
	/// <returns><see cref="BLResult.BL_SUCCESS"/></returns>
	public static BLResult Seed(this ref BLRandom random, UInt64 seed) {
		unsafe {
			fixed (BLRandom* prandom = &random)
				return blRandomReset(prandom, seed);
		}
	}
	/// <param name="random">The struct holding the current state of the PRNG generator</param>
	/// <returns>Pseudo-random <see cref="UInt32"/></returns>
	public static UInt32 NextUInt32(this ref BLRandom random) {
		unsafe {
			fixed (BLRandom* prandom = &random)
				return blRandomNextUInt32(prandom);
		}
	}
	/// <param name="random">The struct holding the current state of the PRNG generator</param>
	/// <returns>Pseudo-random <see cref="UInt64"/></returns>
	public static UInt64 NextUInt64(this ref BLRandom random) {
		unsafe {
			fixed (BLRandom* prandom = &random)
				return blRandomNextUInt64(prandom);
		}
	}
	/// <param name="random">The struct holding the current state of the PRNG generator</param>
	/// <returns>Pseudo-random <see cref="Double"/></returns>
	public static Double NextDouble(this ref BLRandom random) {
		unsafe {
			fixed (BLRandom* prandom = &random)
				return blRandomNextDouble(prandom);
		}
	}
	/// <summary>
	/// <para>
	/// Blend2D runtime scope sets up the runtime such that floating point operations
	/// behave in a consistent manner across platforms. This method enables this mode.
	/// </para>
	/// Further documentation on this feature available <see href="https://blend2d.com/doc/classBLRuntimeScope.html">here</see>
	/// </summary>
	/// <param name="scope">The structure holding internal state for the scope</param>
	/// <returns>The status code returned by the blRuntimeScopeBegin native procedure</returns>
	public static BLResult Begin(this ref BLRuntimeScopeCore scope) {
		unsafe {
			fixed (BLRuntimeScopeCore* pscope = &scope)
				return blRuntimeScopeBegin(pscope);
		}
	}
	/// <summary>
	/// <para>
	/// Blend2D runtime scope sets up the runtime such that floating point operations
	/// behave in a consistent manner across platforms. This method disables this mode.
	/// </para>
	/// Further documentation on this feature available <see href="https://blend2d.com/doc/classBLRuntimeScope.html">here</see>
	/// </summary>
	/// <param name="scope">The structure holding internal state for the scope</param>
	/// <returns>The status code returned by the blRuntimeScopeBegin native procedure</returns>
	public static BLResult End(this ref BLRuntimeScopeCore scope) {
		unsafe {
			fixed (BLRuntimeScopeCore* pscope = &scope)
				return blRuntimeScopeEnd(pscope);
		}
	}
	/// <summary>
	/// <para>
	/// Blend2D runtime scope sets up the runtime such that floating point operations
	/// behave in a consistent manner across platforms. This method enquires the state of this mode.
	/// </para>
	/// Further documentation on this feature available <see href="https://blend2d.com/doc/classBLRuntimeScope.html">here</see>
	/// </summary>
	/// <param name="scope">The structure holding internal state for the scope</param>
	/// <returns>Whether this mode is in fact active</returns>
	public static Boolean IsActive(this ref BLRuntimeScopeCore scope) {
		unsafe {
			fixed (BLRuntimeScopeCore* pscope = &scope)
				return blRuntimeScopeIsActive(pscope);
		}
	}
	/// <summary>
	/// Sanitises this structure, ensuring valid and simplified format information,
	/// as expected by the rest of the Blend2D machinery.
	/// </summary>
	/// <param name="info">The struct to be sanitised</param>
	/// <returns>The status code returned by the <see cref="blFormatInfoSanitize"/> native procedure</returns>
	public static BLResult Sanitise(this ref BLFormatInfo info) {
		unsafe {
			fixed (BLFormatInfo* pinfo = &info)
				return blFormatInfoSanitize(pinfo);
		}
	}
	/// <summary>
	/// Populates the struct with information describing a supported format as specified
	/// by <see cref="BLFormat"/>. Used by the <see cref="blPixelConverterCreate"/> procedure.
	/// </summary>
	/// <param name="info">The struct to be populated</param>
	/// <param name="format">Supported format</param>
	/// <returns>The status code returned by the <see cref="blFormatInfoQuery"/> native procedure</returns>
	public static BLResult QueryInfo(this ref BLFormatInfo info, BLFormat format) {
		unsafe {
			fixed (BLFormatInfo* pinfo = &info)
				return blFormatInfoQuery(pinfo, format);
		}
	}
	/// <summary>
	/// Populates the struct with information about the underlying Blend2D
	/// shared native library's compile-time properties
	/// </summary>
	/// <param name="info">The struct to be populated</param>
	/// <returns>The status code returned by the <see cref="blRuntimeQueryInfo"/> native procedure</returns>
	public static BLResult QueryInfo(this ref BLRuntimeBuildInfo info) {
		unsafe {
			fixed (BLRuntimeBuildInfo* pinfo = &info)
				return blRuntimeQueryInfo(BLRuntimeInfoType.BL_RUNTIME_INFO_TYPE_BUILD, pinfo);
		}
	}
	/// <summary>
	/// Populates the struct with information about the system at runtime as
	/// reported by the underlying Blend2D shared native library
	/// </summary>
	/// <param name="info">The struct to be populated</param>
	/// <returns>The status code returned by the <see cref="blRuntimeQueryInfo"/> native procedure</returns>
	public static BLResult QueryInfo(this ref BLRuntimeSystemInfo info) {
		unsafe {
			fixed (BLRuntimeSystemInfo* pinfo = &info)
				return blRuntimeQueryInfo(BLRuntimeInfoType.BL_RUNTIME_INFO_TYPE_SYSTEM, pinfo);
		}
	}
	/// <summary>
	/// Populates the struct with information about the resource allocated
	/// by the underlying Blend2D shared native library at runtime
	/// </summary>
	/// <param name="info">The struct to be populated</param>
	/// <returns>The status code returned by the <see cref="blRuntimeQueryInfo"/> native procedure</returns>
	public static BLResult QueryInfo(this ref BLRuntimeResourceInfo info) {
		unsafe {
			fixed (BLRuntimeResourceInfo* pinfo = &info)
				return blRuntimeQueryInfo(BLRuntimeInfoType.BL_RUNTIME_INFO_TYPE_SYSTEM, pinfo);
		}
	}
	/// <summary>
	/// Reads the fixed buffer <see cref="BLRuntimeBuildInfo.compilerInfo"/> into a .NET <see cref="String"/>
	/// </summary>
	/// <param name="info">The populated struct to be read</param>
	/// <returns>Compiler information as a heap allocated <see cref="String"/></returns>
	public static String CompilerInformation(this ref BLRuntimeBuildInfo info) {
		unsafe {
			fixed (BLRuntimeBuildInfo* pinfo = &info)
				return Marshal.PtrToStringAnsi((IntPtr) pinfo->compilerInfo, 32);
		}
	}
	/// <summary>
	/// Reads the fixed buffer <see cref="BLRuntimeSystemInfo.cpuVendor"/> into a .NET <see cref="String"/>
	/// </summary>
	/// <param name="info">The populated struct to be read</param>
	/// <returns>CPU Vendor name as a heap allocated <see cref="String"/></returns>
	public static String CPUVendor(this ref BLRuntimeSystemInfo info) {
		unsafe {
			fixed (BLRuntimeSystemInfo* pinfo = &info)
				return Marshal.PtrToStringAnsi((IntPtr) pinfo->cpuVendor, 16);
		}
	}
	/// <summary>
	/// Reads the fixed buffer <see cref="BLRuntimeSystemInfo.cpuBrand"/> into a .NET <see cref="String"/>
	/// </summary>
	/// <param name="info">The populated struct to be read</param>
	/// <returns>CPU Brand name as a heap allocated <see cref="String"/></returns>
	public static String CPUBrand(this ref BLRuntimeSystemInfo info) {
		unsafe {
			fixed (BLRuntimeSystemInfo* pinfo = &info)
				return Marshal.PtrToStringAnsi((IntPtr) pinfo->cpuBrand, 64);
		}
	}
}

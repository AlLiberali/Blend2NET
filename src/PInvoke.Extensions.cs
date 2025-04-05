using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AlLiberali.Blend2NET;

/// Convenience extension methods provieded over a selection of the crude unsafe ones under PInvoke.Procedures.cs
public static partial class PInvoke {
	#region common
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
	#endregion common
	#region array
	/// <summary>
	/// Gets the number of elements contained in the <see cref="BLArrayCore"/>.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The number of elements contained in the <see cref="BLArrayCore"/>.</returns>
	public static Int64 Size(this ref BLArrayCore core) {
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				return (Int64) blArrayGetSize(pcore);
		}
	}
	/// <summary>
	/// Removes all items from the <see cref="BLArrayCore"/>.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The status code returned by the <see cref="blArrayClear"/> native procedure</returns>
	public static BLResult Clear(this ref BLArrayCore core) {
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				return blArrayClear(pcore);
		}
	}
	/// <summary>
	/// Gets the element at <paramref name="index"/>
	/// </summary>
	/// <typeparam name="T">The type of the elements within the array</typeparam>
	/// <param name="core">The struct holding the object</param>
	/// <param name="index">The zero-based index of the element to get</param>
	/// <returns>Copy of element at <paramref name="index"/> or <c>null</c> if no such thing exists</returns>
	public static T? Get<T>(this ref BLArrayCore core, Int32 index) where T : unmanaged {
		if (!(0 <= index || index < core.Size()))
			return null;
		unsafe {
			T* pitem = null;
			fixed (BLArrayCore* pcore = &core)
				pitem = ((T*) blArrayGetData(pcore));
			if (pitem is null)
				return null;
			pitem += index;
			return Marshal.PtrToStructure<T>((IntPtr) pitem);
		}
	}
	/// <summary>
	/// Sets the element at <paramref name="index"/> to <paramref name="value"/>
	/// </summary>
	/// <typeparam name="T">The type of the elements within the array</typeparam>
	/// <param name="core">The struct holding the object</param>
	/// <param name="index">The zero-based index of the element to set</param>
	/// <param name="value">The thing to be put at <paramref name="index"/></param>
	/// <returns>
	/// <list type="bullet">
	/// <item><see cref="BLResult.BL_ERROR_INVALID_KEY"/> if the index is out of range</item>
	/// <item><see cref="BLResult.BL_ERROR_NOT_IMPLEMENTED"/> if <typeparamref name="T"/> is not supported</item>
	/// <item>The status code returned by the relevant <c>blArrayReplace*</c> native procedure</item>
	/// </list>
	/// </returns>
	public static BLResult Set<T>(this ref BLArrayCore core, Int32 index, T value) where T : unmanaged {
		if (!(0 <= index || index < core.Size()))
			return BLResult.BL_ERROR_INVALID_KEY;
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				return value switch {
					SByte v => blArrayReplaceU8(pcore, (IntPtr) index, (Byte) v),
					Byte v => blArrayReplaceU8(pcore, (IntPtr) index, v),
					Int16 v => blArrayReplaceU16(pcore, (IntPtr) index, (UInt16) v),
					UInt16 v => blArrayReplaceU16(pcore, (IntPtr) index, v),
					Int32 v => blArrayReplaceU32(pcore, (IntPtr) index, (UInt32) v),
					UInt32 v => blArrayReplaceU32(pcore, (IntPtr) index, v),
					Int64 v => blArrayReplaceU64(pcore, (IntPtr) index, (UInt64) v),
					UInt64 v => blArrayReplaceU64(pcore, (IntPtr) index, v),
					Single v => blArrayReplaceF32(pcore, (IntPtr) index, v),
					Double v => blArrayReplaceF64(pcore, (IntPtr) index, v),
					T => sizeof(T) switch {
						1 or 2 or 3 or 4 or 6 or 8 or 10 or 12 or 16 or 20 or 24 or 32 => blArrayReplaceItem(pcore, (IntPtr) index, &value),
						_ => BLResult.BL_ERROR_NOT_IMPLEMENTED
					}
				};
		}
	}
	/// <summary>
	/// Appends <paramref name="value"/> to the end of the array
	/// </summary>
	/// <typeparam name="T">The type of the elements within the array</typeparam>
	/// <param name="core">The struct holding the object</param>
	/// <param name="value">The thing to be appended</param>
	/// <returns>
	/// <list type="bullet">
	/// <item><see cref="BLResult.BL_ERROR_NOT_IMPLEMENTED"/> if <typeparamref name="T"/> is not supported</item>
	/// <item>The status code returned by the relevant <c>blArrayAppend*</c> native procedure</item>
	/// </list>
	/// </returns>
	public static BLResult Append<T>(this ref BLArrayCore core, T value) where T : unmanaged {
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				return value switch {
					SByte v => blArrayAppendU8(pcore, (Byte) v),
					Byte v => blArrayAppendU8(pcore, v),
					Int16 v => blArrayAppendU16(pcore, (UInt16) v),
					UInt16 v => blArrayAppendU16(pcore, v),
					Int32 v => blArrayAppendU32(pcore, (UInt32) v),
					UInt32 v => blArrayAppendU32(pcore, v),
					Int64 v => blArrayAppendU64(pcore, (UInt64) v),
					UInt64 v => blArrayAppendU64(pcore, v),
					Single v => blArrayAppendF32(pcore, v),
					Double v => blArrayAppendF64(pcore, v),
					T => sizeof(T) switch {
						1 or 2 or 3 or 4 or 6 or 8 or 10 or 12 or 16 or 20 or 24 or 32 => blArrayAppendItem(pcore, &value),
						_ => BLResult.BL_ERROR_NOT_IMPLEMENTED
					}
				};
		}
	}
	/// <summary>
	/// Inserts <paramref name="value"/> at <paramref name="index"/>
	/// </summary>
	/// <typeparam name="T">The type of the elements within the array</typeparam>
	/// <param name="core">The struct holding the object</param>
	/// <param name="index">The zero-based index for the element to be inserted</param>
	/// <param name="value">The thing to be put at <paramref name="index"/></param>
	/// <returns>
	/// <list type="bullet">
	/// <item><see cref="BLResult.BL_ERROR_INVALID_KEY"/> if the index is out of range</item>
	/// <item><see cref="BLResult.BL_ERROR_NOT_IMPLEMENTED"/> if <typeparamref name="T"/> is not supported</item>
	/// <item>The status code returned by the relevant <c>blArrayInsert*</c> native procedure</item>
	/// </list>
	/// </returns>
	public static BLResult Insert<T>(this ref BLArrayCore core, Int32 index, T value) where T : unmanaged {
		if (!(0 <= index || index < core.Size()))
			return BLResult.BL_ERROR_INVALID_KEY;
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				return value switch {
					SByte v => blArrayInsertU8(pcore, (IntPtr) index, (Byte) v),
					Byte v => blArrayInsertU8(pcore, (IntPtr) index, v),
					Int16 v => blArrayInsertU16(pcore, (IntPtr) index, (UInt16) v),
					UInt16 v => blArrayInsertU16(pcore, (IntPtr) index, v),
					Int32 v => blArrayInsertU32(pcore, (IntPtr) index, (UInt32) v),
					UInt32 v => blArrayInsertU32(pcore, (IntPtr) index, v),
					Int64 v => blArrayInsertU64(pcore, (IntPtr) index, (UInt64) v),
					UInt64 v => blArrayInsertU64(pcore, (IntPtr) index, v),
					Single v => blArrayInsertF32(pcore, (IntPtr) index, v),
					Double v => blArrayInsertF64(pcore, (IntPtr) index, v),
					T => sizeof(T) switch {
						1 or 2 or 3 or 4 or 6 or 8 or 10 or 12 or 16 or 20 or 24 or 32 => blArrayInsertItem(pcore, (IntPtr) index, &value),
						_ => BLResult.BL_ERROR_NOT_IMPLEMENTED
					}
				};
		}
	}
	/// <summary>
	/// Removes the element at <paramref name="index"/>
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <param name="index">The zero-based index of the element to remove</param>
	/// <returns>
	/// <list type="bullet">
	/// <item><see cref="BLResult.BL_ERROR_INVALID_KEY"/> if the index is out of range</item>
	/// <item>The status code returned by the relevant <c>blArrayReplace*</c> native procedure</item>
	/// </list>
	/// </returns>
	public static BLResult Remove(this ref BLArrayCore core, Int32 index) {
		if (!(0 <= index || index < core.Size()))
			return BLResult.BL_ERROR_INVALID_KEY;
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				return blArrayRemoveIndex(pcore, (IntPtr) index);
		}
	}
	#endregion array
	#region fontface
	/// <summary>
	/// Initialises a font face read from <paramref name="filePath"/>
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="filePath">Path to font file</param>
	/// <param name="readFlags">Memory mapping options</param>
	/// <returns>The status code returned by the <see cref="blFontFaceCreateFromFile"/> native procedure</returns>
	public static BLResult Initialise(this ref BLFontFaceCore core, String filePath, BLFileReadFlags readFlags = BLFileReadFlags.BL_FILE_READ_NO_FLAGS) {
		core.Initialise();
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
				return blFontFaceCreateFromFile(pcore, filePath, readFlags);
		}
	}
	/// <summary>
	/// Enquires the full name for the font face.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The name as promised or <see langword="null"/> if the <see cref="blFontFaceGetFullName"/> native procedure fails.</returns>
	public static String? GetFullName(this ref BLFontFaceCore core) {
		unsafe {
			BLResult err;
			BLStringCore* pstring = stackalloc BLStringCore[1];
			fixed (BLFontFaceCore* pcore = &core)
				err = blFontFaceGetFullName(pcore, pstring);
			if (err != BLResult.BL_SUCCESS)
				return null;
			Byte* pchar = blStringGetData(pstring);
			Int32 length = (Int32) blStringGetSize(pstring);
			return Encoding.ASCII.GetString(pchar, length);
		}
	}
	/// <summary>
	/// Enquires the family name for the font face.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The name as promised or <see langword="null"/> if the <see cref="blFontFaceGetFamilyName"/> native procedure fails.</returns>
	public static String? GetFamilyName(this ref BLFontFaceCore core) {
		unsafe {
			BLResult err;
			BLStringCore* pstring = stackalloc BLStringCore[1];
			fixed (BLFontFaceCore* pcore = &core)
				err = blFontFaceGetFamilyName(pcore, pstring);
			if (err != BLResult.BL_SUCCESS)
				return null;
			Byte* pchar = blStringGetData(pstring);
			Int32 length = (Int32) blStringGetSize(pstring);
			return Encoding.ASCII.GetString(pchar, length);
		}
	}
	/// <summary>
	/// Enquires the subfamily name for the font face.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The name as promised or <see langword="null"/> if the <see cref="blFontFaceGetSubfamilyName"/> native procedure fails.</returns>
	public static String? GetSubfamilyName(this ref BLFontFaceCore core) {
		unsafe {
			BLResult err;
			BLStringCore* pstring = stackalloc BLStringCore[1];
			fixed (BLFontFaceCore* pcore = &core)
				err = blFontFaceGetSubfamilyName(pcore, pstring);
			if (err != BLResult.BL_SUCCESS)
				return null;
			Byte* pchar = blStringGetData(pstring);
			Int32 length = (Int32) blStringGetSize(pstring);
			return Encoding.ASCII.GetString(pchar, length);
		}
	}
	/// <summary>
	/// Enquires the PostScript name for the font face.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The name as promised or <see langword="null"/> if the <see cref="blFontFaceGetPostScriptName"/> native procedure fails.</returns>
	public static String? GetPostScriptName(this ref BLFontFaceCore core) {
		unsafe {
			BLResult err;
			BLStringCore* pstring = stackalloc BLStringCore[1];
			fixed (BLFontFaceCore* pcore = &core)
				err = blFontFaceGetPostScriptName(pcore, pstring);
			if (err != BLResult.BL_SUCCESS)
				return null;
			Byte* pchar = blStringGetData(pstring);
			Int32 length = (Int32) blStringGetSize(pstring);
			return Encoding.ASCII.GetString(pchar, length);
		}
	}
	/// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
	public static Boolean Equals(this ref BLFontFaceCore core, BLFontFaceCore other) {
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
				return blFontFaceEquals(pcore, &other);
		}
	}
	/// <summary>
	/// Does what it says on the tin
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>Struct of data requested</returns>
	public static BLFontFaceInfo GetFaceInformation(this ref BLFontFaceCore core) {
		BLFontFaceInfo ret;
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
				blFontFaceGetFaceInfo(pcore, &ret);
		}
		return ret;
	}
	/// <summary>
	/// Does what it says on the tin
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>Struct of data requested</returns>
	public static BLFontDesignMetrics GetDesignMetrics(this ref BLFontFaceCore core) {
		BLFontDesignMetrics ret;
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
				blFontFaceGetDesignMetrics(pcore, &ret);
		}
		return ret;
	}
	/// <summary>
	/// Does what it says on the tin
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>Struct of data requested</returns>
	public static BLFontUnicodeCoverage GetUnicodeCoverage(this ref BLFontFaceCore core) {
		BLFontUnicodeCoverage ret;
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
				blFontFaceGetUnicodeCoverage(pcore, &ret);
		}
		return ret;
	}
	#endregion fontface
	#region imagecodec
	/// <summary>
	/// Finds a <see cref="BLImageCodecCore"/> associated with <paramref name="name"/>
	/// within the <paramref name="codecArray"/> and initialises <paramref name="core"/>
	/// with it.
	/// <para/>
	/// Note that this doesn't destroy any instance held previously by <paramref name="core"/>
	/// </summary>
	/// <param name="core">The struct to hold the codec found</param>
	/// <param name="name">Name of the codec</param>
	/// <param name="codecArray">Array containing codecs</param>
	/// <returns>The status code returned by the <see cref="blImageCodecFindByName"/> native procedure</returns>
	/// <seealso cref="PopulateWithBuiltinImageCodecs(ref BLArrayCore)"/>
	public static BLResult FindByName(this ref BLImageCodecCore core, String name, ref BLArrayCore codecArray) {
		unsafe {
			fixed (BLImageCodecCore* pcore = &core)
			fixed (BLArrayCore* parray = &codecArray)
				return blImageCodecFindByName(pcore, name, (IntPtr) Encoding.UTF8.GetByteCount(name), parray);
		}
	}
	/// <summary>
	/// Finds a <see cref="BLImageCodecCore"/> associated with <paramref name="extension"/>
	/// within the <paramref name="codecArray"/> and initialises <paramref name="core"/>
	/// with it.
	/// <para/>
	/// Note that this doesn't destroy any instance held previously by <paramref name="core"/>
	/// </summary>
	/// <param name="core">The struct to hold the codec found</param>
	/// <param name="extension">File extension of the codec's format</param>
	/// <param name="codecArray">Array containing codecs</param>
	/// <returns>The status code returned by the <see cref="blImageCodecFindByExtension"/> native procedure</returns>
	/// <seealso cref="PopulateWithBuiltinImageCodecs(ref BLArrayCore)"/>
	public static BLResult FindByExtension(this ref BLImageCodecCore core, String extension, ref BLArrayCore codecArray) {
		unsafe {
			fixed (BLImageCodecCore* pcore = &core)
			fixed (BLArrayCore* parray = &codecArray)
				return blImageCodecFindByExtension(pcore, extension, (IntPtr) Encoding.UTF8.GetByteCount(extension), parray);
		}
	}
	/// <summary>
	/// Initialises a decoder instance of the codec.
	/// <para/>
	/// Note that this doesn't destroy any instance held previously by <paramref name="decoder"/>
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <param name="decoder">The struct for the decoder object</param>
	/// <returns>The status code returned by the <see cref="blImageCodecCreateDecoder"/> native procedure</returns>
	public static BLResult InitialiseDecoder(this ref BLImageCodecCore core, ref BLImageDecoderCore decoder) {
		unsafe {
			fixed (BLImageCodecCore* pcore = &core)
			fixed (BLImageDecoderCore* pdecoder = &decoder)
				return blImageCodecCreateDecoder(pcore, pdecoder);
		}
	}
	/// <summary>
	/// Initialises a encoder instance of the codec
	/// <para/>
	/// Note that this doesn't destroy any instance held previously by <paramref name="encoder"/>
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <param name="encoder">The struct for the encoder object</param>
	/// <returns>The status code returned by the <see cref="blImageCodecCreateEncoder"/> native procedure</returns>
	public static BLResult InitialiseEncoder(this ref BLImageCodecCore core, ref BLImageEncoderCore encoder) {
		unsafe {
			fixed (BLImageCodecCore* pcore = &core)
			fixed (BLImageEncoderCore* pencoder = &encoder)
				return blImageCodecCreateEncoder(pcore, pencoder);
		}
	}
	/// <summary>
	/// Adds this codec instance to builtin instances within the Blend2D library.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The status code returned by the <see cref="blImageCodecAddToBuiltIn"/> native procedure</returns>
	public static BLResult AddToBuiltins(this ref BLImageCodecCore core) {
		unsafe {
			fixed (BLImageCodecCore* pcore = &core)
				return blImageCodecAddToBuiltIn(pcore);
		}
	}
	/// <summary>
	/// Removes this codec instance from builtin instances within the Blend2D library.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The status code returned by the <see cref="blImageCodecAddToBuiltIn"/> native procedure</returns>
	public static BLResult RemoveFromBuiltins(this ref BLImageCodecCore core) {
		unsafe {
			fixed (BLImageCodecCore* pcore = &core)
				return blImageCodecRemoveFromBuiltIn(pcore);
		}
	}
	/// <summary>
	/// Populates an uninitialised <see cref="BLArrayCore"/> with <see cref="BLImageCodecCore"/>s
	/// built into the Blend2D library.
	/// <para/>
	/// This method initialises a <see cref="BLArrayCore"/>. Remember to <see cref="Destroy{T}"/>
	/// this instance and any instance held previously by <paramref name="core"/>.
	/// </summary>
	/// <param name="core">The struct to be initialised and populated</param>
	/// <returns>The status code returned by the <see cref="blImageCodecArrayInitBuiltInCodecs"/> native procedure</returns>
	public static BLResult PopulateWithBuiltinImageCodecs(this ref BLArrayCore core) {
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				return blImageCodecArrayInitBuiltInCodecs(pcore);
		}
	}
	#endregion imagecodec
	#region image
	/// <summary>
	/// Initialises a <paramref name="width"/> by <paramref name="height"/> image of
	/// <paramref name="format"/>
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="width">Width of the image</param>
	/// <param name="height">Height of the image</param>
	/// <param name="format">Colour format of the image</param>
	/// <returns>The status code returned by the <see cref="blImageCreate"/> native procedure</returns>
	public static BLResult Initialise(this ref BLImageCore core, UInt32 width, UInt32 height, BLFormat format) {
		core.Initialise();
		unsafe {
			fixed (BLImageCore* pcore = &core)
				return blImageCreate(pcore, width, height, format);
		}
	}
	/// <summary>
	/// Initialises an image read from <paramref name="filePath"/> using codecs within <paramref name="codecs"/>
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="filePath">Path to image file</param>
	/// <param name="codecs">Array of codecs</param>
	/// <returns>The status code returned by the <see cref="blImageReadFromFile"/> native procedure</returns>
	public static BLResult Initialise(this ref BLImageCore core, String filePath, ref BLArrayCore codecs) {
		core.Initialise();
		unsafe {
			fixed (BLImageCore* pcore = &core)
			fixed (BLArrayCore* pcodecs = &codecs)
				return blImageReadFromFile(pcore, filePath, pcodecs);
		}
	}
	/// <summary>
	/// Initialises an image read from <paramref name="filePath"/> using builtin codecs
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="filePath">Path to image file</param>
	/// <returns>The status code returned by the <see cref="blImageReadFromFile"/> native procedure</returns>
	public static BLResult Initialise(this ref BLImageCore core, String filePath) {
		core.Initialise();
		unsafe {
			fixed (BLImageCore* pcore = &core)
				return blImageReadFromFile(pcore, filePath, null);
		}
	}
	/// <summary>
	/// Initialises an image read from <paramref name="inputStream"/> using codecs within <paramref name="codecs"/>
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="inputStream">Readable stream of an image</param>
	/// <param name="codecs">Array of codecs</param>
	/// <returns>
	/// The status code returned by the <see cref="blImageReadFromData"/> native procedure
	/// or <see cref="BLResult.BL_ERROR_INVALID_HANDLE"/> if <paramref name="inputStream"/>
	/// can't be read.
	/// </returns>
	public static BLResult Initialise(this ref BLImageCore core, Stream inputStream, ref BLArrayCore codecs) {
		if (!inputStream.CanRead)
			return BLResult.BL_ERROR_INVALID_HANDLE;
		core.Initialise();
		Byte[] data = new Byte[inputStream.Length];
		inputStream.Read(data);
		unsafe {
			fixed (BLImageCore* pcore = &core)
			fixed (Byte* pdata = data)
			fixed (BLArrayCore* pcodecs = &codecs)
				return blImageReadFromData(pcore, pdata, (IntPtr) data.Length, pcodecs);
		}
	}
	/// <summary>
	/// Initialises an image read from <paramref name="inputStream"/> using builtin codecs
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="inputStream">Readable stream of an image</param>
	/// <returns>
	/// The status code returned by the <see cref="blImageReadFromData"/> native procedure
	/// or <see cref="BLResult.BL_ERROR_INVALID_HANDLE"/> if <paramref name="inputStream"/>
	/// can't be read.
	/// </returns>
	public static BLResult Initialise(this ref BLImageCore core, Stream inputStream) {
		if (!inputStream.CanRead)
			return BLResult.BL_ERROR_INVALID_HANDLE;
		core.Initialise();
		Byte[] data = new Byte[inputStream.Length];
		inputStream.Read(data);
		unsafe {
			fixed (BLImageCore* pcore = &core)
			fixed (Byte* pdata = data)
				return blImageReadFromData(pcore, pdata, (IntPtr) data.Length, null);
		}
	}
	/// <summary>
	/// Converts the image's colour format
	/// </summary>
	/// <param name="core">The struct to be initialised</param>
	/// <param name="format">Output colour format of the image</param>
	/// <returns>The status code returned by the <see cref="blImageConvert"/> native procedure</returns>
	public static BLResult Convert(this ref BLImageCore core, BLFormat format) {
		unsafe {
			fixed (BLImageCore* pcore = &core)
				return blImageConvert(pcore, format);
		}
	}
	/// <summary>
	/// Scales the image at <paramref name="source"/> to <paramref name="width"/> by <paramref name="height"/>
	/// dimensions using <paramref name="filter"/> image scaling filter and stores it within <paramref name="core"/>
	/// </summary>
	/// <param name="core">Scaling destination</param>
	/// <param name="source">Scaling source</param>
	/// <param name="width">Target width</param>
	/// <param name="height">Target height</param>
	/// <param name="filter">Scaling strategy</param>
	/// <returns>The status code returned by the <see cref="blImageScale"/> native procedure</returns>
	public static BLResult Scale(this ref BLImageCore core, ref BLImageCore source, Int32 width, Int32 height, BLImageScaleFilter filter) {
		unsafe {
			BLSizeI* size = stackalloc BLSizeI[1];
			size->w = width;
			size->h = height;
			fixed (BLImageCore* pcore = &core)
			fixed (BLImageCore* psource = &source)
				return blImageScale(pcore, psource, size, filter);
		}
	}
	/// <summary>
	/// Outputs the image to <paramref name="filePath"/> using <paramref name="codec"/>
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <param name="filePath">Output path</param>
	/// <param name="codec">Image format to use</param>
	/// <returns>The status code returned by <see cref="blImageWriteToFile"/> native procedure</returns>
	public static BLResult WriteToFile(this ref BLImageCore core, String filePath, ref BLImageCodecCore codec) {
		unsafe {
			fixed (BLImageCore* pcore = &core)
			fixed (BLImageCodecCore* pcodec = &codec)
				return blImageWriteToFile(pcore, filePath, pcodec);
		}
	}
	/// <summary>
	/// Outputs the image to <paramref name="filePath"/> using a builtin codec that corrosponds to the
	/// file extension specified in <paramref name="filePath"/>
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <param name="filePath">Output path</param>
	/// <returns>The status code returned by <see cref="blImageWriteToFile"/> native procedure</returns>
	public static BLResult WriteToFile(this ref BLImageCore core, String filePath) {
		unsafe {
			fixed (BLImageCore* pcore = &core)
				return blImageWriteToFile(pcore, filePath, null);
		}
	}
	/// <summary>
	/// Outputs the image in the format specified by <paramref name="codec"/>
	/// in form of a <see cref="MemoryStream"/> which can be used with the rest
	/// of <see cref="System.IO"/> machinery.
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <param name="codec">Image format to use</param>
	/// <returns>A <see cref="MemoryStream"/> or null if the inners fail</returns>
	public static MemoryStream? GetOutputStream(this ref BLImageCore core, ref BLImageCodecCore codec) {
		using Array<Byte> bytes = [];
		BLResult err;
		unsafe {
			fixed (BLImageCore* pcore = &core)
			fixed (BLImageCodecCore* pcodec = &codec)
			fixed (BLArrayCore* pbytes = &bytes.core)
				err = blImageWriteToData(pcore, pbytes, pcodec);
		}
		if (err != BLResult.BL_SUCCESS)
			return null;
		return new MemoryStream([.. bytes], false);
	}
	/// <summary>
	/// Gets the width of the image
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>Width</returns>
	public static UInt32 GetWidth(this ref BLImageCore core) {
		unsafe {
			BLImageData* pdata = stackalloc BLImageData[1];
			fixed (BLImageCore* pcore = &core)
				blImageGetData(pcore, pdata);
			return (UInt32) pdata->size.w;
		}
	}
	/// <summary>
	/// Gets the height of the image
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>Height</returns>
	public static UInt32 GetHeight(this ref BLImageCore core) {
		unsafe {
			BLImageData* pdata = stackalloc BLImageData[1];
			fixed (BLImageCore* pcore = &core)
				blImageGetData(pcore, pdata);
			return (UInt32) pdata->size.h;
		}
	}
	/// <summary>
	/// Gets the <see cref="BLFormat"/> of the image
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>Pixel format</returns>
	public static BLFormat GetFormat(this ref BLImageCore core) {
		unsafe {
			BLImageData* pdata = stackalloc BLImageData[1];
			fixed (BLImageCore* pcore = &core)
				blImageGetData(pcore, pdata);
			return pdata->format;
		}
	}
	#endregion image
	#region context
	/// <summary>
	/// Flushes drawing calls in the <paramref name="core"/> command queue
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <param name="flag">Asynchrony</param>
	/// <returns>The status code returned by <see cref="blContextFlush"/> native procedure</returns>
	public static BLResult Flush(this ref BLContextCore core, BLContextFlushFlags flag = BLContextFlushFlags.BL_CONTEXT_FLUSH_NO_FLAGS) {
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextFlush(pcore, flag);
		}
	}
	/// <summary>
	/// Flushes drawing queue, detaches from the rendering target, releases resources and resets <paramref name="core"/> to null instance
	/// </summary>
	/// <param name="core">The struct holding the object</param>
	/// <returns>The status code returned by <see cref="blContextEnd"/> native procedure</returns>
	public static BLResult End(this ref BLContextCore core) {
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextEnd(pcore);
		}
	}
	#endregion context
	#region pixelconverter
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
			fixed (BLFormatInfo* dst = &destination)
			fixed (BLFormatInfo* src = &source)
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
	#endregion pixelconverter
	#region random
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
	#endregion random
	#region runtimescope
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
	#endregion runtimescope
	#region format
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
	#endregion format
	#region runtime
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
	#endregion runtime
}

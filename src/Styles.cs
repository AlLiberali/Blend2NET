using System;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <inheritdoc/>
public abstract class Style : BlendObject<BLVarCore> {
	private protected Style() {
	}
}
/// <summary>
/// Mono-colour styling
/// </summary>
public class Colour : Style {
	/// <summary>
	/// Constructs a new colour instance with the specified characteristics
	/// </summary>
	/// <param name="r">Red channel value</param>
	/// <param name="g">Green channel value</param>
	/// <param name="b">Blue channel value</param>
	/// <param name="a">Alpha channel value</param>
	public Colour(Single r, Single g, Single b, Single a = 1.0f) : this(new BLRgba() { r = r, g = g, b = b, a = a }) {
	}
	/// <summary>
	/// Constructs a new colour instance with the specified characteristics
	/// </summary>
	/// <param name="rgba">Combined ARGB primitive; Big endian.</param>
	public Colour(BLRgba rgba) {
		unsafe {
			fixed (BLVarCore* pcore = &core)
				blVarInitRgba(pcore, &rgba);
		}
	}
	/// <inheritdoc cref="Colour(Single, Single, Single, Single)"/>
	public Colour(Byte r, Byte g, Byte b, Byte a = Byte.MaxValue) : this(((UInt32) a << 0x18) | ((UInt32) r << 0x10) | ((UInt32) g << 0x8) | b) {
	}
	/// <inheritdoc cref="Colour(BLRgba)"/>
	public Colour(BLRgba32 rgba) : this(rgba.value) {
	}
	/// <inheritdoc cref="Colour(BLRgba)"/>
	public Colour(UInt32 rgba) {
		unsafe {
			fixed (BLVarCore* pcore = &core)
				blVarInitRgba32(pcore, rgba);
		}
	}
	/// <inheritdoc cref="Colour(Single, Single, Single, Single)"/>
	public Colour(UInt16 r, UInt16 g, UInt16 b, UInt16 a = UInt16.MaxValue) : this(((UInt64) a << 0x30) | ((UInt64) r << 0x20) | ((UInt64) g << 0x10) | b) {
	}
	/// <inheritdoc cref="Colour(BLRgba)"/>
	public Colour(BLRgba64 rgba) : this(rgba.value) {
	}
	/// <inheritdoc cref="Colour(BLRgba)"/>
	public Colour(UInt64 rgba) {
		unsafe {
			fixed (BLVarCore* pcore = &core)
				blVarInitRgba64(pcore, rgba);
		}
	}
	/// <summary>
	/// Blend2D primitive representation
	/// </summary>
	/// <returns>Primitive struct</returns>
	public BLRgba64 ToBLRgba64() {
		BLRgba64 ret = default;
		unsafe {
			fixed (BLVarCore* pcore = &core)
				blVarToRgba64(pcore, &ret.value);
		}
		return ret;
	}
	/// <inheritdoc cref="ToBLRgba64"/>
	public BLRgba32 ToBLRgba32() {
		BLRgba32 ret = default;
		unsafe {
			fixed (BLVarCore* pcore = &core)
				blVarToRgba32(pcore, &ret.value);
		}
		return ret;
	}
	/// <inheritdoc cref="ToBLRgba64"/>
	public BLRgba ToBLRgba() {
		BLRgba ret = default;
		unsafe {
			fixed (BLVarCore* pcore = &core)
				blVarToRgba(pcore, &ret);
		}
		return ret;
	}
}
/// <summary>
/// Convenience RGBA32 colour values
/// </summary>
public static class ColourCodes {
#pragma warning disable CS1591
	public static readonly UInt32 Liberal = 0xFF_FC_AA_17;
	public static readonly UInt32 BritishBlue = 0xFF_00_24_7D;
	public static readonly UInt32 BritishRed = 0xFF_CF_14_2B;
	public static readonly UInt32 MicrosoftRed = 0xFF_F1_4F_21;
	public static readonly UInt32 MicrosoftGreen = 0xFF_7E_B9_00;
	public static readonly UInt32 MicrosoftBlue = 0xFF_00_A3_EE;
	public static readonly UInt32 MicrosoftYellow = 0xFF_FE_B8_00;
	public static readonly UInt32 MicrosoftGrey = 0xFF_72_72_72;
	public static readonly UInt32 MicrosoftNet = 0xFF_51_2B_D4;
	public static readonly UInt32 White = 0xFF_FF_FF_FF;
	public static readonly UInt32 Grey = 0xFF_80_80_80;
	public static readonly UInt32 Black = 0xFF_00_00_00;
	public static readonly UInt32 Transparent;
	public static readonly UInt32 Red = 0xFF_FF_00_00;
	public static readonly UInt32 Green = 0xFF_00_FF_00;
	public static readonly UInt32 Blue = 0xFF_00_00_FF;
	public static readonly UInt32 Yellow = Red | Green;
	public static readonly UInt32 Magenta = Red | Blue;
	public static readonly UInt32 Cyan = Blue | Green;
	public static readonly UInt32 Salmon = Red | Grey;
	public static readonly UInt32 GamerDrinkGreen = Green | Grey;
	public static readonly UInt32 Lavender = Blue | Grey;
	public static readonly UInt32 Custard = Yellow | Grey;
	public static readonly UInt32 Pink = Magenta | Grey;
	public static readonly UInt32 Aqua = Cyan | Grey;
	public static UInt32 Random {
		get {
			BLRandom random = default;
			random.Seed((UInt64) DateTime.Now.Ticks);
			return random.NextUInt32() | 0xFF_00_00_00;
		}
	}
#pragma warning restore CS1591
}
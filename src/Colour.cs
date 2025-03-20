using System;
using System.Runtime.InteropServices;

namespace AlLiberali.Blend2NET.Colour;

#pragma warning disable IDE0079
#pragma warning disable CA1051
#pragma warning disable CA1069
#pragma warning disable CA1707

/// <summary>
/// 32-bit RGBA color (8-bit per component) stored as `0xAARRGGBB`.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLRgba32 {
	/// <summary>
	/// Packed 32-bit RGBA value.
	/// </summary>
	public UInt32 value;
}
/// <summary>
/// 64-bit RGBA color (16-bit per component) stored as `0xAAAARRRRGGGGBBBB`.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLRgba64 {
	/// <summary>
	/// Packed 64-bit RGBA value.
	/// </summary>
	public UInt64 value;
}
/// <summary>
/// 128-bit RGBA color stored as 4 32-bit floating point values in [RGBA] order.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLRgba {
	/// <summary>
	/// Red component.
	/// </summary>
	Single r;
	/// <summary>
	/// Green component.
	/// </summary>
	Single g;
	/// <summary>
	/// Blur component.
	/// </summary>
	Single b;
	/// <summary>
	/// Alpha component.
	/// </summary>
	Single a;
}
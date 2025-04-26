using System;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;
#pragma warning disable CS1591
/// <summary>
/// Smooth transitioning style, along an axis, betwixt colour-position stops
/// </summary>
public abstract class Gradient : Style {
	/// <summary>
	/// The extension behaviour when a gradient reaches its limits
	/// </summary>
	public BLExtendMode ExtendMode {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetExtendMode((BLGradientCore*) pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetExtendMode((BLGradientCore*) pcore, value);
			}
		}
	}
	/// <summary>
	/// How many stops does this gradient have
	/// </summary>
	public Int32 StopCount {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return (Int32) blGradientGetSize((BLGradientCore*) pcore);
			}
		}
	}
	/// <summary>
	/// Whether this gradient has any stops
	/// </summary>
	public Boolean Empty => StopCount == 0;
	public Double X0 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 0);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 0, value);
			}
		}
	}
	public Double Y0 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 1);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 1, value);
			}
		}
	}
	private protected Gradient() {
	}
	/// <summary>
	/// Adds a stop to the gradient
	/// </summary>
	/// <param name="offset">Where along the gradient axis</param>
	/// <param name="rgba">Colour of the stop</param>
	/// <returns>The status code returned by the <see cref="blGradientAddStopRgba64(BLGradientCore*, Double, UInt64)"/> native procedure</returns>
	public BLResult TryAddStop(Double offset, UInt64 rgba) {
		unsafe {
			fixed (void* pcore = &core)
				return blGradientAddStopRgba64((BLGradientCore*) pcore, offset, rgba);
		}
	}
	/// <inheritdoc cref="TryAddStop(Double, UInt64)"/>
	public BLResult TryAddStop(Double offset, UInt32 rgba) {
		unsafe {
			fixed (void* pcore = &core)
				return blGradientAddStopRgba32((BLGradientCore*) pcore, offset, rgba);
		}
	}
	/// <inheritdoc cref="TryAddStop(Double, UInt64)"/>
	public BLResult TryAddStop(Double offset, Colour rgba) => TryAddStop(offset, rgba.ToBLRgba64().value);
	/// <summary>
	/// Adds a stop to the gradient
	/// </summary>
	/// <param name="stop">The stop</param>
	/// <returns>The status code returned by the <see cref="blGradientAddStopRgba64(BLGradientCore*, Double, UInt64)"/> native procedure</returns>
	public BLResult TryAddStop(BLGradientStop stop) => TryAddStop(stop.offset, stop.rgba.value);

	public BLResult TryGetStop(Double offset, out BLGradientStop result) {
		result = default;
		unsafe {
			BLGradientStop* pstops;
			fixed (void* pcore = &core)
				pstops = blGradientGetStops((BLGradientCore*) pcore);
			for (Int32 i = 0; i < StopCount; i++)
				if (pstops[i].offset == offset) {
					result = pstops[i];
					return BLResult.BL_SUCCESS;
				}
		}
		return BLResult.StopNotFound;
	}

	public BLResult TryGetStop(Int32 index, out BLGradientStop result) {
		result = default;
		if (index < 0 || index >= StopCount)
			return BLResult.IndexOutOfRange;
		unsafe {
			BLGradientStop* pstops;
			fixed (void* pcore = &core)
				pstops = blGradientGetStops((BLGradientCore*) pcore);
			result = pstops[index];
			return BLResult.BL_SUCCESS;
		}
	}
}
public class LinearGradient : Gradient {
	public Double X1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 2);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 2, value);
			}
		}
	}
	public Double Y1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 3);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 3, value);
			}
		}
	}
}
public class RadialGradient : Gradient {
	public Double X1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 2);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 2, value);
			}
		}
	}
	public Double Y1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 3);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 3, value);
			}
		}
	}
	public Double R0 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 4);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 4, value);
			}
		}
	}
	public Double R1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 5);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 5, value);
			}
		}
	}
}
public class ConicalGradient : Gradient {
	public Double Angle {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 2);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 2, value);
			}
		}
	}
	public Double Repeat {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) 3);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) 3, value);
			}
		}
	}
}
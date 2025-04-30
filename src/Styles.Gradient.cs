using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Smooth transitioning style, along an axis, betwixt colour-position stops
/// </summary>
[SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix")]
public abstract class Gradient : Style, ITransformable, IDictionary<Double, BLRgba64> {
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
	/// <summary>
	/// X-axis element for the starting position of the gradient
	/// </summary>
	public Double X0 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_X0);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_X0, value);
			}
		}
	}
	/// <summary>
	/// Y-axis element for the starting position of the gradient
	/// </summary>
	public Double Y0 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_Y0);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_Y0, value);
			}
		}
	}
	/// <inheritdoc/>
	public ICollection<Double> Keys => this.Select(x => x.Key).ToArray();
	/// <inheritdoc/>
	public ICollection<BLRgba64> Values => this.Select(x => x.Value).ToArray();
	/// <inheritdoc/>
	public Int32 Count {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (void* pcore = &core)
					return (Int32) blGradientGetSize((BLGradientCore*) pcore);
			}
		}
	}
	/// <inheritdoc/>
	public Boolean IsReadOnly => false;
	/// <inheritdoc/>
	public BLRgba64 this[Double key] {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLRgba64 ret;
			if (!TryGetValue(key, out ret))
				throw new KeyNotFoundException();
			return ret;
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			if (!ContainsKey(key)) {
				Add(key, value, true);
				return;
			}
			unsafe {
				fixed (void* pcore = &core) {
					IntPtr index = blGradientIndexOfStop((BLGradientCore*) pcore, key);
					blGradientReplaceStopRgba64((BLGradientCore*) pcore, index, key, value);
				}
			}
		}
	}
	private protected Gradient(BLGradientType t) {
		unsafe {
			fixed (void* pcore = &core) {
				blGradientInit((BLGradientCore*) pcore);
				blGradientSetType((BLGradientCore*) pcore, t);
			}
		}
	}
	/// <inheritdoc/>
	public BLResult Transform(BLMatrix2D mat) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLVarCore* pcore = &core)
				return blGradientApplyTransformOp((BLGradientCore*) pcore, BLTransformOp.BL_TRANSFORM_OP_TRANSFORM, &mat);
		}
	}
	/// <inheritdoc/>
	public BLResult PostTransform(BLMatrix2D mat) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLVarCore* pcore = &core)
				return blGradientApplyTransformOp((BLGradientCore*) pcore, BLTransformOp.BL_TRANSFORM_OP_POST_TRANSFORM, &mat);
		}
	}
	/// <inheritdoc/>
	public void ResetTransform() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLMatrix2D mat = BLMatrix2D.Identity;
		unsafe {
			fixed (BLVarCore* pcore = &core)
				blGradientApplyTransformOp((BLGradientCore*) pcore, BLTransformOp.BL_TRANSFORM_OP_ASSIGN, &mat);
		}
	}
	/// <inheritdoc/>
	/// <exception cref="ArgumentOutOfRangeException">When <paramref name="key"/> isn't within [0, 1] range</exception>
	public void Add(Double key, BLRgba64 value) => Add(key, value, false);
	private void Add(Double key, BLRgba64 value, Boolean skipCheck) {
		if (!skipCheck && ContainsKey(key))
			throw new ArgumentException("An stop with this offset already exists", nameof(key));
		if (!(0 <= key && key <= 1))
			throw new ArgumentOutOfRangeException(nameof(key));
		unsafe {
			fixed (void* pcore = &core)
				blGradientAddStopRgba64((BLGradientCore*) pcore, key, value);
		}
	}
	/// <inheritdoc/>
	public Boolean ContainsKey(Double key) => this.Any(x => x.Key == key);
	/// <inheritdoc/>
	public Boolean Remove(Double key) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (void* pcore = &core)
				return blGradientRemoveStopByOffset((BLGradientCore*) pcore, key, true) == BLResult.BL_SUCCESS;
		}
	}
	/// <inheritdoc/>
	public Boolean TryGetValue(Double key, out BLRgba64 value) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		value = default;
		unsafe {
			BLGradientStop* pdata = default;
			fixed (void* pcore = &core)
				pdata = blGradientGetStops((BLGradientCore*) pcore);
			ObjectDisposedException.ThrowIf(pdata == null, this);
			ReadOnlySpan<BLGradientStop> stops = new(pdata, Count);
			foreach (BLGradientStop stop in stops)
				if (stop.offset == key) {
					value = stop.rgba;
					return true;
				}
		}
		return false;
	}
	/// <inheritdoc/>
	public void Add(KeyValuePair<Double, BLRgba64> item) => Add(item.Key, item.Value);
	/// <inheritdoc/>
	public void Clear() {
		unsafe {
			fixed (void* pcore = &core)
				blGradientResetStops((BLGradientCore*) pcore);
		}
	}
	/// <inheritdoc/>
	public Boolean Contains(KeyValuePair<Double, BLRgba64> item) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		return ContainsKey(item.Key) && this[item.Key] == item.Value;
	}
	/// <inheritdoc/>
	public void CopyTo(KeyValuePair<Double, BLRgba64>[] array, Int32 arrayIndex) {
		if (array is null)
			throw new ArgumentNullException(nameof(array));
		if (arrayIndex < 0)
			throw new ArgumentOutOfRangeException(nameof(arrayIndex));
		if (array.Length - arrayIndex < Count)
			throw new ArgumentException("Gradient's stop collection larger than the space passed to this method for it to be copied into", nameof(arrayIndex));
		unsafe {
			BLGradientStop* pdata = default;
			fixed (void* pcore = &core)
				pdata = blGradientGetStops((BLGradientCore*) pcore);
			ObjectDisposedException.ThrowIf(pdata == null, this);
			var stops = new ReadOnlySpan<BLGradientStop>(pdata, Count);
			for (Int32 i = arrayIndex; i < array.Length; i++)
				array[i] = new(stops[i - arrayIndex].offset, stops[i - arrayIndex].rgba);
		}
	}
	/// <inheritdoc/>
	public Boolean Remove(KeyValuePair<Double, BLRgba64> item) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLRgba64 v;
		if (!TryGetValue(item.Key, out v))
			return false;
		if (v != item.Value)
			return false;
		return Remove(item.Key);
	}
	/// <inheritdoc/>
	public IEnumerator<KeyValuePair<Double, BLRgba64>> GetEnumerator() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLGradientStop[] stops = new BLGradientStop[Count];
		unsafe {
			BLGradientStop* pdata = default;
			fixed (void* pcore = &core)
				pdata = blGradientGetStops((BLGradientCore*) pcore);
			ObjectDisposedException.ThrowIf(pdata == null, this);
			new ReadOnlySpan<BLGradientStop>(pdata, Count).CopyTo(stops);
		}
		foreach (BLGradientStop stop in stops)
			yield return new(stop.offset, stop.rgba);
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
/// <summary>
/// Linear transition of colours between points
/// (<see cref="Gradient.X0"/>, <see cref="Gradient.Y0"/>) and
/// (<see cref="X1"/>, <see cref="Y1"/>)
/// </summary>
public class LinearGradient : Gradient {
	/// <summary>
	/// Linear transition of colours between points
	/// (<see cref="Gradient.X0"/>, <see cref="Gradient.Y0"/>) and
	/// (<see cref="X1"/>, <see cref="Y1"/>)
	/// </summary>
	public LinearGradient() : base(BLGradientType.BL_GRADIENT_TYPE_LINEAR) {
	}
	/// <summary>
	/// X-axis element for the ending position of the gradient
	/// </summary>
	public Double X1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_X1);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_X1, value);
			}
		}
	}
	/// <summary>
	/// Y-axis element for the ending position of the gradient
	/// </summary>
	public Double Y1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_Y1);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_Y1, value);
			}
		}
	}
}
/// <summary>
/// Radial transition of colours between the central point
/// (<see cref="Gradient.X0"/>, <see cref="Gradient.Y0"/>) and
/// and the focal point (<see cref="X1"/>, <see cref="Y1"/>)
/// </summary>
public class RadialGradient : Gradient {
	/// <summary>
	/// Radial transition of colours between the central point
	/// (<see cref="Gradient.X0"/>, <see cref="Gradient.Y0"/>) and
	/// and the focal point (<see cref="X1"/>, <see cref="Y1"/>)
	/// </summary>
	public RadialGradient() : base(BLGradientType.BL_GRADIENT_TYPE_RADIAL) {
	}
	/// <summary>
	/// X-axis element for the focal point of the gradient
	/// </summary>
	public Double X1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_X1);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_X1, value);
			}
		}
	}
	/// <summary>
	/// Y-axis element for the focal point of the gradient
	/// </summary>
	public Double Y1 {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_Y1);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_COMMON_Y1, value);
			}
		}
	}
	/// <summary>
	/// Centre point radius
	/// </summary>
	public Double CentreRadius {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_RADIAL_R0);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_RADIAL_R0, value);
			}
		}
	}
	/// <summary>
	/// Focal point radius
	/// </summary>
	public Double FocalRadius {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_RADIAL_R1);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_RADIAL_R1, value);
			}
		}
	}
}
/// <summary>
/// Conical transition of colours around the central point at
/// (<see cref="Gradient.X0"/>, <see cref="Gradient.Y0"/>)
/// such that it starts and ends on the line at clockwise <see cref="Angle"/>
/// with respect to the "eastwards" axis out of the central point;
/// Repeating <see cref="Repeat"/> times, clockwise.
/// </summary>
public class ConicalGradient : Gradient {
	/// <summary>
	/// Conical transition of colours around the central point at
	/// (<see cref="Gradient.X0"/>, <see cref="Gradient.Y0"/>)
	/// such that it starts and ends on the line at clockwise <see cref="Angle"/>
	/// with respect to the "eastwards" axis out of the central point;
	/// Repeating <see cref="Repeat"/> times, clockwise.
	/// </summary>
	public ConicalGradient() : base(BLGradientType.BL_GRADIENT_TYPE_CONIC) {
		Repeat = 1.0;
	}
	/// <summary>
	/// Starting angle with respect to the "eastwards" axis out of central point
	/// </summary>
	public Double Angle {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_CONIC_ANGLE);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_CONIC_ANGLE, value);
			}
		}
	}
	/// <summary>
	/// How many times the gradient is to be repeated when circling around the central point
	/// </summary>
	public Double Repeat {
		get {
			unsafe {
				fixed (void* pcore = &core)
					return blGradientGetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_CONIC_REPEAT);
			}
		}
		set {
			unsafe {
				fixed (void* pcore = &core)
					blGradientSetValue((BLGradientCore*) pcore, (IntPtr) BLGradientValue.BL_GRADIENT_VALUE_CONIC_REPEAT, value);
			}
		}
	}
}
using System;
using System.Collections.Generic;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Where all the drawing happens
/// </summary>
public sealed class Context : BlendObject<BLContextCore> {
	private readonly SortedList<UInt64, BLContextCookie> cookieStore = [];
	/// <summary>
	/// Width of the context in abstract units. Pixels in case of an image
	/// </summary>
	public Double Width {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLSize size;
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextGetTargetSize(pcore, &size);
			}
			return size.w;
		}
	}
	/// <summary>
	/// Height of the context in abstract units. Pixels in case of an image
	/// </summary>
	public Double Height {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLSize size;
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextGetTargetSize(pcore, &size);
			}
			return size.h;
		}
	}
	/// <summary>
	/// Global Alpha channel, default for all relevant operations, itself defaults to 1.0
	/// </summary>
	public Double Alpha {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return blContextGetGlobalAlpha(pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetGlobalAlpha(pcore, value);
			}
		}
	}
	/// <summary>
	/// Global composition operator, defaults to <see cref="BLCompOp.BL_COMP_OP_SRC_OVER"/>
	/// </summary>
	public BLCompOp CompositionOperator {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return blContextGetCompOp(pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetCompOp(pcore, value);
			}
		}
	}
	/// <summary>
	/// Quality settings for the renderer
	/// </summary>
	public BLRenderingQuality RenderingQuality {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return (BLRenderingQuality) blContextGetHint(pcore, BLContextHint.BL_CONTEXT_HINT_RENDERING_QUALITY);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetHint(pcore, BLContextHint.BL_CONTEXT_HINT_RENDERING_QUALITY, (UInt32) value);
			}
		}
	}
	/// <summary>
	/// Algorithm for gradient calculations
	/// </summary>
	public BLGradientQuality GradientQuality {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return (BLGradientQuality) blContextGetHint(pcore, BLContextHint.BL_CONTEXT_HINT_GRADIENT_QUALITY);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetHint(pcore, BLContextHint.BL_CONTEXT_HINT_GRADIENT_QUALITY, (UInt32) value);
			}
		}
	}
	/// <summary>
	/// Algorithm for pattern calculations
	/// </summary>
	public BLPatternQuality PatternQuality {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return (BLPatternQuality) blContextGetHint(pcore, BLContextHint.BL_CONTEXT_HINT_PATTERN_QUALITY);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetHint(pcore, BLContextHint.BL_CONTEXT_HINT_PATTERN_QUALITY, (UInt32) value);
			}
		}
	}
	/// <summary>
	/// Curve flattening strategy
	/// </summary>
	private BLFlattenMode FlatteningMode {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
	}
	/// <summary>
	/// Curve offsetting strategy
	/// </summary>
	private BLOffsetMode OffsettingMode {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
	}
	/// <summary>
	/// Curve flattening tolerance
	/// </summary>
	private Double FlatteningTolerance {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
	}
	/// <summary>
	/// Cubic to quadratic curve simplification tolerance
	/// </summary>
	private Double SimplificationTolerance {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
	}
	/// <summary>
	/// Parameter that affects offsetting behaviour. The effect depends on <see cref="BLOffsetMode"/> set for <see cref="OffsettingMode"/>
	/// </summary>
	private Double OffsettingParameter {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			throw new NotImplementedException();
		}
	}
	/// <summary>
	/// Meta matrix is a core transformation matrix that is normally
	/// not changed by transformations applied to the context.
	/// Instead it acts as a secondary matrix used to create the
	/// final transformation matrix from meta and user matrices.
	/// <para/>
	/// Meta matrix can be used to scale the whole context for
	/// HI-DPI rendering or to change the orientation of the
	/// image being rendered, however, the number of use-cases is unlimited.
	/// </summary>
	public BLMatrix2D MetaTransform {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLMatrix2D ret;
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextGetMetaTransform(pcore, &ret);
			}
			return ret;
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLMatrix2D temp = UserTransform;
			UserTransform = value;
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextUserToMeta(pcore);
			}
			UserTransform = temp;
		}
	}
	/// <summary>
	/// User matrix contains all the transformations that happens to rendering context unless reset through this property
	/// </summary>
	public BLMatrix2D UserTransform {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLMatrix2D ret;
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextGetUserTransform(pcore, &ret);
			}
			return ret;
		}
		set {
			Transform(value, BLTransformOp.BL_TRANSFORM_OP_ASSIGN);
		}
	}
	/// <summary>
	/// <see cref="UserTransform"/> and <see cref="MetaTransform"/> combined;
	/// Thus the effective transformation matrix
	/// </summary>
	public BLMatrix2D FinalTransform {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLMatrix2D ret;
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextGetFinalTransform(pcore, &ret);
			}
			return ret;
		}
	}
	private BLResult Transform(BLMatrix2D mat, BLTransformOp op) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextApplyTransformOp(pcore, op, &mat);
		}
	}
	public BLResult Transform(BLMatrix2D mat) => Transform(mat, BLTransformOp.BL_TRANSFORM_OP_TRANSFORM);
	public BLResult Translate(Double dx, Double dy) => Transform(new BLMatrix2D().Translation(dx, dy), BLTransformOp.BL_TRANSFORM_OP_TRANSLATE);
	public BLResult Scale(Double factor) => Transform(new BLMatrix2D().Scaling(factor, factor), BLTransformOp.BL_TRANSFORM_OP_SCALE);
	public BLResult Scale(Double xf, Double yf) => Transform(new BLMatrix2D().Scaling(xf, yf), BLTransformOp.BL_TRANSFORM_OP_SCALE);
	public BLResult Skew(Double xf, Double yf) => Transform(new BLMatrix2D().Skewing(xf, yf), BLTransformOp.BL_TRANSFORM_OP_SKEW);
	public BLResult Rotate(Double angle) => Transform(new BLMatrix2D().Rotation(angle, 0, 0), BLTransformOp.BL_TRANSFORM_OP_ROTATE);
	public BLResult Rotate(Double angle, Double xc, Double yc) => Transform(new BLMatrix2D().Rotation(angle, xc, yc), BLTransformOp.BL_TRANSFORM_OP_ROTATE_PT);
	public BLResult PostTransform(BLMatrix2D mat) => Transform(mat, BLTransformOp.BL_TRANSFORM_OP_POST_TRANSFORM);
	public BLResult PostTranslate(Double dx, Double dy) => Transform(new BLMatrix2D().Translation(dx, dy), BLTransformOp.BL_TRANSFORM_OP_POST_TRANSLATE);
	public BLResult PostScale(Double factor) => Transform(new BLMatrix2D().Scaling(factor, factor), BLTransformOp.BL_TRANSFORM_OP_POST_SCALE);
	public BLResult PostScale(Double xf, Double yf) => Transform(new BLMatrix2D().Scaling(xf, yf), BLTransformOp.BL_TRANSFORM_OP_POST_SCALE);
	public BLResult PostSkew(Double xf, Double yf) => Transform(new BLMatrix2D().Skewing(xf, yf), BLTransformOp.BL_TRANSFORM_OP_POST_SKEW);
	public BLResult PostRotate(Double angle) => Transform(new BLMatrix2D().Rotation(angle, 0, 0), BLTransformOp.BL_TRANSFORM_OP_POST_ROTATE);
	public BLResult PostRotate(Double angle, Double xc, Double yc) => Transform(new BLMatrix2D().Rotation(angle, xc, yc), BLTransformOp.BL_TRANSFORM_OP_POST_ROTATE_PT);
	public BLResult Clip(BLRect rect) {
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextClipToRectD(pcore, &rect);
		}
	}
	/// <summary>
	/// Pushes the current state of the context into the <paramref name="cookieId"/> stack
	/// </summary>
	/// <param name="cookieId">Stack ID; 0 by default</param>
	/// <returns>The status code returned by <see cref="blContextSave"/> native procedure</returns>
	public BLResult Push(UInt64 cookieId = 0) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLContextCookie cookie;
		if (!cookieStore.TryGetValue(cookieId, out cookie))
			cookie.count = 0;
		BLResult ret;
		unsafe {
			fixed (BLContextCore* pcore = &core)
				ret = blContextSave(pcore, &cookie);
		}
		if (ret != BLResult.BL_SUCCESS)
			return ret;
		cookie.count++;
		cookieStore.Remove(cookieId);
		cookieStore.Add(cookieId, cookie);
		return ret;
	}
	/// <summary>
	/// Pops the last stored context state off the <paramref name="cookieId"/> stack
	/// </summary>
	/// <param name="cookieId">Stack ID</param>
	/// <returns>
	/// The status code returned by <see cref="blContextRestore"/> native procedure;
	/// Or <see cref="BLResult.NoSuchCookieError"/> if <paramref name="cookieId"/> stack doesn't exist
	/// </returns>
	public BLResult Pop(UInt64 cookieId = 0) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLContextCookie cookie;
		if (!cookieStore.TryGetValue(cookieId, out cookie))
			return BLResult.NoSuchCookieError;
		BLResult ret;
		unsafe {
			fixed (BLContextCore* pcore = &core)
				ret = blContextRestore(pcore, &cookie);
		}
		if (ret != BLResult.BL_SUCCESS)
			return ret;
		cookie.count--;
		cookieStore.Remove(cookieId);
		if (cookieStore.Count != 0)
			cookieStore.Add(cookieId, cookie);
		return ret;
	}
	/// <summary>
	/// Flushes the context command queue synchronously
	/// </summary>
	public BLResult Flush() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		return core.Flush(BLContextFlushFlags.BL_CONTEXT_FLUSH_SYNC);
	}
	/// <summary>
	/// Flushes the context command queue asynchronously.
	/// <para/>
	/// The asynchrony is done on the native side thus this method doesn't introduce
	/// colouring to the .NET side and just returns immediately. (Well as immediately as a method call)
	/// </summary>
	public BLResult FlushAsync() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		return core.Flush();
	}
	private protected override void Destroy() {
		core.End();
		base.Destroy();
	}
	/// <summary>
	/// Clears the entire context clean
	/// </summary>
	public BLResult Clear() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextClearAll(pcore);
		}
	}
	/// <summary>
	/// Clears the area specified clean
	/// </summary>
	/// <param name="rect">Coordinates and area to clear</param>
	public BLResult Clear(BLRectI rect) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextClearRectI(pcore, &rect);
		}
	}
	/// <inheritdoc cref="Clear(BLRectI)"/>
	public BLResult Clear(BLRect rect) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextClearRectD(pcore, &rect);
		}
	}
}
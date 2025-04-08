using System;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Where all the drawing happens
/// </summary>
public sealed class Context : BlendObject<BLContextCore> {
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
	/// Flushes the context command queue synchronously
	/// </summary>
	public void Flush() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		core.Flush(BLContextFlushFlags.BL_CONTEXT_FLUSH_SYNC);
	}
	/// <summary>
	/// Flushes the context command queue asynchronously.
	/// <para/>
	/// The asynchrony is done on the native side thus this method doesn't introduce
	/// colouring to the .NET side and just returns immediately. (Well as immediately as a method call)
	/// </summary>
	public void FlushAsync() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		core.Flush();
	}
	private protected override void Destroy() {
		core.End();
		base.Destroy();
	}
	/// <summary>
	/// Clears the entire context clean
	/// </summary>
	public void Clear() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				blContextClearAll(pcore);
		}
	}
	/// <summary>
	/// Clears the area specified clean
	/// </summary>
	/// <param name="rect">Coordinates and area to clear</param>
	public void Clear(BLRectI rect) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				blContextClearRectI(pcore, &rect);
		}
	}
	/// <inheritdoc cref="Clear(BLRectI)"/>
	public void Clear(BLRect rect) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				blContextClearRectD(pcore, &rect);
		}
	}
	/// <summary>
	/// Initiates a fluent chain that carries out a fill operation upon the context
	/// </summary>
	public IStyleSelector<ITransformSelector<IFillGeometrySelector>, IFillGeometrySelector> Fill() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		return new FillOperator(this);
	}
	/// <summary>
	/// Initiates a fluent chain that carries out a stroke operation upon the context
	/// </summary>
	public IStyleSelector<ITransformSelector<IStrokeGeometrySelector>, IStrokeGeometrySelector> Stroke() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		return new StrokeOperator(this);
	}
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public abstract class AbstractOperator {
		private protected readonly Context ctx;
		private protected BLVarCore style;
		private protected BLMatrix2D globalTransform;
		private protected AbstractOperator(Context ctx) {
			this.ctx = ctx;
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core) {
					fixed (BLMatrix2D* pmat = &globalTransform)
						blContextGetUserTransform(pcore, pmat);
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_RESET, null);
				}
			}
		}
		private protected void Reset() {
			unsafe {
				fixed (BLVarCore* pcore = &style)
					blVarDestroy(pcore);
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLMatrix2D* pmat = &globalTransform)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ASSIGN, pmat);
			}
		}
	}
	/// <summary>
	/// See <see cref="Fill"/>
	/// </summary>
	public sealed class FillOperator :
		AbstractOperator,
		IStyleSelector<ITransformSelector<IFillGeometrySelector>, IFillGeometrySelector>,
		ITransformSelector<IFillGeometrySelector>,
		IFillGeometrySelector {
		internal FillOperator(Context ctx) : base(ctx) {
		}
		#region FillStyle
		public ITransformSelector<IFillGeometrySelector> DefaultStyle() {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLVarCore* pvar = &style)
					blContextGetFillStyle(pcore, pvar);
			}
			return this;
		}
		public ITransformSelector<IFillGeometrySelector> SolidColour(BLRgba rgba) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
					blVarInitRgba(pcore, &rgba);
			}
			return this;
		}
		public ITransformSelector<IFillGeometrySelector> SolidColour(BLRgba32 rgba) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
					blVarInitRgba32(pcore, rgba.value);
			}
			return this;
		}
		public ITransformSelector<IFillGeometrySelector> SolidColour(BLRgba64 rgba) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
					blVarInitRgba64(pcore, rgba.value);
			}
			return this;
		}
		public ITransformSelector<IFillGeometrySelector> Gradient(ref BLGradientCore gradient) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
				fixed (BLGradientCore* pgrad = &gradient)
					blVarAssignWeak(pcore, pgrad);
			}
			return this;
		}
		public ITransformSelector<IFillGeometrySelector> Pattern(ref BLPatternCore pattern) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
				fixed (BLPatternCore* ppatt = &pattern)
					blVarAssignWeak(pcore, ppatt);
			}
			return this;
		}
		#endregion FillStyle
		#region FillTransform
		public IFillGeometrySelector DefaultTransform() {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLMatrix2D* pmat = &globalTransform)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ASSIGN, pmat);
			}
			return this;
		}
		public IFillGeometrySelector Translate(Double dx, Double dy) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetTranslation(pmat, dx, dy);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_TRANSLATE, pmat);
			}
			return this;
		}
		public IFillGeometrySelector Scale(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetScaling(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_SCALE, pmat);
			}
			return this;
		}
		public IFillGeometrySelector Skew(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetSkewing(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_SKEW, pmat);
			}
			return this;
		}
		public IFillGeometrySelector Rotate(Double angle) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ROTATE, &angle);
			}
			return this;
		}
		public IFillGeometrySelector Rotate(Double angle, Double x, Double y) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetRotation(pmat, angle, x, y);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ROTATE_PT, pmat);
			}
			return this;
		}
		public IFillGeometrySelector PostTranslate(Double dx, Double dy) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetTranslation(pmat, dx, dy);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_TRANSLATE, pmat);
			}
			return this;
		}
		public IFillGeometrySelector PostScale(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetScaling(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_SCALE, pmat);
			}
			return this;
		}
		public IFillGeometrySelector PostSkew(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetSkewing(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_SKEW, pmat);
			}
			return this;
		}
		public IFillGeometrySelector PostRotate(Double angle) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_ROTATE, &angle);
			}
			return this;
		}
		public IFillGeometrySelector PostRotate(Double angle, Double x, Double y) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetRotation(pmat, angle, x, y);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_ROTATE_PT, pmat);
			}
			return this;
		}
		#endregion FillTransform
		#region FillGeometry
		public void All() {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (void* pstyle = &style) {
					blContextFillAllExt(pcore, pstyle);
					blVarDestroy(pstyle);
				}
			}
		}
		public void Rectangle(BLRect rect) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLVarCore* pstyle = &style)
					blContextFillRectDExt(pcore, &rect, pstyle);
			}
		}
		public void Rectangle(BLRectI rect) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLVarCore* pstyle = &style)
					blContextFillRectIExt(pcore, &rect, pstyle);
			}
		}
		#endregion FillGeometry
	}
	/// <summary>
	/// See <see cref="Stroke"/>
	/// </summary>
	public sealed class StrokeOperator :
		AbstractOperator,
		IStyleSelector<ITransformSelector<IStrokeGeometrySelector>, IStrokeGeometrySelector>,
		ITransformSelector<IStrokeGeometrySelector>,
		IStrokeGeometrySelector {
		internal StrokeOperator(Context ctx) : base(ctx) {
		}
		#region StrokeStyle
		public ITransformSelector<IStrokeGeometrySelector> DefaultStyle() {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLVarCore* pvar = &style)
					blContextGetStrokeStyle(pcore, pvar);
			}
			return this;
		}
		public ITransformSelector<IStrokeGeometrySelector> SolidColour(BLRgba rgba) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
					blVarInitRgba(pcore, &rgba);
			}
			return this;
		}
		public ITransformSelector<IStrokeGeometrySelector> SolidColour(BLRgba32 rgba) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
					blVarInitRgba32(pcore, rgba.value);
			}
			return this;
		}
		public ITransformSelector<IStrokeGeometrySelector> SolidColour(BLRgba64 rgba) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
					blVarInitRgba64(pcore, rgba.value);
			}
			return this;
		}
		public ITransformSelector<IStrokeGeometrySelector> Gradient(ref BLGradientCore gradient) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
				fixed (BLGradientCore* pgrad = &gradient)
					blVarAssignWeak(pcore, pgrad);
			}
			return this;
		}
		public ITransformSelector<IStrokeGeometrySelector> Pattern(ref BLPatternCore pattern) {
			unsafe {
				fixed (BLVarCore* pcore = &style)
				fixed (BLPatternCore* ppatt = &pattern)
					blVarAssignWeak(pcore, ppatt);
			}
			return this;
		}
		#endregion StrokeStyle
		#region StrokeTransform
		public IStrokeGeometrySelector DefaultTransform() {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLMatrix2D* pmat = &globalTransform)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ASSIGN, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector Translate(Double dx, Double dy) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetTranslation(pmat, dx, dy);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_TRANSLATE, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector Scale(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetScaling(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_SCALE, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector Skew(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetSkewing(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_SKEW, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector Rotate(Double angle) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ROTATE, &angle);
			}
			return this;
		}
		public IStrokeGeometrySelector Rotate(Double angle, Double x, Double y) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetRotation(pmat, angle, x, y);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ROTATE_PT, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector PostTranslate(Double dx, Double dy) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetTranslation(pmat, dx, dy);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_TRANSLATE, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector PostScale(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetScaling(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_SCALE, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector PostSkew(Double xf, Double yf) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetSkewing(pmat, xf, yf);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_SKEW, pmat);
			}
			return this;
		}
		public IStrokeGeometrySelector PostRotate(Double angle) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_ROTATE, &angle);
			}
			return this;
		}
		public IStrokeGeometrySelector PostRotate(Double angle, Double x, Double y) {
			unsafe {
				BLMatrix2D* pmat = stackalloc BLMatrix2D[1];
				blMatrix2DSetRotation(pmat, angle, x, y);
				fixed (BLContextCore* pcore = &ctx.core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_ROTATE_PT, pmat);
			}
			return this;
		}
		#endregion StrokeTransform
		#region StrokeGeometry
		public void Rectangle(BLRect rect) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLVarCore* pstyle = &style)
					blContextStrokeRectDExt(pcore, &rect, pstyle);
			}
		}
		public void Rectangle(BLRectI rect) {
			unsafe {
				fixed (BLContextCore* pcore = &ctx.core)
				fixed (BLVarCore* pstyle = &style)
					blContextStrokeRectIExt(pcore, &rect, pstyle);
			}
		}
		#endregion StrokeGeometry
	}
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IStyleSelector<T, TGeom> where T : ITransformSelector<TGeom> where TGeom : IStrokeGeometrySelector {
		/// <summary>
		/// Draws using context's default styling
		/// </summary>
		public T DefaultStyle();
		/// <summary>
		/// Draws using a solid colour as specified
		/// </summary>
		/// <param name="rgba">Colour for this operation</param>
		public T SolidColour(BLRgba rgba);
		/// <inheritdoc cref="SolidColour(BLRgba)"/>
		public T SolidColour(BLRgba32 rgba);
		/// <inheritdoc cref="SolidColour(BLRgba)"/>
		public T SolidColour(BLRgba64 rgba);
		/// <inheritdoc cref="SolidColour(BLRgba)"/>
		public T SolidColour(UInt32 rgba) => SolidColour(new BLRgba32() { value = rgba });
		/// <inheritdoc cref="SolidColour(BLRgba)"/>
		public T SolidColour(UInt64 rgba) => SolidColour(new BLRgba64() { value = rgba });
		/// <inheritdoc cref="SolidColour(BLRgba)"/>
		public T SolidColour(Single r, Single g, Single b, Single a) => SolidColour(new BLRgba() { r = r, g = g, b = b, a = a });
		/// <summary>
		/// Draws using <paramref name="gradient"/>
		/// </summary>
		/// <param name="gradient">Gradient for this operation</param>
		public T Gradient(ref BLGradientCore gradient);
		/// <summary>
		/// Draws using <paramref name="pattern"/>
		/// </summary>
		/// <param name="pattern">Pattern for this operation</param>
		public T Pattern(ref BLPatternCore pattern);
	}
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface ITransformSelector<T> where T : IStrokeGeometrySelector {
		/// <summary>
		/// Applies the context's default user transformation
		/// </summary>
		public T DefaultTransform();
		/// <summary>
		/// Translates this rendering call by <paramref name="vec"/>
		/// </summary>
		/// <param name="vec">Translation vector</param>
		public T Translate(BLPoint vec) => Translate(vec.x, vec.y);
		/// <inheritdoc cref="Translate(BLPoint)"/>
		public T Translate(BLPointI vec) => Translate((Double) vec.x, vec.y);
		/// <summary>
		/// Translates this rendering call by (<paramref name="dx"/>, <paramref name="dy"/>)
		/// </summary>
		/// <param name="dx">Horizontal element of translation</param>
		/// <param name="dy">Vertical element of translation</param>
		public T Translate(Double dx, Double dy);
		/// <inheritdoc cref="Translate(double, double)"/>
		public T Translate(Int32 dx, Int32 dy) => Translate((Double) dx, dy);
		/// <summary>
		/// Scales this rendering call by <paramref name="factor"/>
		/// </summary>
		/// <param name="factor">Scaling factor</param>
		public T Scale(BLPoint factor) => Scale(factor.x, factor.y);
		/// <inheritdoc cref="Scale(BLPoint)"/>
		public T Scale(BLPointI factor) => Scale((Double) factor.x, factor.y);
		/// <summary>
		/// Scales this rendering call by <paramref name="xf"/> in horizontal axis and
		/// <paramref name="yf"/> in vertical axis
		/// </summary>
		/// <param name="xf">Horizontal scaling factor</param>
		/// <param name="yf">Vertical scaling factor</param>
		public T Scale(Double xf, Double yf);
		/// <inheritdoc cref="Scale(double, double)"/>
		public T Scale(Int32 xf, Int32 yf) => Scale((Double) xf, yf);
		/// <inheritdoc cref="Scale(BLPoint)"/>
		public T Scale(Double factor) => Scale(factor, factor);
		/// <inheritdoc cref="Scale(BLPoint)"/>
		public T Scale(Int32 factor) => Scale((Double) factor, factor);
		public T Skew(BLPoint factor) => Skew(factor.x, factor.y);
		public T Skew(BLPointI factor) => Skew((Double) factor.x, factor.y);
		public T Skew(Double xf, Double yf);
		public T Skew(Int32 xf, Int32 yf) => Skew((Double) xf, yf);
		public T Rotate(Double angle);
		public T Rotate(Double angle, BLPoint origin) => Rotate(angle, origin.x, origin.y);
		public T Rotate(Double angle, BLPointI origin) => Rotate(angle, (Double) origin.x, origin.y);
		public T Rotate(Double angle, Double x, Double y);
		public T Rotate(Double angle, Int32 x, Int32 y) => Rotate(angle, (Double) x, y);
		public T PostTranslate(BLPoint vec) => PostTranslate(vec.x, vec.y);
		public T PostTranslate(BLPointI vec) => PostTranslate((Double) vec.x, vec.y);
		public T PostTranslate(Double dx, Double dy);
		public T PostTranslate(Int32 dx, Int32 dy) => PostTranslate((Double) dx, dy);
		public T PostScale(BLPoint factor) => PostScale(factor.x, factor.y);
		public T PostScale(BLPointI factor) => PostScale((Double) factor.x, factor.y);
		public T PostScale(Double xf, Double yf);
		public T PostScale(Int32 xf, Int32 yf) => PostScale((Double) xf, yf);
		public T PostScale(Double factor) => PostScale(factor, factor);
		public T PostScale(Int32 factor) => PostScale((Double) factor, factor);
		public T PostSkew(BLPoint factor) => PostSkew(factor.x, factor.y);
		public T PostSkew(BLPointI factor) => PostSkew((Double) factor.x, factor.y);
		public T PostSkew(Double xf, Double yf);
		public T PostSkew(Int32 xf, Int32 yf) => PostSkew((Double) xf, yf);
		public T PostRotate(Double angle);
		public T PostRotate(Double angle, BLPoint origin) => PostRotate(angle, origin.x, origin.y);
		public T PostRotate(Double angle, BLPointI origin) => PostRotate(angle, (Double) origin.x, origin.y);
		public T PostRotate(Double angle, Double x, Double y);
		public T PostRotate(Double angle, Int32 x, Int32 y) => PostRotate(angle, (Double) x, y);
	}
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IStrokeGeometrySelector {
		public void Rectangle(BLRect rect);
		public void Rectangle(BLRectI rect);
		public void Rectangle(Double x, Double y, Double width, Double height) => Rectangle(new BLRect() { x = x, y = y, w = width, h = height });
		public void Rectangle(Int32 x, Int32 y, Int32 width, Int32 height) => Rectangle(new BLRectI() { x = x, y = y, w = width, h = height });
	}
	/// <inheritdoc/>
	public interface IFillGeometrySelector : IStrokeGeometrySelector {
		public void All();
	}
}
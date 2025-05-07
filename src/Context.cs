using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Where all the drawing happens
/// </summary>
public sealed class Context : BlendObject<BLContextCore>, ITransformable {
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
	private BLApproximationOptions ApproximationOptions {
		// TODO: Hacky AF. Ask for API procedures upstream ASAP
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				return *(BLApproximationOptions*) ((IntPtr*) *((IntPtr*) core.obj.impl + 1) + 14);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				*((BLApproximationOptions*) ((IntPtr*) *((IntPtr*) core.obj.impl + 1) + 14)) = value;
			}
		}
	}
	/// <summary>
	/// Curve flattening strategy
	/// </summary>
	public BLFlattenMode FlatteningMode {
		get => ApproximationOptions.flattenMode;
		set => ApproximationOptions = ApproximationOptions with { flattenMode = value };
	}
	/// <summary>
	/// Curve offsetting strategy
	/// </summary>
	public BLOffsetMode OffsettingMode {
		get => ApproximationOptions.offsetMode;
		set => ApproximationOptions = ApproximationOptions with { offsetMode = value };
	}
	/// <summary>
	/// Curve flattening tolerance
	/// </summary>
	public Double FlatteningTolerance {
		get => ApproximationOptions.flattenTolerance;
		set => ApproximationOptions = ApproximationOptions with { flattenTolerance = value };
	}
	/// <summary>
	/// Cubic to quadratic curve simplification tolerance
	/// </summary>
	public Double SimplificationTolerance {
		get => ApproximationOptions.simplifyTolerance;
		set => ApproximationOptions = ApproximationOptions with { simplifyTolerance = value };
	}
	/// <summary>
	/// Parameter that affects offsetting behaviour. The effect depends on <see cref="BLOffsetMode"/> set for <see cref="OffsettingMode"/>
	/// </summary>
	public Double OffsettingParameter {
		get => ApproximationOptions.offsetParameter;
		set => ApproximationOptions = ApproximationOptions with { offsetParameter = value };
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
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_ASSIGN, &value);
			}
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
	/// <summary>
	/// Width of the stroking "pen"
	/// </summary>
	public Double StrokeWidth {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return blContextGetStrokeWidth(pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetStrokeWidth(pcore, value);
			}
		}
	}
	/// <inheritdoc/>
	public BLResult Transform(BLMatrix2D mat) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_TRANSFORM, &mat);
		}
	}
	/// <inheritdoc/>
	public BLResult PostTransform(BLMatrix2D mat) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextApplyTransformOp(pcore, BLTransformOp.BL_TRANSFORM_OP_POST_TRANSFORM, &mat);
		}
	}
	/// <inheritdoc/>
	public void ResetTransform() => UserTransform = BLMatrix2D.Identity;
	/// <summary>
	/// Clips drawing operations to the context edges
	/// </summary>
	/// <returns>The status code returned by <see cref="blContextClipToRectD"/> native procedure</returns>
	public BLResult Clip() => Clip(new BLRect() { y = 0, x = 0, w = Width, h = Height });
	/// <summary>
	/// Clips drawing operations to the boundary box specified by <paramref name="rect"/>
	/// </summary>
	/// <param name="rect">Boundary box</param>
	/// <returns>The status code returned by <see cref="blContextClipToRectD"/> native procedure</returns>
	public BLResult Clip(BLRect rect) {
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextClipToRectD(pcore, &rect);
		}
	}
	/// <summary>
	/// Clips drawing operations to the boundary box specified by <paramref name="rect"/>
	/// </summary>
	/// <param name="rect">Boundary box</param>
	/// <returns>The status code returned by <see cref="blContextClipToRectI"/> native procedure</returns>
	public BLResult Clip(BLRectI rect) {
		unsafe {
			fixed (BLContextCore* pcore = &core)
				return blContextClipToRectI(pcore, &rect);
		}
	}
	/// <summary>
	/// Pushes the current state of the context into the <paramref name="cookieId"/> stack
	/// </summary>
	/// <param name="cookieId">Stack ID; 0 by default</param>
	/// <returns>The status code returned by <see cref="blContextSave"/> native procedure</returns>
	public BLResult Push(UInt64 cookieId = 0) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		if (!cookieStore.TryGetValue(cookieId, out BLContextCookie cookie))
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
	/// <summary>
	/// Fills the entire context using <paramref name="style"/>
	/// </summary>
	/// <param name="style">Styling to be used</param>
	/// <returns>The status code returned by <see cref="blContextFillAllExt"/> native procedure</returns>
	public BLResult Fill(Style style) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLVarCore* pstyle = &style.core)
				return blContextFillAllExt(pcore, pstyle);
		}
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private BLResult FillGeometry<TGeom>(BLGeometryType type, TGeom geom, Style style) where TGeom : unmanaged {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (void* pstyle = &style.core)
				return blContextFillGeometryExt(pcore, type, &geom, pstyle);
		}
	}
	/// <summary>
	/// Fill operation over the area specified by <paramref name="geom"/> using <paramref name="style"/>
	/// </summary>
	/// <param name="geom">Shape to be filled</param>
	/// <param name="style">Styling to be used</param>
	/// <returns>The status code returned by the relevant native procedure</returns>
	public BLResult FillRectangle(BLRect geom, Style style) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (void* pstyle = &style.core)
				return blContextFillRectDExt(pcore, &geom, pstyle);
		}
	}
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillRectangle(BLRectI geom, Style style) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (void* pstyle = &style.core)
				return blContextFillRectIExt(pcore, &geom, pstyle);
		}
	}
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillBox(BLBox geom, Style style) {
		(geom.x0, geom.x1) = geom.x0 < geom.x1 ? (geom.x0, geom.x1) : (geom.x1, geom.x0);
		(geom.y0, geom.y1) = geom.y0 < geom.y1 ? (geom.y0, geom.y1) : (geom.y1, geom.y0);
		geom.x1 -= geom.x0;
		geom.y1 -= geom.y0;
		unsafe {
			return FillRectangle(*(BLRect*) &geom, style);
		}
	}
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillBox(BLBoxI geom, Style style) {
		(geom.x0, geom.x1) = geom.x0 < geom.x1 ? (geom.x0, geom.x1) : (geom.x1, geom.x0);
		(geom.y0, geom.y1) = geom.y0 < geom.y1 ? (geom.y0, geom.y1) : (geom.y1, geom.y0);
		geom.x1 -= geom.x0;
		geom.y1 -= geom.y0;
		unsafe {
			return FillRectangle(*(BLRectI*) &geom, style);
		}
	}
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillCircle(BLCircle geom, Style style) => FillGeometry(BLGeometryType.BL_GEOMETRY_TYPE_CIRCLE, geom, style);
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillEllipse(BLEllipse geom, Style style) => FillGeometry(BLGeometryType.BL_GEOMETRY_TYPE_ELLIPSE, geom, style);
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillRoundRectangle(BLRoundRect geom, Style style) => FillGeometry(BLGeometryType.BL_GEOMETRY_TYPE_ROUND_RECT, geom, style);
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillChord(BLArc geom, Style style) => FillGeometry(BLGeometryType.BL_GEOMETRY_TYPE_CHORD, geom, style);
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillPie(BLArc geom, Style style) => FillGeometry(BLGeometryType.BL_GEOMETRY_TYPE_PIE, geom, style);
	/// <inheritdoc cref="FillRectangle(BLRect, Style)"/>
	public BLResult FillTriangle(BLTriangle geom, Style style) => FillGeometry(BLGeometryType.BL_GEOMETRY_TYPE_TRIANGLE, geom, style);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="origin"></param>
	/// <param name="font"></param>
	/// <param name="text"></param>
	/// <param name="style"></param>
	/// <returns></returns>
	public BLResult FillString(BLPoint origin, Font font, String text, Style style) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLFontCore* pfont = &font.core)
			fixed (void* pstyle = &style.core)
				return blContextFillUtf16TextDExt(pcore, &origin, pfont, text, (IntPtr) text.Length, pstyle);
		}
	}
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private BLResult StrokeGeometry<TGeom>(BLGeometryType type, TGeom geom, Style style) where TGeom : unmanaged {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (void* pstyle = &style.core)
				return blContextStrokeGeometryExt(pcore, type, &geom, pstyle);
		}
	}
	/// <summary>
	/// Stroke operation enclosing the area specified by <paramref name="geom"/> using <paramref name="style"/>
	/// </summary>
	/// <param name="geom">Shape to be filled</param>
	/// <param name="style">Styling to be used</param>
	/// <returns>The status code returned by the relevant native procedure</returns>
	public BLResult StrokeRectangle(BLRect geom, Style style) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (void* pstyle = &style.core)
				return blContextStrokeRectDExt(pcore, &geom, pstyle);
		}
	}
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeRectangle(BLRectI geom, Style style) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (void* pstyle = &style.core)
				return blContextStrokeRectIExt(pcore, &geom, pstyle);
		}
	}
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeBox(BLBox geom, Style style) {
		(geom.x0, geom.x1) = geom.x0 < geom.x1 ? (geom.x0, geom.x1) : (geom.x1, geom.x0);
		(geom.y0, geom.y1) = geom.y0 < geom.y1 ? (geom.y0, geom.y1) : (geom.y1, geom.y0);
		geom.x1 -= geom.x0;
		geom.y1 -= geom.y0;
		unsafe {
			return StrokeRectangle(*(BLRect*) &geom, style);
		}
	}
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeBox(BLBoxI geom, Style style) {
		(geom.x0, geom.x1) = geom.x0 < geom.x1 ? (geom.x0, geom.x1) : (geom.x1, geom.x0);
		(geom.y0, geom.y1) = geom.y0 < geom.y1 ? (geom.y0, geom.y1) : (geom.y1, geom.y0);
		geom.x1 -= geom.x0;
		geom.y1 -= geom.y0;
		unsafe {
			return StrokeRectangle(*(BLRectI*) &geom, style);
		}
	}
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeLine(BLLine geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_LINE, geom, style);
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeCircle(BLCircle geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_CIRCLE, geom, style);
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeEllipse(BLEllipse geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_ELLIPSE, geom, style);
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeRoundRectangle(BLRoundRect geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_ROUND_RECT, geom, style);
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeArc(BLArc geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_ARC, geom, style);
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeChord(BLArc geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_CHORD, geom, style);
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokePie(BLArc geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_PIE, geom, style);
	/// <inheritdoc cref="StrokeRectangle(BLRect, Style)"/>
	public BLResult StrokeTriangle(BLTriangle geom, Style style) => StrokeGeometry(BLGeometryType.BL_GEOMETRY_TYPE_TRIANGLE, geom, style);
	/// <summary>
	/// Blits an area bound by <paramref name="src"/> within <paramref name="img"/>
	/// upon the context starting at <paramref name="dst"/> point
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <param name="src">Area of image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitImageD"/> native procedure</returns>
	public BLResult Blit(BLPoint dst, Image img, BLRectI src) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitImageD(pcore, &dst, pimg, &src);
		}
	}
	/// <summary>
	/// Blits the image, <paramref name="img"/>, upon the context starting at <paramref name="dst"/> point
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitImageD"/> native procedure</returns>
	public BLResult Blit(BLPoint dst, Image img) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitImageD(pcore, &dst, pimg, null);
		}
	}
	/// <summary>
	/// Blits an area bound by <paramref name="src"/> within <paramref name="img"/>
	/// upon the context starting at <paramref name="dst"/> point
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <param name="src">Area of image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitImageI"/> native procedure</returns>
	public BLResult Blit(BLPointI dst, Image img, BLRectI src) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitImageI(pcore, &dst, pimg, &src);
		}
	}
	/// <summary>
	/// Blits the image, <paramref name="img"/>, upon the context starting at <paramref name="dst"/> point
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitImageI"/> native procedure</returns>
	public BLResult Blit(BLPointI dst, Image img) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitImageI(pcore, &dst, pimg, null);
		}
	}
	/// <summary>
	/// Blits an area bound by <paramref name="src"/> within <paramref name="img"/>
	/// upon the context, scaled to fit in the <paramref name="dst"/> boundary box
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <param name="src">Area of image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitScaledImageD"/> native procedure</returns>
	public BLResult BlitScaled(BLRect dst, Image img, BLRectI src) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitScaledImageD(pcore, &dst, pimg, &src);
		}
	}
	/// <summary>
	/// Blits the image, <paramref name="img"/>, upon the context,
	/// scaled to fit in the <paramref name="dst"/> boundary box
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitScaledImageD"/> native procedure</returns>
	public BLResult BlitScaled(BLRect dst, Image img) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitScaledImageD(pcore, &dst, pimg, null);
		}
	}
	/// <summary>
	/// Blits an area bound by <paramref name="src"/> within <paramref name="img"/>
	/// upon the context, scaled to fit in the <paramref name="dst"/> boundary box
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <param name="src">Area of image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitScaledImageI"/> native procedure</returns>
	public BLResult BlitScaled(BLRectI dst, Image img, BLRectI src) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitScaledImageI(pcore, &dst, pimg, &src);
		}
	}
	/// <summary>
	/// Blits the image, <paramref name="img"/>, upon the context,
	/// scaled to fit in the <paramref name="dst"/> boundary box
	/// </summary>
	/// <param name="dst">Blitting origin point</param>
	/// <param name="img">The image to be blitted</param>
	/// <returns>The status code returned by <see cref="blContextBlitScaledImageI"/> native procedure</returns>
	public BLResult BlitScaled(BLRectI dst, Image img) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (BLContextCore* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				return blContextBlitScaledImageI(pcore, &dst, pimg, null);
		}
	}
}
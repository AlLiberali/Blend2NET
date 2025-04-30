using System;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Use of an image as a pattern to style elements
/// </summary>
public class Pattern : Style, ITransformable {
	/// <summary>
	/// The extension behaviour when a pattern reaches its limits
	/// </summary>
	public BLExtendMode ExtendMode {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (void* pcore = &core)
					return blPatternGetExtendMode((BLPatternCore*) pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (void* pcore = &core)
					blPatternSetExtendMode((BLPatternCore*) pcore, value);
			}
		}
	}
	/// <summary>
	/// Area within image to be used as the pattern
	/// </summary>
	public BLRectI Area {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			BLRectI ret;
			unsafe {
				fixed (void* pcore = &core)
					blPatternGetArea((BLPatternCore*) pcore, &ret);
			}
			return ret;
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (void* pcore = &core)
					blPatternSetArea((BLPatternCore*) pcore, &value);
			}
		}
	}
	internal Pattern(Image img) {
		BLRectI rect = new() { x = 0, y = 0, h = (Int32) img.Height, w = (Int32) img.Width };
		BLMatrix2D mat = BLMatrix2D.Identity;
		unsafe {
			fixed (void* pcore = &core)
			fixed (BLImageCore* pimg = &img.core)
				blPatternInitAs((BLPatternCore*) pcore, pimg, &rect, BLExtendMode.BL_EXTEND_MODE_REPEAT, &mat);
		}
	}
	/// <inheritdoc/>
	public BLResult PostTransform(BLMatrix2D mat) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (void* pcore = &core)
				return blPatternApplyTransformOp((BLPatternCore*) pcore, BLTransformOp.BL_TRANSFORM_OP_POST_TRANSFORM, &mat);
		}
	}
	/// <inheritdoc/>
	public void ResetTransform() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		BLMatrix2D mat = BLMatrix2D.Identity;
		unsafe {
			fixed (void* pcore = &core)
				blPatternApplyTransformOp((BLPatternCore*) pcore, BLTransformOp.BL_TRANSFORM_OP_ASSIGN, &mat);
		}
	}
	/// <inheritdoc/>
	public BLResult Transform(BLMatrix2D mat) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		unsafe {
			fixed (void* pcore = &core)
				return blPatternApplyTransformOp((BLPatternCore*) pcore, BLTransformOp.BL_TRANSFORM_OP_TRANSFORM, &mat);
		}
	}
}
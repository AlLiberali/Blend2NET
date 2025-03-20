using System;
using System.Runtime.InteropServices;
using AlLiberali.Blend2NET.Colour;
using AlLiberali.Blend2NET.Geometry;
using static AlLiberali.Blend2NET.Array_;
using size_t = System.IntPtr;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable CA1401
#pragma warning disable CA1707
#pragma warning disable CA1711
#pragma warning disable CA2101

public sealed partial class Context : IBlendObject<Context, Context.BLContextCore>, IDisposable {
	[DllImport("blend2d")]
	public static extern BLResult blContextInit(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextInitMove(ref BLContextCore self, ref BLContextCore other);
	[DllImport("blend2d")]
	public static extern BLResult blContextInitWeak(ref BLContextCore self, ref BLContextCore other);
	[DllImport("blend2d")]
	public static extern BLResult blContextInitAs(ref BLContextCore self, ref BLImageCore image, ref BLContextCreateInfo cci);
	[DllImport("blend2d")]
	public static extern BLResult blContextDestroy(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextReset(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextAssignMove(ref BLContextCore self, ref BLContextCore other);
	[DllImport("blend2d")]
	public static extern BLResult blContextAssignWeak(ref BLContextCore self, ref BLContextCore other);
	[DllImport("blend2d")]
	public static extern BLContextType blContextGetType(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetTargetSize(ref BLContextCore self, ref BLSize targetSizeOut);
	[DllImport("blend2d")]
	public unsafe static extern BLImageCore* blContextGetTargetImage(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextBegin(ref BLContextCore self, ref BLImageCore image, ref BLContextCreateInfo cci);
	[DllImport("blend2d")]
	public static extern BLResult blContextEnd(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextFlush(ref BLContextCore self, BLContextFlushFlags flags);
	[DllImport("blend2d")]
	public static extern BLResult blContextSave(ref BLContextCore self, ref BLContextCookie cookie);
	[DllImport("blend2d")]
	public static extern BLResult blContextRestore(ref BLContextCore self, ref BLContextCookie cookie);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetMetaTransform(ref BLContextCore self, out BLMatrix2D transformOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetUserTransform(ref BLContextCore self, out BLMatrix2D transformOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetFinalTransform(ref BLContextCore self, out BLMatrix2D transformOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextUserToMeta(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextApplyTransformOp(ref BLContextCore self, BLTransformOp opType, const void* opData);
	[DllImport("blend2d")]
	public static extern UInt32 blContextGetHint(ref BLContextCore self, BLContextHint hintType);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetHint(ref BLContextCore self, BLContextHint hintType, UInt32 value);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetHints(ref BLContextCore self, ref BLContextHints hintsOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetHints(ref BLContextCore self, ref BLContextHints hints);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFlattenMode(ref BLContextCore self, BLFlattenMode mode);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFlattenTolerance(ref BLContextCore self, Double tolerance);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetApproximationOptions(ref BLContextCore self, ref BLApproximationOptions options);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetFillStyle(ref BLContextCore self, out BLVarCore styleOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetTransformedFillStyle(ref BLContextCore self, out BLVarCore styleOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFillStyle(ref BLContextCore self, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFillStyleWithMode(ref BLContextCore self, ref BLUnknown style, BLContextStyleTransformMode transformMode);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFillStyleRgba(ref BLContextCore self, in BLRgba rgba);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFillStyleRgba32(ref BLContextCore self, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFillStyleRgba64(ref BLContextCore self, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextDisableFillStyle(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern Double blContextGetFillAlpha(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFillAlpha(ref BLContextCore self, Double alpha);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetStrokeStyle(ref BLContextCore self, out BLVarCore styleOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetTransformedStrokeStyle(ref BLContextCore self, out BLVarCore styleOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeStyle(ref BLContextCore self, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeStyleWithMode(ref BLContextCore self, ref BLUnknown style, BLContextStyleTransformMode transformMode);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeStyleRgba(ref BLContextCore self, ref BLRgba rgba);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeStyleRgba32(ref BLContextCore self, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeStyleRgba64(ref BLContextCore self, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextDisableStrokeStyle(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern Double blContextGetStrokeAlpha(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeAlpha(ref BLContextCore self, Double alpha);
	[DllImport("blend2d")]
	public static extern BLResult blContextSwapStyles(ref BLContextCore self, BLContextStyleSwapMode mode);
	[DllImport("blend2d")]
	public static extern Double blContextGetGlobalAlpha(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetGlobalAlpha(ref BLContextCore self, Double alpha);
	[DllImport("blend2d")]
	public static extern BLCompOp blContextGetCompOp(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetCompOp(ref BLContextCore self, BLCompOp compOp);
	[DllImport("blend2d")]
	public static extern BLFillRule blContextGetFillRule(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetFillRule(ref BLContextCore self, BLFillRule fillRule);
	[DllImport("blend2d")]
	public static extern Double blContextGetStrokeWidth(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeWidth(ref BLContextCore self, Double width);
	[DllImport("blend2d")]
	public static extern Double blContextGetStrokeMiterLimit(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeMiterLimit(ref BLContextCore self, Double miterLimit);
	[DllImport("blend2d")]
	public static extern BLStrokeCap blContextGetStrokeCap(ref BLContextCore self, BLStrokeCapPosition position);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeCap(ref BLContextCore self, BLStrokeCapPosition position, BLStrokeCap strokeCap);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeCaps(ref BLContextCore self, BLStrokeCap strokeCap);
	[DllImport("blend2d")]
	public static extern BLStrokeJoin blContextGetStrokeJoin(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeJoin(ref BLContextCore self, BLStrokeJoin strokeJoin);
	[DllImport("blend2d")]
	public static extern BLStrokeTransformOrder blContextGetStrokeTransformOrder(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeTransformOrder(ref BLContextCore self, BLStrokeTransformOrder transformOrder);
	[DllImport("blend2d")]
	public static extern Double blContextGetStrokeDashOffset(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeDashOffset(ref BLContextCore self, Double dashOffset);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetStrokeDashArray(ref BLContextCore self, ref BLArrayCore dashArrayOut);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeDashArray(ref BLContextCore self, ref BLArrayCore dashArray);
	[DllImport("blend2d")]
	public static extern BLResult blContextGetStrokeOptions(ref BLContextCore self, ref BLStrokeOptionsCore options);
	[DllImport("blend2d")]
	public static extern BLResult blContextSetStrokeOptions(ref BLContextCore self, ref BLStrokeOptionsCore options);
	[DllImport("blend2d")]
	public static extern BLResult blContextClipToRectI(ref BLContextCore self, ref BLRectI rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextClipToRectD(ref BLContextCore self, ref BLRect rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextRestoreClipping(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextClearAll(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextClearRectI(ref BLContextCore self, ref BLRectI rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextClearRectD(ref BLContextCore self, ref BLRect rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillAll(ref BLContextCore self);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillAllRgba32(ref BLContextCore self, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillAllRgba64(ref BLContextCore self, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillAllExt(ref BLContextCore self, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectI(ref BLContextCore self, ref BLRectI rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectIRgba32(ref BLContextCore self, ref BLRectI rect, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectIRgba64(ref BLContextCore self, ref BLRectI rect, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectIExt(ref BLContextCore self, ref BLRectI rect, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectD(ref BLContextCore self, ref BLRect rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectDRgba32(ref BLContextCore self, ref BLRect rect, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectDRgba64(ref BLContextCore self, ref BLRect rect, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillRectDExt(ref BLContextCore self, ref BLRect rect, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillPathD(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillPathDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillPathDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillPathDExt(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGeometry(ref BLContextCore self, BLGeometryType type, const void* data);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGeometryRgba32(ref BLContextCore self, BLGeometryType type, const void* data, BLRgba32 rgba32);
[DllImport("blend2d")]
	public static extern BLResult blContextFillGeometryRgba64(ref BLContextCore self, BLGeometryType type, const void* data, BLRgba64 rgba64);
[DllImport("blend2d")]
	public static extern BLResult blContextFillGeometryExt(ref BLContextCore self, BLGeometryType type, const void* data, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf8TextDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf16TextDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, ref BLUnknown style);
	/* No UTF-32 because fuck marshalling that
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillUtf32TextDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size, ref BLUnknown style);
	*/
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillGlyphRunDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskI(ref BLContextCore self, ref BLPointI origin, ref BLImageCore mask, ref BLRectI maskArea);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLImageCore mask, ref BLRectI maskArea, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLImageCore mask, ref BLRectI maskArea, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskIExt(ref BLContextCore self, ref BLPointI origin, ref BLImageCore mask, ref BLRectI maskArea, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskD(ref BLContextCore self, ref BLPoint origin, ref BLImageCore mask, ref BLRectI maskArea);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLImageCore mask, ref BLRectI maskArea, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLImageCore mask, ref BLRectI maskArea, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextFillMaskDExt(ref BLContextCore self, ref BLPoint origin, ref BLImageCore mask, ref BLRectI maskArea, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectI(ref BLContextCore self, ref BLRectI rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectIRgba32(ref BLContextCore self, ref BLRectI rect, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectIRgba64(ref BLContextCore self, ref BLRectI rect, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectIExt(ref BLContextCore self, ref BLRectI rect, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectD(ref BLContextCore self, ref BLRect rect);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectDRgba32(ref BLContextCore self, ref BLRect rect, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectDRgba64(ref BLContextCore self, ref BLRect rect, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeRectDExt(ref BLContextCore self, ref BLRect rect, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokePathD(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokePathDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokePathDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokePathDExt(ref BLContextCore self, ref BLPoint origin, ref BLPathCore path, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGeometry(ref BLContextCore self, BLGeometryType type, const void* data);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGeometryRgba32(ref BLContextCore self, BLGeometryType type, const void* data, BLRgba32 rgba32);
[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGeometryRgba64(ref BLContextCore self, BLGeometryType type, const void* data, BLRgba64 rgba64);
[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGeometryExt(ref BLContextCore self, BLGeometryType type, const void* data, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf8TextDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf16TextDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, [MarshalAs(UnmanagedType.LPWStr)] string text, size_t size, ref BLUnknown style);
	/* No UTF-32 because fuck marshalling that
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, const UInt32* text, size_t size, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeUtf32TextDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, const UInt32* text, size_t size, ref BLUnknown style);
	*/
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunI(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunIRgba32(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunIRgba64(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunIExt(ref BLContextCore self, ref BLPointI origin, ref BLFontCore font, ref BLGlyphRun glyphRun, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunD(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunDRgba32(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba32 rgba32);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunDRgba64(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun, BLRgba64 rgba64);
	[DllImport("blend2d")]
	public static extern BLResult blContextStrokeGlyphRunDExt(ref BLContextCore self, ref BLPoint origin, ref BLFontCore font, ref BLGlyphRun glyphRun, ref BLUnknown style);
	[DllImport("blend2d")]
	public static extern BLResult blContextBlitImageI(ref BLContextCore self, ref BLPointI origin, ref BLImageCore img, ref BLRectI imgArea);
	[DllImport("blend2d")]
	public static extern BLResult blContextBlitImageD(ref BLContextCore self, ref BLPoint origin, ref BLImageCore img, ref BLRectI imgArea);
	[DllImport("blend2d")]
	public static extern BLResult blContextBlitScaledImageI(ref BLContextCore self, ref BLRectI rect, ref BLImageCore img, ref BLRectI imgArea);
	[DllImport("blend2d")]
	public static extern BLResult blContextBlitScaledImageD(ref BLContextCore self, ref BLRect rect, ref BLImageCore img, ref BLRectI imgArea);
}

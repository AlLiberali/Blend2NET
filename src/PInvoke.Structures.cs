using System;
using System.Runtime.InteropServices;
using BLTag = System.UInt32;
using int16_t = System.Int16;
using int32_t = System.Int32;
using int64_t = System.Int64;
using int8_t = System.SByte;
using intptr_t = System.IntPtr;
using size_t = System.IntPtr;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE1006
#pragma warning disable IDE0079
#pragma warning disable CS0649
#pragma warning disable CS1591
#pragma warning disable CA1051
#pragma warning disable CA1711

public static partial class PInvoke {
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IGenericInitialisable { }
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IGenericMoveInitialisableAndDestroyable { }
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IGenericWeakInitialisable { }
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IGenericWeakCopyable { }
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IGenericDeepCopyable { }
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IGenericResettable { }
	/// <summary>
	/// Not to be implemented by users
	/// </summary>
	public interface IBlendObjectCore { }
	public struct BLRange {
		public size_t start;
		public size_t end;
	}
	public struct BLRandom {
		internal UInt64 data0;
		internal UInt64 data1;
	}
	public struct BLContextCookie {
		internal UInt64 data0;
		internal UInt64 data1;
	}
	public struct BLRuntimeScopeCore {
		internal UInt32 data0;
		internal UInt32 data1;
	}
	public struct BLFileCore : IGenericInitialisable {
		internal IntPtr handle;
	}
	public unsafe struct BLFileInfo {
		public uint64_t size;
		public int64_t modifiedTime;
		public BLFileInfoFlags flags;
		public uint32_t uid;
		public uint32_t gid;
		internal fixed uint32_t reserved[5];
	}
	public struct BLFontQueryProperties {
		public uint32_t style;
		public uint32_t weight;
		public uint32_t stretch;
	}
	public unsafe struct BLFontTable {
		public uint8_t* data;
		public size_t size;
	}
	public struct BLFontUnicodeCoverage {
		public uint32_t data0;
		public uint32_t data1;
		public uint32_t data2;
		public uint32_t data3;
	}
	public struct BLGlyphInfo {
		public uint32_t cluster;
		internal uint32_t reserved;
	}
	public struct BLGlyphMappingState {
		public size_t glyphCount;
		public size_t undefinedFirst;
		public size_t undefinedCount;
	}
	public struct BLGlyphPlacement {
		public BLPointI placement;
		public BLPointI advance;
	}
	public struct BLTextMetrics {
		public BLPoint advance;
		public BLPoint leadingBearing;
		public BLPoint trailingBearing;
		public BLBox boundingBox;
	}
	public struct BLGradientStop {
		public Double offset;
		public BLRgba64 rgba;
	}
	public struct BLPixelConverterOptions {
		public BLPointI origin;
		public size_t gap;
	}
	public unsafe struct BLRuntimeBuildInfo {
		public uint32_t majorVersion;
		public uint32_t minorVersion;
		public uint32_t patchVersion;
		public BLRuntimeBuildType buildType;
		public BLRuntimeCpuFeatures baselineCpuFeatures;
		public BLRuntimeCpuFeatures supportedCpuFeatures;
		public uint32_t maxImageSize;
		public uint32_t maxThreadCount;
		internal fixed uint32_t reserved[2];
		public fixed Byte compilerInfo[32];
	}
	public unsafe struct BLRuntimeSystemInfo {
		public BLRuntimeCpuArch cpuArch;
		public BLRuntimeCpuFeatures cpuFeatures;
		public uint32_t coreCount;
		public uint32_t threadCount;
		public uint32_t threadStackSize;
		public uint32_t removed;
		public uint32_t allocationGranularity;
		internal fixed uint32_t reserved[5];
		public fixed Byte cpuVendor[16];
		public fixed Byte cpuBrand[64];
	}
	public unsafe struct BLRuntimeResourceInfo {
		public size_t vmUsed;
		public size_t vmReserved;
		public size_t vmOverhead;
		public size_t vmBlockCount;
		public size_t zmUsed;
		public size_t zmReserved;
		public size_t zmOverhead;
		public size_t zmBlockCount;
		public size_t dynamicPipelineCount;
		internal fixed long reserved[7];
	}
	public struct BLRgba32 {
		public uint32_t value;
	}
	public struct BLRgba64 {
		public uint64_t value;
	}
	public struct BLRgba {
		public Single r;
		public Single g;
		public Single b;
		public Single a;
	}
	public struct BLPointI {
		public Int32 x;
		public Int32 y;
	}
	public struct BLSizeI {
		public Int32 w;
		public Int32 h;
	}
	public struct BLBoxI {
		public Int32 x0;
		public Int32 y0;
		public Int32 x1;
		public Int32 y1;
	}
	public struct BLRectI {
		public Int32 x;
		public Int32 y;
		public Int32 w;
		public Int32 h;
	}
	public struct BLPoint {
		public Double x;
		public Double y;
	}
	public struct BLSize {
		public Double w;
		public Double h;
	}
	public struct BLBox {
		public Double x0;
		public Double y0;
		public Double x1;
		public Double y1;
	}
	public struct BLRect {
		public Double x;
		public Double y;
		public Double w;
		public Double h;
	}
	public struct BLLine {
		public Double x0;
		public Double y0;
		public Double x1;
		public Double y1;
	}
	public struct BLTriangle {
		public Double x0;
		public Double y0;
		public Double x1;
		public Double y1;
		public Double x2;
		public Double y2;
	}
	public struct BLRoundRect {
		public Double x;
		public Double y;
		public Double w;
		public Double h;
		public Double rx;
		public Double ry;
	}
	public struct BLCircle {
		public Double cx;
		public Double cy;
		public Double r;
	}
	public struct BLEllipse {
		public Double cx;
		public Double cy;
		public Double rx;
		public Double ry;
	}
	public struct BLArc {
		public Double cx;
		public Double cy;
		public Double rx;
		public Double ry;
		public Double start;
		public Double sweep;
	}
	public struct BLMatrix2D {
		public Double m00;
		public Double m01;
		public Double m10;
		public Double m11;
		public Double m20;
		public Double m21;
	}
	public struct BLFontMatrix {
		public Double m00;
		public Double m01;
		public Double m10;
		public Double m11;
	}
	public unsafe struct BLApproximationOptions {
		public uint8_t flattenMode;
		public uint8_t offsetMode;
		internal fixed uint8_t reservedFlags[6];
		public Double flattenTolerance;
		public Double simplifyTolerance;
		public Double offsetParameter;
	}
	public unsafe struct BLStrokeOptionsCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable {
		public uint8_t startCap;
		public uint8_t endCap;
		public uint8_t join;
		public uint8_t transformOrder;
		internal fixed uint8_t reserved[4];
		public Double width;
		public Double miterLimit;
		public Double dashOffset;
		public BLArrayCore dashArray;
	}
	public unsafe struct BLImageInfo {
		public BLSizeI size;
		public BLSize density;
		public BLFormatFlags flags;
		public uint16_t depth;
		public uint16_t planeCount;
		public uint64_t frameCount;
		public uint32_t repeatCount;
		internal fixed uint32_t reserved[3];
		public fixed byte format[16];
		public fixed byte compression[16];
	}
	public struct BLFormatInfo {
		public uint32_t depth;
		public BLFormatFlags flags;
		public uint8_t rSize;
		public uint8_t gSize;
		public uint8_t bSize;
		public uint8_t aSize;
		public uint8_t rShift;
		public uint8_t gShift;
		public uint8_t bShift;
		public uint8_t aShift;
	}
	public unsafe struct BLImageData {
		public void* pixelData;
		public intptr_t stride;
		public BLSizeI size;
		public BLFormat format;
		public BLFormatFlags flags;
	}
	public unsafe struct BLGlyphRun {
		public void* glyphData;
		public void* placementData;
		public size_t size;
		internal uint8_t reserved;
		public uint8_t placementType;
		public int8_t glyphAdvance;
		public int8_t placementAdvance;
		public uint32_t flags;
	}
	public struct BLFontDesignMetrics {
		public Int32 unitsPerEm;
		public Int32 lowestPPEM;
		public Int32 lineGap;
		public Int32 xHeight;
		public Int32 capHeight;
		public Int32 ascent;
		public Int32 vAscent;
		public Int32 descent;
		public Int32 vDescent;
		public Int32 hMinLSB;
		public Int32 vMinLSB;
		public Int32 hMinTSB;
		public Int32 vMinTSB;
		public Int32 hMaxAdvance;
		public Int32 vMaxAdvance;
		public BLBoxI glyphBoundingBox;
		public Int32 underlinePosition;
		public Int32 underlineThickness;
		public Int32 strikethroughPosition;
		public Int32 strikethroughThickness;
	}
	public struct BLFontMetrics {
		public Single size;
		public Single ascent;
		public Single vAscent;
		public Single descent;
		public Single vDescent;
		public Single lineGap;
		public Single xHeight;
		public Single capHeight;
		public Single xMin;
		public Single yMin;
		public Single xMax;
		public Single yMax;
		public Single underlinePosition;
		public Single underlineThickness;
		public Single strikethroughPosition;
		public Single strikethroughThickness;
	}
	public unsafe struct BLFontFaceInfo {
		public uint8_t faceType;
		public uint8_t outlineType;
		internal fixed uint8_t reserved8[2];
		public uint32_t glyphCount;
		public uint32_t revision;
		public uint32_t faceIndex;
		public uint32_t faceFlags;
		public uint32_t diagFlags;
		internal fixed uint32_t reserved[2];
	}
	public struct BLFontFeatureItem {
		public BLTag tag;
		public uint32_t value;
	}
	[StructLayout(LayoutKind.Sequential, Size = 296)]
	public unsafe struct BLFontFeatureSettingsView {
		public BLFontFeatureItem* data;
		public size_t size;
		public BLFontFeatureItem ssoData;
	}
	public struct BLFontVariationItem {
		public BLTag tag;
		public Single value;
	}
	public unsafe struct BLFontVariationSettingsView {
		public BLFontVariationItem* data;
		public size_t size;
		public BLFontVariationItem ssoData0;
		public BLFontVariationItem ssoData1;
		public BLFontVariationItem ssoData2;
	}
	public unsafe struct BLBitSetSegment {
		public uint32_t _startWord;
		public fixed uint32_t _data[(Int32) BLBitSetConstants.BL_BIT_SET_SEGMENT_WORD_COUNT];
	}
	public unsafe struct BLBitSetData {
		public BLBitSetSegment* segmentData;
		public uint32_t segmentCount;
		public BLBitSetSegment ssoSegment0;
		public BLBitSetSegment ssoSegment1;
		public BLBitSetSegment ssoSegment2;
	}
	[StructLayout(LayoutKind.Sequential, Size = 80)]
	public unsafe struct BLPixelConverterCore :
		IGenericInitialisable,
		IGenericWeakInitialisable,
		IGenericResettable,
		IGenericWeakCopyable {
		public void* convertFunc;
		public uint8_t flags;
	}
	public struct BLContextCreateInfo {
		public BLContextCreateFlags flags;
		public uint32_t threadCount;
		public BLRuntimeCpuFeatures cpuFeatures;
		public uint32_t commandQueueLimit;
		public uint32_t savedStateLimit;
		public BLPointI pixelOrigin;
		internal uint32_t reserved;
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct BLContextHints {
		[FieldOffset(0)] public uint8_t renderingQuality;
		[FieldOffset(0)] public uint8_t gradientQuality;
		[FieldOffset(0)] public uint8_t patternQuality;
	}
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	public unsafe struct BLObjectCore : IBlendObjectCore {
		[FieldOffset(0)]
		BLRgba32 rgba32;
		[FieldOffset(0)]
		BLRgba64 rgba64;
		[FieldOffset(0)]
		BLRgba rgba;
		[FieldOffset(0)]
		public fixed byte char_data[16];
		[FieldOffset(0)]
		public fixed int8_t i8_data[16];
		[FieldOffset(0)]
		public fixed uint8_t u8_data[16];
		[FieldOffset(0)]
		public fixed int16_t i16_data[8];
		[FieldOffset(0)]
		public fixed uint16_t u16_data[8];
		[FieldOffset(0)]
		public fixed int32_t i32_data[4];
		[FieldOffset(0)]
		public fixed uint32_t u32_data[4];
		[FieldOffset(0)]
		public fixed int64_t i64_data[2];
		[FieldOffset(0)]
		public fixed uint64_t u64_data[2];
		[FieldOffset(0)]
		public fixed Single f32_data[4];
		[FieldOffset(0)]
		public fixed Double f64_data[2];
		[FieldOffset(0)]
		public void* impl;
		[FieldOffset(8)]
		public uint32_t impl_payload;
		[FieldOffset(12)]
		public uint32_t info;
	}
	public struct BLArrayCore :
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IGenericDeepCopyable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLBitArrayCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLBitSetCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IGenericDeepCopyable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLStringCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IGenericDeepCopyable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLFontDataCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLPathCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IGenericDeepCopyable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLFontFaceCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLFontFeatureSettingsCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLFontVariationSettingsCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLFontCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLGradientCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLImageCodecCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLImageCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IGenericDeepCopyable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLPatternCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IGenericDeepCopyable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLVarCore : IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLContextCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLFontManagerCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLImageDecoderCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public struct BLImageEncoderCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericWeakInitialisable,
		IGenericWeakCopyable,
		IGenericResettable,
		IBlendObjectCore {
		public BLObjectCore obj;
	}
	public unsafe struct BLGlyphBufferCore :
		IGenericInitialisable,
		IGenericMoveInitialisableAndDestroyable,
		IGenericResettable {
		public void* impl;
	}
}
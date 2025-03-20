using System;
using System.Runtime.InteropServices;

namespace AlLiberali.Blend2NET.Geometry;

#pragma warning disable IDE0079
#pragma warning disable CA1051
#pragma warning disable CA1069
#pragma warning disable CA1707

/// <summary>
/// Direction of a geometry used by geometric primitives and paths.
/// </summary>
public enum BLGeometryDirection : UInt32 {
	/// <summary>
	/// No direction specified.
	/// </summary>
	BL_GEOMETRY_DIRECTION_NONE = 0,
	/// <summary>
	/// Clockwise direction.
	/// </summary>
	BL_GEOMETRY_DIRECTION_CW = 1,
	/// <summary>
	/// Counter-clockwise direction.
	/// </summary>
	BL_GEOMETRY_DIRECTION_CCW = 2
}

/// <summary>
/// Geometry describes a shape or path that can be either rendered or added to a BLPath container. Both \ref BLPath
/// and <see cref="Context"/> provide functionality to work with all geometry types. Please note that each type provided
/// here requires to pass a matching struct or class to the function that consumes a `geometryType` and `geometryData`
/// arguments.
/// </summary>
public enum BLGeometryType : UInt32 {
	/// <summary>
	/// No geometry provided.
	/// </summary>
	BL_GEOMETRY_TYPE_NONE = 0,
	/// <summary>
	/// BLBoxI struct.
	/// </summary>
	BL_GEOMETRY_TYPE_BOXI = 1,
	/// <summary>
	/// BLBox struct.
	/// </summary>
	BL_GEOMETRY_TYPE_BOXD = 2,
	/// <summary>
	/// BLRectI struct.
	/// </summary>
	BL_GEOMETRY_TYPE_RECTI = 3,
	/// <summary>
	/// BLRect struct.
	/// </summary>
	BL_GEOMETRY_TYPE_RECTD = 4,
	/// <summary>
	/// BLCircle struct.
	/// </summary>
	BL_GEOMETRY_TYPE_CIRCLE = 5,
	/// <summary>
	/// BLEllipse struct.
	/// </summary>
	BL_GEOMETRY_TYPE_ELLIPSE = 6,
	/// <summary>
	/// BLRoundRect struct.
	/// </summary>
	BL_GEOMETRY_TYPE_ROUND_RECT = 7,
	/// <summary>
	/// BLArc struct.
	/// </summary>
	BL_GEOMETRY_TYPE_ARC = 8,
	/// <summary>
	/// BLArc struct representing chord.
	/// </summary>
	BL_GEOMETRY_TYPE_CHORD = 9,
	/// <summary>
	/// BLArc struct representing pie.
	/// </summary>
	BL_GEOMETRY_TYPE_PIE = 10,
	/// <summary>
	/// BLLine struct.
	/// </summary>
	BL_GEOMETRY_TYPE_LINE = 11,
	/// <summary>
	/// BLTriangle struct.
	/// </summary>
	BL_GEOMETRY_TYPE_TRIANGLE = 12,
	/// <summary>
	/// BLArrayView<BLPointI> representing a polyline.
	/// </summary>
	BL_GEOMETRY_TYPE_POLYLINEI = 13,
	/// <summary>
	/// BLArrayView<BLPoint> representing a polyline.
	/// </summary>
	BL_GEOMETRY_TYPE_POLYLINED = 14,
	/// <summary>
	/// BLArrayView<BLPointI> representing a polygon.
	/// </summary>
	BL_GEOMETRY_TYPE_POLYGONI = 15,
	/// <summary>
	/// BLArrayView<BLPoint> representing a polygon.
	/// </summary>
	BL_GEOMETRY_TYPE_POLYGOND = 16,
	/// <summary>
	/// BLArrayView<BLBoxI> struct.
	/// </summary>
	BL_GEOMETRY_TYPE_ARRAY_VIEW_BOXI = 17,
	/// <summary>
	/// BLArrayView<BLBox> struct.
	/// </summary>
	BL_GEOMETRY_TYPE_ARRAY_VIEW_BOXD = 18,
	/// <summary>
	/// BLArrayView<BLRectI> struct.
	/// </summary>
	BL_GEOMETRY_TYPE_ARRAY_VIEW_RECTI = 19,
	/// <summary>
	/// BLArrayView<BLRect> struct.
	/// </summary>
	BL_GEOMETRY_TYPE_ARRAY_VIEW_RECTD = 20,
	/// <summary>
	/// BLPath (or BLPathCore).
	/// </summary>
	BL_GEOMETRY_TYPE_PATH = 21,
	/// <summary>
	/// Maximum value of `BLGeometryType`.
	/// </summary>
	BL_GEOMETRY_TYPE_MAX_VALUE = 21,
}

/// <summary>
/// Fill rule.
/// </summary>
public enum BLFillRule : UInt32 {
	/// <summary>
	/// Non-zero fill-rule.
	/// </summary>
	BL_FILL_RULE_NON_ZERO = 0,
	/// <summary>
	/// Even-odd fill-rule.
	/// </summary>
	BL_FILL_RULE_EVEN_ODD = 1
}

/// <summary>
/// Hit-test result.
/// </summary>
public enum BLHitTest : UInt32 {
	/// <summary>
	/// Fully in.
	/// </summary>
	BL_HIT_TEST_IN = 0,
	/// <summary>
	/// Partially in/out.
	/// </summary>
	BL_HIT_TEST_PART = 1,
	/// <summary>
	/// Fully out.
	/// </summary>
	BL_HIT_TEST_OUT = 2,
	/// <summary>
	/// Hit test failed (invalid argument, NaNs, etc).
	/// </summary>
	BL_HIT_TEST_INVALID = 0xFFFFFFFFu
}

/// <summary>
/// Point specified as [x, y] using `int` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLPointI {
	Int32 x;
	Int32 y;
}

/// <summary>
/// Size specified as [w, h] using int as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLSizeI {
	Int32 w;
	Int32 h;
}

/// <summary>
/// Box specified as [x0, y0, x1, y1] using `int` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLBoxI {
	Int32 x0;
	Int32 y0;
	Int32 x1;
	Int32 y1;
}

/// <summary>
/// Rectangle specified as [x, y, w, h] using `int` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLRectI {
	Int32 x;
	Int32 y;
	Int32 w;
	Int32 h;
}

/// <summary>
/// Point specified as [x, y] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLPoint {
	Double x;
	Double y;
}
/// <summary>
/// Size specified as [w, h] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLSize {
	Double w;
	Double h;
}

/// <summary>
/// Box specified as [x0, y0, x1, y1] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLBox {
	Double x0;
	Double y0;
	Double x1;
	Double y1;
}

/// <summary>
/// Rectangle specified as [x, y, w, h] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLRect {
	Double x;
	Double y;
	Double w;
	Double h;
}

/// <summary>
/// Line specified as [x0, y0, x1, y1] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLLine {
	Double x0;
	Double y0;
	Double x1;
	Double y1;
}

/// <summary>
/// Triangle data specified as [x0, y0, x1, y1, x2, y2] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLTriangle {
	Double x0;
	Double y0;
	Double x1;
	Double y1;
	Double x2;
	Double y2;
}

/// <summary>
/// Rounded rectangle specified as [x, y, w, h, rx, ry] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLRoundRect {
	Double x;
	Double y;
	Double w;
	Double h;
	Double rx;
	Double ry;
}

/// <summary>
/// Circle specified as [cx, cy, r] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLCircle {
	Double cx;
	Double cy;
	Double r;
}

/// <summary>
/// Ellipse specified as [cx, cy, rx, ry] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLEllipse {
	Double cx;
	Double cy;
	Double rx;
	Double ry;
}

/// <summary>
/// Arc specified as [cx, cy, rx, ry, start, sweep] using `double` as a storage type.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BLArc {
	Double cx;
	Double cy;
	Double rx;
	Double ry;
	Double start;
	Double sweep;
}

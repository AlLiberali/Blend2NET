using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
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
		internal UInt64 count;
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
		public readonly Boolean this[Int32 index] => index switch {
			>= 0 and < 32 => ((data0 >> index) & 1) == 1,
			>= 32 and < 64 => ((data1 >> index) & 1) == 1,
			>= 64 and < 96 => ((data2 >> index) & 1) == 1,
			>= 96 and < 128 => ((data3 >> index) & 1) == 1,
			_ => throw new ArgumentOutOfRangeException(nameof(index)),
		};
		public static explicit operator BLFontUnicodeCoverageIndex[](BLFontUnicodeCoverage coverage) => [..
			Enumerable.Range(0, 128)
				.AsParallel()
				.Select(i => coverage[i])
				.Select((b, i) => (BLFontUnicodeCoverageIndex) (b ? i : 256))
				.Where(e => e != (BLFontUnicodeCoverageIndex) 256)
		];
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
		public static implicit operator UInt32(BLRgba32 x) => x.value;
		public static implicit operator BLRgba32(UInt32 x) => new() { value = x };
	}
	public struct BLRgba64 {
		public uint64_t value;
		public static implicit operator UInt64(BLRgba64 x) => x.value;
		public static implicit operator BLRgba64(UInt64 x) => new() { value = x };
		public static implicit operator BLRgba64(UInt32 x) {
			UInt64 ret = 0;
			UInt16 component = (UInt16) ((x & 0xFF_00_00_00) >> 0x18);
			component *= 0x101;
			ret |= component;
			ret <<= 0x10;
			component = (UInt16) ((x & 0x00_FF_00_00) >> 0x10);
			component *= 0x101;
			ret |= component;
			ret <<= 0x10;
			component = (UInt16) ((x & 0x00_00_FF_00) >> 0x8);
			component *= 0x101;
			ret |= component;
			ret <<= 0x10;
			component = (UInt16) ((x & 0x00_00_00_FF));
			component *= 0x101;
			ret |= component;
			return ret;
		}
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
	// The following struct is a modified version of the reference source for
	// System.Numerics.Matrix3x2 and is therefore:
	// Copyright (c) Microsoft. All rights reserved.
	// Licensed under the MIT license.
	// Which is essentially the same licence as the project except that
	// it requires citing the copyright declaration above
	// and the permission notice within the licence to be included
	// in all substantial portions of the Software
	public struct BLMatrix2D(Double m00, Double m01, Double m10, Double m11, Double m20, Double m21) : IEquatable<BLMatrix2D> {
		/// <summary>
		/// The first element of the first row
		/// </summary>
		public Double M00 = m00;
		/// <summary>
		/// The second element of the first row
		/// </summary>
		public Double M01 = m01;
		/// <summary>
		/// The first element of the second row
		/// </summary>
		public Double M10 = m10;
		/// <summary>
		/// The second element of the second row
		/// </summary>
		public Double M11 = m11;
		/// <summary>
		/// The first element of the third row
		/// </summary>
		public Double M20 = m20;
		/// <summary>
		/// The second element of the third row
		/// </summary>
		public Double M21 = m21;
		/// <summary>
		/// Returns the multiplicative identity matrix.
		/// </summary>
		public static BLMatrix2D Identity { get; } = new BLMatrix2D(1, 0, 0, 1, 0, 0);
		/// <summary>
		/// Returns whether the matrix is the identity matrix.
		/// </summary>
		public readonly Boolean IsIdentity => M00 == 1f && M11 == 1f && // Check diagonal element first for early out.
					M01 == 0f && M10 == 0f && M20 == 0f && M21 == 0f;
		/// <summary>
		/// Creates a translation matrix from the given X and Y components.
		/// </summary>
		/// <param name="xPosition">The X position.</param>
		/// <param name="yPosition">The Y position.</param>
		/// <returns>A translation matrix.</returns>
		public static BLMatrix2D CreateTranslation(Double xPosition, Double yPosition) {
			BLMatrix2D result;
			result.M00 = 1.0;
			result.M01 = 0.0;
			result.M10 = 0.0;
			result.M11 = 1.0;
			result.M20 = xPosition;
			result.M21 = yPosition;
			return result;
		}
		/// <summary>
		/// Creates a scale matrix from the given X and Y components.
		/// </summary>
		/// <param name="xScale">Value to scale by on the X-axis.</param>
		/// <param name="yScale">Value to scale by on the Y-axis.</param>
		/// <returns>A scaling matrix.</returns>
		public static BLMatrix2D CreateScale(Double xScale, Double yScale) {
			BLMatrix2D result;
			result.M00 = xScale;
			result.M01 = 0.0f;
			result.M10 = 0.0f;
			result.M11 = yScale;
			result.M20 = 0.0f;
			result.M21 = 0.0f;
			return result;
		}
		/// <summary>
		/// Creates a scale matrix that is offset by a given centre point.
		/// </summary>
		/// <param name="xScale">Value to scale by on the X-axis.</param>
		/// <param name="yScale">Value to scale by on the Y-axis.</param>
		/// <param name="cx">The centre point coordinate on the X-axis.</param>
		/// <param name="cy">The centre point coordinate on the Y-axis.</param>
		/// <returns>A scaling matrix.</returns>
		public static BLMatrix2D CreateScale(Double xScale, Double yScale, Double cx, Double cy) {
			BLMatrix2D result;
			Double tx = cx * (1 - xScale);
			Double ty = cy * (1 - yScale);
			result.M00 = xScale;
			result.M01 = 0.0f;
			result.M10 = 0.0f;
			result.M11 = yScale;
			result.M20 = tx;
			result.M21 = ty;
			return result;
		}
		/// <summary>
		/// Creates a scale matrix that scales uniformly with the given scale.
		/// </summary>
		/// <param name="scale">The uniform scale to use.</param>
		/// <returns>A scaling matrix.</returns>
		public static BLMatrix2D CreateScale(Double scale) {
			BLMatrix2D result;
			result.M00 = scale;
			result.M01 = 0.0f;
			result.M10 = 0.0f;
			result.M11 = scale;
			result.M20 = 0.0f;
			result.M21 = 0.0f;
			return result;
		}
		/// <summary>
		/// Creates a skew matrix from the given angles in radians.
		/// </summary>
		/// <param name="radiansX">The X angle, in radians.</param>
		/// <param name="radiansY">The Y angle, in radians.</param>
		/// <returns>A skew matrix.</returns>
		public static BLMatrix2D CreateSkew(Double radiansX, Double radiansY) {
			BLMatrix2D result;
			Double xTan = (Double) Math.Tan(radiansX);
			Double yTan = (Double) Math.Tan(radiansY);
			result.M00 = 1.0f;
			result.M01 = yTan;
			result.M10 = xTan;
			result.M11 = 1.0f;
			result.M20 = 0.0f;
			result.M21 = 0.0f;
			return result;
		}
		/// <summary>
		/// Creates a rotation matrix using the given rotation in radians.
		/// </summary>
		/// <param name="radians">The amount of rotation, in radians.</param>
		/// <returns>A rotation matrix.</returns>
		public static BLMatrix2D CreateRotation(Double radians) {
			BLMatrix2D result;

			radians = (Double) Math.IEEERemainder(radians, Math.PI * 2);

			Double c, s;

			const Double epsilon = 0.001f * (Double) Math.PI / 180f;     // 0.1% of a degree

			if (radians > -epsilon && radians < epsilon) {
				// Exact case for zero rotation.
				c = 1;
				s = 0;
			} else if (radians > Math.PI / 2 - epsilon && radians < Math.PI / 2 + epsilon) {
				// Exact case for 90 degree rotation.
				c = 0;
				s = 1;
			} else if (radians < -Math.PI + epsilon || radians > Math.PI - epsilon) {
				// Exact case for 180 degree rotation.
				c = -1;
				s = 0;
			} else if (radians > -Math.PI / 2 - epsilon && radians < -Math.PI / 2 + epsilon) {
				// Exact case for 270 degree rotation.
				c = 0;
				s = -1;
			} else {
				// Arbitrary rotation.
				c = (Double) Math.Cos(radians);
				s = (Double) Math.Sin(radians);
			}

			// [  c  s ]
			// [ -s  c ]
			// [  0  0 ]
			result.M00 = c;
			result.M01 = s;
			result.M10 = -s;
			result.M11 = c;
			result.M20 = 0.0f;
			result.M21 = 0.0f;

			return result;
		}
		/// <summary>
		/// Creates a rotation matrix using the given rotation in radians and a centre point.
		/// </summary>
		/// <param name="radians">The amount of rotation, in radians.</param>
		/// <param name="cx">The centre point coordinate on the X-axis.</param>
		/// <param name="cy">The centre point coordinate on the Y-axis.</param>
		/// <returns>A rotation matrix.</returns>
		public static BLMatrix2D CreateRotation(Double radians, Double cx, Double cy) {
			BLMatrix2D result;
			radians = Math.IEEERemainder(radians, Math.PI * 2);
			Double c;
			Double s;
			const Double epsilon = 0.001 * Math.PI / 180;     // 0.1% of a degree
			if (radians > -epsilon && radians < epsilon) {
				// Exact case for zero rotation.
				c = 1;
				s = 0;
			} else if (radians > Math.PI / 2 - epsilon && radians < Math.PI / 2 + epsilon) {
				// Exact case for 90 degree rotation.
				c = 0;
				s = 1;
			} else if (radians < -Math.PI + epsilon || radians > Math.PI - epsilon) {
				// Exact case for 180 degree rotation.
				c = -1;
				s = 0;
			} else if (radians > -Math.PI / 2 - epsilon && radians < -Math.PI / 2 + epsilon) {
				// Exact case for 270 degree rotation.
				c = 0;
				s = -1;
			} else {
				// Arbitrary rotation.
				c = Math.Cos(radians);
				s = Math.Sin(radians);
			}
			Double x = (cx * (1 - c)) + (cy * s);
			Double y = (cy * (1 - c)) - (cx * s);
			result.M00 = c;
			result.M01 = s;
			result.M10 = -s;
			result.M11 = c;
			result.M20 = x;
			result.M21 = y;
			return result;
		}
		/// <summary>
		/// Calculates the determinant for this matrix. 
		/// The determinant is calculated by expanding the matrix with a third column whose values are (0,0,1).
		/// </summary>
		/// <returns>The determinant.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly Double GetDeterminant() => (M00 * M11) - (M10 * M01);
		/// <summary>
		/// Attempts to invert the given matrix. If the operation succeeds, the inverted matrix is stored in the result parameter.
		/// </summary>
		/// <param name="matrix">The source matrix.</param>
		/// <param name="result">The output matrix.</param>
		/// <returns>True if the operation succeeded, False otherwise.</returns>
		public static Boolean TryInvert(BLMatrix2D matrix, out BLMatrix2D result) {
			Double det = matrix.GetDeterminant();
			if (Math.Abs(det) < Double.Epsilon) {
				result = new BLMatrix2D(Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN);
				return false;
			}
			Double invDet = 1.0f / det;
			result.M00 = matrix.M11 * invDet;
			result.M01 = -matrix.M01 * invDet;
			result.M10 = -matrix.M10 * invDet;
			result.M11 = matrix.M00 * invDet;
			result.M20 = (matrix.M10 * matrix.M21 - matrix.M20 * matrix.M11) * invDet;
			result.M21 = (matrix.M20 * matrix.M01 - matrix.M00 * matrix.M21) * invDet;
			return true;
		}
		/// <summary>
		/// Linearly interpolates from matrix1 to matrix2, based on the third parameter.
		/// </summary>
		/// <param name="matrix1">The first source matrix.</param>
		/// <param name="matrix2">The second source matrix.</param>
		/// <param name="amount">The relative weighting of matrix2.</param>
		/// <returns>The interpolated matrix.</returns>
		public static BLMatrix2D LinearInterpolate(BLMatrix2D matrix1, BLMatrix2D matrix2, Double amount) {
			BLMatrix2D result;
			// First row
			result.M00 = matrix1.M00 + (matrix2.M00 - matrix1.M00) * amount;
			result.M01 = matrix1.M01 + (matrix2.M01 - matrix1.M01) * amount;
			// Second row
			result.M10 = matrix1.M10 + (matrix2.M10 - matrix1.M10) * amount;
			result.M11 = matrix1.M11 + (matrix2.M11 - matrix1.M11) * amount;
			// Third row
			result.M20 = matrix1.M20 + (matrix2.M20 - matrix1.M20) * amount;
			result.M21 = matrix1.M21 + (matrix2.M21 - matrix1.M21) * amount;
			return result;
		}
		/// <summary>
		/// Negates the given matrix by multiplying all values by -1.
		/// </summary>
		/// <param name="value">The source matrix.</param>
		/// <returns>The negated matrix.</returns>
		public static BLMatrix2D Negate(BLMatrix2D value) {
			BLMatrix2D result;
			result.M00 = -value.M00;
			result.M01 = -value.M01;
			result.M10 = -value.M10;
			result.M11 = -value.M11;
			result.M20 = -value.M20;
			result.M21 = -value.M21;
			return result;
		}
		/// <summary>
		/// Adds each matrix element in value1 with its corresponding element in value2.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>The matrix containing the summed values.</returns>
		public static BLMatrix2D Add(BLMatrix2D value1, BLMatrix2D value2) {
			BLMatrix2D result;
			result.M00 = value1.M00 + value2.M00;
			result.M01 = value1.M01 + value2.M01;
			result.M10 = value1.M10 + value2.M10;
			result.M11 = value1.M11 + value2.M11;
			result.M20 = value1.M20 + value2.M20;
			result.M21 = value1.M21 + value2.M21;
			return result;
		}
		/// <summary>
		/// Subtracts each matrix element in value2 from its corresponding element in value1.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>The matrix containing the resulting values.</returns>
		public static BLMatrix2D Subtract(BLMatrix2D value1, BLMatrix2D value2) {
			BLMatrix2D result;
			result.M00 = value1.M00 - value2.M00;
			result.M01 = value1.M01 - value2.M01;
			result.M10 = value1.M10 - value2.M10;
			result.M11 = value1.M11 - value2.M11;
			result.M20 = value1.M20 - value2.M20;
			result.M21 = value1.M21 - value2.M21;
			return result;
		}
		/// <summary>
		/// Multiplies two matrices together and returns the resulting matrix.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>The product matrix.</returns>
		public static BLMatrix2D Multiply(BLMatrix2D value1, BLMatrix2D value2) {
			BLMatrix2D result;
			// First row
			result.M00 = value1.M00 * value2.M00 + value1.M01 * value2.M10;
			result.M01 = value1.M00 * value2.M01 + value1.M01 * value2.M11;
			// Second row
			result.M10 = value1.M10 * value2.M00 + value1.M11 * value2.M10;
			result.M11 = value1.M10 * value2.M01 + value1.M11 * value2.M11;
			// Third row
			result.M20 = value1.M20 * value2.M00 + value1.M21 * value2.M10 + value2.M20;
			result.M21 = value1.M20 * value2.M01 + value1.M21 * value2.M11 + value2.M21;
			return result;
		}
		/// <summary>
		/// Scales all elements in a matrix by the given scalar factor.
		/// </summary>
		/// <param name="value1">The source matrix.</param>
		/// <param name="value2">The scaling value to use.</param>
		/// <returns>The resulting matrix.</returns>
		public static BLMatrix2D Multiply(BLMatrix2D value1, Double value2) {
			BLMatrix2D result;
			result.M00 = value1.M00 * value2;
			result.M01 = value1.M01 * value2;
			result.M10 = value1.M10 * value2;
			result.M11 = value1.M11 * value2;
			result.M20 = value1.M20 * value2;
			result.M21 = value1.M21 * value2;
			return result;
		}
		/// <summary>
		/// Negates the given matrix by multiplying all values by -1.
		/// </summary>
		/// <param name="value">The source matrix.</param>
		/// <returns>The negated matrix.</returns>
		public static BLMatrix2D operator -(BLMatrix2D value) {
			BLMatrix2D m;
			m.M00 = -value.M00;
			m.M01 = -value.M01;
			m.M10 = -value.M10;
			m.M11 = -value.M11;
			m.M20 = -value.M20;
			m.M21 = -value.M21;
			return m;
		}
		/// <summary>
		/// Adds each matrix element in value1 with its corresponding element in value2.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>The matrix containing the summed values.</returns>
		public static BLMatrix2D operator +(BLMatrix2D value1, BLMatrix2D value2) {
			BLMatrix2D m;
			m.M00 = value1.M00 + value2.M00;
			m.M01 = value1.M01 + value2.M01;
			m.M10 = value1.M10 + value2.M10;
			m.M11 = value1.M11 + value2.M11;
			m.M20 = value1.M20 + value2.M20;
			m.M21 = value1.M21 + value2.M21;
			return m;
		}
		/// <summary>
		/// Subtracts each matrix element in value2 from its corresponding element in value1.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>The matrix containing the resulting values.</returns>
		public static BLMatrix2D operator -(BLMatrix2D value1, BLMatrix2D value2) {
			BLMatrix2D m;
			m.M00 = value1.M00 - value2.M00;
			m.M01 = value1.M01 - value2.M01;
			m.M10 = value1.M10 - value2.M10;
			m.M11 = value1.M11 - value2.M11;
			m.M20 = value1.M20 - value2.M20;
			m.M21 = value1.M21 - value2.M21;

			return m;
		}
		/// <summary>
		/// Multiplies two matrices together and returns the resulting matrix.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>The product matrix.</returns>
		public static BLMatrix2D operator *(BLMatrix2D value1, BLMatrix2D value2) {
			BLMatrix2D m;
			// First row
			m.M00 = value1.M00 * value2.M00 + value1.M01 * value2.M10;
			m.M01 = value1.M00 * value2.M01 + value1.M01 * value2.M11;
			// Second row
			m.M10 = value1.M10 * value2.M00 + value1.M11 * value2.M10;
			m.M11 = value1.M10 * value2.M01 + value1.M11 * value2.M11;
			// Third row
			m.M20 = value1.M20 * value2.M00 + value1.M21 * value2.M10 + value2.M20;
			m.M21 = value1.M20 * value2.M01 + value1.M21 * value2.M11 + value2.M21;
			return m;
		}
		/// <summary>
		/// Scales all elements in a matrix by the given scalar factor.
		/// </summary>
		/// <param name="value1">The source matrix.</param>
		/// <param name="value2">The scaling value to use.</param>
		/// <returns>The resulting matrix.</returns>
		public static BLMatrix2D operator *(BLMatrix2D value1, Double value2) {
			BLMatrix2D m;
			m.M00 = value1.M00 * value2;
			m.M01 = value1.M01 * value2;
			m.M10 = value1.M10 * value2;
			m.M11 = value1.M11 * value2;
			m.M20 = value1.M20 * value2;
			m.M21 = value1.M21 * value2;
			return m;
		}
		/// <summary>
		/// Returns a boolean indicating whether the given matrices are equal.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>True if the matrices are equal; False otherwise.</returns>
		public static Boolean operator ==(BLMatrix2D value1, BLMatrix2D value2) => (value1.M00 == value2.M00 && value1.M11 == value2.M11 && // Check diagonal element first for early out.
					value1.M01 == value2.M01 && value1.M10 == value2.M10 &&
					value1.M20 == value2.M20 && value1.M21 == value2.M21);
		/// <summary>
		/// Returns a boolean indicating whether the given matrices are not equal.
		/// </summary>
		/// <param name="value1">The first source matrix.</param>
		/// <param name="value2">The second source matrix.</param>
		/// <returns>True if the matrices are not equal; False if they are equal.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean operator !=(BLMatrix2D value1, BLMatrix2D value2) => !(value1 == value2);
		/// <summary>
		/// Returns a boolean indicating whether the matrix is equal to the other given matrix.
		/// </summary>
		/// <param name="other">The other matrix to test equality against.</param>
		/// <returns>True if this matrix is equal to other; False otherwise.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly Boolean Equals(BLMatrix2D other) => this == other;
		/// <summary>
		/// Returns a boolean indicating whether the given Object is equal to this matrix instance.
		/// </summary>
		/// <param name="obj">The Object to compare against.</param>
		/// <returns>True if the Object is equal to this matrix; False otherwise.</returns>
		public override readonly Boolean Equals(Object obj) => obj is BLMatrix2D other && Equals(other);
		/// <summary>
		/// Returns a String representing this matrix instance.
		/// </summary>
		/// <returns>The string representation.</returns>
		public override readonly String ToString() {
			CultureInfo ci = CultureInfo.CurrentCulture;
			return String.Format(ci, "{{ {{M11:{0} M12:{1}}} {{M21:{2} M22:{3}}} {{M31:{4} M32:{5}}} }}",
							M00.ToString(ci), M01.ToString(ci),
							M10.ToString(ci), M11.ToString(ci),
							M20.ToString(ci), M21.ToString(ci));
		}
		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override readonly Int32 GetHashCode() =>
			M00.GetHashCode() + M01.GetHashCode() +
			M10.GetHashCode() + M11.GetHashCode() +
			M20.GetHashCode() + M21.GetHashCode();
	}
	public struct BLFontMatrix {
		public Double m00;
		public Double m01;
		public Double m10;
		public Double m11;
	}
	public unsafe struct BLApproximationOptions {
		public BLFlattenMode flattenMode;
		public BLOffsetMode offsetMode;
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
		public BLFontFaceType faceType;
		public BLFontOutlineType outlineType;
		internal fixed uint8_t reserved8[2];
		public uint32_t glyphCount;
		public uint32_t revision;
		public uint32_t faceIndex;
		public BLFontFaceFlags faceFlags;
		public BLFontFaceDiagFlags diagFlags;
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
	public struct BLVarCore :
		IBlendObjectCore,
		IGenericMoveInitialisableAndDestroyable {
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
	public readonly struct BLTag(uint32_t value) {
		public readonly UInt32 value = value;
		public static explicit operator BLTag(String s) {
			if (Encoding.ASCII.GetByteCount(s) > 4)
				throw new ArgumentException($"OpenType tags are 4 ASCII characters long", nameof(s));
			Span<Byte> bytes = stackalloc Byte[4];
			Encoding.ASCII.GetBytes(s).CopyTo(bytes);
			return new(MemoryMarshal.Read<UInt32>(bytes));
		}
		public static implicit operator String(BLTag tag) {
			Span<UInt32> u = stackalloc UInt32[1];
			u[0] = tag.value;
			return Encoding.ASCII.GetString(MemoryMarshal.AsBytes(u));
		}
	}
}
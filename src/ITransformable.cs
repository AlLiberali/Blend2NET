using System;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;
/// <summary>
/// Provision of convenient methods to transformable constructs
/// </summary>
public interface ITransformable {
	/// <summary>
	/// Performs the transformation operation as specified by <paramref name="mat"/> matrix.
	/// </summary>
	/// <param name="mat"></param>
	BLResult Transform(BLMatrix2D mat);
	/// <summary>
	/// Performs the transformation operation as specified by <paramref name="mat"/> matrix in reverse order of multiplication.
	/// </summary>
	/// <param name="mat"></param>
	BLResult PostTransform(BLMatrix2D mat);
	/// <summary>
	/// Resets the transformation matrix to multiplicative identity
	/// </summary>
	void ResetTransform();
	/// <summary>
	/// Shifts the frame of reference by (<paramref name="dx"/>, <paramref name="dy"/>)
	/// </summary>
	/// <param name="dx">Shift vector X-axis element</param>
	/// <param name="dy">Shift vector Y-axis element</param>
	public BLResult Translate(Double dx, Double dy) => Transform(BLMatrix2D.CreateTranslation(dx, dy));
	/// <summary>
	/// Scales the context by <paramref name="factor"/>.
	/// </summary>
	/// <param name="factor">Scaling factor</param>
	public BLResult Scale(Double factor) => Transform(BLMatrix2D.CreateScale(factor, factor));
	/// <summary>
	/// Scales the context by (<paramref name="xf"/>, <paramref name="yf"/>).
	/// </summary>
	/// <param name="xf">X-axis scaling factor</param>
	/// <param name="yf">Y-axis scaling factor</param>
	public BLResult Scale(Double xf, Double yf) => Transform(BLMatrix2D.CreateScale(xf, yf));
	/// <summary>
	/// Shears the context by (<paramref name="xf"/>, <paramref name="yf"/>).
	/// </summary>
	/// <param name="xf">X-axis shearing factor</param>
	/// <param name="yf">Y-axis shearing factor</param>
	public BLResult Skew(Double xf, Double yf) => Transform(BLMatrix2D.CreateSkew(xf, yf));
	/// <summary>
	/// Rotates the context about the centre of coordinates.
	/// </summary>
	/// <param name="angle">Angle in radians</param>
	BLResult Rotate(Double angle) => Transform(BLMatrix2D.CreateRotation(angle, 0, 0));
	/// <summary>
	/// Rotates the context about (<paramref name="xc"/>, <paramref name="yc"/>).
	/// </summary>
	/// <param name="angle">Angle in radians</param>
	/// <param name="xc">Centre of rotation X-axis element</param>
	/// <param name="yc">Centre of rotation Y-axis element</param>
	public BLResult Rotate(Double angle, Double xc, Double yc) => Transform(BLMatrix2D.CreateRotation(angle, xc, yc));
	/// <summary>
	/// Shifts the frame of reference by (<paramref name="dx"/>, <paramref name="dy"/>) in reverse order of matrix multiplication.
	/// </summary>
	/// <param name="dx">Shift vector X-axis element</param>
	/// <param name="dy">Shift vector Y-axis element</param>
	public BLResult PostTranslate(Double dx, Double dy) => PostTransform(BLMatrix2D.CreateTranslation(dx, dy));
	/// <summary>
	/// Scales the context by <paramref name="factor"/>  in reverse order of matrix multiplication.
	/// </summary>
	/// <param name="factor">Scaling factor</param>
	public BLResult PostScale(Double factor) => PostTransform(BLMatrix2D.CreateScale(factor, factor));
	/// <summary>
	/// Scales the context by (<paramref name="xf"/>, <paramref name="yf"/>)  in reverse order of matrix multiplication.
	/// </summary>
	/// <param name="xf">X-axis scaling factor</param>
	/// <param name="yf">Y-axis scaling factor</param>
	public BLResult PostScale(Double xf, Double yf) => PostTransform(BLMatrix2D.CreateScale(xf, yf));
	/// <summary>
	/// Shears the context by (<paramref name="xf"/>, <paramref name="yf"/>) in reverse order of matrix multiplication.
	/// </summary>
	/// <param name="xf">X-axis shearing factor</param>
	/// <param name="yf">Y-axis shearing factor</param>
	public BLResult PostSkew(Double xf, Double yf) => PostTransform(BLMatrix2D.CreateSkew(xf, yf));
	/// <summary>
	/// Rotates the context about the centre of coordinates in reverse order of matrix multiplication.
	/// </summary>
	/// <param name="angle">Angle in radians</param>
	BLResult PostRotate(Double angle) => PostTransform(BLMatrix2D.CreateRotation(angle, 0, 0));
	/// <summary>
	/// Rotates the context about (<paramref name="xc"/>, <paramref name="yc"/>) in reverse order of matrix multiplication.
	/// </summary>
	/// <param name="angle">Angle in radians</param>
	/// <param name="xc">Centre of rotation X-axis element</param>
	/// <param name="yc">Centre of rotation Y-axis element</param>
	public BLResult PostRotate(Double angle, Double xc, Double yc) => PostTransform(BLMatrix2D.CreateRotation(angle, xc, yc));
}
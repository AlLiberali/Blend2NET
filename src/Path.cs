using System;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Represents a sequence of continuous primitives to be drawn.
/// </summary>
public sealed class Path : BlendObject<BLPathCore> {
	/// <summary>
	/// Initializes a new instance of the <see cref="Path"/> class.
	/// </summary>
	public Path() {
		core.Initialise();
	}
	/// <summary>
	/// Moves the current point in the path to the specified coordinates without drawing a line.
	/// </summary>
	/// <param name="x">The X-coordinate of the new point.</param>
	/// <param name="y">The Y-coordinate of the new point.</param>
	public BLResult MoveTo(Double x, Double y) {
		unsafe {
			fixed (BLPathCore* pcore = &core)
				return blPathMoveTo(pcore, x, y);
		}
	}
}
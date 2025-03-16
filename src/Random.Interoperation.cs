using System;
using System.Runtime.InteropServices;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA1401
#pragma warning disable CA1707
#pragma warning disable CA1711
#pragma warning disable CA2101

public sealed partial class Random {
	/// <summary>
	/// Simple pseudo random number generator based on `XORSHIFT+`, which has 64-bit seed, 128 bits of state, and full period `2^128 - 1`.
	/// </summary>
	/// <remarks>
	/// Based on a paper by Sebastiano Vigna:
	/// http://vigna.di.unimi.it/ftp/papers/xorshiftplus.pdf
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct BLRandom : IBlendStruct<BLRandom> {
		internal UInt64 data0;
		internal UInt64 data1;
		public readonly Boolean Equals(BLRandom other) => data0 == other.data0 && data1 == other.data1;
		public override readonly Boolean Equals(object obj) => obj is BLRandom other && Equals(other);
		public static Boolean operator ==(BLRandom left, BLRandom right) => left.Equals(right);
		public static Boolean operator !=(BLRandom left, BLRandom right) => !(left == right);
		public override readonly Int32 GetHashCode() => (Int32) data0;
	}
	[DllImport("blend2d")]
	public static extern BLResult blRandomReset(ref BLRandom self, UInt64 seed);
	[DllImport("blend2d")]
	public static extern UInt32 blRandomNextUInt32(ref BLRandom self);
	[DllImport("blend2d")]
	public static extern UInt64 blRandomNextUInt64(ref BLRandom self);
	[DllImport("blend2d")]
	public static extern Double blRandomNextDouble(ref BLRandom self);
}

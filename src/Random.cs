using System;

namespace AlLiberali.Blend2NET;
public sealed partial class Random : IBlendObject<Random, Random.BLRandom> {
	private BLRandom self;
	public Random() {
		Reset();
	}
	public Random(UInt64 seed) {
		Reset(seed);
	}
	public void Reset(UInt64 seed = default) {
		if (seed == default)
			seed = (UInt64) new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
		blRandomReset(ref self, seed);
	}
	public override Int32 GetHashCode() => (Int32) self.data0 * (Int32) self.data1;
	public override Boolean Equals(Object obj) => ((Random) obj) == this;
	public static Boolean operator ==(Random a, Random b) => (a.self.data0 == b.self.data0) && (a.self.data1 == b.self.data1);
	public static Boolean operator !=(Random a, Random b) => !(a == b);
	public UInt32 NextUInt32() => blRandomNextUInt32(ref self);
	public UInt64 NextUInt64() => blRandomNextUInt64(ref self);
	/// <summary>
	/// Next PRNG Double in [0, 1) range
	/// </summary>
	/// <returns></returns>
	public Double NextDouble() => blRandomNextDouble(ref self);
	public Boolean Equals(IBlendObject<Random, BLRandom> other) => other.Thyself().Equals(self);
	IBlendStruct<BLRandom> IBlendObject<Random, BLRandom>.Thyself() => self;
	R IBlendObject<Random, BLRandom>.Apply<R>(Func<IBlendStruct<BLRandom>, R> func) => func(self);
}

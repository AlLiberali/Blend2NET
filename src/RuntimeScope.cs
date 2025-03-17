using System;
using System.Runtime.InteropServices;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA1401
#pragma warning disable CA1707
#pragma warning disable CA1711
#pragma warning disable CA2101

public sealed class RuntimeScope : IBlendObject<RuntimeScope, RuntimeScope.BLRuntimeScopeCore>, IDisposable {
	public struct BLRuntimeScopeCore : IBlendStruct<BLRuntimeScopeCore> {
		internal UInt64 data0;
		public readonly Boolean Equals(BLRuntimeScopeCore other) => data0 == other.data0;
		public override readonly Boolean Equals(object obj) => obj is BLRuntimeScopeCore other && Equals(other);
		public static Boolean operator ==(BLRuntimeScopeCore left, BLRuntimeScopeCore right) => left.Equals(right);
		public static Boolean operator !=(BLRuntimeScopeCore left, BLRuntimeScopeCore right) => !(left == right);
		public override readonly Int32 GetHashCode() => (Int32) data0;
	}
	[DllImport("blend2d")]
	public static extern BLResult blRuntimeScopeBegin(ref BLRuntimeScopeCore self);
	[DllImport("blend2d")]
	public static extern BLResult blRuntimeScopeEnd(ref BLRuntimeScopeCore self);
	[DllImport("blend2d")]
	public static extern bool blRuntimeScopeIsActive(ref BLRuntimeScopeCore self);
	private BLRuntimeScopeCore self;
	private Boolean isDisposed;

	public Boolean Equals(IBlendObject<RuntimeScope, BLRuntimeScopeCore> other) => other.Thyself().Equals(self);
	IBlendStruct<BLRuntimeScopeCore> IBlendObject<RuntimeScope, BLRuntimeScopeCore>.Thyself() => self;
	R IBlendObject<RuntimeScope, BLRuntimeScopeCore>.Apply<R>(Func<IBlendStruct<BLRuntimeScopeCore>, R> func) => func(self);
	public RuntimeScope(Boolean active = true) {
		if (active)
			blRuntimeScopeBegin(ref self);
	}
	public Boolean Active {
		get => blRuntimeScopeIsActive(ref self);
		set {
			if (!Active) {
				if (value)
					blRuntimeScopeBegin(ref self);
				return;
			}
			if (value)
				return;
			var err = blRuntimeScopeEnd(ref self);
			if (err != BLResult.BL_SUCCESS)
				throw new BlendException(err);
		}
	}
	~RuntimeScope() {
		Dispose();
	}
	public void Dispose() {
		if (isDisposed)
			return;
		var err = blRuntimeScopeEnd(ref self);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		isDisposed = true;
		GC.SuppressFinalize(this);
	}
}

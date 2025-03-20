using System;

namespace AlLiberali.Blend2NET;
public sealed partial class Context : IBlendObject<Context, Context.BLContextCore>, IDisposable {
	private BLContextCore self;
	private Boolean isDisposed;
	public Context(Context other, Boolean move = false) {
		if (move)
			blContextInitMove(ref self, ref other.self);
		else
			blContextInitWeak(ref self, ref other.self);
	}
	public Context() {
		blContextInit(ref self);
	}
	~Context() {
		Dispose();
	}
	public void Dispose() {
		if (isDisposed)
			return;
		isDisposed = true;
		var err = blContextDestroy(ref self);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		GC.SuppressFinalize(this);
	}
	public Boolean Equals(IBlendObject<Context, BLContextCore> other) => other.Thyself().Equals(self);
	IBlendStruct<BLContextCore> IBlendObject<Context, BLContextCore>.Thyself() => self;
	R IBlendObject<Context, BLContextCore>.Apply<R>(Func<IBlendStruct<BLContextCore>, R> func) => func(self);
}

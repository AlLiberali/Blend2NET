using System;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Where all the drawing happens
/// </summary>
public sealed class Context : BlendObject<BLContextCore> {
	/// <summary>
	/// Global Alpha channel, default for all relevant operations, itself defaults to 1.0
	/// </summary>
	public Double Alpha {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return blContextGetGlobalAlpha(pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetGlobalAlpha(pcore, value);
			}
		}
	}
	/// <summary>
	/// Global composition operator, defaults to <see cref="BLCompOp.BL_COMP_OP_SRC_OVER"/>
	/// </summary>
	public BLCompOp CompositionOperator {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					return blContextGetCompOp(pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLContextCore* pcore = &core)
					blContextSetCompOp(pcore, value);
			}
		}
	}
	/// <summary>
	/// Flushes the context command queue synchronously
	/// </summary>
	public void Flush() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		core.Flush(BLContextFlushFlags.BL_CONTEXT_FLUSH_SYNC);
	}
	/// <summary>
	/// Flushes the context command queue asynchronously.
	/// <para/>
	/// The asynchrony is done on the native side thus this method doesn't introduce
	/// colouring to the .NET side and just returns immediately. (Well as immediately as a method call)
	/// </summary>
	public void FlushAsync() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		core.Flush();
	}
	private protected override void Destroy() {
		core.End();
		base.Destroy();
	}
}
using System;
using System.Collections.Generic;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Not to be implemented by users
/// </summary>
public abstract class BlendObject<T> : IDisposable where T : unmanaged, IGenericMoveInitialisableAndDestroyable {
	internal T core;
	internal readonly List<IDisposable> dependentDisposables = [];
	private protected BlendObject() {
	}
	private protected virtual void Destroy() {
		dependentDisposables.ForEach(disposable => disposable.Dispose());
		core.Destroy();
	}
	#region IDisposable
	private protected Boolean disposedValue;
	/// <inheritdoc/>
	~BlendObject() {
		Dispose();
	}
	/// <inheritdoc/>
	public void Dispose() {
		if (disposedValue)
			return;
		Destroy();
		disposedValue = true;
		GC.SuppressFinalize(this);
	}
	#endregion IDisposable
}
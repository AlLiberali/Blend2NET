using System;
using System.Collections;
using System.Collections.Generic;
using static AlLiberali.Blend2NET.Array_;

namespace AlLiberali.Blend2NET;

public sealed class Array<T> : IList<T>, IDisposable where T : unmanaged, IBlendObject {
	private BLArrayCore self;
	private Boolean isDisposed;
	public Int32 Count => (Int32) blArrayGetSize(ref self);
	public Int32 Capacity => (Int32) blArrayGetCapacity(ref self);
	public Boolean IsReadOnly => false;
	public T this[Int32 index] {
		get {
			T ret;
			unsafe {
				
			}
		}
		set { }
	}
	internal Array() {
	}
	~Array() {
		Dispose();
	}
	public void Dispose() {
		if (isDisposed)
			return;
		isDisposed = true;
		GC.SuppressFinalize(this);
	}

	public Int32 IndexOf(T item) => throw new NotImplementedException();
	public void Insert(Int32 index, T item) {
		BLResult err = item switch {
			Byte v => blArrayInsertU8(ref self, (IntPtr) index, v),
			SByte v => blArrayInsertU8(ref self, (IntPtr) index, (Byte) v),
			UInt16 v => blArrayInsertU16(ref self, (IntPtr) index, v),
			Int16 v => blArrayInsertU16(ref self, (IntPtr) index, (UInt16) v),
			UInt32 v => blArrayInsertU32(ref self, (IntPtr) index, v),
			Int32 v => blArrayInsertU32(ref self, (IntPtr) index, (UInt32) v),
			UInt64 v => blArrayInsertU64(ref self, (IntPtr) index, v),
			Int64 v => blArrayInsertU64(ref self, (IntPtr) index, (UInt64) v),
			Single v => blArrayInsertF32(ref self, (IntPtr) index, v),
			Double v => blArrayInsertF64(ref self, (IntPtr) index, v),
			IBlendObject o => o.Apply((IBlendStruct s) => blArrayInsertItem(ref self, (IntPtr) index, ref s))
		};
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	public void RemoveAt(Int32 index) {
		var err = blArrayRemoveIndex(ref self, (IntPtr) index);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	public void Add(T item) {
		BLResult err = item switch {
			Byte v => blArrayAppendU8(ref self, v),
			SByte v => blArrayAppendU8(ref self, (Byte) v),
			UInt16 v => blArrayAppendU16(ref self, v),
			Int16 v => blArrayAppendU16(ref self, (UInt16) v),
			UInt32 v => blArrayAppendU32(ref self, v),
			Int32 v => blArrayAppendU32(ref self, (UInt32) v),
			UInt64 v => blArrayAppendU64(ref self, v),
			Int64 v => blArrayAppendU64(ref self, (UInt64) v),
			Single v => blArrayAppendF32(ref self, v),
			Double v => blArrayAppendF64(ref self, v),
			IBlendObject o => o.Apply((IBlendStruct s) => blArrayAppendItem(ref self, ref s))
		};
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	/// <summary>
	/// Removes all items from <see cref="Array{T}"/>
	/// </summary>
	/// <exception cref="BlendException"></exception>
	public void Clear() {
		var err = blArrayClear(ref self);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	public Boolean Contains(T item) => throw new NotImplementedException();
	public void CopyTo(T[] array, Int32 arrayIndex) => throw new NotImplementedException();
	public Boolean Remove(T item) => throw new NotImplementedException();
	public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

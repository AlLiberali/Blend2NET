using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static AlLiberali.Blend2NET.Array_;

namespace AlLiberali.Blend2NET;

public sealed class PrimitiveArray<T> : IList<T>, IDisposable where T : unmanaged, IComparable<T> { // No INumber in netstandard 2.1 :(
	private BLArrayCore self;
	private Boolean isDisposed;
	public Int32 Count => (Int32) blArrayGetSize(ref self);
	public Int32 Capacity => (Int32) blArrayGetCapacity(ref self);
	public Boolean IsReadOnly => false;
	public T this[Int32 index] {
		get {
			if (!(0 <= index || index < Count))
				throw new ArgumentOutOfRangeException(nameof(index));
			IntPtr p = IntPtr.Add(blArrayGetData(ref self), index * (Int32) blArrayGetItemSize(ref self));
			return Marshal.PtrToStructure<T>(p);
		}
		set {
			if (!(0 <= index || index < Count))
				throw new ArgumentOutOfRangeException(nameof(index));
			BLResult err = value switch {
				Byte v => blArrayReplaceU8(ref self, (IntPtr) index, v),
				SByte v => blArrayReplaceU8(ref self, (IntPtr) index, (Byte) v),
				UInt16 v => blArrayReplaceU16(ref self, (IntPtr) index, v),
				Int16 v => blArrayReplaceU16(ref self, (IntPtr) index, (UInt16) v),
				UInt32 v => blArrayReplaceU32(ref self, (IntPtr) index, v),
				Int32 v => blArrayReplaceU32(ref self, (IntPtr) index, (UInt32) v),
				UInt64 v => blArrayReplaceU64(ref self, (IntPtr) index, v),
				Int64 v => blArrayReplaceU64(ref self, (IntPtr) index, (UInt64) v),
				Single v => blArrayReplaceF32(ref self, (IntPtr) index, v),
				Double v => blArrayReplaceF64(ref self, (IntPtr) index, v),
				_ => throw new NotSupportedException()
			};
			if (err != BLResult.BL_SUCCESS)
				throw new BlendException(err);
		}
	}
	public PrimitiveArray() {
		T dummy = default;
		BLResult err = dummy switch {
			Byte v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT8),
			SByte v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT8),
			UInt16 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT16),
			Int16 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT16),
			UInt32 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT32),
			Int32 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT32),
			UInt64 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT64),
			Int64 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT64),
			Single v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_FLOAT32),
			Double v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_FLOAT64),
			_ => throw new NotSupportedException()
		};
	}
	public PrimitiveArray(PrimitiveArray<T> other, Boolean move = false) {
		if (move)
			blArrayInitMove(ref self, ref other.self);
		else
			blArrayInitWeak(ref self, ref other.self);
	}
	~PrimitiveArray() {
		Dispose();
	}
	public void Dispose() {
		if (isDisposed)
			return;
		isDisposed = true;
		var err = blArrayDestroy(ref self);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		GC.SuppressFinalize(this);
	}
	public Int32 IndexOf(T item) {
		for (Int32 i = 0; i < Count; i++)
			if (this[i].CompareTo(item) == 0)
				return i;
		return -1;
	}
	public void Insert(Int32 index, T item) {
		if (!(0 <= index || index < Count))
			throw new ArgumentOutOfRangeException(nameof(index));
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
			_ => throw new NotSupportedException()
		};
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	public void RemoveAt(Int32 index) {
		if (!(0 <= index || index < Count))
			throw new ArgumentOutOfRangeException(nameof(index));
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
			_ => throw new NotSupportedException()
		};
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	public void AddRange(IEnumerable<T> collection) {
		if (collection is null)
			throw new ArgumentNullException(nameof(collection));
		foreach (T item in collection)
			Add(item);
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
	public Boolean Contains(T item) => IndexOf(item) != -1;
	public Boolean Exists(Predicate<T> match) {
		if (match is null)
			throw new ArgumentNullException(nameof(match));
		return this.AsParallel().Any(item => match(item));
	}
	public void ForEach(Action<T> action) {
		if (action is null)
			throw new ArgumentNullException(nameof(action));
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++) {
			action(Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize)));
		}
	}
	public Int32 FindIndex(Predicate<T> match) {
		if (match is null)
			throw new ArgumentNullException(nameof(match));
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++) {
			T item = Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize));
			if (match(item))
				return i;
		}
		return -1;
	}
	public T? Find(Predicate<T> match) {
		var i = FindIndex(match);
		return i != -1 ? this[i] : null;
	}
	public void CopyTo(T[] array, Int32 arrayIndex) {
		if (array is null)
			throw new ArgumentNullException(nameof(array));
		if (arrayIndex < 0)
			throw new ArgumentOutOfRangeException(nameof(arrayIndex));
		if (array.Length - arrayIndex < Count)
			throw new ArgumentException("Insufficient space betwixt arrayIndex and the end of the array");
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++)
			array[i + arrayIndex] = Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize));
	}
	public PrimitiveArray<TOutput> ConvertAll<TOutput>(Func<T, TOutput> converter) where TOutput : unmanaged, IComparable<TOutput> {
		if (converter is null)
			throw new ArgumentNullException(nameof(converter));
		var ret = new PrimitiveArray<TOutput>();
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++)
			ret.Add(converter(Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize))));
		return ret;
	}
	public Boolean Remove(T item) {
		var i = IndexOf(item);
		if (i == -1)
			return false;
		RemoveAt(i);
		return true;
	}
	public Int32 EnsureCapacity(Int32 capacity) {
		if (Capacity >= capacity)
			return Capacity;
		var err = blArrayReserve(ref self, (IntPtr) capacity);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		return Capacity;
	}

	public IEnumerator<T> GetEnumerator() {
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++)
			yield return Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize));
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
public sealed class ObjectArray<T> : IList<T>, IBlendObject<ObjectArray<T>, BLArrayCore>, IDisposable where T : class, IBlendObject<ObjectArray<T>, BLArrayCore> {
	private BLArrayCore self;
	private Boolean isDisposed;
	public Int32 Count => (Int32) blArrayGetSize(ref self);
	public Int32 Capacity => (Int32) blArrayGetCapacity(ref self);
	public Boolean IsReadOnly => false;
	public T this[Int32 index] {
		get {
			if (!(0 <= index || index < Count))
				throw new ArgumentOutOfRangeException(nameof(index));
			IntPtr p = IntPtr.Add(blArrayGetData(ref self), index * (Int32) blArrayGetItemSize(ref self));
			return Marshal.PtrToStructure<T>(p);
		}
		set {
			if (!(0 <= index || index < Count))
				throw new ArgumentOutOfRangeException(nameof(index));
			BLResult err = value switch {
				Byte v => blArrayReplaceU8(ref self, (IntPtr) index, v),
				SByte v => blArrayReplaceU8(ref self, (IntPtr) index, (Byte) v),
				UInt16 v => blArrayReplaceU16(ref self, (IntPtr) index, v),
				Int16 v => blArrayReplaceU16(ref self, (IntPtr) index, (UInt16) v),
				UInt32 v => blArrayReplaceU32(ref self, (IntPtr) index, v),
				Int32 v => blArrayReplaceU32(ref self, (IntPtr) index, (UInt32) v),
				UInt64 v => blArrayReplaceU64(ref self, (IntPtr) index, v),
				Int64 v => blArrayReplaceU64(ref self, (IntPtr) index, (UInt64) v),
				Single v => blArrayReplaceF32(ref self, (IntPtr) index, v),
				Double v => blArrayReplaceF64(ref self, (IntPtr) index, v),
				_ => throw new NotSupportedException()
			};
			if (err != BLResult.BL_SUCCESS)
				throw new BlendException(err);
		}
	}
	public ObjectArray() {
		T? dummy = default;
		BLResult err = dummy switch {
			Byte v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT8),
			SByte v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT8),
			UInt16 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT16),
			Int16 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT16),
			UInt32 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT32),
			Int32 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT32),
			UInt64 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT64),
			Int64 v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_INT64),
			Single v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_FLOAT32),
			Double v => blArrayInit(ref self, BLObjectType.BL_OBJECT_TYPE_ARRAY_FLOAT64),
			_ => throw new NotSupportedException()
		};
	}
	public ObjectArray(ObjectArray<T> other, Boolean move = false) {
		if (move)
			blArrayInitMove(ref self, ref other.self);
		else
			blArrayInitWeak(ref self, ref other.self);
	}
	~ObjectArray() {
		Dispose();
	}
	public void Dispose() {
		if (isDisposed)
			return;
		isDisposed = true;
		var err = blArrayDestroy(ref self);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		GC.SuppressFinalize(this);
	}
	public Int32 IndexOf(T item) {
		for (Int32 i = 0; i < Count; i++)
			if (this[i].Equals(item))
				return i;
		return -1;
	}
	public void Insert(Int32 index, T item) {
		if (!(0 <= index || index < Count))
			throw new ArgumentOutOfRangeException(nameof(index));
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
			_ => throw new NotSupportedException()
		};
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	public void RemoveAt(Int32 index) {
		if (!(0 <= index || index < Count))
			throw new ArgumentOutOfRangeException(nameof(index));
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
			_ => throw new NotSupportedException()
		};
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
	}
	public void AddRange(IEnumerable<T> collection) {
		if (collection is null)
			throw new ArgumentNullException(nameof(collection));
		foreach (T item in collection)
			Add(item);
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
	public Boolean Contains(T item) => IndexOf(item) != -1;
	public Boolean Exists(Predicate<T> match) {
		if (match is null)
			throw new ArgumentNullException(nameof(match));
		return this.AsParallel().Any(item => match(item));
	}
	public void ForEach(Action<T> action) {
		if (action is null)
			throw new ArgumentNullException(nameof(action));
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++) {
			action(Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize)));
		}
	}
	public Int32 FindIndex(Predicate<T> match) {
		if (match is null)
			throw new ArgumentNullException(nameof(match));
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++) {
			T item = Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize));
			if (match(item))
				return i;
		}
		return -1;
	}
	public T? Find(Predicate<T> match) {
		var i = FindIndex(match);
		return i != -1 ? this[i] : null;
	}
	public void CopyTo(T[] array, Int32 arrayIndex) {
		if (array is null)
			throw new ArgumentNullException(nameof(array));
		if (arrayIndex < 0)
			throw new ArgumentOutOfRangeException(nameof(arrayIndex));
		if (array.Length - arrayIndex < Count)
			throw new ArgumentException("Insufficient space betwixt arrayIndex and the end of the array");
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++)
			array[i + arrayIndex] = Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize));
	}
	public PrimitiveArray<TOutput> ConvertAll<TOutput>(Func<T, TOutput> converter) where TOutput : unmanaged, IComparable<TOutput> {
		if (converter is null)
			throw new ArgumentNullException(nameof(converter));
		var ret = new PrimitiveArray<TOutput>();
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++)
			ret.Add(converter(Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize))));
		return ret;
	}
	public Boolean Remove(T item) {
		var i = IndexOf(item);
		if (i == -1)
			return false;
		RemoveAt(i);
		return true;
	}
	public Int32 EnsureCapacity(Int32 capacity) {
		if (Capacity >= capacity)
			return Capacity;
		var err = blArrayReserve(ref self, (IntPtr) capacity);
		if (err != BLResult.BL_SUCCESS)
			throw new BlendException(err);
		return Capacity;
	}

	public IEnumerator<T> GetEnumerator() {
		IntPtr p = blArrayGetData(ref self);
		Int32 itemSize = (Int32) blArrayGetItemSize(ref self);
		for (Int32 i = 0; i < Count; i++)
			yield return Marshal.PtrToStructure<T>(IntPtr.Add(p, i * itemSize));
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public Boolean Equals(IBlendObject<ObjectArray<T>, BLArrayCore> other) => other.Thyself().Equals(self);
	IBlendStruct<BLArrayCore> IBlendObject<ObjectArray<T>, BLArrayCore>.Thyself() => self;
	R IBlendObject<ObjectArray<T>, BLArrayCore>.Apply<R>(Func<IBlendStruct<BLArrayCore>, R> func) => func(self);
}
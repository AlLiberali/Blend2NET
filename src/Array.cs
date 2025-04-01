using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// Blend2D implementation of a dynamic array.
/// Some procedures within its API require it.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class Array<T> : BlendObject<BLArrayCore>, IList<T> where T : unmanaged {
	/// <summary>
	/// An empty Blend2D array of <typeparamref name="T"/> where <typeparamref name="T"/> is:
	/// <list type="bullet">
	/// <item>An 8, 16, 32 or 64 bit integer, signed or unsigned</item>
	/// <item>An <see cref="IBlendObjectCore"/> struct. Substructs of <see cref="PInvoke"/></item>
	/// <item>Any 1, 2, 3, 4, 6, 8, 10, 12, 16, 20, 24 or 32 byte wide struct</item>
	/// </list>
	/// I would've specified more type constraints in code but this library is targeting netstandard2.1
	/// </summary>
	/// <exception cref="NotImplementedException">When an unsupported <typeparamref name="T"/> is to be constructed</exception>
	/// <seealso cref="BLArrayCore"/>
	public Array() {
		T v = default;
		unsafe {
			fixed (BLArrayCore* pcore = &core)
				_ = blArrayInit(pcore, v switch {
					SByte _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_INT8,
					Byte _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT8,
					Int16 _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_INT16,
					UInt16 _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT16,
					Int32 _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_INT32,
					UInt32 _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT32,
					Int64 _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_INT64,
					UInt64 _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_UINT64,
					Single _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_FLOAT32,
					Double _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_FLOAT64,
					IBlendObjectCore _ => BLObjectType.BL_OBJECT_TYPE_ARRAY_OBJECT,
					_ => sizeof(T) switch {
						1 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_1,
						2 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_2,
						3 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_3,
						4 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_4,
						6 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_6,
						8 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_8,
						10 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_10,
						12 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_12,
						16 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_16,
						20 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_20,
						24 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_24,
						32 => BLObjectType.BL_OBJECT_TYPE_ARRAY_STRUCT_32,
						_ => throw new NotImplementedException("")
					}
				});
		}
	}
	/// <summary>
	/// A weak copy of <paramref name="other"/> when <paramref name="move"/> is <see langword="false"/>;
	/// <paramref name="other"/> reset and its members move to this new instance otherwise.
	/// </summary>
	/// <param name="other">The other array instance to be weakly copied or reset</param>
	/// <param name="move">Whether to move or to weakly copy</param>
	public Array(Array<T> other, Boolean move = false) {
		if (move)
			core.MoveInitialise(ref other.core);
		else
			core.WeakCopyInitialise(ref other.core);
	}
	#region IList<T>
	/// <inheritdoc/>
	public T this[Int32 index] {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.Get<T>(index) ?? throw new ArgumentOutOfRangeException(nameof(index));
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			if (core.Set<T>(index, value) != BLResult.BL_SUCCESS)
				throw new ArgumentOutOfRangeException(nameof(index));
		}
	}
	/// <inheritdoc/>
	public Int32 Count {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return (Int32) core.Size();
		}
	}
	/// <inheritdoc/>
	public Boolean IsReadOnly => false;
	/// <inheritdoc/>
	public void Add(T item) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		if (core.Append(item) != BLResult.BL_SUCCESS)
			throw new NotSupportedException();
	}
	/// <inheritdoc/>
	public void Clear() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		core.Clear();
	}
	/// <inheritdoc/>
	public Boolean Contains(T item) => IndexOf(item) != -1;
	/// <inheritdoc/>
	public void CopyTo(T[] array, Int32 arrayIndex) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		if (array is null)
			throw new ArgumentNullException(nameof(array));
		if (arrayIndex < 0)
			throw new ArgumentOutOfRangeException(nameof(arrayIndex));
		if ((array.Length - arrayIndex) < core.Size())
			throw new ArgumentException("Array larger than the space passed to this method for it to be copied into");
		unsafe {
			Byte* pdata;
			Int32 itemSize;
			fixed (BLArrayCore* pcore = &core) {
				pdata = (Byte*) blArrayGetData(pcore);
				itemSize = (Int32) blArrayGetItemSize(pcore);
			}
			itemSize *= (Int32) core.Size();
			fixed (T* parr = &array[arrayIndex]) {
				Byte* parray = (Byte*) parr;
				for (int i = 0; i < itemSize; i++) {
					*parray = *pdata;
					parray++;
					pdata++;
				}
			}
		}
	}
	/// <inheritdoc/>
	public IEnumerator<T> GetEnumerator() {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		T[] items = new T[(Int32) core.Size()];
		CopyTo(items, 0);
		for (Int32 i = 0; i < core.Size(); i++)
			yield return items[i];
	}
	/// <inheritdoc/>
	public Int32 IndexOf(T item) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		ReadOnlySpan<Byte> itemSpan = MemoryMarshal.Cast<T, Byte>(MemoryMarshal.CreateReadOnlySpan(ref item, 1));
		unsafe {
			T* pdata = null;
			fixed (BLArrayCore* pcore = &core) {
				pdata = (T*) blArrayGetData(pcore);
			}
			if (pdata is null)
				return -1;
			ReadOnlySpan<T> haySpan = new ReadOnlySpan<T>(pdata, (Int32) core.Size());
			T needle;
			ReadOnlySpan<Byte> needleSpan;
			for (int i = 0; i < Count; i++) {
				needle = haySpan[i];
				needleSpan = MemoryMarshal.Cast<T, Byte>(MemoryMarshal.CreateReadOnlySpan(ref needle, 1));
				if (needleSpan.SequenceEqual(itemSpan))
					return i;
			}
		}
		return -1;
	}
	/// <inheritdoc/>
	public void Insert(Int32 index, T item) {
		BLResult err = core.Insert(index, item);
		if (err == BLResult.BL_ERROR_INVALID_KEY)
			throw new ArgumentOutOfRangeException(nameof(index));
		else if (err != BLResult.BL_SUCCESS)
			throw new NotSupportedException();
	}
	/// <inheritdoc/>
	public Boolean Remove(T item) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		Int32 index = IndexOf(item);
		if (index == -1)
			return false;
		if (core.Remove(index) != BLResult.BL_SUCCESS)
			return false;
		return true;
	}
	/// <inheritdoc/>
	public void RemoveAt(Int32 index) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		if (core.Remove(index) == BLResult.BL_ERROR_INVALID_KEY)
			throw new ArgumentOutOfRangeException(nameof(index));
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	#endregion IList<T>
}
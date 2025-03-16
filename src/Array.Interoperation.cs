using System;
using System.Runtime.InteropServices;
using size_t = System.IntPtr;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA1010
#pragma warning disable CA1401
#pragma warning disable CA1707
#pragma warning disable CA1711
#pragma warning disable CA2101

public static class Array_ {
	[StructLayout(LayoutKind.Sequential)]
	public struct BLArrayCore : IBlendStruct<BLArrayCore> {
		internal IntPtr impl;
		private readonly IntPtr internals;
		public readonly Boolean Equals(BLArrayCore other) => impl == other.impl && internals == other.internals;
		public override readonly Boolean Equals(object obj) => obj is BLArrayCore other && Equals(other);
		public static Boolean operator ==(BLArrayCore left, BLArrayCore right) => left.Equals(right);
		public static Boolean operator !=(BLArrayCore left, BLArrayCore right) => !(left == right);
		public override readonly Int32 GetHashCode() => (Int32) impl;
	}
	[DllImport("blend2d")]
	public static extern BLResult blArrayInit(ref BLArrayCore self, BLObjectType arrayType);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInitMove(ref BLArrayCore self, ref BLArrayCore other);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInitWeak(ref BLArrayCore self, ref BLArrayCore other);
	[DllImport("blend2d")]
	public static extern BLResult blArrayDestroy(ref BLArrayCore self);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReset(ref BLArrayCore self);
	[DllImport("blend2d")]
	public static extern size_t blArrayGetSize(ref BLArrayCore self);
	[DllImport("blend2d")]
	public static extern size_t blArrayGetCapacity(ref BLArrayCore self);
	[DllImport("blend2d")]
	public static extern size_t blArrayGetItemSize(ref BLArrayCore self);
	[DllImport("blend2d")]
	public unsafe static extern IntPtr blArrayGetData(ref BLArrayCore self);
	[DllImport("blend2d")]
	public static extern BLResult blArrayClear(ref BLArrayCore self);
	[DllImport("blend2d")]
	public static extern BLResult blArrayShrink(ref BLArrayCore self);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReserve(ref BLArrayCore self, size_t n);
	[DllImport("blend2d")]
	public static extern BLResult blArrayResize(ref BLArrayCore self, size_t n, IntPtr fill);
	[DllImport("blend2d")]
	public static extern BLResult blArrayMakeMutable(ref BLArrayCore self, out IntPtr dataOut);
	[DllImport("blend2d")]
	public static extern BLResult blArrayModifyOp(ref BLArrayCore self, BLModifyOp op, size_t n, out IntPtr dataOut);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertOp(ref BLArrayCore self, size_t index, size_t n, out IntPtr dataOut);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAssignMove(ref BLArrayCore self, ref BLArrayCore other);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAssignWeak(ref BLArrayCore self, ref BLArrayCore other);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAssignDeep(ref BLArrayCore self, ref BLArrayCore other);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAssignData(ref BLArrayCore self, IntPtr data, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAssignExternalData(ref BLArrayCore self, void* data, size_t size, size_t capacity, BLDataAccessFlags dataAccessFlags, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendU8(ref BLArrayCore self, Byte value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendU16(ref BLArrayCore self, UInt16 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendU32(ref BLArrayCore self, UInt32 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendU64(ref BLArrayCore self, UInt64 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendF32(ref BLArrayCore self, float value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendF64(ref BLArrayCore self, double value);
	internal static BLResult blArrayAppendItem<T>(ref BLArrayCore self, ref IBlendStruct<T> item) {
		var mem = Marshal.AllocHGlobal(Marshal.SizeOf(item));
		Marshal.StructureToPtr(item, mem, false);
		var ret = blArrayAppendItem(ref self, mem);
		Marshal.FreeHGlobal(mem);
		return ret;
	}
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendItem(ref BLArrayCore self, IntPtr item);
	[DllImport("blend2d")]
	public static extern BLResult blArrayAppendData(ref BLArrayCore self, IntPtr data, size_t n);

	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertU8(ref BLArrayCore self, size_t index, Byte value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertU16(ref BLArrayCore self, size_t index, UInt16 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertU32(ref BLArrayCore self, size_t index, UInt32 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertU64(ref BLArrayCore self, size_t index, UInt64 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertF32(ref BLArrayCore self, size_t index, float value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertF64(ref BLArrayCore self, size_t index, double value);
	internal static BLResult blArrayInsertItem<T>(ref BLArrayCore self, size_t index, ref IBlendStruct<T> item) {
		var mem = Marshal.AllocHGlobal(Marshal.SizeOf(item));
		Marshal.StructureToPtr(item, mem, false);
		var ret = blArrayInsertItem(ref self, index, mem);
		Marshal.FreeHGlobal(mem);
		return ret;
	}
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertItem(ref BLArrayCore self, size_t index, IntPtr item);
	[DllImport("blend2d")]
	public static extern BLResult blArrayInsertData(ref BLArrayCore self, size_t index, IntPtr data, size_t n);

	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceU8(ref BLArrayCore self, size_t index, Byte value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceU16(ref BLArrayCore self, size_t index, UInt16 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceU32(ref BLArrayCore self, size_t index, UInt32 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceU64(ref BLArrayCore self, size_t index, UInt64 value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceF32(ref BLArrayCore self, size_t index, float value);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceF64(ref BLArrayCore self, size_t index, double value);
	internal static BLResult blArrayReplaceItem<T>(ref BLArrayCore self, size_t index, ref IBlendStruct<T> item) {
		var mem = Marshal.AllocHGlobal(Marshal.SizeOf(item));
		Marshal.StructureToPtr(item, mem, false);
		var ret = blArrayReplaceItem(ref self, index, mem);
		Marshal.FreeHGlobal(mem);
		return ret;
	}
	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceItem(ref BLArrayCore self, size_t index, IntPtr item);
	[DllImport("blend2d")]
	public static extern BLResult blArrayReplaceData(ref BLArrayCore self, size_t rStart, size_t rEnd, IntPtr data, size_t n);
	[DllImport("blend2d")]
	public static extern BLResult blArrayRemoveIndex(ref BLArrayCore self, size_t index);
	[DllImport("blend2d")]
	public static extern BLResult blArrayRemoveRange(ref BLArrayCore self, size_t rStart, size_t rEnd);
	[DllImport("blend2d")]
	public static extern bool blArrayEquals(ref BLArrayCore a, ref BLArrayCore b);
}

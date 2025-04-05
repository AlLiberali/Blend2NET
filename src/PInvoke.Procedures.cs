using System;
using System.Runtime.InteropServices;
using BLGlyphId = System.UInt32;
using BLTag = System.UInt32;
using int32_t = System.Int32;
using int64_t = System.Int64;
using intptr_t = System.IntPtr;
using size_t = System.IntPtr;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable CS1591
#pragma warning disable CA1401
#pragma warning disable CA1711
#pragma warning disable CA2101

/// Platform/Invoke method signatures to the Blend2D C API
public static partial class PInvoke {
	#region object
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectAllocImpl(BLObjectCore* self, BLObjectInfoBits objectInfo, size_t implSize);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectAllocImplAligned(BLObjectCore* self, BLObjectInfoBits objectInfo, size_t implSize, size_t implAlignment);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectAllocImplExternal(BLObjectCore* self, BLObjectInfoBits objectInfo, size_t implSize, [MarshalAs(UnmanagedType.U8)] Boolean immutable, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectFreeImpl(void* impl);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectInitMove(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectInitWeak(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectReset(void* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectAssignMove(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectAssignWeak(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectGetProperty(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, BLVarCore* valueOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectGetPropertyBool(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, bool* valueOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectGetPropertyInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int32_t* valueOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectGetPropertyInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int64_t* valueOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectGetPropertyUInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint32_t* valueOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectGetPropertyUInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint64_t* valueOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectGetPropertyDouble(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, Double* valueOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectSetProperty(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, void* value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectSetPropertyBool(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, [MarshalAs(UnmanagedType.U8)] Boolean value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectSetPropertyInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectSetPropertyInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectSetPropertyUInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectSetPropertyUInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blObjectSetPropertyDouble(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, Double value);
	#endregion object
	#region array
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInit(BLArrayCore* self, BLObjectType arrayType);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInitMove(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInitWeak(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayDestroy(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReset(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blArrayGetSize(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blArrayGetCapacity(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blArrayGetItemSize(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe void* blArrayGetData(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayClear(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayShrink(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReserve(BLArrayCore* self, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayResize(BLArrayCore* self, size_t n, void* fill);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayMakeMutable(BLArrayCore* self, void** dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayModifyOp(BLArrayCore* self, BLModifyOp op, size_t n, void** dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertOp(BLArrayCore* self, size_t index, size_t n, void** dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAssignMove(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAssignWeak(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAssignDeep(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAssignData(BLArrayCore* self, void* data, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAssignExternalData(BLArrayCore* self, void* data, size_t size, size_t capacity, BLDataAccessFlags dataAccessFlags, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendU8(BLArrayCore* self, uint8_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendU16(BLArrayCore* self, uint16_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendU32(BLArrayCore* self, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendU64(BLArrayCore* self, uint64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendF32(BLArrayCore* self, float value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendF64(BLArrayCore* self, Double value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendItem(BLArrayCore* self, void* item);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayAppendData(BLArrayCore* self, void* data, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertU8(BLArrayCore* self, size_t index, uint8_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertU16(BLArrayCore* self, size_t index, uint16_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertU32(BLArrayCore* self, size_t index, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertU64(BLArrayCore* self, size_t index, uint64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertF32(BLArrayCore* self, size_t index, float value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertF64(BLArrayCore* self, size_t index, Double value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertItem(BLArrayCore* self, size_t index, void* item);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayInsertData(BLArrayCore* self, size_t index, void* data, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceU8(BLArrayCore* self, size_t index, uint8_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceU16(BLArrayCore* self, size_t index, uint16_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceU32(BLArrayCore* self, size_t index, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceU64(BLArrayCore* self, size_t index, uint64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceF32(BLArrayCore* self, size_t index, float value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceF64(BLArrayCore* self, size_t index, Double value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceItem(BLArrayCore* self, size_t index, void* item);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayReplaceData(BLArrayCore* self, size_t rStart, size_t rEnd, void* data, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayRemoveIndex(BLArrayCore* self, size_t index);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blArrayRemoveRange(BLArrayCore* self, size_t rStart, size_t rEnd);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blArrayEquals(BLArrayCore* a, BLArrayCore* b);
	#endregion array
	#region bitarray
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayInit(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayInitMove(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayInitWeak(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayDestroy(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayReset(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayAssignMove(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayAssignWeak(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayAssignWords(BLBitArrayCore* self, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitArrayIsEmpty(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitArrayGetSize(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitArrayGetWordCount(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitArrayGetCapacity(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t* blBitArrayGetData(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitArrayGetCardinality(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitArrayGetCardinalityInRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitArrayHasBit(BLBitArrayCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitArrayHasBitsInRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitArraySubsumes(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitArrayIntersects(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitArrayGetRange(BLBitArrayCore* self, uint32_t* startOut, uint32_t* endOut);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitArrayEquals(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitArrayCompare(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayClear(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayResize(BLBitArrayCore* self, uint32_t nBits);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayReserve(BLBitArrayCore* self, uint32_t nBits);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayShrink(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArraySetBit(BLBitArrayCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayFillRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayFillWords(BLBitArrayCore* self, uint32_t bitIndex, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayClearBit(BLBitArrayCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayClearRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayClearWord(BLBitArrayCore* self, uint32_t bitIndex, uint32_t wordValue);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayClearWords(BLBitArrayCore* self, uint32_t bitIndex, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayReplaceOp(BLBitArrayCore* self, uint32_t nBits, uint32_t** dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayReplaceBit(BLBitArrayCore* self, uint32_t bitIndex, [MarshalAs(UnmanagedType.U8)] Boolean bitValue);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayReplaceWord(BLBitArrayCore* self, uint32_t bitIndex, uint32_t wordValue);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayReplaceWords(BLBitArrayCore* self, uint32_t bitIndex, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayAppendBit(BLBitArrayCore* self, [MarshalAs(UnmanagedType.U8)] Boolean bitValue);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayAppendWord(BLBitArrayCore* self, uint32_t wordValue);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitArrayAppendWords(BLBitArrayCore* self, uint32_t* wordData, uint32_t wordCount);
	#endregion bitarray
	#region bitset
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetInit(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetInitMove(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetInitWeak(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetInitRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetDestroy(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetReset(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAssignMove(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAssignWeak(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAssignDeep(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAssignRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAssignWords(BLBitSetCore* self, uint32_t startWord, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitSetIsEmpty(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetGetData(BLBitSetCore* self, BLBitSetData* @out);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitSetGetSegmentCount(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitSetGetSegmentCapacity(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitSetGetCardinality(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitSetGetCardinalityInRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitSetHasBit(BLBitSetCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitSetHasBitsInRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitSetSubsumes(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitSetIntersects(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitSetGetRange(BLBitSetCore* self, uint32_t* startOut, uint32_t* endOut);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blBitSetEquals(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blBitSetCompare(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetClear(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetShrink(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetOptimize(BLBitSetCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetChop(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAddBit(BLBitSetCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAddRange(BLBitSetCore* self, uint32_t rangeStartBit, uint32_t rangeEndBit);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetAddWords(BLBitSetCore* self, uint32_t startWord, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetClearBit(BLBitSetCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blBitSetClearRange(BLBitSetCore* self, uint32_t rangeStartBit, uint32_t rangeEndBit);
	#endregion bitset
	#region file
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileInit(BLFileCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileReset(BLFileCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileOpen(BLFileCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileOpenFlags openFlags);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileClose(BLFileCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileSeek(BLFileCore* self, int64_t offset, BLFileSeekType seekType, int64_t* positionOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileRead(BLFileCore* self, void* buffer, size_t n, size_t* bytesReadOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileWrite(BLFileCore* self, void* buffer, size_t n, size_t* bytesWrittenOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileTruncate(BLFileCore* self, int64_t maxSize);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileGetInfo(BLFileCore* self, BLFileInfo* infoOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileGetSize(BLFileCore* self, uint64_t* fileSizeOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileSystemGetInfo([MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileInfo* infoOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileSystemReadFile([MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLArrayCore* dst, size_t maxSize, BLFileReadFlags readFlags);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFileSystemWriteFile([MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, void* data, size_t size, size_t* bytesWrittenOut);
	#endregion file
	#region string
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInit(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInitMove(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInitWeak(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInitWithData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringDestroy(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringReset(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe Byte* blStringGetData(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blStringGetSize(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blStringGetCapacity(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringClear(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringShrink(BLStringCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringReserve(BLStringCore* self, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringResize(BLStringCore* self, size_t n, char fill);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringMakeMutable(BLStringCore* self, char** dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringModifyOp(BLStringCore* self, BLModifyOp op, size_t n, char** dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInsertOp(BLStringCore* self, size_t index, size_t n, char** dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringAssignMove(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringAssignWeak(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringAssignDeep(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringAssignData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringApplyOpChar(BLStringCore* self, BLModifyOp op, char c, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringApplyOpData(BLStringCore* self, BLModifyOp op, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringApplyOpString(BLStringCore* self, BLModifyOp op, BLStringCore* other);
	/*
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringApplyOpFormat(BLStringCore* self, BLModifyOp op, char* fmt, ...);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringApplyOpFormatV(BLStringCore* self, BLModifyOp op, char* fmt, va_list ap);
	*/
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInsertChar(BLStringCore* self, size_t index, char c, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInsertData(BLStringCore* self, size_t index, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringInsertString(BLStringCore* self, size_t index, BLStringCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringRemoveIndex(BLStringCore* self, size_t index);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStringRemoveRange(BLStringCore* self, size_t rStart, size_t rEnd);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blStringEquals(BLStringCore* a, BLStringCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blStringEqualsData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blStringCompare(BLStringCore* a, BLStringCore* b);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blStringCompareData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	#endregion string
	#region fontdata
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataInit(BLFontDataCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataInitMove(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataInitWeak(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataDestroy(BLFontDataCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataReset(BLFontDataCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataAssignMove(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataAssignWeak(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataCreateFromFile(BLFontDataCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileReadFlags readFlags);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataCreateFromDataArray(BLFontDataCore* self, BLArrayCore* dataArray);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataCreateFromData(BLFontDataCore* self, void* data, size_t dataSize, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontDataEquals(BLFontDataCore* a, BLFontDataCore* b);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blFontDataGetFaceCount(BLFontDataCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLFontFaceType blFontDataGetFaceType(BLFontDataCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLFontDataFlags blFontDataGetFlags(BLFontDataCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDataGetTableTags(BLFontDataCore* self, uint32_t faceIndex, BLArrayCore* dst);
	[DllImport("blend2d")]
	public static extern unsafe size_t blFontDataGetTables(BLFontDataCore* self, uint32_t faceIndex, BLFontTable* dst, BLTag* tags, size_t count);
	#endregion fontdata
	#region glyphbuffer
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferInit(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferInitMove(BLGlyphBufferCore* self, BLGlyphBufferCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferDestroy(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferReset(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferClear(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blGlyphBufferGetSize(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blGlyphBufferGetFlags(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLGlyphRun* blGlyphBufferGetGlyphRun(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t* blGlyphBufferGetContent(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLGlyphInfo* blGlyphBufferGetInfoData(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLGlyphPlacement* blGlyphBufferGetPlacementData(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferSetText(BLGlyphBufferCore* self, void* textData, size_t size, BLTextEncoding encoding);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferSetGlyphs(BLGlyphBufferCore* self, uint32_t* glyphData, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferSetGlyphsFromStruct(BLGlyphBufferCore* self, void* glyphData, size_t size, size_t glyphIdSize, intptr_t glyphIdAdvance);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferSetDebugSink(BLGlyphBufferCore* self, delegate*<char*, size_t, void*, void> sink, void* userData);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGlyphBufferResetDebugSink(BLGlyphBufferCore* self);
	#endregion glyphbuffer
	#region path
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathInit(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathInitMove(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathInitWeak(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathDestroy(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathReset(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blPathGetSize(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blPathGetCapacity(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe uint8_t* blPathGetCommandData(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLPoint* blPathGetVertexData(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathClear(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathShrink(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathReserve(BLPathCore* self, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathModifyOp(BLPathCore* self, BLModifyOp op, size_t n, uint8_t** cmdDataOut, BLPoint** vtxDataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAssignMove(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAssignWeak(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAssignDeep(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathSetVertexAt(BLPathCore* self, size_t index, uint32_t cmd, Double x, Double y);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathMoveTo(BLPathCore* self, Double x0, Double y0);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathLineTo(BLPathCore* self, Double x1, Double y1);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathPolyTo(BLPathCore* self, BLPoint* poly, size_t count);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathQuadTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathConicTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2, Double w);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathCubicTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2, Double x3, Double y3);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathSmoothQuadTo(BLPathCore* self, Double x2, Double y2);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathSmoothCubicTo(BLPathCore* self, Double x2, Double y2, Double x3, Double y3);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathArcTo(BLPathCore* self, Double x, Double y, Double rx, Double ry, Double start, Double sweep, [MarshalAs(UnmanagedType.U8)] Boolean forceMoveTo);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathArcQuadrantTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathEllipticArcTo(BLPathCore* self, Double rx, Double ry, Double xAxisRotation, [MarshalAs(UnmanagedType.U8)] Boolean largeArcFlag, [MarshalAs(UnmanagedType.U8)] Boolean sweepFlag, Double x1, Double y1);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathClose(BLPathCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddGeometry(BLPathCore* self, BLGeometryType geometryType, void* geometryData, BLMatrix2D* m, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddBoxI(BLPathCore* self, BLBoxI* box, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddBoxD(BLPathCore* self, BLBox* box, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddRectI(BLPathCore* self, BLRectI* rect, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddRectD(BLPathCore* self, BLRect* rect, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddPath(BLPathCore* self, BLPathCore* other, BLRange* range);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddTranslatedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLPoint* p);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddTransformedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLMatrix2D* m);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddReversedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLPathReverseMode reverseMode);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathAddStrokedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLStrokeOptionsCore* options, BLApproximationOptions* approx);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathRemoveRange(BLPathCore* self, BLRange* range);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathTranslate(BLPathCore* self, BLRange* range, BLPoint* p);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathTransform(BLPathCore* self, BLRange* range, BLMatrix2D* m);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathFitTo(BLPathCore* self, BLRange* range, BLRect* rect, uint32_t fitFlags);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blPathEquals(BLPathCore* a, BLPathCore* b);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathGetInfoFlags(BLPathCore* self, uint32_t* flagsOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathGetControlBox(BLPathCore* self, BLBox* boxOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathGetBoundingBox(BLPathCore* self, BLBox* boxOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathGetFigureRange(BLPathCore* self, size_t index, BLRange* rangeOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathGetLastVertex(BLPathCore* self, BLPoint* vtxOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathGetClosestVertex(BLPathCore* self, BLPoint* p, Double maxDistance, size_t* indexOut, Double* distanceOut);
	[DllImport("blend2d")]
	public static extern unsafe BLHitTest blPathHitTest(BLPathCore* self, BLPoint* p, BLFillRule fillRule);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStrokeOptionsInit(BLStrokeOptionsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStrokeOptionsInitMove(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStrokeOptionsInitWeak(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStrokeOptionsDestroy(BLStrokeOptionsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStrokeOptionsReset(BLStrokeOptionsCore* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blStrokeOptionsEquals(BLStrokeOptionsCore* a, BLStrokeOptionsCore* b);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStrokeOptionsAssignMove(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blStrokeOptionsAssignWeak(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPathStrokeToSink(BLPathCore* self, BLRange* range, BLStrokeOptionsCore* strokeOptions, BLApproximationOptions* approximationOptions, BLPathCore* a, BLPathCore* b, BLPathCore* c, delegate*<BLPathCore*, BLPathCore*, BLPathCore*, size_t, size_t, void*, BLResult> sink, void* userData);
	#endregion path
	#region fontface
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceInit(BLFontFaceCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceInitMove(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceInitWeak(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceDestroy(BLFontFaceCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceReset(BLFontFaceCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceAssignMove(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceAssignWeak(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontFaceEquals(BLFontFaceCore* a, BLFontFaceCore* b);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceCreateFromFile(BLFontFaceCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileReadFlags readFlags);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceCreateFromData(BLFontFaceCore* self, BLFontDataCore* fontData, uint32_t faceIndex);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetFullName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetFamilyName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetSubfamilyName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetPostScriptName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetFaceInfo(BLFontFaceCore* self, BLFontFaceInfo* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetDesignMetrics(BLFontFaceCore* self, BLFontDesignMetrics* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetUnicodeCoverage(BLFontFaceCore* self, BLFontUnicodeCoverage* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetCharacterCoverage(BLFontFaceCore* self, BLBitSetCore* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontFaceHasScriptTag(BLFontFaceCore* self, BLTag scriptTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontFaceHasFeatureTag(BLFontFaceCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontFaceHasVariationTag(BLFontFaceCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetScriptTags(BLFontFaceCore* self, BLArrayCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetFeatureTags(BLFontFaceCore* self, BLArrayCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFaceGetVariationTags(BLFontFaceCore* self, BLArrayCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsInit(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsInitMove(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsInitWeak(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsDestroy(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsReset(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsClear(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsShrink(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsAssignMove(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsAssignWeak(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe size_t blFontFeatureSettingsGetSize(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blFontFeatureSettingsGetCapacity(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsGetView(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsView* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontFeatureSettingsHasValue(BLFontFeatureSettingsCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blFontFeatureSettingsGetValue(BLFontFeatureSettingsCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsSetValue(BLFontFeatureSettingsCore* self, BLTag featureTag, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontFeatureSettingsRemoveValue(BLFontFeatureSettingsCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontFeatureSettingsEquals(BLFontFeatureSettingsCore* a, BLFontFeatureSettingsCore* b);
	#endregion fontface
	#region fontvariation
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsInit(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsInitMove(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsInitWeak(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsDestroy(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsReset(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsClear(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsShrink(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsAssignMove(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsAssignWeak(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public static extern unsafe size_t blFontVariationSettingsGetSize(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blFontVariationSettingsGetCapacity(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsGetView(BLFontVariationSettingsCore* self, BLFontVariationSettingsView* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontVariationSettingsHasValue(BLFontVariationSettingsCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	public static extern unsafe float blFontVariationSettingsGetValue(BLFontVariationSettingsCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsSetValue(BLFontVariationSettingsCore* self, BLTag variationTag, float value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontVariationSettingsRemoveValue(BLFontVariationSettingsCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontVariationSettingsEquals(BLFontVariationSettingsCore* a, BLFontVariationSettingsCore* b);
	#endregion fontvariation
	#region font
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontInit(BLFontCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontInitMove(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontInitWeak(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontDestroy(BLFontCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontReset(BLFontCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontAssignMove(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontAssignWeak(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontEquals(BLFontCore* a, BLFontCore* b);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontCreateFromFace(BLFontCore* self, BLFontFaceCore* face, float size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontCreateFromFaceWithSettings(BLFontCore* self, BLFontFaceCore* face, float size, BLFontFeatureSettingsCore* featureSettings, BLFontVariationSettingsCore* variationSettings);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetFace(BLFontCore* self, BLFontFaceCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe float blFontGetSize(BLFontCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontSetSize(BLFontCore* self, float size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetMetrics(BLFontCore* self, BLFontMetrics* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetMatrix(BLFontCore* self, BLFontMatrix* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetDesignMetrics(BLFontCore* self, BLFontDesignMetrics* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetFeatureSettings(BLFontCore* self, BLFontFeatureSettingsCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontSetFeatureSettings(BLFontCore* self, BLFontFeatureSettingsCore* featureSettings);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontResetFeatureSettings(BLFontCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetVariationSettings(BLFontCore* self, BLFontVariationSettingsCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontSetVariationSettings(BLFontCore* self, BLFontVariationSettingsCore* variationSettings);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontResetVariationSettings(BLFontCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontShape(BLFontCore* self, BLGlyphBufferCore* gb);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontMapTextToGlyphs(BLFontCore* self, BLGlyphBufferCore* gb, BLGlyphMappingState* stateOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontPositionGlyphs(BLFontCore* self, BLGlyphBufferCore* gb);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontApplyKerning(BLFontCore* self, BLGlyphBufferCore* gb);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontApplyGSub(BLFontCore* self, BLGlyphBufferCore* gb, BLBitArrayCore* lookups);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontApplyGPos(BLFontCore* self, BLGlyphBufferCore* gb, BLBitArrayCore* lookups);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetTextMetrics(BLFontCore* self, BLGlyphBufferCore* gb, BLTextMetrics* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetGlyphBounds(BLFontCore* self, uint32_t* glyphData, intptr_t glyphAdvance, BLBoxI* @out, size_t count);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetGlyphAdvances(BLFontCore* self, uint32_t* glyphData, intptr_t glyphAdvance, BLGlyphPlacement* @out, size_t count);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetGlyphOutlines(BLFontCore* self, BLGlyphId glyphId, BLMatrix2D* userTransform, BLPathCore* @out, delegate*<BLPathCore*, void*, void*, BLResult> sink, void* userData);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontGetGlyphRunOutlines(BLFontCore* self, BLGlyphRun* glyphRun, BLMatrix2D* userTransform, BLPathCore* @out, delegate*<BLPathCore*, void*, void*, BLResult> sink, void* userData);
	#endregion font
	#region matrix
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DSetIdentity(BLMatrix2D* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DSetTranslation(BLMatrix2D* self, Double x, Double y);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DSetScaling(BLMatrix2D* self, Double x, Double y);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DSetSkewing(BLMatrix2D* self, Double x, Double y);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DSetRotation(BLMatrix2D* self, Double angle, Double cx, Double cy);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DApplyOp(BLMatrix2D* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DInvert(BLMatrix2D* dst, BLMatrix2D* src);
	[DllImport("blend2d")]
	public static extern unsafe BLTransformType blMatrix2DGetType(BLMatrix2D* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blMatrix2DMapPointDArray(BLMatrix2D* self, BLPoint* dst, BLPoint* src, size_t count);
	#endregion matrix
	#region gradient
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientInit(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientInitMove(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientInitWeak(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientInitAs(BLGradientCore* self, BLGradientType type, void* values, BLExtendMode extendMode, BLGradientStop* stops, size_t n, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientDestroy(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientReset(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientAssignMove(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientAssignWeak(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientCreate(BLGradientCore* self, BLGradientType type, void* values, BLExtendMode extendMode, BLGradientStop* stops, size_t n, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientShrink(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientReserve(BLGradientCore* self, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLGradientType blGradientGetType(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientSetType(BLGradientCore* self, BLGradientType type);
	[DllImport("blend2d")]
	public static extern unsafe BLExtendMode blGradientGetExtendMode(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientSetExtendMode(BLGradientCore* self, BLExtendMode extendMode);
	[DllImport("blend2d")]
	public static extern unsafe Double blGradientGetValue(BLGradientCore* self, size_t index);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientSetValue(BLGradientCore* self, size_t index, Double value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientSetValues(BLGradientCore* self, size_t index, Double* values, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe size_t blGradientGetSize(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blGradientGetCapacity(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLGradientStop* blGradientGetStops(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientResetStops(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientAssignStops(BLGradientCore* self, BLGradientStop* stops, size_t n);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientAddStopRgba32(BLGradientCore* self, Double offset, uint32_t argb32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientAddStopRgba64(BLGradientCore* self, Double offset, uint64_t argb64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientRemoveStop(BLGradientCore* self, size_t index);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientRemoveStopByOffset(BLGradientCore* self, Double offset, uint32_t all);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientRemoveStopsByIndex(BLGradientCore* self, size_t rStart, size_t rEnd);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientRemoveStopsByOffset(BLGradientCore* self, Double offsetMin, Double offsetMax);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientReplaceStopRgba32(BLGradientCore* self, size_t index, Double offset, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientReplaceStopRgba64(BLGradientCore* self, size_t index, Double offset, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe size_t blGradientIndexOfStop(BLGradientCore* self, Double offset);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientGetTransform(BLGradientCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public static extern unsafe BLTransformType blGradientGetTransformType(BLGradientCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blGradientApplyTransformOp(BLGradientCore* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blGradientEquals(BLGradientCore* a, BLGradientCore* b);
	#endregion gradient
	#region format
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFormatInfoQuery(BLFormatInfo* self, BLFormat format);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFormatInfoSanitize(BLFormatInfo* self);
	#endregion format
	#region imagecodec
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecInit(BLImageCodecCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecInitMove(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecInitWeak(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecInitByName(BLImageCodecCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecDestroy(BLImageCodecCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecReset(BLImageCodecCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecAssignMove(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecAssignWeak(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecFindByName(BLImageCodecCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecFindByExtension(BLImageCodecCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecFindByData(BLImageCodecCore* self, void* data, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blImageCodecInspectData(BLImageCodecCore* self, void* data, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecCreateDecoder(BLImageCodecCore* self, BLImageDecoderCore* dst);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecCreateEncoder(BLImageCodecCore* self, BLImageEncoderCore* dst);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecArrayInitBuiltInCodecs(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecArrayAssignBuiltInCodecs(BLArrayCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecAddToBuiltIn(BLImageCodecCore* codec);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCodecRemoveFromBuiltIn(BLImageCodecCore* codec);
	#endregion imagecodec
	#region image
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageInit(BLImageCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageInitMove(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageInitWeak(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageInitAs(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageInitAsFromData(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format, void* pixelData, intptr_t stride, BLDataAccessFlags accessFlags, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDestroy(BLImageCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageReset(BLImageCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageAssignMove(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageAssignWeak(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageAssignDeep(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCreate(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageCreateFromData(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format, void* pixelData, intptr_t stride, BLDataAccessFlags accessFlags, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageGetData(BLImageCore* self, BLImageData* dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageMakeMutable(BLImageCore* self, BLImageData* dataOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageConvert(BLImageCore* self, BLFormat format);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blImageEquals(BLImageCore* a, BLImageCore* b);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageScale(BLImageCore* dst, BLImageCore* src, BLSizeI* size, BLImageScaleFilter filter);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageReadFromFile(BLImageCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageReadFromData(BLImageCore* self, void* data, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageWriteToFile(BLImageCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLImageCodecCore* codec);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageWriteToData(BLImageCore* self, BLArrayCore* dst, BLImageCodecCore* codec);
	#endregion image
	#region pattern
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternInit(BLPatternCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternInitMove(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternInitWeak(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternInitAs(BLPatternCore* self, BLImageCore* image, BLRectI* area, BLExtendMode extendMode, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternDestroy(BLPatternCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternReset(BLPatternCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternAssignMove(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternAssignWeak(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternAssignDeep(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternCreate(BLPatternCore* self, BLImageCore* image, BLRectI* area, BLExtendMode extendMode, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternGetImage(BLPatternCore* self, BLImageCore* image);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternSetImage(BLPatternCore* self, BLImageCore* image, BLRectI* area);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternResetImage(BLPatternCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternGetArea(BLPatternCore* self, BLRectI* areaOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternSetArea(BLPatternCore* self, BLRectI* area);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternResetArea(BLPatternCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLExtendMode blPatternGetExtendMode(BLPatternCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternSetExtendMode(BLPatternCore* self, BLExtendMode extendMode);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternGetTransform(BLPatternCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public static extern unsafe BLTransformType blPatternGetTransformType(BLPatternCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPatternApplyTransformOp(BLPatternCore* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blPatternEquals(BLPatternCore* a, BLPatternCore* b);
	#endregion pattern
	#region var
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitType(void* self, BLObjectType type);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitNull(void* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitBool(void* self, [MarshalAs(UnmanagedType.U8)] Boolean value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitInt32(void* self, int32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitInt64(void* self, int64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitUInt32(void* self, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitUInt64(void* self, uint64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitDouble(void* self, Double value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitRgba(void* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitRgba32(void* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitRgba64(void* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitMove(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarInitWeak(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarDestroy(void* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarReset(void* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignNull(void* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignBool(void* self, [MarshalAs(UnmanagedType.U8)] Boolean value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignInt32(void* self, int32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignInt64(void* self, int64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignUInt32(void* self, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignUInt64(void* self, uint64_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignDouble(void* self, Double value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignRgba(void* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignRgba32(void* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignRgba64(void* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignMove(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarAssignWeak(void* self, void* other);
	[DllImport("blend2d")]
	public static extern unsafe BLObjectType blVarGetType(void* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToBool(void* self, [MarshalAs(UnmanagedType.U1)] Boolean* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToInt32(void* self, int32_t* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToInt64(void* self, int64_t* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToUInt32(void* self, uint32_t* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToUInt64(void* self, uint64_t* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToDouble(void* self, Double* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToRgba(void* self, BLRgba* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToRgba32(void* self, uint32_t* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blVarToRgba64(void* self, uint64_t* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEquals(void* a, void* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsNull(void* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsBool(void* self, [MarshalAs(UnmanagedType.U1)] Boolean value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsInt64(void* self, int64_t value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsUInt64(void* self, uint64_t value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsDouble(void* self, Double value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsRgba(void* self, BLRgba* rgba);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsRgba32(void* self, uint32_t rgba32);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarEqualsRgba64(void* self, uint64_t rgba64);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blVarStrictEquals(void* a, void* b);
	#endregion var
	#region context
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextInit(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextInitMove(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextInitWeak(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextInitAs(BLContextCore* self, BLImageCore* image, BLContextCreateInfo* cci);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextDestroy(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextReset(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextAssignMove(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextAssignWeak(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLContextType blContextGetType(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetTargetSize(BLContextCore* self, BLSize* targetSizeOut);
	[DllImport("blend2d")]
	public static extern unsafe BLImageCore* blContextGetTargetImage(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextBegin(BLContextCore* self, BLImageCore* image, BLContextCreateInfo* cci);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextEnd(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFlush(BLContextCore* self, BLContextFlushFlags flags);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSave(BLContextCore* self, BLContextCookie* cookie);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextRestore(BLContextCore* self, BLContextCookie* cookie);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetMetaTransform(BLContextCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetUserTransform(BLContextCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetFinalTransform(BLContextCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextUserToMeta(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextApplyTransformOp(BLContextCore* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blContextGetHint(BLContextCore* self, BLContextHint hintType);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetHint(BLContextCore* self, BLContextHint hintType, uint32_t value);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetHints(BLContextCore* self, BLContextHints* hintsOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetHints(BLContextCore* self, BLContextHints* hints);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFlattenMode(BLContextCore* self, BLFlattenMode mode);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFlattenTolerance(BLContextCore* self, Double tolerance);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetApproximationOptions(BLContextCore* self, BLApproximationOptions* options);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetFillStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetTransformedFillStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFillStyle(BLContextCore* self, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFillStyleWithMode(BLContextCore* self, void* style, BLContextStyleTransformMode transformMode);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFillStyleRgba(BLContextCore* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFillStyleRgba32(BLContextCore* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFillStyleRgba64(BLContextCore* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextDisableFillStyle(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe Double blContextGetFillAlpha(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFillAlpha(BLContextCore* self, Double alpha);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetStrokeStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetTransformedStrokeStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeStyle(BLContextCore* self, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeStyleWithMode(BLContextCore* self, void* style, BLContextStyleTransformMode transformMode);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeStyleRgba(BLContextCore* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeStyleRgba32(BLContextCore* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeStyleRgba64(BLContextCore* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextDisableStrokeStyle(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe Double blContextGetStrokeAlpha(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeAlpha(BLContextCore* self, Double alpha);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSwapStyles(BLContextCore* self, BLContextStyleSwapMode mode);
	[DllImport("blend2d")]
	public static extern unsafe Double blContextGetGlobalAlpha(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetGlobalAlpha(BLContextCore* self, Double alpha);
	[DllImport("blend2d")]
	public static extern unsafe BLCompOp blContextGetCompOp(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetCompOp(BLContextCore* self, BLCompOp compOp);
	[DllImport("blend2d")]
	public static extern unsafe BLFillRule blContextGetFillRule(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetFillRule(BLContextCore* self, BLFillRule fillRule);
	[DllImport("blend2d")]
	public static extern unsafe Double blContextGetStrokeWidth(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeWidth(BLContextCore* self, Double width);
	[DllImport("blend2d")]
	public static extern unsafe Double blContextGetStrokeMiterLimit(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeMiterLimit(BLContextCore* self, Double miterLimit);
	[DllImport("blend2d")]
	public static extern unsafe BLStrokeCap blContextGetStrokeCap(BLContextCore* self, BLStrokeCapPosition position);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeCap(BLContextCore* self, BLStrokeCapPosition position, BLStrokeCap strokeCap);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeCaps(BLContextCore* self, BLStrokeCap strokeCap);
	[DllImport("blend2d")]
	public static extern unsafe BLStrokeJoin blContextGetStrokeJoin(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeJoin(BLContextCore* self, BLStrokeJoin strokeJoin);
	[DllImport("blend2d")]
	public static extern unsafe BLStrokeTransformOrder blContextGetStrokeTransformOrder(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeTransformOrder(BLContextCore* self, BLStrokeTransformOrder transformOrder);
	[DllImport("blend2d")]
	public static extern unsafe Double blContextGetStrokeDashOffset(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeDashOffset(BLContextCore* self, Double dashOffset);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetStrokeDashArray(BLContextCore* self, BLArrayCore* dashArrayOut);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeDashArray(BLContextCore* self, BLArrayCore* dashArray);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextGetStrokeOptions(BLContextCore* self, BLStrokeOptionsCore* options);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextSetStrokeOptions(BLContextCore* self, BLStrokeOptionsCore* options);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextClipToRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextClipToRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextRestoreClipping(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextClearAll(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextClearRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextClearRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillAll(BLContextCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillAllRgba32(BLContextCore* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillAllRgba64(BLContextCore* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillAllExt(BLContextCore* self, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectIRgba32(BLContextCore* self, BLRectI* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectIRgba64(BLContextCore* self, BLRectI* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectIExt(BLContextCore* self, BLRectI* rect, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectDRgba32(BLContextCore* self, BLRect* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectDRgba64(BLContextCore* self, BLRect* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillRectDExt(BLContextCore* self, BLRect* rect, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillPathD(BLContextCore* self, BLPoint* origin, BLPathCore* path);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillPathDRgba32(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillPathDRgba64(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillPathDExt(BLContextCore* self, BLPoint* origin, BLPathCore* path, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGeometry(BLContextCore* self, BLGeometryType type, void* data);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGeometryRgba32(BLContextCore* self, BLGeometryType type, void* data, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGeometryRgba64(BLContextCore* self, BLGeometryType type, void* data, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGeometryExt(BLContextCore* self, BLGeometryType type, void* data, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf8TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf16TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillUtf32TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunI(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunD(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillGlyphRunDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskI(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskIRgba32(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskIRgba64(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskIExt(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskD(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskDRgba32(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskDRgba64(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextFillMaskDExt(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectIRgba32(BLContextCore* self, BLRectI* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectIRgba64(BLContextCore* self, BLRectI* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectIExt(BLContextCore* self, BLRectI* rect, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectDRgba32(BLContextCore* self, BLRect* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectDRgba64(BLContextCore* self, BLRect* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeRectDExt(BLContextCore* self, BLRect* rect, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokePathD(BLContextCore* self, BLPoint* origin, BLPathCore* path);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokePathDRgba32(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokePathDRgba64(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokePathDExt(BLContextCore* self, BLPoint* origin, BLPathCore* path, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGeometry(BLContextCore* self, BLGeometryType type, void* data);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGeometryRgba32(BLContextCore* self, BLGeometryType type, void* data, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGeometryRgba64(BLContextCore* self, BLGeometryType type, void* data, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGeometryExt(BLContextCore* self, BLGeometryType type, void* data, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf8TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf16TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeUtf32TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunI(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunD(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextStrokeGlyphRunDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextBlitImageI(BLContextCore* self, BLPointI* origin, BLImageCore* img, BLRectI* imgArea);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextBlitImageD(BLContextCore* self, BLPoint* origin, BLImageCore* img, BLRectI* imgArea);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextBlitScaledImageI(BLContextCore* self, BLRectI* rect, BLImageCore* img, BLRectI* imgArea);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blContextBlitScaledImageD(BLContextCore* self, BLRect* rect, BLImageCore* img, BLRectI* imgArea);
	#endregion context
	#region fontmanager
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerInit(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerInitMove(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerInitWeak(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerInitNew(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerDestroy(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerReset(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerAssignMove(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerAssignWeak(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerCreate(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blFontManagerGetFaceCount(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public static extern unsafe size_t blFontManagerGetFamilyCount(BLFontManagerCore* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontManagerHasFace(BLFontManagerCore* self, BLFontFaceCore* face);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerAddFace(BLFontManagerCore* self, BLFontFaceCore* face);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerQueryFace(BLFontManagerCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, BLFontQueryProperties* properties, BLFontFaceCore* @out);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blFontManagerQueryFacesByFamilyName(BLFontManagerCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, BLArrayCore* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blFontManagerEquals(BLFontManagerCore* a, BLFontManagerCore* b);
	#endregion fontmanager
	#region imagedecoder
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderInit(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderInitMove(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderInitWeak(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderDestroy(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderReset(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderAssignMove(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderAssignWeak(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderRestart(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderReadInfo(BLImageDecoderCore* self, BLImageInfo* infoOut, uint8_t* data, size_t size);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageDecoderReadFrame(BLImageDecoderCore* self, BLImageCore* imageOut, uint8_t* data, size_t size);
	#endregion imagedecoder
	#region imageencoder
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderInit(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderInitMove(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderInitWeak(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderDestroy(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderReset(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderAssignMove(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderAssignWeak(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderRestart(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blImageEncoderWriteFrame(BLImageEncoderCore* self, BLArrayCore* dst, BLImageCore* image);
	#endregion imageencoder
	#region pixelconverter
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPixelConverterInit(BLPixelConverterCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPixelConverterInitWeak(BLPixelConverterCore* self, BLPixelConverterCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPixelConverterDestroy(BLPixelConverterCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPixelConverterReset(BLPixelConverterCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPixelConverterAssign(BLPixelConverterCore* self, BLPixelConverterCore* other);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPixelConverterCreate(BLPixelConverterCore* self, BLFormatInfo* dstInfo, BLFormatInfo* srcInfo, BLPixelConverterCreateFlags createFlags);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blPixelConverterConvert(BLPixelConverterCore* self, void* dstData, intptr_t dstStride, void* srcData, intptr_t srcStride, uint32_t w, uint32_t h, BLPixelConverterOptions* options);
	#endregion
	#region random
	[DllImport("blend2d")]
	public static extern unsafe BLResult blRandomReset(BLRandom* self, uint64_t seed);
	[DllImport("blend2d")]
	public static extern unsafe uint32_t blRandomNextUInt32(BLRandom* self);
	[DllImport("blend2d")]
	public static extern unsafe uint64_t blRandomNextUInt64(BLRandom* self);
	[DllImport("blend2d")]
	public static extern unsafe Double blRandomNextDouble(BLRandom* self);
	#endregion random
	#region runtime
	[DllImport("blend2d")]
	public static extern BLResult blRuntimeCleanup(BLRuntimeCleanupFlags cleanupFlags);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blRuntimeQueryInfo(BLRuntimeInfoType infoType, void* infoOut);
	#endregion runtime
	#region runtimescope
	[DllImport("blend2d")]
	public static extern unsafe BLResult blRuntimeScopeBegin(BLRuntimeScopeCore* self);
	[DllImport("blend2d")]
	public static extern unsafe BLResult blRuntimeScopeEnd(BLRuntimeScopeCore* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern unsafe Boolean blRuntimeScopeIsActive(BLRuntimeScopeCore* self);
	#endregion runtimescope
}

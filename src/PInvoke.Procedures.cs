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
#pragma warning disable CA1401
#pragma warning disable CA1711
#pragma warning disable CA2101

public static partial class PInvoke {
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectAllocImpl(BLObjectCore* self, BLObjectInfoBits objectInfo, size_t implSize);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectAllocImplAligned(BLObjectCore* self, BLObjectInfoBits objectInfo, size_t implSize, size_t implAlignment);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectAllocImplExternal(BLObjectCore* self, BLObjectInfoBits objectInfo, size_t implSize, [MarshalAs(UnmanagedType.U8)] Boolean immutable, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectFreeImpl(void* impl);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectInitMove(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectInitWeak(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectReset(void* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectAssignMove(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectAssignWeak(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectGetProperty(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, BLVarCore* valueOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectGetPropertyBool(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, bool* valueOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectGetPropertyInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int32_t* valueOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectGetPropertyInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int64_t* valueOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectGetPropertyUInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint32_t* valueOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectGetPropertyUInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint64_t* valueOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectGetPropertyDouble(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, Double* valueOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectSetProperty(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, void* value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectSetPropertyBool(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, [MarshalAs(UnmanagedType.U8)] Boolean value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectSetPropertyInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectSetPropertyInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, int64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectSetPropertyUInt32(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectSetPropertyUInt64(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, uint64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blObjectSetPropertyDouble(void* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, Double value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInit(BLArrayCore* self, BLObjectType arrayType);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInitMove(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInitWeak(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayDestroy(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReset(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blArrayGetSize(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blArrayGetCapacity(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blArrayGetItemSize(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern void* blArrayGetData(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayClear(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayShrink(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReserve(BLArrayCore* self, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayResize(BLArrayCore* self, size_t n, void* fill);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayMakeMutable(BLArrayCore* self, void** dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayModifyOp(BLArrayCore* self, BLModifyOp op, size_t n, void** dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertOp(BLArrayCore* self, size_t index, size_t n, void** dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAssignMove(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAssignWeak(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAssignDeep(BLArrayCore* self, BLArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAssignData(BLArrayCore* self, void* data, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAssignExternalData(BLArrayCore* self, void* data, size_t size, size_t capacity, BLDataAccessFlags dataAccessFlags, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendU8(BLArrayCore* self, uint8_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendU16(BLArrayCore* self, uint16_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendU32(BLArrayCore* self, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendU64(BLArrayCore* self, uint64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendF32(BLArrayCore* self, float value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendF64(BLArrayCore* self, Double value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendItem(BLArrayCore* self, void* item);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayAppendData(BLArrayCore* self, void* data, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertU8(BLArrayCore* self, size_t index, uint8_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertU16(BLArrayCore* self, size_t index, uint16_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertU32(BLArrayCore* self, size_t index, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertU64(BLArrayCore* self, size_t index, uint64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertF32(BLArrayCore* self, size_t index, float value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertF64(BLArrayCore* self, size_t index, Double value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertItem(BLArrayCore* self, size_t index, void* item);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayInsertData(BLArrayCore* self, size_t index, void* data, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceU8(BLArrayCore* self, size_t index, uint8_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceU16(BLArrayCore* self, size_t index, uint16_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceU32(BLArrayCore* self, size_t index, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceU64(BLArrayCore* self, size_t index, uint64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceF32(BLArrayCore* self, size_t index, float value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceF64(BLArrayCore* self, size_t index, Double value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceItem(BLArrayCore* self, size_t index, void* item);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayReplaceData(BLArrayCore* self, size_t rStart, size_t rEnd, void* data, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayRemoveIndex(BLArrayCore* self, size_t index);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blArrayRemoveRange(BLArrayCore* self, size_t rStart, size_t rEnd);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blArrayEquals(BLArrayCore* a, BLArrayCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayInit(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayInitMove(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayInitWeak(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayDestroy(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayReset(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayAssignMove(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayAssignWeak(BLBitArrayCore* self, BLBitArrayCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayAssignWords(BLBitArrayCore* self, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitArrayIsEmpty(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitArrayGetSize(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitArrayGetWordCount(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitArrayGetCapacity(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t* blBitArrayGetData(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitArrayGetCardinality(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitArrayGetCardinalityInRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitArrayHasBit(BLBitArrayCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitArrayHasBitsInRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitArraySubsumes(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitArrayIntersects(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitArrayGetRange(BLBitArrayCore* self, uint32_t* startOut, uint32_t* endOut);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitArrayEquals(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitArrayCompare(BLBitArrayCore* a, BLBitArrayCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayClear(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayResize(BLBitArrayCore* self, uint32_t nBits);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayReserve(BLBitArrayCore* self, uint32_t nBits);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayShrink(BLBitArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArraySetBit(BLBitArrayCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayFillRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayFillWords(BLBitArrayCore* self, uint32_t bitIndex, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayClearBit(BLBitArrayCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayClearRange(BLBitArrayCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayClearWord(BLBitArrayCore* self, uint32_t bitIndex, uint32_t wordValue);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayClearWords(BLBitArrayCore* self, uint32_t bitIndex, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayReplaceOp(BLBitArrayCore* self, uint32_t nBits, uint32_t** dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayReplaceBit(BLBitArrayCore* self, uint32_t bitIndex, [MarshalAs(UnmanagedType.U8)] Boolean bitValue);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayReplaceWord(BLBitArrayCore* self, uint32_t bitIndex, uint32_t wordValue);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayReplaceWords(BLBitArrayCore* self, uint32_t bitIndex, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayAppendBit(BLBitArrayCore* self, [MarshalAs(UnmanagedType.U8)] Boolean bitValue);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayAppendWord(BLBitArrayCore* self, uint32_t wordValue);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitArrayAppendWords(BLBitArrayCore* self, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetInit(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetInitMove(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetInitWeak(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetInitRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetDestroy(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetReset(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAssignMove(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAssignWeak(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAssignDeep(BLBitSetCore* self, BLBitSetCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAssignRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAssignWords(BLBitSetCore* self, uint32_t startWord, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitSetIsEmpty(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetGetData(BLBitSetCore* self, BLBitSetData* @out);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitSetGetSegmentCount(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitSetGetSegmentCapacity(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitSetGetCardinality(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitSetGetCardinalityInRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitSetHasBit(BLBitSetCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitSetHasBitsInRange(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitSetSubsumes(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitSetIntersects(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitSetGetRange(BLBitSetCore* self, uint32_t* startOut, uint32_t* endOut);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blBitSetEquals(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blBitSetCompare(BLBitSetCore* a, BLBitSetCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetClear(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetShrink(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetOptimize(BLBitSetCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetChop(BLBitSetCore* self, uint32_t startBit, uint32_t endBit);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAddBit(BLBitSetCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAddRange(BLBitSetCore* self, uint32_t rangeStartBit, uint32_t rangeEndBit);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetAddWords(BLBitSetCore* self, uint32_t startWord, uint32_t* wordData, uint32_t wordCount);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetClearBit(BLBitSetCore* self, uint32_t bitIndex);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blBitSetClearRange(BLBitSetCore* self, uint32_t rangeStartBit, uint32_t rangeEndBit);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileInit(BLFileCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileReset(BLFileCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileOpen(BLFileCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileOpenFlags openFlags);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileClose(BLFileCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileSeek(BLFileCore* self, int64_t offset, BLFileSeekType seekType, int64_t* positionOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileRead(BLFileCore* self, void* buffer, size_t n, size_t* bytesReadOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileWrite(BLFileCore* self, void* buffer, size_t n, size_t* bytesWrittenOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileTruncate(BLFileCore* self, int64_t maxSize);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileGetInfo(BLFileCore* self, BLFileInfo* infoOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileGetSize(BLFileCore* self, uint64_t* fileSizeOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileSystemGetInfo([MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileInfo* infoOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileSystemReadFile([MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLArrayCore* dst, size_t maxSize, BLFileReadFlags readFlags);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFileSystemWriteFile([MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, void* data, size_t size, size_t* bytesWrittenOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInit(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInitMove(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInitWeak(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInitWithData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringDestroy(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringReset(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern char* blStringGetData(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blStringGetSize(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blStringGetCapacity(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringClear(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringShrink(BLStringCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringReserve(BLStringCore* self, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringResize(BLStringCore* self, size_t n, char fill);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringMakeMutable(BLStringCore* self, char** dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringModifyOp(BLStringCore* self, BLModifyOp op, size_t n, char** dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInsertOp(BLStringCore* self, size_t index, size_t n, char** dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringAssignMove(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringAssignWeak(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringAssignDeep(BLStringCore* self, BLStringCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringAssignData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringApplyOpChar(BLStringCore* self, BLModifyOp op, char c, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringApplyOpData(BLStringCore* self, BLModifyOp op, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringApplyOpString(BLStringCore* self, BLModifyOp op, BLStringCore* other);
	/*
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringApplyOpFormat(BLStringCore* self, BLModifyOp op, char* fmt, ...);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringApplyOpFormatV(BLStringCore* self, BLModifyOp op, char* fmt, va_list ap);
	*/
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInsertChar(BLStringCore* self, size_t index, char c, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInsertData(BLStringCore* self, size_t index, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringInsertString(BLStringCore* self, size_t index, BLStringCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringRemoveIndex(BLStringCore* self, size_t index);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStringRemoveRange(BLStringCore* self, size_t rStart, size_t rEnd);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blStringEquals(BLStringCore* a, BLStringCore* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blStringEqualsData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blStringCompare(BLStringCore* a, BLStringCore* b);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blStringCompareData(BLStringCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String str, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataInit(BLFontDataCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataInitMove(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataInitWeak(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataDestroy(BLFontDataCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataReset(BLFontDataCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataAssignMove(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataAssignWeak(BLFontDataCore* self, BLFontDataCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataCreateFromFile(BLFontDataCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileReadFlags readFlags);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataCreateFromDataArray(BLFontDataCore* self, BLArrayCore* dataArray);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataCreateFromData(BLFontDataCore* self, void* data, size_t dataSize, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontDataEquals(BLFontDataCore* a, BLFontDataCore* b);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blFontDataGetFaceCount(BLFontDataCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLFontFaceType blFontDataGetFaceType(BLFontDataCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLFontDataFlags blFontDataGetFlags(BLFontDataCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDataGetTableTags(BLFontDataCore* self, uint32_t faceIndex, BLArrayCore* dst);
	[DllImport("blend2d")]
	public unsafe static extern size_t blFontDataGetTables(BLFontDataCore* self, uint32_t faceIndex, BLFontTable* dst, BLTag* tags, size_t count);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferInit(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferInitMove(BLGlyphBufferCore* self, BLGlyphBufferCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferDestroy(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferReset(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferClear(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blGlyphBufferGetSize(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blGlyphBufferGetFlags(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLGlyphRun* blGlyphBufferGetGlyphRun(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t* blGlyphBufferGetContent(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLGlyphInfo* blGlyphBufferGetInfoData(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLGlyphPlacement* blGlyphBufferGetPlacementData(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferSetText(BLGlyphBufferCore* self, void* textData, size_t size, BLTextEncoding encoding);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferSetGlyphs(BLGlyphBufferCore* self, uint32_t* glyphData, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferSetGlyphsFromStruct(BLGlyphBufferCore* self, void* glyphData, size_t size, size_t glyphIdSize, intptr_t glyphIdAdvance);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferSetDebugSink(BLGlyphBufferCore* self, delegate*<char*, size_t, void*, void> sink, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGlyphBufferResetDebugSink(BLGlyphBufferCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathInit(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathInitMove(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathInitWeak(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathDestroy(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathReset(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blPathGetSize(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blPathGetCapacity(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern uint8_t* blPathGetCommandData(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLPoint* blPathGetVertexData(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathClear(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathShrink(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathReserve(BLPathCore* self, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathModifyOp(BLPathCore* self, BLModifyOp op, size_t n, uint8_t** cmdDataOut, BLPoint** vtxDataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAssignMove(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAssignWeak(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAssignDeep(BLPathCore* self, BLPathCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathSetVertexAt(BLPathCore* self, size_t index, uint32_t cmd, Double x, Double y);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathMoveTo(BLPathCore* self, Double x0, Double y0);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathLineTo(BLPathCore* self, Double x1, Double y1);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathPolyTo(BLPathCore* self, BLPoint* poly, size_t count);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathQuadTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathConicTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2, Double w);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathCubicTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2, Double x3, Double y3);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathSmoothQuadTo(BLPathCore* self, Double x2, Double y2);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathSmoothCubicTo(BLPathCore* self, Double x2, Double y2, Double x3, Double y3);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathArcTo(BLPathCore* self, Double x, Double y, Double rx, Double ry, Double start, Double sweep, [MarshalAs(UnmanagedType.U8)] Boolean forceMoveTo);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathArcQuadrantTo(BLPathCore* self, Double x1, Double y1, Double x2, Double y2);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathEllipticArcTo(BLPathCore* self, Double rx, Double ry, Double xAxisRotation, [MarshalAs(UnmanagedType.U8)] Boolean largeArcFlag, [MarshalAs(UnmanagedType.U8)] Boolean sweepFlag, Double x1, Double y1);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathClose(BLPathCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddGeometry(BLPathCore* self, BLGeometryType geometryType, void* geometryData, BLMatrix2D* m, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddBoxI(BLPathCore* self, BLBoxI* box, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddBoxD(BLPathCore* self, BLBox* box, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddRectI(BLPathCore* self, BLRectI* rect, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddRectD(BLPathCore* self, BLRect* rect, BLGeometryDirection dir);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddPath(BLPathCore* self, BLPathCore* other, BLRange* range);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddTranslatedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLPoint* p);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddTransformedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLMatrix2D* m);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddReversedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLPathReverseMode reverseMode);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathAddStrokedPath(BLPathCore* self, BLPathCore* other, BLRange* range, BLStrokeOptionsCore* options, BLApproximationOptions* approx);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathRemoveRange(BLPathCore* self, BLRange* range);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathTranslate(BLPathCore* self, BLRange* range, BLPoint* p);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathTransform(BLPathCore* self, BLRange* range, BLMatrix2D* m);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathFitTo(BLPathCore* self, BLRange* range, BLRect* rect, uint32_t fitFlags);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blPathEquals(BLPathCore* a, BLPathCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathGetInfoFlags(BLPathCore* self, uint32_t* flagsOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathGetControlBox(BLPathCore* self, BLBox* boxOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathGetBoundingBox(BLPathCore* self, BLBox* boxOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathGetFigureRange(BLPathCore* self, size_t index, BLRange* rangeOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathGetLastVertex(BLPathCore* self, BLPoint* vtxOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathGetClosestVertex(BLPathCore* self, BLPoint* p, Double maxDistance, size_t* indexOut, Double* distanceOut);
	[DllImport("blend2d")]
	public unsafe static extern BLHitTest blPathHitTest(BLPathCore* self, BLPoint* p, BLFillRule fillRule);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStrokeOptionsInit(BLStrokeOptionsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStrokeOptionsInitMove(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStrokeOptionsInitWeak(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStrokeOptionsDestroy(BLStrokeOptionsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStrokeOptionsReset(BLStrokeOptionsCore* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blStrokeOptionsEquals(BLStrokeOptionsCore* a, BLStrokeOptionsCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStrokeOptionsAssignMove(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blStrokeOptionsAssignWeak(BLStrokeOptionsCore* self, BLStrokeOptionsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPathStrokeToSink(BLPathCore* self, BLRange* range, BLStrokeOptionsCore* strokeOptions, BLApproximationOptions* approximationOptions, BLPathCore* a, BLPathCore* b, BLPathCore* c, delegate*<BLPathCore*, BLPathCore*, BLPathCore*, size_t, size_t, void*, BLResult> sink, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceInit(BLFontFaceCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceInitMove(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceInitWeak(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceDestroy(BLFontFaceCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceReset(BLFontFaceCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceAssignMove(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceAssignWeak(BLFontFaceCore* self, BLFontFaceCore* other);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontFaceEquals(BLFontFaceCore* a, BLFontFaceCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceCreateFromFile(BLFontFaceCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLFileReadFlags readFlags);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceCreateFromData(BLFontFaceCore* self, BLFontDataCore* fontData, uint32_t faceIndex);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetFullName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetFamilyName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetSubfamilyName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetPostScriptName(BLFontFaceCore* self, BLStringCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetFaceInfo(BLFontFaceCore* self, BLFontFaceInfo* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetDesignMetrics(BLFontFaceCore* self, BLFontDesignMetrics* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetUnicodeCoverage(BLFontFaceCore* self, BLFontUnicodeCoverage* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetCharacterCoverage(BLFontFaceCore* self, BLBitSetCore* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontFaceHasScriptTag(BLFontFaceCore* self, BLTag scriptTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontFaceHasFeatureTag(BLFontFaceCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontFaceHasVariationTag(BLFontFaceCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetScriptTags(BLFontFaceCore* self, BLArrayCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetFeatureTags(BLFontFaceCore* self, BLArrayCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFaceGetVariationTags(BLFontFaceCore* self, BLArrayCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsInit(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsInitMove(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsInitWeak(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsDestroy(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsReset(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsClear(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsShrink(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsAssignMove(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsAssignWeak(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern size_t blFontFeatureSettingsGetSize(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blFontFeatureSettingsGetCapacity(BLFontFeatureSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsGetView(BLFontFeatureSettingsCore* self, BLFontFeatureSettingsView* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontFeatureSettingsHasValue(BLFontFeatureSettingsCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blFontFeatureSettingsGetValue(BLFontFeatureSettingsCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsSetValue(BLFontFeatureSettingsCore* self, BLTag featureTag, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontFeatureSettingsRemoveValue(BLFontFeatureSettingsCore* self, BLTag featureTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontFeatureSettingsEquals(BLFontFeatureSettingsCore* a, BLFontFeatureSettingsCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsInit(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsInitMove(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsInitWeak(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsDestroy(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsReset(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsClear(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsShrink(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsAssignMove(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsAssignWeak(BLFontVariationSettingsCore* self, BLFontVariationSettingsCore* other);
	[DllImport("blend2d")]
	public unsafe static extern size_t blFontVariationSettingsGetSize(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blFontVariationSettingsGetCapacity(BLFontVariationSettingsCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsGetView(BLFontVariationSettingsCore* self, BLFontVariationSettingsView* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontVariationSettingsHasValue(BLFontVariationSettingsCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	public unsafe static extern float blFontVariationSettingsGetValue(BLFontVariationSettingsCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsSetValue(BLFontVariationSettingsCore* self, BLTag variationTag, float value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontVariationSettingsRemoveValue(BLFontVariationSettingsCore* self, BLTag variationTag);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontVariationSettingsEquals(BLFontVariationSettingsCore* a, BLFontVariationSettingsCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontInit(BLFontCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontInitMove(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontInitWeak(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontDestroy(BLFontCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontReset(BLFontCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontAssignMove(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontAssignWeak(BLFontCore* self, BLFontCore* other);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontEquals(BLFontCore* a, BLFontCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontCreateFromFace(BLFontCore* self, BLFontFaceCore* face, float size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontCreateFromFaceWithSettings(BLFontCore* self, BLFontFaceCore* face, float size, BLFontFeatureSettingsCore* featureSettings, BLFontVariationSettingsCore* variationSettings);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetFace(BLFontCore* self, BLFontFaceCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern float blFontGetSize(BLFontCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontSetSize(BLFontCore* self, float size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetMetrics(BLFontCore* self, BLFontMetrics* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetMatrix(BLFontCore* self, BLFontMatrix* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetDesignMetrics(BLFontCore* self, BLFontDesignMetrics* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetFeatureSettings(BLFontCore* self, BLFontFeatureSettingsCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontSetFeatureSettings(BLFontCore* self, BLFontFeatureSettingsCore* featureSettings);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontResetFeatureSettings(BLFontCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetVariationSettings(BLFontCore* self, BLFontVariationSettingsCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontSetVariationSettings(BLFontCore* self, BLFontVariationSettingsCore* variationSettings);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontResetVariationSettings(BLFontCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontShape(BLFontCore* self, BLGlyphBufferCore* gb);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontMapTextToGlyphs(BLFontCore* self, BLGlyphBufferCore* gb, BLGlyphMappingState* stateOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontPositionGlyphs(BLFontCore* self, BLGlyphBufferCore* gb);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontApplyKerning(BLFontCore* self, BLGlyphBufferCore* gb);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontApplyGSub(BLFontCore* self, BLGlyphBufferCore* gb, BLBitArrayCore* lookups);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontApplyGPos(BLFontCore* self, BLGlyphBufferCore* gb, BLBitArrayCore* lookups);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetTextMetrics(BLFontCore* self, BLGlyphBufferCore* gb, BLTextMetrics* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetGlyphBounds(BLFontCore* self, uint32_t* glyphData, intptr_t glyphAdvance, BLBoxI* @out, size_t count);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetGlyphAdvances(BLFontCore* self, uint32_t* glyphData, intptr_t glyphAdvance, BLGlyphPlacement* @out, size_t count);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetGlyphOutlines(BLFontCore* self, BLGlyphId glyphId, BLMatrix2D* userTransform, BLPathCore* @out, delegate*<BLPathCore*, void*, void*, BLResult> sink, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontGetGlyphRunOutlines(BLFontCore* self, BLGlyphRun* glyphRun, BLMatrix2D* userTransform, BLPathCore* @out, delegate*<BLPathCore*, void*, void*, BLResult> sink, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DSetIdentity(BLMatrix2D* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DSetTranslation(BLMatrix2D* self, Double x, Double y);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DSetScaling(BLMatrix2D* self, Double x, Double y);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DSetSkewing(BLMatrix2D* self, Double x, Double y);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DSetRotation(BLMatrix2D* self, Double angle, Double cx, Double cy);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DApplyOp(BLMatrix2D* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DInvert(BLMatrix2D* dst, BLMatrix2D* src);
	[DllImport("blend2d")]
	public unsafe static extern BLTransformType blMatrix2DGetType(BLMatrix2D* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blMatrix2DMapPointDArray(BLMatrix2D* self, BLPoint* dst, BLPoint* src, size_t count);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientInit(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientInitMove(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientInitWeak(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientInitAs(BLGradientCore* self, BLGradientType type, void* values, BLExtendMode extendMode, BLGradientStop* stops, size_t n, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientDestroy(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientReset(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientAssignMove(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientAssignWeak(BLGradientCore* self, BLGradientCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientCreate(BLGradientCore* self, BLGradientType type, void* values, BLExtendMode extendMode, BLGradientStop* stops, size_t n, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientShrink(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientReserve(BLGradientCore* self, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLGradientType blGradientGetType(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientSetType(BLGradientCore* self, BLGradientType type);
	[DllImport("blend2d")]
	public unsafe static extern BLExtendMode blGradientGetExtendMode(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientSetExtendMode(BLGradientCore* self, BLExtendMode extendMode);
	[DllImport("blend2d")]
	public unsafe static extern Double blGradientGetValue(BLGradientCore* self, size_t index);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientSetValue(BLGradientCore* self, size_t index, Double value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientSetValues(BLGradientCore* self, size_t index, Double* values, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern size_t blGradientGetSize(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blGradientGetCapacity(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLGradientStop* blGradientGetStops(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientResetStops(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientAssignStops(BLGradientCore* self, BLGradientStop* stops, size_t n);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientAddStopRgba32(BLGradientCore* self, Double offset, uint32_t argb32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientAddStopRgba64(BLGradientCore* self, Double offset, uint64_t argb64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientRemoveStop(BLGradientCore* self, size_t index);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientRemoveStopByOffset(BLGradientCore* self, Double offset, uint32_t all);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientRemoveStopsByIndex(BLGradientCore* self, size_t rStart, size_t rEnd);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientRemoveStopsByOffset(BLGradientCore* self, Double offsetMin, Double offsetMax);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientReplaceStopRgba32(BLGradientCore* self, size_t index, Double offset, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientReplaceStopRgba64(BLGradientCore* self, size_t index, Double offset, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern size_t blGradientIndexOfStop(BLGradientCore* self, Double offset);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientGetTransform(BLGradientCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public unsafe static extern BLTransformType blGradientGetTransformType(BLGradientCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blGradientApplyTransformOp(BLGradientCore* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blGradientEquals(BLGradientCore* a, BLGradientCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFormatInfoQuery(BLFormatInfo* self, BLFormat format);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFormatInfoSanitize(BLFormatInfo* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecInit(BLImageCodecCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecInitMove(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecInitWeak(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecInitByName(BLImageCodecCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecDestroy(BLImageCodecCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecReset(BLImageCodecCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecAssignMove(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecAssignWeak(BLImageCodecCore* self, BLImageCodecCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecFindByName(BLImageCodecCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecFindByExtension(BLImageCodecCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecFindByData(BLImageCodecCore* self, void* data, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blImageCodecInspectData(BLImageCodecCore* self, void* data, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecCreateDecoder(BLImageCodecCore* self, BLImageDecoderCore* dst);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecCreateEncoder(BLImageCodecCore* self, BLImageEncoderCore* dst);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecArrayInitBuiltInCodecs(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecArrayAssignBuiltInCodecs(BLArrayCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecAddToBuiltIn(BLImageCodecCore* codec);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCodecRemoveFromBuiltIn(BLImageCodecCore* codec);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageInit(BLImageCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageInitMove(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageInitWeak(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageInitAs(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageInitAsFromData(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format, void* pixelData, intptr_t stride, BLDataAccessFlags accessFlags, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDestroy(BLImageCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageReset(BLImageCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageAssignMove(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageAssignWeak(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageAssignDeep(BLImageCore* self, BLImageCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCreate(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageCreateFromData(BLImageCore* self, uint32_t w, uint32_t h, BLFormat format, void* pixelData, intptr_t stride, BLDataAccessFlags accessFlags, delegate*<void*, void*, void*, void> destroyFunc, void* userData);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageGetData(BLImageCore* self, BLImageData* dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageMakeMutable(BLImageCore* self, BLImageData* dataOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageConvert(BLImageCore* self, BLFormat format);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blImageEquals(BLImageCore* a, BLImageCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageScale(BLImageCore* dst, BLImageCore* src, BLSizeI* size, BLImageScaleFilter filter);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageReadFromFile(BLImageCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageReadFromData(BLImageCore* self, void* data, size_t size, BLArrayCore* codecs);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageWriteToFile(BLImageCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String fileName, BLImageCodecCore* codec);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageWriteToData(BLImageCore* self, BLArrayCore* dst, BLImageCodecCore* codec);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternInit(BLPatternCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternInitMove(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternInitWeak(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternInitAs(BLPatternCore* self, BLImageCore* image, BLRectI* area, BLExtendMode extendMode, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternDestroy(BLPatternCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternReset(BLPatternCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternAssignMove(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternAssignWeak(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternAssignDeep(BLPatternCore* self, BLPatternCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternCreate(BLPatternCore* self, BLImageCore* image, BLRectI* area, BLExtendMode extendMode, BLMatrix2D* transform);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternGetImage(BLPatternCore* self, BLImageCore* image);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternSetImage(BLPatternCore* self, BLImageCore* image, BLRectI* area);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternResetImage(BLPatternCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternGetArea(BLPatternCore* self, BLRectI* areaOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternSetArea(BLPatternCore* self, BLRectI* area);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternResetArea(BLPatternCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLExtendMode blPatternGetExtendMode(BLPatternCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternSetExtendMode(BLPatternCore* self, BLExtendMode extendMode);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternGetTransform(BLPatternCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public unsafe static extern BLTransformType blPatternGetTransformType(BLPatternCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPatternApplyTransformOp(BLPatternCore* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blPatternEquals(BLPatternCore* a, BLPatternCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitType(void* self, BLObjectType type);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitNull(void* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitBool(void* self, [MarshalAs(UnmanagedType.U8)] Boolean value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitInt32(void* self, int32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitInt64(void* self, int64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitUInt32(void* self, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitUInt64(void* self, uint64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitDouble(void* self, Double value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitRgba(void* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitRgba32(void* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitRgba64(void* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitMove(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarInitWeak(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarDestroy(void* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarReset(void* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignNull(void* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignBool(void* self, [MarshalAs(UnmanagedType.U8)] Boolean value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignInt32(void* self, int32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignInt64(void* self, int64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignUInt32(void* self, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignUInt64(void* self, uint64_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignDouble(void* self, Double value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignRgba(void* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignRgba32(void* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignRgba64(void* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignMove(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarAssignWeak(void* self, void* other);
	[DllImport("blend2d")]
	public unsafe static extern BLObjectType blVarGetType(void* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToBool(void* self, bool* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToInt32(void* self, int32_t* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToInt64(void* self, int64_t* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToUInt32(void* self, uint32_t* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToUInt64(void* self, uint64_t* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToDouble(void* self, Double* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToRgba(void* self, BLRgba* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToRgba32(void* self, uint32_t* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blVarToRgba64(void* self, uint64_t* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEquals(void* a, void* b);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsNull(void* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsBool(void* self, [MarshalAs(UnmanagedType.U8)] Boolean value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsInt64(void* self, int64_t value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsUInt64(void* self, uint64_t value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsDouble(void* self, Double value);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsRgba(void* self, BLRgba* rgba);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsRgba32(void* self, uint32_t rgba32);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarEqualsRgba64(void* self, uint64_t rgba64);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blVarStrictEquals(void* a, void* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextInit(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextInitMove(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextInitWeak(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextInitAs(BLContextCore* self, BLImageCore* image, BLContextCreateInfo* cci);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextDestroy(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextReset(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextAssignMove(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextAssignWeak(BLContextCore* self, BLContextCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLContextType blContextGetType(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetTargetSize(BLContextCore* self, BLSize* targetSizeOut);
	[DllImport("blend2d")]
	public unsafe static extern BLImageCore* blContextGetTargetImage(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextBegin(BLContextCore* self, BLImageCore* image, BLContextCreateInfo* cci);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextEnd(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFlush(BLContextCore* self, BLContextFlushFlags flags);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSave(BLContextCore* self, BLContextCookie* cookie);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextRestore(BLContextCore* self, BLContextCookie* cookie);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetMetaTransform(BLContextCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetUserTransform(BLContextCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetFinalTransform(BLContextCore* self, BLMatrix2D* transformOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextUserToMeta(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextApplyTransformOp(BLContextCore* self, BLTransformOp opType, void* opData);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blContextGetHint(BLContextCore* self, BLContextHint hintType);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetHint(BLContextCore* self, BLContextHint hintType, uint32_t value);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetHints(BLContextCore* self, BLContextHints* hintsOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetHints(BLContextCore* self, BLContextHints* hints);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFlattenMode(BLContextCore* self, BLFlattenMode mode);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFlattenTolerance(BLContextCore* self, Double tolerance);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetApproximationOptions(BLContextCore* self, BLApproximationOptions* options);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetFillStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetTransformedFillStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFillStyle(BLContextCore* self, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFillStyleWithMode(BLContextCore* self, void* style, BLContextStyleTransformMode transformMode);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFillStyleRgba(BLContextCore* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFillStyleRgba32(BLContextCore* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFillStyleRgba64(BLContextCore* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextDisableFillStyle(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern Double blContextGetFillAlpha(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFillAlpha(BLContextCore* self, Double alpha);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetStrokeStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetTransformedStrokeStyle(BLContextCore* self, BLVarCore* styleOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeStyle(BLContextCore* self, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeStyleWithMode(BLContextCore* self, void* style, BLContextStyleTransformMode transformMode);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeStyleRgba(BLContextCore* self, BLRgba* rgba);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeStyleRgba32(BLContextCore* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeStyleRgba64(BLContextCore* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextDisableStrokeStyle(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern Double blContextGetStrokeAlpha(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeAlpha(BLContextCore* self, Double alpha);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSwapStyles(BLContextCore* self, BLContextStyleSwapMode mode);
	[DllImport("blend2d")]
	public unsafe static extern Double blContextGetGlobalAlpha(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetGlobalAlpha(BLContextCore* self, Double alpha);
	[DllImport("blend2d")]
	public unsafe static extern BLCompOp blContextGetCompOp(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetCompOp(BLContextCore* self, BLCompOp compOp);
	[DllImport("blend2d")]
	public unsafe static extern BLFillRule blContextGetFillRule(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetFillRule(BLContextCore* self, BLFillRule fillRule);
	[DllImport("blend2d")]
	public unsafe static extern Double blContextGetStrokeWidth(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeWidth(BLContextCore* self, Double width);
	[DllImport("blend2d")]
	public unsafe static extern Double blContextGetStrokeMiterLimit(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeMiterLimit(BLContextCore* self, Double miterLimit);
	[DllImport("blend2d")]
	public unsafe static extern BLStrokeCap blContextGetStrokeCap(BLContextCore* self, BLStrokeCapPosition position);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeCap(BLContextCore* self, BLStrokeCapPosition position, BLStrokeCap strokeCap);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeCaps(BLContextCore* self, BLStrokeCap strokeCap);
	[DllImport("blend2d")]
	public unsafe static extern BLStrokeJoin blContextGetStrokeJoin(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeJoin(BLContextCore* self, BLStrokeJoin strokeJoin);
	[DllImport("blend2d")]
	public unsafe static extern BLStrokeTransformOrder blContextGetStrokeTransformOrder(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeTransformOrder(BLContextCore* self, BLStrokeTransformOrder transformOrder);
	[DllImport("blend2d")]
	public unsafe static extern Double blContextGetStrokeDashOffset(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeDashOffset(BLContextCore* self, Double dashOffset);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetStrokeDashArray(BLContextCore* self, BLArrayCore* dashArrayOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeDashArray(BLContextCore* self, BLArrayCore* dashArray);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextGetStrokeOptions(BLContextCore* self, BLStrokeOptionsCore* options);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextSetStrokeOptions(BLContextCore* self, BLStrokeOptionsCore* options);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextClipToRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextClipToRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextRestoreClipping(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextClearAll(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextClearRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextClearRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillAll(BLContextCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillAllRgba32(BLContextCore* self, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillAllRgba64(BLContextCore* self, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillAllExt(BLContextCore* self, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectIRgba32(BLContextCore* self, BLRectI* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectIRgba64(BLContextCore* self, BLRectI* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectIExt(BLContextCore* self, BLRectI* rect, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectDRgba32(BLContextCore* self, BLRect* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectDRgba64(BLContextCore* self, BLRect* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillRectDExt(BLContextCore* self, BLRect* rect, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillPathD(BLContextCore* self, BLPoint* origin, BLPathCore* path);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillPathDRgba32(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillPathDRgba64(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillPathDExt(BLContextCore* self, BLPoint* origin, BLPathCore* path, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGeometry(BLContextCore* self, BLGeometryType type, void* data);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGeometryRgba32(BLContextCore* self, BLGeometryType type, void* data, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGeometryRgba64(BLContextCore* self, BLGeometryType type, void* data, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGeometryExt(BLContextCore* self, BLGeometryType type, void* data, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf8TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf16TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillUtf32TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunI(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunD(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillGlyphRunDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskI(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskIRgba32(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskIRgba64(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskIExt(BLContextCore* self, BLPointI* origin, BLImageCore* mask, BLRectI* maskArea, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskD(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskDRgba32(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskDRgba64(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextFillMaskDExt(BLContextCore* self, BLPoint* origin, BLImageCore* mask, BLRectI* maskArea, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectI(BLContextCore* self, BLRectI* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectIRgba32(BLContextCore* self, BLRectI* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectIRgba64(BLContextCore* self, BLRectI* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectIExt(BLContextCore* self, BLRectI* rect, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectD(BLContextCore* self, BLRect* rect);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectDRgba32(BLContextCore* self, BLRect* rect, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectDRgba64(BLContextCore* self, BLRect* rect, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeRectDExt(BLContextCore* self, BLRect* rect, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokePathD(BLContextCore* self, BLPoint* origin, BLPathCore* path);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokePathDRgba32(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokePathDRgba64(BLContextCore* self, BLPoint* origin, BLPathCore* path, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokePathDExt(BLContextCore* self, BLPoint* origin, BLPathCore* path, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGeometry(BLContextCore* self, BLGeometryType type, void* data);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGeometryRgba32(BLContextCore* self, BLGeometryType type, void* data, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGeometryRgba64(BLContextCore* self, BLGeometryType type, void* data, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGeometryExt(BLContextCore* self, BLGeometryType type, void* data, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf8TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPUTF8Str)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf16TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, [MarshalAs(UnmanagedType.LPWStr)] String text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextI(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextD(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeUtf32TextDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, uint32_t* text, size_t size, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunI(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunIRgba32(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunIRgba64(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunIExt(BLContextCore* self, BLPointI* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunD(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunDRgba32(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint32_t rgba32);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunDRgba64(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, uint64_t rgba64);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextStrokeGlyphRunDExt(BLContextCore* self, BLPoint* origin, BLFontCore* font, BLGlyphRun* glyphRun, void* style);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextBlitImageI(BLContextCore* self, BLPointI* origin, BLImageCore* img, BLRectI* imgArea);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextBlitImageD(BLContextCore* self, BLPoint* origin, BLImageCore* img, BLRectI* imgArea);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextBlitScaledImageI(BLContextCore* self, BLRectI* rect, BLImageCore* img, BLRectI* imgArea);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blContextBlitScaledImageD(BLContextCore* self, BLRect* rect, BLImageCore* img, BLRectI* imgArea);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerInit(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerInitMove(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerInitWeak(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerInitNew(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerDestroy(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerReset(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerAssignMove(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerAssignWeak(BLFontManagerCore* self, BLFontManagerCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerCreate(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blFontManagerGetFaceCount(BLFontManagerCore* self);
	[DllImport("blend2d")]
	public unsafe static extern size_t blFontManagerGetFamilyCount(BLFontManagerCore* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontManagerHasFace(BLFontManagerCore* self, BLFontFaceCore* face);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerAddFace(BLFontManagerCore* self, BLFontFaceCore* face);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerQueryFace(BLFontManagerCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, BLFontQueryProperties* properties, BLFontFaceCore* @out);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blFontManagerQueryFacesByFamilyName(BLFontManagerCore* self, [MarshalAs(UnmanagedType.LPUTF8Str)] String name, size_t nameSize, BLArrayCore* @out);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blFontManagerEquals(BLFontManagerCore* a, BLFontManagerCore* b);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderInit(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderInitMove(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderInitWeak(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderDestroy(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderReset(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderAssignMove(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderAssignWeak(BLImageDecoderCore* self, BLImageDecoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderRestart(BLImageDecoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderReadInfo(BLImageDecoderCore* self, BLImageInfo* infoOut, uint8_t* data, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageDecoderReadFrame(BLImageDecoderCore* self, BLImageCore* imageOut, uint8_t* data, size_t size);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderInit(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderInitMove(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderInitWeak(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderDestroy(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderReset(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderAssignMove(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderAssignWeak(BLImageEncoderCore* self, BLImageEncoderCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderRestart(BLImageEncoderCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blImageEncoderWriteFrame(BLImageEncoderCore* self, BLArrayCore* dst, BLImageCore* image);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPixelConverterInit(BLPixelConverterCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPixelConverterInitWeak(BLPixelConverterCore* self, BLPixelConverterCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPixelConverterDestroy(BLPixelConverterCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPixelConverterReset(BLPixelConverterCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPixelConverterAssign(BLPixelConverterCore* self, BLPixelConverterCore* other);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPixelConverterCreate(BLPixelConverterCore* self, BLFormatInfo* dstInfo, BLFormatInfo* srcInfo, BLPixelConverterCreateFlags createFlags);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blPixelConverterConvert(BLPixelConverterCore* self, void* dstData, intptr_t dstStride, void* srcData, intptr_t srcStride, uint32_t w, uint32_t h, BLPixelConverterOptions* options);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blRandomReset(BLRandom* self, uint64_t seed);
	[DllImport("blend2d")]
	public unsafe static extern uint32_t blRandomNextUInt32(BLRandom* self);
	[DllImport("blend2d")]
	public unsafe static extern uint64_t blRandomNextUInt64(BLRandom* self);
	[DllImport("blend2d")]
	public unsafe static extern Double blRandomNextDouble(BLRandom* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blRuntimeCleanup(BLRuntimeCleanupFlags cleanupFlags);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blRuntimeQueryInfo(BLRuntimeInfoType infoType, void* infoOut);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blRuntimeScopeBegin(BLRuntimeScopeCore* self);
	[DllImport("blend2d")]
	public unsafe static extern BLResult blRuntimeScopeEnd(BLRuntimeScopeCore* self);
	[DllImport("blend2d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe static extern Boolean blRuntimeScopeIsActive(BLRuntimeScopeCore* self);
}

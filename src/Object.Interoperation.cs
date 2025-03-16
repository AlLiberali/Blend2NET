using System;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable CA1069
#pragma warning disable CA1707

/// <summary>
/// Object type identifier.
/// </summary>
public enum BLObjectType : UInt32 {
	/// <summary>
	/// Object represents a <see cref="BLRgba" /> value stored as four 32-bit floating point components (can be used as Style).
	/// </summary>
	BL_OBJECT_TYPE_RGBA = 0,
	/// <summary>
	/// Object represents a <see cref="BLRgba32" /> value stored as 32-bit integer in `0xAARRGGBB` form.
	/// </summary>
	BL_OBJECT_TYPE_RGBA32 = 1,
	/// <summary>
	/// Object represents a <see cref="BLRgba64" /> value stored as 64-bit integer in `0xAAAARRRRGGGGBBBB` form.
	/// </summary>
	BL_OBJECT_TYPE_RGBA64 = 2,
	/// <summary>
	/// Object is `Null` (can be used as style).
	/// </summary>
	BL_OBJECT_TYPE_NULL = 3,
	/// <summary>
	/// Object is <see cref="BLPattern" /> (can be used as style).
	/// </summary>
	BL_OBJECT_TYPE_PATTERN = 4,
	/// <summary>
	/// Object is <see cref="BLGradient" /> (can be used as style).
	/// </summary>
	BL_OBJECT_TYPE_GRADIENT = 5,
	/// <summary>
	/// Object is <see cref="BLImage" />.
	/// </summary>
	BL_OBJECT_TYPE_IMAGE = 9,
	/// <summary>
	/// Object is <see cref="BLPath" />.
	/// </summary>
	BL_OBJECT_TYPE_PATH = 10,
	/// <summary>
	/// Object is <see cref="BLFont" />.
	/// </summary>
	BL_OBJECT_TYPE_FONT = 16,
	/// <summary>
	/// Object is <see cref="BLFontFeatureSettings" />.
	/// </summary>
	BL_OBJECT_TYPE_FONT_FEATURE_SETTINGS = 17,
	/// <summary>
	/// Object is <see cref="BLFontVariationSettings" />.
	/// </summary>
	BL_OBJECT_TYPE_FONT_VARIATION_SETTINGS = 18,
	/// <summary>
	/// Object is <see cref="BLBitArray" />.
	/// </summary>
	BL_OBJECT_TYPE_BIT_ARRAY = 25,
	/// <summary>
	/// Object is <see cref="BLBitSet" />.
	/// </summary>
	BL_OBJECT_TYPE_BIT_SET = 26,
	/// <summary>
	/// Object represents a boolean value.
	/// </summary>
	BL_OBJECT_TYPE_BOOL = 28,
	/// <summary>
	/// Object represents a 64-bit signed integer value.
	/// </summary>
	BL_OBJECT_TYPE_INT64 = 29,
	/// <summary>
	/// Object represents a 64-bit unsigned integer value.
	/// </summary>
	BL_OBJECT_TYPE_UINT64 = 30,
	/// <summary>
	/// Object represents a 64-bit floating point value.
	/// </summary>
	BL_OBJECT_TYPE_DOUBLE = 31,
	/// <summary>
	/// Object is <see cref="BLString" />.
	/// </summary>
	BL_OBJECT_TYPE_STRING = 32,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a `BLObject` compatible type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_OBJECT = 33,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 8-bit signed integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_INT8 = 34,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 8-bit unsigned integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_UINT8 = 35,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 16-bit signed integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_INT16 = 36,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 16-bit unsigned integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_UINT16 = 37,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 32-bit signed integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_INT32 = 38,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 32-bit unsigned integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_UINT32 = 39,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 64-bit signed integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_INT64 = 40,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 64-bit unsigned integral type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_UINT64 = 41,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 32-bit floating point type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_FLOAT32 = 42,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` matches 64-bit floating point type.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_FLOAT64 = 43,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 1.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_1 = 44,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 2.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_2 = 45,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 3.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_3 = 46,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 4.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_4 = 47,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 6.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_6 = 48,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 8.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_8 = 49,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 10.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_10 = 50,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 12.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_12 = 51,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 16.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_16 = 52,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 20.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_20 = 53,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 24.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_24 = 54,
	/// <summary>
	/// Object is \ref BLArray<T> where `T` is a struct of size 32.
	/// </summary>
	BL_OBJECT_TYPE_ARRAY_STRUCT_32 = 55,
	/// <summary>
	/// Object is <see cref="BLContext" />.
	/// </summary>
	BL_OBJECT_TYPE_CONTEXT = 100,
	/// <summary>
	/// Object is <see cref="BLImageCodec" />.
	/// </summary>
	BL_OBJECT_TYPE_IMAGE_CODEC = 101,
	/// <summary>
	/// Object is <see cref="BLImageDecoder" />.
	/// </summary>
	BL_OBJECT_TYPE_IMAGE_DECODER = 102,
	/// <summary>
	/// Object is <see cref="BLImageEncoder" />.
	/// </summary>
	BL_OBJECT_TYPE_IMAGE_ENCODER = 103,
	/// <summary>
	/// Object is <see cref="BLFontFace" />.
	/// </summary>
	BL_OBJECT_TYPE_FONT_FACE = 104,
	/// <summary>
	/// Object is <see cref="BLFontData" />.
	/// </summary>
	BL_OBJECT_TYPE_FONT_DATA = 105,
	/// <summary>
	/// Object is <see cref="BLFontManager" />.
	/// </summary>
	BL_OBJECT_TYPE_FONT_MANAGER = 106
}

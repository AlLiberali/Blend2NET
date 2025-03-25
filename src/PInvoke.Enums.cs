using System;

namespace AlLiberali.Blend2NET;

#pragma warning disable IDE0079
#pragma warning disable CA1069
#pragma warning disable CA1707
#pragma warning disable CA1711

public static partial class PInvoke {
	public enum BLResult : UInt32 {
		BL_SUCCESS = 0,
		BL_ERROR_OUT_OF_MEMORY = 0x00010000u,
		BL_ERROR_INVALID_VALUE,
		BL_ERROR_INVALID_STATE,
		BL_ERROR_INVALID_HANDLE,
		BL_ERROR_INVALID_CONVERSION,
		BL_ERROR_OVERFLOW,
		BL_ERROR_NOT_INITIALIZED,
		BL_ERROR_NOT_IMPLEMENTED,
		BL_ERROR_NOT_PERMITTED,
		BL_ERROR_IO,
		BL_ERROR_BUSY,
		BL_ERROR_INTERRUPTED,
		BL_ERROR_TRY_AGAIN,
		BL_ERROR_TIMED_OUT,
		BL_ERROR_BROKEN_PIPE,
		BL_ERROR_INVALID_SEEK,
		BL_ERROR_SYMLINK_LOOP,
		BL_ERROR_FILE_TOO_LARGE,
		BL_ERROR_ALREADY_EXISTS,
		BL_ERROR_ACCESS_DENIED,
		BL_ERROR_MEDIA_CHANGED,
		BL_ERROR_READ_ONLY_FS,
		BL_ERROR_NO_DEVICE,
		BL_ERROR_NO_ENTRY,
		BL_ERROR_NO_MEDIA,
		BL_ERROR_NO_MORE_DATA,
		BL_ERROR_NO_MORE_FILES,
		BL_ERROR_NO_SPACE_LEFT,
		BL_ERROR_NOT_EMPTY,
		BL_ERROR_NOT_FILE,
		BL_ERROR_NOT_DIRECTORY,
		BL_ERROR_NOT_SAME_DEVICE,
		BL_ERROR_NOT_BLOCK_DEVICE,
		BL_ERROR_INVALID_FILE_NAME,
		BL_ERROR_FILE_NAME_TOO_LONG,
		BL_ERROR_TOO_MANY_OPEN_FILES,
		BL_ERROR_TOO_MANY_OPEN_FILES_BY_OS,
		BL_ERROR_TOO_MANY_LINKS,
		BL_ERROR_TOO_MANY_THREADS,
		BL_ERROR_THREAD_POOL_EXHAUSTED,
		BL_ERROR_FILE_EMPTY,
		BL_ERROR_OPEN_FAILED,
		BL_ERROR_NOT_ROOT_DEVICE,
		BL_ERROR_UNKNOWN_SYSTEM_ERROR,
		BL_ERROR_INVALID_ALIGNMENT,
		BL_ERROR_INVALID_SIGNATURE,
		BL_ERROR_INVALID_DATA,
		BL_ERROR_INVALID_STRING,
		BL_ERROR_INVALID_KEY,
		BL_ERROR_DATA_TRUNCATED,
		BL_ERROR_DATA_TOO_LARGE,
		BL_ERROR_DECOMPRESSION_FAILED,
		BL_ERROR_INVALID_GEOMETRY,
		BL_ERROR_NO_MATCHING_VERTEX,
		BL_ERROR_INVALID_CREATE_FLAGS,
		BL_ERROR_NO_MATCHING_COOKIE,
		BL_ERROR_NO_STATES_TO_RESTORE,
		BL_ERROR_TOO_MANY_SAVED_STATES,
		BL_ERROR_IMAGE_TOO_LARGE,
		BL_ERROR_IMAGE_NO_MATCHING_CODEC,
		BL_ERROR_IMAGE_UNKNOWN_FILE_FORMAT,
		BL_ERROR_IMAGE_DECODER_NOT_PROVIDED,
		BL_ERROR_IMAGE_ENCODER_NOT_PROVIDED,
		BL_ERROR_PNG_MULTIPLE_IHDR,
		BL_ERROR_PNG_INVALID_IDAT,
		BL_ERROR_PNG_INVALID_IEND,
		BL_ERROR_PNG_INVALID_PLTE,
		BL_ERROR_PNG_INVALID_TRNS,
		BL_ERROR_PNG_INVALID_FILTER,
		BL_ERROR_JPEG_UNSUPPORTED_FEATURE,
		BL_ERROR_JPEG_INVALID_SOS,
		BL_ERROR_JPEG_INVALID_SOF,
		BL_ERROR_JPEG_MULTIPLE_SOF,
		BL_ERROR_JPEG_UNSUPPORTED_SOF,
		BL_ERROR_FONT_NOT_INITIALIZED,
		BL_ERROR_FONT_NO_MATCH,
		BL_ERROR_FONT_NO_CHARACTER_MAPPING,
		BL_ERROR_FONT_MISSING_IMPORTANT_TABLE,
		BL_ERROR_FONT_FEATURE_NOT_AVAILABLE,
		BL_ERROR_FONT_CFF_INVALID_DATA,
		BL_ERROR_FONT_PROGRAM_TERMINATED,
		BL_ERROR_GLYPH_SUBSTITUTION_TOO_LARGE,
		BL_ERROR_INVALID_GLYPH
	}
	public enum BLByteOrder : UInt32 {
		BL_BYTE_ORDER_LE = 0,
		BL_BYTE_ORDER_BE = 1
	}
	public enum BLDataAccessFlags : UInt32 {
		BL_DATA_ACCESS_NO_FLAGS = 0x00u,
		BL_DATA_ACCESS_READ = 0x01u,
		BL_DATA_ACCESS_WRITE = 0x02u,
		BL_DATA_ACCESS_RW = 0x03u,
		BL_DATA_ACCESS_FORCE_UINT = 0xFFFFFFFFu
	}
	public enum BLDataSourceType : UInt32 {
		BL_DATA_SOURCE_TYPE_NONE = 0,
		BL_DATA_SOURCE_TYPE_MEMORY = 1,
		BL_DATA_SOURCE_TYPE_FILE = 2,
		BL_DATA_SOURCE_TYPE_CUSTOM = 3
	}
	public enum BLModifyOp : UInt32 {
		BL_MODIFY_OP_ASSIGN_FIT = 0,
		BL_MODIFY_OP_ASSIGN_GROW = 1,
		BL_MODIFY_OP_APPEND_FIT = 2,
		BL_MODIFY_OP_APPEND_GROW = 3
	}
	public enum BLBooleanOp : UInt32 {
		BL_BOOLEAN_OP_COPY = 0,
		BL_BOOLEAN_OP_AND = 1,
		BL_BOOLEAN_OP_OR = 2,
		BL_BOOLEAN_OP_XOR = 3,
		BL_BOOLEAN_OP_AND_NOT = 4,
		BL_BOOLEAN_OP_NOT_AND = 5
	}
	public enum BLExtendMode : UInt32 {
		BL_EXTEND_MODE_PAD = 0,
		BL_EXTEND_MODE_REPEAT = 1,
		BL_EXTEND_MODE_REFLECT = 2,
		BL_EXTEND_MODE_PAD_X_PAD_Y = 0,
		BL_EXTEND_MODE_PAD_X_REPEAT_Y = 3,
		BL_EXTEND_MODE_PAD_X_REFLECT_Y = 4,
		BL_EXTEND_MODE_REPEAT_X_REPEAT_Y = 1,
		BL_EXTEND_MODE_REPEAT_X_PAD_Y = 5,
		BL_EXTEND_MODE_REPEAT_X_REFLECT_Y = 6,
		BL_EXTEND_MODE_REFLECT_X_REFLECT_Y = 2,
		BL_EXTEND_MODE_REFLECT_X_PAD_Y = 7,
		BL_EXTEND_MODE_REFLECT_X_REPEAT_Y = 8
	}
	public enum BLTextEncoding : UInt32 {
		BL_TEXT_ENCODING_UTF8 = 0,
		BL_TEXT_ENCODING_UTF16 = 1,
		BL_TEXT_ENCODING_UTF32 = 2,
		BL_TEXT_ENCODING_LATIN1 = 3
	}
	public enum BLObjectInfoShift : Int32 {
		BL_OBJECT_INFO_P_SHIFT = 0,
		BL_OBJECT_INFO_Q_SHIFT = 8,
		BL_OBJECT_INFO_C_SHIFT = 8,
		BL_OBJECT_INFO_B_SHIFT = 12,
		BL_OBJECT_INFO_A_SHIFT = 16,
		BL_OBJECT_INFO_TYPE_SHIFT = 22,
		BL_OBJECT_INFO_R_SHIFT = 29,
		BL_OBJECT_INFO_D_SHIFT = 30,
		BL_OBJECT_INFO_M_SHIFT = 31
	}
	public enum BLObjectInfoBits : Int32 {
		BL_OBJECT_INFO_P_MASK = 0xFF << BLObjectInfoShift.BL_OBJECT_INFO_P_SHIFT,
		BL_OBJECT_INFO_Q_MASK = 0xFF << BLObjectInfoShift.BL_OBJECT_INFO_Q_SHIFT,
		BL_OBJECT_INFO_C_MASK = 0x0F << BLObjectInfoShift.BL_OBJECT_INFO_C_SHIFT,
		BL_OBJECT_INFO_B_MASK = 0x0F << BLObjectInfoShift.BL_OBJECT_INFO_B_SHIFT,
		BL_OBJECT_INFO_A_MASK = 0x3F << BLObjectInfoShift.BL_OBJECT_INFO_A_SHIFT,
		BL_OBJECT_INFO_FIELDS_MASK = 0x003FFFFF,
		BL_OBJECT_INFO_TYPE_MASK = 0x7F << BLObjectInfoShift.BL_OBJECT_INFO_TYPE_SHIFT,
		BL_OBJECT_INFO_R_FLAG = 0x01 << BLObjectInfoShift.BL_OBJECT_INFO_R_SHIFT,
		BL_OBJECT_INFO_D_FLAG = 0x01 << BLObjectInfoShift.BL_OBJECT_INFO_D_SHIFT,
		BL_OBJECT_INFO_M_FLAG = 0x01 << BLObjectInfoShift.BL_OBJECT_INFO_M_SHIFT,
		BL_OBJECT_INFO_MD_FLAGS = BL_OBJECT_INFO_M_FLAG | BL_OBJECT_INFO_D_FLAG,
		BL_OBJECT_INFO_MDR_FLAGS = BL_OBJECT_INFO_M_FLAG | BL_OBJECT_INFO_D_FLAG | BL_OBJECT_INFO_R_FLAG
	}
	public enum BLObjectType : UInt32 {
		BL_OBJECT_TYPE_RGBA = 0,
		BL_OBJECT_TYPE_RGBA32 = 1,
		BL_OBJECT_TYPE_RGBA64 = 2,
		BL_OBJECT_TYPE_NULL = 3,
		BL_OBJECT_TYPE_PATTERN = 4,
		BL_OBJECT_TYPE_GRADIENT = 5,
		BL_OBJECT_TYPE_IMAGE = 9,
		BL_OBJECT_TYPE_PATH = 10,
		BL_OBJECT_TYPE_FONT = 16,
		BL_OBJECT_TYPE_FONT_FEATURE_SETTINGS = 17,
		BL_OBJECT_TYPE_FONT_VARIATION_SETTINGS = 18,
		BL_OBJECT_TYPE_BIT_ARRAY = 25,
		BL_OBJECT_TYPE_BIT_SET = 26,
		BL_OBJECT_TYPE_BOOL = 28,
		BL_OBJECT_TYPE_INT64 = 29,
		BL_OBJECT_TYPE_UINT64 = 30,
		BL_OBJECT_TYPE_DOUBLE = 31,
		BL_OBJECT_TYPE_STRING = 32,
		BL_OBJECT_TYPE_ARRAY_OBJECT = 33,
		BL_OBJECT_TYPE_ARRAY_INT8 = 34,
		BL_OBJECT_TYPE_ARRAY_UINT8 = 35,
		BL_OBJECT_TYPE_ARRAY_INT16 = 36,
		BL_OBJECT_TYPE_ARRAY_UINT16 = 37,
		BL_OBJECT_TYPE_ARRAY_INT32 = 38,
		BL_OBJECT_TYPE_ARRAY_UINT32 = 39,
		BL_OBJECT_TYPE_ARRAY_INT64 = 40,
		BL_OBJECT_TYPE_ARRAY_UINT64 = 41,
		BL_OBJECT_TYPE_ARRAY_FLOAT32 = 42,
		BL_OBJECT_TYPE_ARRAY_FLOAT64 = 43,
		BL_OBJECT_TYPE_ARRAY_STRUCT_1 = 44,
		BL_OBJECT_TYPE_ARRAY_STRUCT_2 = 45,
		BL_OBJECT_TYPE_ARRAY_STRUCT_3 = 46,
		BL_OBJECT_TYPE_ARRAY_STRUCT_4 = 47,
		BL_OBJECT_TYPE_ARRAY_STRUCT_6 = 48,
		BL_OBJECT_TYPE_ARRAY_STRUCT_8 = 49,
		BL_OBJECT_TYPE_ARRAY_STRUCT_10 = 50,
		BL_OBJECT_TYPE_ARRAY_STRUCT_12 = 51,
		BL_OBJECT_TYPE_ARRAY_STRUCT_16 = 52,
		BL_OBJECT_TYPE_ARRAY_STRUCT_20 = 53,
		BL_OBJECT_TYPE_ARRAY_STRUCT_24 = 54,
		BL_OBJECT_TYPE_ARRAY_STRUCT_32 = 55,
		BL_OBJECT_TYPE_CONTEXT = 100,
		BL_OBJECT_TYPE_IMAGE_CODEC = 101,
		BL_OBJECT_TYPE_IMAGE_DECODER = 102,
		BL_OBJECT_TYPE_IMAGE_ENCODER = 103,
		BL_OBJECT_TYPE_FONT_FACE = 104,
		BL_OBJECT_TYPE_FONT_DATA = 105,
		BL_OBJECT_TYPE_FONT_MANAGER = 106
	}
	public enum BLBitSetConstants : UInt32 {
		BL_BIT_SET_INVALID_INDEX = 0xFFFFFFFFu,
		BL_BIT_SET_RANGE_MASK = 0x80000000u,
		BL_BIT_SET_SEGMENT_WORD_COUNT = 4u
	}
	public enum BLFileInfoFlags : UInt32 {
		BL_FILE_INFO_OWNER_R = 0x00000100u,
		BL_FILE_INFO_OWNER_W = 0x00000080u,
		BL_FILE_INFO_OWNER_X = 0x00000040u,
		BL_FILE_INFO_OWNER_MASK = 0x000001C0u,
		BL_FILE_INFO_GROUP_R = 0x00000020u,
		BL_FILE_INFO_GROUP_W = 0x00000010u,
		BL_FILE_INFO_GROUP_X = 0x00000008u,
		BL_FILE_INFO_GROUP_MASK = 0x00000038u,
		BL_FILE_INFO_OTHER_R = 0x00000004u,
		BL_FILE_INFO_OTHER_W = 0x00000002u,
		BL_FILE_INFO_OTHER_X = 0x00000001u,
		BL_FILE_INFO_OTHER_MASK = 0x00000007u,
		BL_FILE_INFO_SUID = 0x00000800u,
		BL_FILE_INFO_SGID = 0x00000400u,
		BL_FILE_INFO_PERMISSIONS_MASK = 0x00000FFFu,
		BL_FILE_INFO_REGULAR = 0x00010000u,
		BL_FILE_INFO_DIRECTORY = 0x00020000u,
		BL_FILE_INFO_SYMLINK = 0x00040000u,
		BL_FILE_INFO_CHAR_DEVICE = 0x00100000u,
		BL_FILE_INFO_BLOCK_DEVICE = 0x00200000u,
		BL_FILE_INFO_FIFO = 0x00400000u,
		BL_FILE_INFO_SOCKET = 0x00800000u,
		BL_FILE_INFO_HIDDEN = 0x01000000u,
		BL_FILE_INFO_EXECUTABLE = 0x02000000u,
		BL_FILE_INFO_ARCHIVE = 0x04000000u,
		BL_FILE_INFO_SYSTEM = 0x08000000u,
		BL_FILE_INFO_VALID = 0x80000000u
	}
	public enum BLFileOpenFlags : UInt32 {
		BL_FILE_OPEN_NO_FLAGS = 0u,
		BL_FILE_OPEN_READ = 0x00000001u,
		BL_FILE_OPEN_WRITE = 0x00000002u,
		BL_FILE_OPEN_RW = 0x00000003u,
		BL_FILE_OPEN_CREATE = 0x00000004u,
		BL_FILE_OPEN_DELETE = 0x00000008u,
		BL_FILE_OPEN_TRUNCATE = 0x00000010u,
		BL_FILE_OPEN_READ_EXCLUSIVE = 0x10000000u,
		BL_FILE_OPEN_WRITE_EXCLUSIVE = 0x20000000u,
		BL_FILE_OPEN_RW_EXCLUSIVE = 0x30000000u,
		BL_FILE_OPEN_CREATE_EXCLUSIVE = 0x40000000u,
		BL_FILE_OPEN_DELETE_EXCLUSIVE = 0x80000000u
	}
	public enum BLFileSeekType : UInt32 {
		BL_FILE_SEEK_SET = 0,
		BL_FILE_SEEK_CUR = 1,
		BL_FILE_SEEK_END = 2
	}
	public enum BLFileReadFlags : UInt32 {
		BL_FILE_READ_NO_FLAGS = 0u,
		BL_FILE_READ_MMAP_ENABLED = 0x00000001u,
		BL_FILE_READ_MMAP_AVOID_SMALL = 0x00000002u,
		BL_FILE_READ_MMAP_NO_FALLBACK = 0x00000008u
	}
	public enum BLGeometryDirection : UInt32 {
		BL_GEOMETRY_DIRECTION_NONE = 0,
		BL_GEOMETRY_DIRECTION_CW = 1,
		BL_GEOMETRY_DIRECTION_CCW = 2
	}
	public enum BLGeometryType : UInt32 {
		BL_GEOMETRY_TYPE_NONE = 0,
		BL_GEOMETRY_TYPE_BOXI = 1,
		BL_GEOMETRY_TYPE_BOXD = 2,
		BL_GEOMETRY_TYPE_RECTI = 3,
		BL_GEOMETRY_TYPE_RECTD = 4,
		BL_GEOMETRY_TYPE_CIRCLE = 5,
		BL_GEOMETRY_TYPE_ELLIPSE = 6,
		BL_GEOMETRY_TYPE_ROUND_RECT = 7,
		BL_GEOMETRY_TYPE_ARC = 8,
		BL_GEOMETRY_TYPE_CHORD = 9,
		BL_GEOMETRY_TYPE_PIE = 10,
		BL_GEOMETRY_TYPE_LINE = 11,
		BL_GEOMETRY_TYPE_TRIANGLE = 12,
		BL_GEOMETRY_TYPE_POLYLINEI = 13,
		BL_GEOMETRY_TYPE_POLYLINED = 14,
		BL_GEOMETRY_TYPE_POLYGONI = 15,
		BL_GEOMETRY_TYPE_POLYGOND = 16,
		BL_GEOMETRY_TYPE_ARRAY_VIEW_BOXI = 17,
		BL_GEOMETRY_TYPE_ARRAY_VIEW_BOXD = 18,
		BL_GEOMETRY_TYPE_ARRAY_VIEW_RECTI = 19,
		BL_GEOMETRY_TYPE_ARRAY_VIEW_RECTD = 20,
		BL_GEOMETRY_TYPE_PATH = 21
	}
	public enum BLFillRule : UInt32 {
		BL_FILL_RULE_NON_ZERO = 0,
		BL_FILL_RULE_EVEN_ODD = 1
	}
	public enum BLHitTest : UInt32 {
		BL_HIT_TEST_IN = 0,
		BL_HIT_TEST_PART = 1,
		BL_HIT_TEST_OUT = 2,
		BL_HIT_TEST_INVALID = 0xFFFFFFFFu
	}
	public enum BLOrientation : UInt32 {
		BL_ORIENTATION_HORIZONTAL = 0,
		BL_ORIENTATION_VERTICAL = 1
	}
	public enum BLFontFaceType : UInt32 {
		BL_FONT_FACE_TYPE_NONE = 0,
		BL_FONT_FACE_TYPE_OPENTYPE = 1
	}
	public enum BLFontStretch : UInt32 {
		BL_FONT_STRETCH_ULTRA_CONDENSED = 1,
		BL_FONT_STRETCH_EXTRA_CONDENSED = 2,
		BL_FONT_STRETCH_CONDENSED = 3,
		BL_FONT_STRETCH_SEMI_CONDENSED = 4,
		BL_FONT_STRETCH_NORMAL = 5,
		BL_FONT_STRETCH_SEMI_EXPANDED = 6,
		BL_FONT_STRETCH_EXPANDED = 7,
		BL_FONT_STRETCH_EXTRA_EXPANDED = 8,
		BL_FONT_STRETCH_ULTRA_EXPANDED = 9
	}
	public enum BLFontStyle : UInt32 {
		BL_FONT_STYLE_NORMAL = 0,
		BL_FONT_STYLE_OBLIQUE = 1,
		BL_FONT_STYLE_ITALIC = 2
	}
	public enum BLFontWeight : UInt32 {
		BL_FONT_WEIGHT_THIN = 100,
		BL_FONT_WEIGHT_EXTRA_LIGHT = 200,
		BL_FONT_WEIGHT_LIGHT = 300,
		BL_FONT_WEIGHT_SEMI_LIGHT = 350,
		BL_FONT_WEIGHT_NORMAL = 400,
		BL_FONT_WEIGHT_MEDIUM = 500,
		BL_FONT_WEIGHT_SEMI_BOLD = 600,
		BL_FONT_WEIGHT_BOLD = 700,
		BL_FONT_WEIGHT_EXTRA_BOLD = 800,
		BL_FONT_WEIGHT_BLACK = 900,
		BL_FONT_WEIGHT_EXTRA_BLACK = 950
	}
	public enum BLFontStringId : UInt32 {
		BL_FONT_STRING_ID_COPYRIGHT_NOTICE = 0,
		BL_FONT_STRING_ID_FAMILY_NAME = 1,
		BL_FONT_STRING_ID_SUBFAMILY_NAME = 2,
		BL_FONT_STRING_ID_UNIQUE_IDENTIFIER = 3,
		BL_FONT_STRING_ID_FULL_NAME = 4,
		BL_FONT_STRING_ID_VERSION_STRING = 5,
		BL_FONT_STRING_ID_POST_SCRIPT_NAME = 6,
		BL_FONT_STRING_ID_TRADEMARK = 7,
		BL_FONT_STRING_ID_MANUFACTURER_NAME = 8,
		BL_FONT_STRING_ID_DESIGNER_NAME = 9,
		BL_FONT_STRING_ID_DESCRIPTION = 10,
		BL_FONT_STRING_ID_VENDOR_URL = 11,
		BL_FONT_STRING_ID_DESIGNER_URL = 12,
		BL_FONT_STRING_ID_LICENSE_DESCRIPTION = 13,
		BL_FONT_STRING_ID_LICENSE_INFO_URL = 14,
		BL_FONT_STRING_ID_RESERVED = 15,
		BL_FONT_STRING_ID_TYPOGRAPHIC_FAMILY_NAME = 16,
		BL_FONT_STRING_ID_TYPOGRAPHIC_SUBFAMILY_NAME = 17,
		BL_FONT_STRING_ID_COMPATIBLE_FULL_NAME = 18,
		BL_FONT_STRING_ID_SAMPLE_TEXT = 19,
		BL_FONT_STRING_ID_POST_SCRIPT_CID_NAME = 20,
		BL_FONT_STRING_ID_WWS_FAMILY_NAME = 21,
		BL_FONT_STRING_ID_WWS_SUBFAMILY_NAME = 22,
		BL_FONT_STRING_ID_LIGHT_BACKGROUND_PALETTE = 23,
		BL_FONT_STRING_ID_DARK_BACKGROUND_PALETTE = 24,
		BL_FONT_STRING_ID_VARIATIONS_POST_SCRIPT_PREFIX = 25,
		BL_FONT_STRING_ID_COMMON_MAX_VALUE = 26,
		BL_FONT_STRING_ID_CUSTOM_START_INDEX = 255
	}
	public enum BLFontUnicodeCoverageIndex : UInt32 {
		BL_FONT_UC_INDEX_BASIC_LATIN,
		BL_FONT_UC_INDEX_LATIN1_SUPPLEMENT,
		BL_FONT_UC_INDEX_LATIN_EXTENDED_A,
		BL_FONT_UC_INDEX_LATIN_EXTENDED_B,
		BL_FONT_UC_INDEX_IPA_EXTENSIONS,
		BL_FONT_UC_INDEX_SPACING_MODIFIER_LETTERS,
		BL_FONT_UC_INDEX_COMBINING_DIACRITICAL_MARKS,
		BL_FONT_UC_INDEX_GREEK_AND_COPTIC,
		BL_FONT_UC_INDEX_COPTIC,
		BL_FONT_UC_INDEX_CYRILLIC,
		BL_FONT_UC_INDEX_ARMENIAN,
		BL_FONT_UC_INDEX_HEBREW,
		BL_FONT_UC_INDEX_VAI,
		BL_FONT_UC_INDEX_ARABIC,
		BL_FONT_UC_INDEX_NKO,
		BL_FONT_UC_INDEX_DEVANAGARI,
		BL_FONT_UC_INDEX_BENGALI,
		BL_FONT_UC_INDEX_GURMUKHI,
		BL_FONT_UC_INDEX_GUJARATI,
		BL_FONT_UC_INDEX_ORIYA,
		BL_FONT_UC_INDEX_TAMIL,
		BL_FONT_UC_INDEX_TELUGU,
		BL_FONT_UC_INDEX_KANNADA,
		BL_FONT_UC_INDEX_MALAYALAM,
		BL_FONT_UC_INDEX_THAI,
		BL_FONT_UC_INDEX_LAO,
		BL_FONT_UC_INDEX_GEORGIAN,
		BL_FONT_UC_INDEX_BALINESE,
		BL_FONT_UC_INDEX_HANGUL_JAMO,
		BL_FONT_UC_INDEX_LATIN_EXTENDED_ADDITIONAL,
		BL_FONT_UC_INDEX_GREEK_EXTENDED,
		BL_FONT_UC_INDEX_GENERAL_PUNCTUATION,
		BL_FONT_UC_INDEX_SUPERSCRIPTS_AND_SUBSCRIPTS,
		BL_FONT_UC_INDEX_CURRENCY_SYMBOLS,
		BL_FONT_UC_INDEX_COMBINING_DIACRITICAL_MARKS_FOR_SYMBOLS,
		BL_FONT_UC_INDEX_LETTERLIKE_SYMBOLS,
		BL_FONT_UC_INDEX_NUMBER_FORMS,
		BL_FONT_UC_INDEX_ARROWS,
		BL_FONT_UC_INDEX_MATHEMATICAL_OPERATORS,
		BL_FONT_UC_INDEX_MISCELLANEOUS_TECHNICAL,
		BL_FONT_UC_INDEX_CONTROL_PICTURES,
		BL_FONT_UC_INDEX_OPTICAL_CHARACTER_RECOGNITION,
		BL_FONT_UC_INDEX_ENCLOSED_ALPHANUMERICS,
		BL_FONT_UC_INDEX_BOX_DRAWING,
		BL_FONT_UC_INDEX_BLOCK_ELEMENTS,
		BL_FONT_UC_INDEX_GEOMETRIC_SHAPES,
		BL_FONT_UC_INDEX_MISCELLANEOUS_SYMBOLS,
		BL_FONT_UC_INDEX_DINGBATS,
		BL_FONT_UC_INDEX_CJK_SYMBOLS_AND_PUNCTUATION,
		BL_FONT_UC_INDEX_HIRAGANA,
		BL_FONT_UC_INDEX_KATAKANA,
		BL_FONT_UC_INDEX_BOPOMOFO,
		BL_FONT_UC_INDEX_HANGUL_COMPATIBILITY_JAMO,
		BL_FONT_UC_INDEX_PHAGS_PA,
		BL_FONT_UC_INDEX_ENCLOSED_CJK_LETTERS_AND_MONTHS,
		BL_FONT_UC_INDEX_CJK_COMPATIBILITY,
		BL_FONT_UC_INDEX_HANGUL_SYLLABLES,
		BL_FONT_UC_INDEX_NON_PLANE,
		BL_FONT_UC_INDEX_PHOENICIAN,
		BL_FONT_UC_INDEX_CJK_UNIFIED_IDEOGRAPHS,
		BL_FONT_UC_INDEX_PRIVATE_USE_PLANE0,
		BL_FONT_UC_INDEX_CJK_STROKES,
		BL_FONT_UC_INDEX_ALPHABETIC_PRESENTATION_FORMS,
		BL_FONT_UC_INDEX_ARABIC_PRESENTATION_FORMS_A,
		BL_FONT_UC_INDEX_COMBINING_HALF_MARKS,
		BL_FONT_UC_INDEX_VERTICAL_FORMS,
		BL_FONT_UC_INDEX_SMALL_FORM_VARIANTS,
		BL_FONT_UC_INDEX_ARABIC_PRESENTATION_FORMS_B,
		BL_FONT_UC_INDEX_HALFWIDTH_AND_FULLWIDTH_FORMS,
		BL_FONT_UC_INDEX_SPECIALS,
		BL_FONT_UC_INDEX_TIBETAN,
		BL_FONT_UC_INDEX_SYRIAC,
		BL_FONT_UC_INDEX_THAANA,
		BL_FONT_UC_INDEX_SINHALA,
		BL_FONT_UC_INDEX_MYANMAR,
		BL_FONT_UC_INDEX_ETHIOPIC,
		BL_FONT_UC_INDEX_CHEROKEE,
		BL_FONT_UC_INDEX_UNIFIED_CANADIAN_ABORIGINAL_SYLLABICS,
		BL_FONT_UC_INDEX_OGHAM,
		BL_FONT_UC_INDEX_RUNIC,
		BL_FONT_UC_INDEX_KHMER,
		BL_FONT_UC_INDEX_MONGOLIAN,
		BL_FONT_UC_INDEX_BRAILLE_PATTERNS,
		BL_FONT_UC_INDEX_YI_SYLLABLES_AND_RADICALS,
		BL_FONT_UC_INDEX_TAGALOG_HANUNOO_BUHID_TAGBANWA,
		BL_FONT_UC_INDEX_OLD_ITALIC,
		BL_FONT_UC_INDEX_GOTHIC,
		BL_FONT_UC_INDEX_DESERET,
		BL_FONT_UC_INDEX_MUSICAL_SYMBOLS,
		BL_FONT_UC_INDEX_MATHEMATICAL_ALPHANUMERIC_SYMBOLS,
		BL_FONT_UC_INDEX_PRIVATE_USE_PLANE_15_16,
		BL_FONT_UC_INDEX_VARIATION_SELECTORS,
		BL_FONT_UC_INDEX_TAGS,
		BL_FONT_UC_INDEX_LIMBU,
		BL_FONT_UC_INDEX_TAI_LE,
		BL_FONT_UC_INDEX_NEW_TAI_LUE,
		BL_FONT_UC_INDEX_BUGINESE,
		BL_FONT_UC_INDEX_GLAGOLITIC,
		BL_FONT_UC_INDEX_TIFINAGH,
		BL_FONT_UC_INDEX_YIJING_HEXAGRAM_SYMBOLS,
		BL_FONT_UC_INDEX_SYLOTI_NAGRI,
		BL_FONT_UC_INDEX_LINEAR_B_SYLLABARY_AND_IDEOGRAMS,
		BL_FONT_UC_INDEX_ANCIENT_GREEK_NUMBERS,
		BL_FONT_UC_INDEX_UGARITIC,
		BL_FONT_UC_INDEX_OLD_PERSIAN,
		BL_FONT_UC_INDEX_SHAVIAN,
		BL_FONT_UC_INDEX_OSMANYA,
		BL_FONT_UC_INDEX_CYPRIOT_SYLLABARY,
		BL_FONT_UC_INDEX_KHAROSHTHI,
		BL_FONT_UC_INDEX_TAI_XUAN_JING_SYMBOLS,
		BL_FONT_UC_INDEX_CUNEIFORM,
		BL_FONT_UC_INDEX_COUNTING_ROD_NUMERALS,
		BL_FONT_UC_INDEX_SUNDANESE,
		BL_FONT_UC_INDEX_LEPCHA,
		BL_FONT_UC_INDEX_OL_CHIKI,
		BL_FONT_UC_INDEX_SAURASHTRA,
		BL_FONT_UC_INDEX_KAYAH_LI,
		BL_FONT_UC_INDEX_REJANG,
		BL_FONT_UC_INDEX_CHAM,
		BL_FONT_UC_INDEX_ANCIENT_SYMBOLS,
		BL_FONT_UC_INDEX_PHAISTOS_DISC,
		BL_FONT_UC_INDEX_CARIAN_LYCIAN_LYDIAN,
		BL_FONT_UC_INDEX_DOMINO_AND_MAHJONG_TILES,
		BL_FONT_UC_INDEX_INTERNAL_USAGE_123,
		BL_FONT_UC_INDEX_INTERNAL_USAGE_124,
		BL_FONT_UC_INDEX_INTERNAL_USAGE_125,
		BL_FONT_UC_INDEX_INTERNAL_USAGE_126,
		BL_FONT_UC_INDEX_INTERNAL_USAGE_127
	}
	public enum BLTextDirection : UInt32 {
		BL_TEXT_DIRECTION_LTR = 0,
		BL_TEXT_DIRECTION_RTL = 1
	}
	public enum BLFontDataFlags : UInt32 {
		BL_FONT_DATA_NO_FLAGS = 0u,
		BL_FONT_DATA_FLAG_COLLECTION = 0x00000001u
	}
	public enum BLGlyphRunFlags : UInt32 {
		BL_GLYPH_RUN_NO_FLAGS = 0u,
		BL_GLYPH_RUN_FLAG_UCS4_CONTENT = 0x10000000u,
		BL_GLYPH_RUN_FLAG_INVALID_TEXT = 0x20000000u,
		BL_GLYPH_RUN_FLAG_UNDEFINED_GLYPHS = 0x40000000u,
		BL_GLYPH_RUN_FLAG_INVALID_FONT_DATA = 0x80000000u
	}
	public enum BLGlyphPlacementType : UInt32 {
		BL_GLYPH_PLACEMENT_TYPE_NONE = 0,
		BL_GLYPH_PLACEMENT_TYPE_ADVANCE_OFFSET = 1,
		BL_GLYPH_PLACEMENT_TYPE_DESIGN_UNITS = 2,
		BL_GLYPH_PLACEMENT_TYPE_USER_UNITS = 3,
		BL_GLYPH_PLACEMENT_TYPE_ABSOLUTE_UNITS = 4
	}
	public enum BLPathCmd : UInt32 {
		BL_PATH_CMD_MOVE = 0,
		BL_PATH_CMD_ON = 1,
		BL_PATH_CMD_QUAD = 2,
		BL_PATH_CMD_CONIC = 3,
		BL_PATH_CMD_CUBIC = 4,
		BL_PATH_CMD_CLOSE = 5,
		BL_PATH_CMD_WEIGHT = 6
	}
	public enum BLPathCmdExtra : UInt32 {
		BL_PATH_CMD_PRESERVE = 0xFFFFFFFFu
	}
	public enum BLPathFlags : UInt32 {
		BL_PATH_NO_FLAGS = 0u,
		BL_PATH_FLAG_EMPTY = 0x00000001u,
		BL_PATH_FLAG_MULTIPLE = 0x00000002u,
		BL_PATH_FLAG_QUADS = 0x00000004u,
		BL_PATH_FLAG_CONICS = 0x00000008u,
		BL_PATH_FLAG_CUBICS = 0x00000010u,
		BL_PATH_FLAG_INVALID = 0x40000000u,
		BL_PATH_FLAG_DIRTY = 0x80000000u
	}
	public enum BLPathReverseMode : UInt32 {
		BL_PATH_REVERSE_MODE_COMPLETE = 0,
		BL_PATH_REVERSE_MODE_SEPARATE = 1
	}
	public enum BLStrokeJoin : UInt32 {
		BL_STROKE_JOIN_MITER_CLIP = 0,
		BL_STROKE_JOIN_MITER_BEVEL = 1,
		BL_STROKE_JOIN_MITER_ROUND = 2,
		BL_STROKE_JOIN_BEVEL = 3,
		BL_STROKE_JOIN_ROUND = 4
	}
	public enum BLStrokeCapPosition : UInt32 {
		BL_STROKE_CAP_POSITION_START = 0,
		BL_STROKE_CAP_POSITION_END = 1
	}
	public enum BLStrokeCap : UInt32 {
		BL_STROKE_CAP_BUTT = 0,
		BL_STROKE_CAP_SQUARE = 1,
		BL_STROKE_CAP_ROUND = 2,
		BL_STROKE_CAP_ROUND_REV = 3,
		BL_STROKE_CAP_TRIANGLE = 4,
		BL_STROKE_CAP_TRIANGLE_REV = 5
	}
	public enum BLStrokeTransformOrder : UInt32 {
		BL_STROKE_TRANSFORM_ORDER_AFTER = 0,
		BL_STROKE_TRANSFORM_ORDER_BEFORE = 1
	}
	public enum BLFlattenMode : UInt32 {
		BL_FLATTEN_MODE_DEFAULT = 0,
		BL_FLATTEN_MODE_RECURSIVE = 1
	}
	public enum BLOffsetMode : UInt32 {
		BL_OFFSET_MODE_DEFAULT = 0,
		BL_OFFSET_MODE_ITERATIVE = 1
	}
	public enum BLFontFaceFlags : UInt32 {
		BL_FONT_FACE_NO_FLAGS = 0u,
		BL_FONT_FACE_FLAG_TYPOGRAPHIC_NAMES = 0x00000001u,
		BL_FONT_FACE_FLAG_TYPOGRAPHIC_METRICS = 0x00000002u,
		BL_FONT_FACE_FLAG_CHAR_TO_GLYPH_MAPPING = 0x00000004u,
		BL_FONT_FACE_FLAG_HORIZONTAL_METIRCS = 0x00000010u,
		BL_FONT_FACE_FLAG_VERTICAL_METRICS = 0x00000020u,
		BL_FONT_FACE_FLAG_HORIZONTAL_KERNING = 0x00000040u,
		BL_FONT_FACE_FLAG_VERTICAL_KERNING = 0x00000080u,
		BL_FONT_FACE_FLAG_OPENTYPE_FEATURES = 0x00000100u,
		BL_FONT_FACE_FLAG_PANOSE_DATA = 0x00000200u,
		BL_FONT_FACE_FLAG_UNICODE_COVERAGE = 0x00000400u,
		BL_FONT_FACE_FLAG_BASELINE_Y_EQUALS_0 = 0x00001000u,
		BL_FONT_FACE_FLAG_LSB_POINT_X_EQUALS_0 = 0x00002000u,
		BL_FONT_FACE_FLAG_VARIATION_SEQUENCES = 0x10000000u,
		BL_FONT_FACE_FLAG_OPENTYPE_VARIATIONS = 0x20000000u,
		BL_FONT_FACE_FLAG_SYMBOL_FONT = 0x40000000u,
		BL_FONT_FACE_FLAG_LAST_RESORT_FONT = 0x80000000u
	}
	public enum BLFontFaceDiagFlags : UInt32 {
		BL_FONT_FACE_DIAG_NO_FLAGS = 0u,
		BL_FONT_FACE_DIAG_WRONG_NAME_DATA = 0x00000001u,
		BL_FONT_FACE_DIAG_FIXED_NAME_DATA = 0x00000002u,
		BL_FONT_FACE_DIAG_WRONG_KERN_DATA = 0x00000004u,
		BL_FONT_FACE_DIAG_FIXED_KERN_DATA = 0x00000008u,
		BL_FONT_FACE_DIAG_WRONG_CMAP_DATA = 0x00000010u,
		BL_FONT_FACE_DIAG_WRONG_CMAP_FORMAT = 0x00000020u
	}
	public enum BLFontOutlineType : UInt32 {
		BL_FONT_OUTLINE_TYPE_NONE = 0,
		BL_FONT_OUTLINE_TYPE_TRUETYPE = 1,
		BL_FONT_OUTLINE_TYPE_CFF = 2,
		BL_FONT_OUTLINE_TYPE_CFF2 = 3
	}
	public enum BLTransformType : UInt32 {
		BL_TRANSFORM_TYPE_IDENTITY = 0,
		BL_TRANSFORM_TYPE_TRANSLATE = 1,
		BL_TRANSFORM_TYPE_SCALE = 2,
		BL_TRANSFORM_TYPE_SWAP = 3,
		BL_TRANSFORM_TYPE_AFFINE = 4,
		BL_TRANSFORM_TYPE_INVALID = 5
	}
	public enum BLTransformOp : UInt32 {
		BL_TRANSFORM_OP_RESET = 0,
		BL_TRANSFORM_OP_ASSIGN = 1,
		BL_TRANSFORM_OP_TRANSLATE = 2,
		BL_TRANSFORM_OP_SCALE = 3,
		BL_TRANSFORM_OP_SKEW = 4,
		BL_TRANSFORM_OP_ROTATE = 5,
		BL_TRANSFORM_OP_ROTATE_PT = 6,
		BL_TRANSFORM_OP_TRANSFORM = 7,
		BL_TRANSFORM_OP_POST_TRANSLATE = 8,
		BL_TRANSFORM_OP_POST_SCALE = 9,
		BL_TRANSFORM_OP_POST_SKEW = 10,
		BL_TRANSFORM_OP_POST_ROTATE = 11,
		BL_TRANSFORM_OP_POST_ROTATE_PT = 12,
		BL_TRANSFORM_OP_POST_TRANSFORM = 13
	}
	public enum BLGradientType : UInt32 {
		BL_GRADIENT_TYPE_LINEAR = 0,
		BL_GRADIENT_TYPE_RADIAL = 1,
		BL_GRADIENT_TYPE_CONIC = 2
	}
	public enum BLGradientValue : UInt32 {
		BL_GRADIENT_VALUE_COMMON_X0 = 0,
		BL_GRADIENT_VALUE_COMMON_Y0 = 1,
		BL_GRADIENT_VALUE_COMMON_X1 = 2,
		BL_GRADIENT_VALUE_COMMON_Y1 = 3,
		BL_GRADIENT_VALUE_RADIAL_R0 = 4,
		BL_GRADIENT_VALUE_RADIAL_R1 = 5,
		BL_GRADIENT_VALUE_CONIC_ANGLE = 2,
		BL_GRADIENT_VALUE_CONIC_REPEAT = 3
	}
	public enum BLGradientQuality : UInt32 {
		BL_GRADIENT_QUALITY_NEAREST = 0,
		BL_GRADIENT_QUALITY_SMOOTH = 1,
		BL_GRADIENT_QUALITY_DITHER = 2
	}
	public enum BLFormat : UInt32 {
		BL_FORMAT_NONE = 0,
		BL_FORMAT_PRGB32 = 1,
		BL_FORMAT_XRGB32 = 2,
		BL_FORMAT_A8 = 3
	}
	public enum BLFormatFlags : UInt32 {
		BL_FORMAT_NO_FLAGS = 0u,
		BL_FORMAT_FLAG_RGB = 0x00000001u,
		BL_FORMAT_FLAG_ALPHA = 0x00000002u,
		BL_FORMAT_FLAG_RGBA = 0x00000003u,
		BL_FORMAT_FLAG_LUM = 0x00000004u,
		BL_FORMAT_FLAG_LUMA = 0x00000006u,
		BL_FORMAT_FLAG_INDEXED = 0x00000010u,
		BL_FORMAT_FLAG_PREMULTIPLIED = 0x00000100u,
		BL_FORMAT_FLAG_BYTE_SWAP = 0x00000200u,
		BL_FORMAT_FLAG_BYTE_ALIGNED = 0x00010000u,
		BL_FORMAT_FLAG_UNDEFINED_BITS = 0x00020000u
	}
	public enum BLImageCodecFeatures : UInt32 {
		BL_IMAGE_CODEC_NO_FEATURES = 0u,
		BL_IMAGE_CODEC_FEATURE_READ = 0x00000001u,
		BL_IMAGE_CODEC_FEATURE_WRITE = 0x00000002u,
		BL_IMAGE_CODEC_FEATURE_LOSSLESS = 0x00000004u,
		BL_IMAGE_CODEC_FEATURE_LOSSY = 0x00000008u,
		BL_IMAGE_CODEC_FEATURE_MULTI_FRAME = 0x00000010u,
		BL_IMAGE_CODEC_FEATURE_IPTC = 0x10000000u,
		BL_IMAGE_CODEC_FEATURE_EXIF = 0x20000000u,
		BL_IMAGE_CODEC_FEATURE_XMP = 0x40000000u
	}
	public enum BLImageInfoFlags : UInt32 {
		BL_IMAGE_INFO_FLAG_NO_FLAGS = 0u,
		BL_IMAGE_INFO_FLAG_PROGRESSIVE = 0x00000001u
	}
	public enum BLImageScaleFilter : UInt32 {
		BL_IMAGE_SCALE_FILTER_NONE = 0,
		BL_IMAGE_SCALE_FILTER_NEAREST = 1,
		BL_IMAGE_SCALE_FILTER_BILINEAR = 2,
		BL_IMAGE_SCALE_FILTER_BICUBIC = 3,
		BL_IMAGE_SCALE_FILTER_LANCZOS = 4
	}
	public enum BLPatternQuality : UInt32 {
		BL_PATTERN_QUALITY_NEAREST = 0,
		BL_PATTERN_QUALITY_BILINEAR = 1
	}
	public enum BLContextType : UInt32 {
		BL_CONTEXT_TYPE_NONE = 0,
		BL_CONTEXT_TYPE_DUMMY = 1,
		BL_CONTEXT_TYPE_RASTER = 3
	}
	public enum BLContextHint : UInt32 {
		BL_CONTEXT_HINT_RENDERING_QUALITY = 0,
		BL_CONTEXT_HINT_GRADIENT_QUALITY = 1,
		BL_CONTEXT_HINT_PATTERN_QUALITY = 2
	}
	public enum BLContextStyleSlot : UInt32 {
		BL_CONTEXT_STYLE_SLOT_FILL = 0,
		BL_CONTEXT_STYLE_SLOT_STROKE = 1
	}
	public enum BLContextRenderTextOp : UInt32 {
		BL_CONTEXT_RENDER_TEXT_OP_UTF8 = BLTextEncoding.BL_TEXT_ENCODING_UTF8,
		BL_CONTEXT_RENDER_TEXT_OP_UTF16 = BLTextEncoding.BL_TEXT_ENCODING_UTF16,
		BL_CONTEXT_RENDER_TEXT_OP_UTF32 = BLTextEncoding.BL_TEXT_ENCODING_UTF32,
		BL_CONTEXT_RENDER_TEXT_OP_LATIN1 = BLTextEncoding.BL_TEXT_ENCODING_LATIN1,
		BL_CONTEXT_RENDER_TEXT_OP_GLYPH_RUN = 4
	}
	public enum BLContextFlushFlags : UInt32 {
		BL_CONTEXT_FLUSH_NO_FLAGS = 0u,
		BL_CONTEXT_FLUSH_SYNC = 0x80000000u
	}
	public enum BLContextCreateFlags : UInt32 {
		BL_CONTEXT_CREATE_NO_FLAGS = 0u,
		BL_CONTEXT_CREATE_FLAG_DISABLE_JIT = 0x00000001u,
		BL_CONTEXT_CREATE_FLAG_FALLBACK_TO_SYNC = 0x00100000u,
		BL_CONTEXT_CREATE_FLAG_ISOLATED_THREAD_POOL = 0x01000000u,
		BL_CONTEXT_CREATE_FLAG_ISOLATED_JIT_RUNTIME = 0x02000000u,
		BL_CONTEXT_CREATE_FLAG_ISOLATED_JIT_LOGGING = 0x04000000u,
		BL_CONTEXT_CREATE_FLAG_OVERRIDE_CPU_FEATURES = 0x08000000u
	}
	public enum BLContextErrorFlags : UInt32 {
		BL_CONTEXT_ERROR_NO_FLAGS = 0u,
		BL_CONTEXT_ERROR_FLAG_INVALID_VALUE = 0x00000001u,
		BL_CONTEXT_ERROR_FLAG_INVALID_STATE = 0x00000002u,
		BL_CONTEXT_ERROR_FLAG_INVALID_GEOMETRY = 0x00000004u,
		BL_CONTEXT_ERROR_FLAG_INVALID_GLYPH = 0x00000008u,
		BL_CONTEXT_ERROR_FLAG_INVALID_FONT = 0x00000010u,
		BL_CONTEXT_ERROR_FLAG_THREAD_POOL_EXHAUSTED = 0x20000000u,
		BL_CONTEXT_ERROR_FLAG_OUT_OF_MEMORY = 0x40000000u,
		BL_CONTEXT_ERROR_FLAG_UNKNOWN_ERROR = 0x80000000u
	}
	public enum BLContextStyleSwapMode : UInt32 {
		BL_CONTEXT_STYLE_SWAP_MODE_STYLES = 0,
		BL_CONTEXT_STYLE_SWAP_MODE_STYLES_WITH_ALPHA = 1
	}
	public enum BLContextStyleTransformMode : UInt32 {
		BL_CONTEXT_STYLE_TRANSFORM_MODE_USER = 0,
		BL_CONTEXT_STYLE_TRANSFORM_MODE_META = 1,
		BL_CONTEXT_STYLE_TRANSFORM_MODE_NONE = 2
	}
	public enum BLClipMode : UInt32 {
		BL_CLIP_MODE_ALIGNED_RECT = 0,
		BL_CLIP_MODE_UNALIGNED_RECT = 1,
		BL_CLIP_MODE_MASK = 2
	}
	public enum BLCompOp : UInt32 {
		BL_COMP_OP_SRC_OVER = 0,
		BL_COMP_OP_SRC_COPY = 1,
		BL_COMP_OP_SRC_IN = 2,
		BL_COMP_OP_SRC_OUT = 3,
		BL_COMP_OP_SRC_ATOP = 4,
		BL_COMP_OP_DST_OVER = 5,
		BL_COMP_OP_DST_COPY = 6,
		BL_COMP_OP_DST_IN = 7,
		BL_COMP_OP_DST_OUT = 8,
		BL_COMP_OP_DST_ATOP = 9,
		BL_COMP_OP_XOR = 10,
		BL_COMP_OP_CLEAR = 11,
		BL_COMP_OP_PLUS = 12,
		BL_COMP_OP_MINUS = 13,
		BL_COMP_OP_MODULATE = 14,
		BL_COMP_OP_MULTIPLY = 15,
		BL_COMP_OP_SCREEN = 16,
		BL_COMP_OP_OVERLAY = 17,
		BL_COMP_OP_DARKEN = 18,
		BL_COMP_OP_LIGHTEN = 19,
		BL_COMP_OP_COLOR_DODGE = 20,
		BL_COMP_OP_COLOR_BURN = 21,
		BL_COMP_OP_LINEAR_BURN = 22,
		BL_COMP_OP_LINEAR_LIGHT = 23,
		BL_COMP_OP_PIN_LIGHT = 24,
		BL_COMP_OP_HARD_LIGHT = 25,
		BL_COMP_OP_SOFT_LIGHT = 26,
		BL_COMP_OP_DIFFERENCE = 27,
		BL_COMP_OP_EXCLUSION = 28
	}
	public enum BLRenderingQuality : UInt32 {
		BL_RENDERING_QUALITY_ANTIALIAS = 0
	}
	public enum BLPixelConverterCreateFlags : UInt32 {
		BL_PIXEL_CONVERTER_CREATE_NO_FLAGS = 0u,
		BL_PIXEL_CONVERTER_CREATE_FLAG_DONT_COPY_PALETTE = 0x00000001u,
		BL_PIXEL_CONVERTER_CREATE_FLAG_ALTERABLE_PALETTE = 0x00000002u,
		BL_PIXEL_CONVERTER_CREATE_FLAG_NO_MULTI_STEP = 0x00000004u
	}
	public enum BLRuntimeLimits : UInt32 {
		BL_RUNTIME_MAX_IMAGE_SIZE = 65535,
		BL_RUNTIME_MAX_THREAD_COUNT = 32
	}
	public enum BLRuntimeInfoType : UInt32 {
		BL_RUNTIME_INFO_TYPE_BUILD = 0,
		BL_RUNTIME_INFO_TYPE_SYSTEM = 1,
		BL_RUNTIME_INFO_TYPE_RESOURCE = 2
	}
	public enum BLRuntimeBuildType : UInt32 {
		BL_RUNTIME_BUILD_TYPE_DEBUG = 0,
		BL_RUNTIME_BUILD_TYPE_RELEASE = 1
	}
	public enum BLRuntimeCpuArch : UInt32 {
		BL_RUNTIME_CPU_ARCH_UNKNOWN = 0,
		BL_RUNTIME_CPU_ARCH_X86 = 1,
		BL_RUNTIME_CPU_ARCH_ARM = 2,
		BL_RUNTIME_CPU_ARCH_MIPS = 3
	}
	public enum BLRuntimeCpuFeatures : UInt32 {
		BL_RUNTIME_CPU_FEATURE_X86_SSE2 = 0x00000001u,
		BL_RUNTIME_CPU_FEATURE_X86_SSE3 = 0x00000002u,
		BL_RUNTIME_CPU_FEATURE_X86_SSSE3 = 0x00000004u,
		BL_RUNTIME_CPU_FEATURE_X86_SSE4_1 = 0x00000008u,
		BL_RUNTIME_CPU_FEATURE_X86_SSE4_2 = 0x00000010u,
		BL_RUNTIME_CPU_FEATURE_X86_AVX = 0x00000020u,
		BL_RUNTIME_CPU_FEATURE_X86_AVX2 = 0x00000040u,
		BL_RUNTIME_CPU_FEATURE_X86_AVX512 = 0x00000080u,
		BL_RUNTIME_CPU_FEATURE_ARM_ASIMD = 0x00000001u,
		BL_RUNTIME_CPU_FEATURE_ARM_CRC32 = 0x00000002u,
		BL_RUNTIME_CPU_FEATURE_ARM_PMULL = 0x00000004u
	}
	public enum BLRuntimeCleanupFlags : UInt32 {
		BL_RUNTIME_CLEANUP_NO_FLAGS = 0u,
		BL_RUNTIME_CLEANUP_OBJECT_POOL = 0x00000001u,
		BL_RUNTIME_CLEANUP_ZEROED_POOL = 0x00000002u,
		BL_RUNTIME_CLEANUP_THREAD_POOL = 0x00000010u,
		BL_RUNTIME_CLEANUP_EVERYTHING = 0xFFFFFFFFu
	}
}
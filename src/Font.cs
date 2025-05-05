using System;
using System.Collections.Generic;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// A font face. Read from an OTF/TTF
/// </summary>
public sealed class FontFace : BlendObject<BLFontFaceCore> {
	private sealed class Data : BlendObject<BLFontDataCore> {
		internal Data(String path) {
			unsafe {
				fixed (BLFontDataCore* pcore = &core)
					if (blFontDataCreateFromFile(pcore, path, BLFileReadFlags.BL_FILE_READ_MMAP_ENABLED | BLFileReadFlags.BL_FILE_READ_MMAP_AVOID_SMALL) != BLResult.BL_SUCCESS)
						throw new ArgumentException("Font couldn't be read from disk or it is invalid", nameof(path));
			}
		}
		internal Data(Array<Byte> bytes) {
			unsafe {
				fixed (BLFontDataCore* pcore = &core)
				fixed (BLArrayCore* pdata = &bytes.core)
					if (blFontDataCreateFromDataArray(pcore, pdata) != BLResult.BL_SUCCESS)
						throw new ArgumentException("Invalid OTF/TTF data provided", nameof(bytes));
			}
		}
	}
	private readonly Data fontData;
	private readonly unsafe struct BLFontFaceImplReduced {
		private readonly void* virt;
		internal readonly BLFontWeight weight;
		internal readonly BLFontStretch stretch;
		internal readonly BLFontStyle style;
	}
	/// <summary>
	/// Returns the default weight of the font face; Which can be its only supported weight as well.
	/// <para/>
	/// A weight of zero is of uninitialised font faces and is thus invalid
	/// </summary>
	public BLFontWeight Weight {
		get {
			unsafe {
				return ((BLFontFaceImplReduced*) core.obj.impl)->weight;
			}
		}
	}
	/// <summary>
	/// Returns the default stretch of the font face; Which can be its only supported weight as well.
	/// <para/>
	/// A stretch of zero is of uninitialised font faces and is thus invalid
	/// </summary>
	public BLFontStretch Stretch {
		get {
			unsafe {
				return ((BLFontFaceImplReduced*) core.obj.impl)->stretch;
			}
		}
	}
	/// <summary>
	/// Returns the style of the font face
	/// </summary>
	public BLFontStyle Style {
		get {
			unsafe {
				return ((BLFontFaceImplReduced*) core.obj.impl)->style;
			}
		}
	}
	/// <inheritdoc cref="PInvoke.GetFaceInformation"/>
	public BLFontFaceInfo Info => core.GetFaceInformation();
	/// <summary>
	/// Number of glyphs provided by this font
	/// </summary>
	public UInt32 GlyphCount => Info.glyphCount;
	/// <summary>
	/// Zero-based index of a face within a OpenType/TrueType collection; Zero if not part of a collection
	/// </summary>
	public UInt32 FaceIndex => Info.faceIndex;
	/// <summary>
	/// Features the font supports
	/// </summary>
	public BLFontFaceFlags FaceFlags => Info.faceFlags;
	/// <summary>
	/// Problems detected with the font
	/// </summary>
	public BLFontFaceDiagFlags DiagnosticFlags => Info.diagFlags;
	/// <summary>
	/// Full name of the font face
	/// </summary>
	public String FullName => core.GetFullName() ?? "";
	/// <summary>
	/// Typographic family name of the font face
	/// </summary>
	public String FamilyName => core.GetFamilyName() ?? "";
	/// <summary>
	/// Typographic subfamily name of the font face
	/// </summary>
	public String SubfamilyName => core.GetSubfamilyName() ?? "";
	/// <summary>
	/// PostScript name of the font face
	/// </summary>
	public String PostScriptName => core.GetPostScriptName() ?? "";
	/// <summary>
	/// Design metrics of this font face
	/// </summary>
	public BLFontDesignMetrics DesignMetrics => core.GetDesignMetrics();
	/// <summary>
	/// Self-reported unicode coverage of the font face. Can be wrong
	/// </summary>
	public BLFontUnicodeCoverageIndex[] UnicodeCoverage => (BLFontUnicodeCoverageIndex[]) core.GetUnicodeCoverage();
	/// <summary>
	/// Initialises a font face descriptor which can be used to construct fonts
	/// </summary>
	/// <param name="path"></param>
	/// <param name="index"></param>
	/// <exception cref="ArgumentException">When font face trying to be parsed off <paramref name="path"/> is invalid or missing</exception>
	public FontFace(String path, UInt32 index) {
		fontData = new(path);
		dependentDisposables.Add(fontData);
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
			fixed (BLFontDataCore* pdata = &fontData.core)
				blFontFaceCreateFromData(pcore, pdata, index);
		}
	}
	/// <summary>
	/// Initialises a font face descriptor which can be used to construct fonts
	/// </summary>
	/// <param name="bytes"></param>
	/// <param name="index"></param>
	/// <exception cref="ArgumentException">When font face trying to be parsed off <paramref name="bytes"/> is invalid or missing</exception>
	public FontFace(ICollection<Byte> bytes, UInt32 index) {
		using Array<Byte> array = [.. bytes];
		fontData = new(array);
		dependentDisposables.Add(fontData);
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
			fixed (BLFontDataCore* pdata = &fontData.core)
				blFontFaceCreateFromData(pcore, pdata, index);
		}
	}
}
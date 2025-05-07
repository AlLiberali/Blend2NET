using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using static AlLiberali.Blend2NET.PInvoke;

namespace AlLiberali.Blend2NET;

/// <summary>
/// A font face. Read from an OTF/TTF
/// </summary>
public sealed class FontFace : BlendObject<BLFontFaceCore> {
	private sealed class Data : BlendObject<BLFontDataCore> {
		internal Data(String path) {
			unsafe {
				core.Initialise();
				fixed (BLFontDataCore* pcore = &core)
					if (blFontDataCreateFromFile(pcore, path, BLFileReadFlags.BL_FILE_READ_MMAP_ENABLED | BLFileReadFlags.BL_FILE_READ_MMAP_AVOID_SMALL) != BLResult.BL_SUCCESS)
						throw new ArgumentException("Font couldn't be read from disk or it is invalid", nameof(path));
			}
		}
		internal Data(Array<Byte> bytes) {
			unsafe {
				core.Initialise();
				fixed (BLFontDataCore* pcore = &core)
				fixed (BLArrayCore* pdata = &bytes.core)
					if (blFontDataCreateFromDataArray(pcore, pdata) != BLResult.BL_SUCCESS)
						throw new ArgumentException("Invalid OTF/TTF data provided", nameof(bytes));
			}
		}
	}
	private readonly Data fontData;
	private readonly unsafe struct BLFontFaceImplReduced {
#pragma warning disable CS0169
		private readonly void* virt;
#pragma warning restore CS0169
#pragma warning disable CS0649
		internal readonly BLFontWeight weight;
		internal readonly BLFontStretch stretch;
		internal readonly BLFontStyle style;
#pragma warning restore CS0649
	}
	/// <summary>
	/// Returns the default weight of the font face; Which can be its only supported weight as well.
	/// <para/>
	/// A weight of zero is of uninitialised font faces and is thus invalid
	/// </summary>
	public BLFontWeight Weight {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
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
			ObjectDisposedException.ThrowIf(disposedValue, this);
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
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				return ((BLFontFaceImplReduced*) core.obj.impl)->style;
			}
		}
	}
	/// <inheritdoc cref="PInvoke.GetFaceInformation"/>
	public BLFontFaceInfo Info {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetFaceInformation();
		}
	}
	/// <summary>
	/// Number of glyphs provided by this font
	/// </summary>
	public UInt32 GlyphCount {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return Info.glyphCount;
		}
	}
	/// <summary>
	/// Zero-based index of a face within a OpenType/TrueType collection; Zero if not part of a collection
	/// </summary>
	public UInt32 FaceIndex {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return Info.faceIndex;
		}
	}
	/// <summary>
	/// Features the font supports
	/// </summary>
	public BLFontFaceFlags FaceFlags {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return Info.faceFlags;
		}
	}
	/// <summary>
	/// Problems detected with the font
	/// </summary>
	public BLFontFaceDiagFlags DiagnosticFlags {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return Info.diagFlags;
		}
	}
	/// <summary>
	/// Full name of the font face
	/// </summary>
	public String FullName {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetFullName() ?? "";
		}
	}
	/// <summary>
	/// Typographic family name of the font face
	/// </summary>
	public String FamilyName {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetFamilyName() ?? "";
		}
	}
	/// <summary>
	/// Typographic subfamily name of the font face
	/// </summary>
	public String SubfamilyName {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetSubfamilyName() ?? "";
		}
	}
	/// <summary>
	/// PostScript name of the font face
	/// </summary>
	public String PostScriptName {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetPostScriptName() ?? "";
		}
	}
	/// <summary>
	/// Design metrics of this font face
	/// </summary>
	public BLFontDesignMetrics DesignMetrics {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return core.GetDesignMetrics();
		}
	}
	/// <summary>
	/// Self-reported unicode coverage of the font face. Can be wrong
	/// </summary>
	public BLFontUnicodeCoverageIndex[] UnicodeCoverage {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			return (BLFontUnicodeCoverageIndex[]) core.GetUnicodeCoverage();
		}
	}
	/// <summary>
	/// Initialises a font face descriptor which can be used to construct fonts
	/// </summary>
	/// <param name="path"></param>
	/// <param name="index"></param>
	/// <exception cref="ArgumentException">When font face trying to be parsed off <paramref name="path"/> is invalid or missing</exception>
	public FontFace(String path, UInt32 index) {
		fontData = new(path);
		dependentDisposables.Add(fontData);
		core.Initialise();
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
		core.Initialise();
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
			fixed (BLFontDataCore* pdata = &fontData.core)
				blFontFaceCreateFromData(pcore, pdata, index);
		}
	}
	private unsafe delegate BLResult GetTagProcedure(BLFontFaceCore* pcore, BLArrayCore* pdata);
	private IEnumerable<BLTag> GetAvailableTags(GetTagProcedure f) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		using Array<BLTag> array = [];
		unsafe {
			fixed (BLFontFaceCore* pcore = &core)
			fixed (BLArrayCore* pdata = &array.core)
				f(pcore, pdata);
		}
		BLTag[] ret = new BLTag[array.Count];
		array.CopyTo(ret, 0);
		return ret;
	}
	/// <summary>
	/// Script tags supported by this font face
	/// </summary>
	public IEnumerable<BLTag> GetAvailableScriptTags() {
		unsafe {
			return GetAvailableTags(blFontFaceGetScriptTags);
		}
	}
	/// <summary>
	/// Feature tags supported by this font face
	/// </summary>
	public IEnumerable<BLTag> GetAvailableFeatureTags() {
		unsafe {
			return GetAvailableTags(blFontFaceGetFeatureTags);
		}
	}
	/// <summary>
	/// Variation tags supported by this font face
	/// </summary>
	public IEnumerable<BLTag> GetAvailableVariationTags() {
		unsafe {
			return GetAvailableTags(blFontFaceGetVariationTags);
		}
	}
	/// <summary>
	/// Creates a font instance of <paramref name="size"/> initial size
	/// </summary>
	public Font CreateFont(Single size) {
		ObjectDisposedException.ThrowIf(disposedValue, this);
		Font ret = new Font(this, size);
		dependentDisposables.Add(ret);
		return ret;
	}
}
/// <summary>
/// A font with specified size, variation and settings, created out of a font face, used to draw glyphs
/// </summary>
public sealed class Font : BlendObject<BLFontCore> {

	/// <summary>
	/// The font face this font got created from
	/// </summary>
	public FontFace FontFace { get; }
	/// <summary>
	/// The font's size
	/// </summary>
	public Single Size {
		get {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLFontCore* pcore = &core)
					return blFontGetSize(pcore);
			}
		}
		set {
			ObjectDisposedException.ThrowIf(disposedValue, this);
			unsafe {
				fixed (BLFontCore* pcore = &core)
					blFontSetSize(pcore, value);
			}
		}
	}
	/// <summary>
	/// OpenType feature tags set for this font instance. Query the underlying <see cref="FontFace"/>'s
	/// <see cref="FontFace.GetAvailableFeatureTags"/> for supported tags.
	/// </summary>
	public TagFacadeDictionary<BLFontFeatureSettingsCore, BLFontFeatureItem, BLFontFeatureSettingsView, UInt32> Features { get; }
	/// <summary>
	/// OpenType variation tags set for this font instance. Query the underlying <see cref="FontFace"/>'s
	/// <see cref="FontFace.GetAvailableFeatureTags"/> for supported tags.
	/// </summary>
	public TagFacadeDictionary<BLFontVariationSettingsCore, BLFontVariationItem, BLFontVariationSettingsView, Single> Variations { get; }
	internal Font(FontFace fontFace, Single size) {
		FontFace = fontFace;
		core.Initialise();
		unsafe {
			fixed (BLFontCore* pcore = &core)
			fixed (BLFontFaceCore* pmummy = &fontFace.core)
				blFontCreateFromFace(pcore, pmummy, size);
		}
		unsafe {
			Features = new(
				this,
				blFontGetFeatureSettings,
				blFontFeatureSettingsGetValue,
				blFontFeatureSettingsSetValue,
				blFontFeatureSettingsHasValue,
				blFontFeatureSettingsRemoveValue,
				blFontFeatureSettingsGetSize,
				blFontFeatureSettingsClear,
				blFontFeatureSettingsGetView
			);
			Variations = new(
				this,
				blFontGetVariationSettings,
				blFontVariationSettingsGetValue,
				blFontVariationSettingsSetValue,
				blFontVariationSettingsHasValue,
				blFontVariationSettingsRemoveValue,
				blFontVariationSettingsGetSize,
				blFontVariationSettingsClear,
				blFontVariationSettingsGetView
			);
		}
		dependentDisposables.Add(Features);
		dependentDisposables.Add(Variations);
	}
}
/// <summary>
/// Interface for the variation and feature settings in a <see cref="Font"/>
/// </summary>
public sealed class TagFacadeDictionary<T, TItem, TView, TValue>
	: BlendObject<T>,
	IDictionary<BLTag, TValue>
	where T : unmanaged, IGenericInitialisable, IGenericMoveInitialisableAndDestroyable
	where TItem : unmanaged
	where TView : unmanaged
	where TValue : unmanaged {
	#region eww dont look
	internal unsafe delegate BLResult GetSettings(BLFontCore* pcore, T* settings);
	internal unsafe delegate TValue GetValue(T* settings, BLTag key);
	internal unsafe delegate BLResult SetValue(T* settings, BLTag key, TValue value);
	internal unsafe delegate Boolean HasKey(T* settings, BLTag key);
	internal unsafe delegate BLResult RemoveKey(T* settings, BLTag key);
	internal unsafe delegate IntPtr Length(T* settings);
	internal unsafe delegate BLResult ClearFunc(T* settings);
	internal unsafe delegate BLResult View(T* settings, TView* view);
	private readonly GetSettings getSettings;
	private readonly GetValue getValue;
	private readonly SetValue setValue;
	private readonly HasKey hasKey;
	private readonly RemoveKey removeKey;
	private readonly Length length;
	private readonly ClearFunc clear;
	private readonly View view;
	private readonly Font mummy;
	internal TagFacadeDictionary(Font m, GetSettings a, GetValue c, SetValue d, HasKey e, RemoveKey f, Length g, ClearFunc h, View i) {
		mummy = m;
		getSettings = a;
		getValue = c;
		setValue = d;
		hasKey = e;
		removeKey = f;
		length = g;
		clear = h;
		view = i;
		core.Initialise();
		unsafe {
			fixed (T* pcore = &core)
			fixed (BLFontCore* pmummy = &mummy.core)
				getSettings(pmummy, pcore);
		}
	}
	#endregion eww dont look
	/// <inheritdoc/>
	public TValue this[BLTag key] {
		get => TryGetValue(key, out TValue value) ? value : throw new KeyNotFoundException();
		set {
			unsafe {
				fixed (T* pcore = &core)
					setValue(pcore, key, value);
			}
		}
	}
	/// <inheritdoc/>
	public Int32 Count {
		get {
			ObjectDisposedException.ThrowIf(mummy.IsDisposed, mummy);
			unsafe {
				fixed (T* pcore = &core)
					return (Int32) length(pcore);
			}
		}
	}
	/// <inheritdoc/>
	public ICollection<BLTag> Keys => [.. this.Select(pair => pair.Key)];
	/// <inheritdoc/>
	public ICollection<TValue> Values => [.. this.Select(pair => pair.Value)];
	/// <inheritdoc/>
	public Boolean IsReadOnly => false;
	/// <inheritdoc/>
	public Boolean ContainsKey(BLTag key) {
		unsafe {
			fixed (T* pcore = &core)
				return hasKey(pcore, key);
		}
	}
	/// <inheritdoc/>
	public IEnumerator<KeyValuePair<BLTag, TValue>> GetEnumerator() {
		ObjectDisposedException.ThrowIf(mummy.IsDisposed, mummy);
		KeyValuePair<BLTag, TValue>[] items;
		unsafe {
			T* psettings = stackalloc T[1];
			TView* pview = stackalloc TView[1];
			fixed (T* pcore = &core)
				view(pcore, pview);
			TItem* pitems = (TItem*) ((BLFontVariationSettingsView*) pview)->data;
			items = new ReadOnlySpan<KeyValuePair<BLTag, TValue>>(pitems, Count).ToArray();
		}
		return ((IEnumerable<KeyValuePair<BLTag, TValue>>) items).GetEnumerator();
	}
	/// <inheritdoc/>
	public Boolean TryGetValue(BLTag key, out TValue value) {
		ObjectDisposedException.ThrowIf(mummy.IsDisposed, mummy);
		value = default;
		unsafe {
			if (!ContainsKey(key))
				return false;
			fixed (T* pcore = &core)
				value = getValue(pcore, key);
		}
		return true;
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc/>
	public void Add(BLTag key, TValue value) => this[key] = value;
	/// <inheritdoc/>
	public Boolean Remove(BLTag key) {
		if (!ContainsKey(key))
			return false;
		unsafe {
			fixed (T* pcore = &core)
				removeKey(pcore, key);
		}
		return true;
	}
	/// <inheritdoc/>
	public void Add(KeyValuePair<BLTag, TValue> item) => this[item.Key] = item.Value;
	/// <inheritdoc/>
	public void Clear() {
		unsafe {
			fixed (T* pcore = &core)
				clear(pcore);
		}
	}
	/// <inheritdoc/>
	public Boolean Contains(KeyValuePair<BLTag, TValue> item) => ContainsKey(item.Key) && this[item.Key].Equals(item.Value);
	/// <inheritdoc/>
	public void CopyTo(KeyValuePair<BLTag, TValue>[] array, Int32 arrayIndex) => this.ToArray().CopyTo(array, arrayIndex);
	/// <inheritdoc/>
	public Boolean Remove(KeyValuePair<BLTag, TValue> item) => Contains(item) && Remove(item.Key);
}
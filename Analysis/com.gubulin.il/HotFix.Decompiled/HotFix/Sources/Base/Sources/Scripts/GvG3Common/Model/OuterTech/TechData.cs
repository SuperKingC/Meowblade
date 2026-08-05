using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Helpers;
using UI.GvGOuterTech;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

public class TechData
{
	public readonly string ItemId;

	private GDEItemData _ConfigData;

	private OuterTechEffectConfig _TechEffect;

	private ITechEffectParser _TechEffectParser;

	public int CacheCount = -1;

	private string _ItemIconUrl;

	public UI_com_TechListPage.TechDataGroup TGroup;

	public GDEItemData ConfigData => _ConfigData ?? (_ConfigData = GDMgr.Get<GDEItemData>(ItemId));

	public OuterTechEffectConfig TechEffect => _TechEffect ?? (_TechEffect = ConfigData.Effect.ToObject<OuterTechEffectConfig>());

	public eOuterTechType TechType => TechEffect?.Type ?? eOuterTechType.Empty;

	public ITechEffectParser TechEffectParser => _TechEffectParser ?? (_TechEffectParser = TechType.GetEffectParser(ConfigData));

	public string TechIconUrl => _ItemIconUrl ?? (_ItemIconUrl = "ui://GvGOuterTech/" + ConfigData.Icon);

	public string Name => ConfigData.Name;

	public string Desc => ConfigData.PostScript;

	public int Rarity => ConfigData.Rarity;

	public int Level => (CacheCount < 0) ? GameManagers.Instance.StockController.GetStock(ItemId) : CacheCount;

	public int MaxLevel => TechEffect.Limit;

	public bool IsMaxLevel => Level == MaxLevel;

	public string CurLevelEffectDesc => TechEffectParser.GetLevelDesc(Mathf.Max(Level, 1));

	public string NextLevelEffectDesc => TechEffectParser.GetLevelDesc(Mathf.Min(Level + 1, MaxLevel));

	public string MaxLevelEffectDesc => TechEffectParser.GetLevelDesc(MaxLevel);

	public bool Unlocked => TGroup == null || TGroup.Unlocked;

	public float EffectValue
	{
		get
		{
			if (TechEffect.Type == eOuterTechType.AddGvGAttribute)
			{
				TechType6_Parser techType6_Parser = (TechType6_Parser)TechEffectParser;
				float x = techType6_Parser.GetX(Level);
				if (techType6_Parser.IsPercent)
				{
					return x * 100f;
				}
			}
			ILRuntimeDebug.LogError("Unhandled Tech EffectValue: " + ItemId);
			return 0f;
		}
	}

	public TechData(string itemId, int cacheCount = -1)
	{
		ItemId = itemId;
		CacheCount = cacheCount;
	}
}

using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

public class RarityData
{
	public class EffectConfig
	{
		public int Produce;

		public int Consume;
	}

	public enum RarityType
	{
		Gray = 1,
		Green,
		Blue,
		Purple,
		Orange,
		Yellow,
		Red
	}

	public readonly int Rarity;

	private GDEItemData _ConfigData;

	private EffectConfig _PieceEffect;

	private string _PieceItemId;

	private string _PieceItemIconUrl;

	public RarityType RT => (RarityType)Rarity;

	public GDEItemData PieceConfigData => _ConfigData ?? (_ConfigData = GDMgr.Get<GDEItemData>(PieceItemId));

	public EffectConfig PieceEffect => _PieceEffect ?? (_PieceEffect = PieceConfigData.Effect.ToObject<EffectConfig>());

	public string PieceItemId => _PieceItemId ?? (_PieceItemId = $"OutTechPiece_{Rarity}");

	public string PieceItemIconUrl => _PieceItemIconUrl ?? (_PieceItemIconUrl = PieceConfigData.Icon.ToPublicResourceIcon());

	public int PieceCount => GameManagers.Instance.StockController.GetStock(PieceItemId);

	public int PieceUpgradeConsume => PieceEffect.Consume;

	public int ToPieceProduce => PieceEffect.Produce;

	public RarityData(int rarity)
	{
		Rarity = rarity;
	}
}

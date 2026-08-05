using Assets.Scripts.UI;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;

public static class SoldierExtensions
{
	public readonly struct GvG3SoldierIconReader
	{
		private readonly Soldier _soldier;

		public int CorrectedPotentialLevel { get; }

		public GvG3SoldierIconReader(Soldier soldier, int originalPotentialLevel = 0)
		{
			_soldier = soldier;
			CorrectedPotentialLevel = originalPotentialLevel;
			CorrectedPotentialLevel = CorrectPotentialLevel(soldier.Data, originalPotentialLevel);
		}

		public string GetIconUrl()
		{
			int skinIndex = GetSkinIndex(CorrectedPotentialLevel);
			string icon = GetIcon(_soldier);
			return $"{icon}_{skinIndex}".ToPublicResourceIcon();
		}

		public string GetFrameIconUrl()
		{
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(CorrectedPotentialLevel);
			return "ui://PublicResources/" + iconFrameBorderSoldier;
		}

		private int CorrectPotentialLevel(GDESoldierData data, int potentialLevel)
		{
			if (data.Tags != null && data.Tags.Contains("WORLD_BOSS"))
			{
				return 9;
			}
			return (potentialLevel > 0) ? potentialLevel : data.PotentialLevel;
		}

		private int GetSkinIndex(int potentialLevel)
		{
			return (potentialLevel == 9) ? 6 : ((potentialLevel + 2) / 2);
		}

		private string GetIcon(Soldier soldier)
		{
			string itemId = soldier.ItemId;
			if (string.IsNullOrEmpty(itemId))
			{
				itemId = GameManagers.Instance.SoldierManager.Get(soldier.Data.ParentSoldierId).ItemId;
			}
			return itemId;
		}
	}

	public static string GetGvG3SoldierIconUrl(this Soldier soldier, int originalPotentialLevel = 0)
	{
		return new GvG3SoldierIconReader(soldier, originalPotentialLevel).GetIconUrl();
	}

	public static string GetGvG3SoldierFrameIconUrl(this Soldier soldier, int originalPotentialLevel = 0)
	{
		return new GvG3SoldierIconReader(soldier, originalPotentialLevel).GetFrameIconUrl();
	}

	public static GvG3SoldierIconReader GetGvG3SoldierIconReader(this Soldier soldier, int originalPotentialLevel = 0)
	{
		return new GvG3SoldierIconReader(soldier, originalPotentialLevel);
	}
}

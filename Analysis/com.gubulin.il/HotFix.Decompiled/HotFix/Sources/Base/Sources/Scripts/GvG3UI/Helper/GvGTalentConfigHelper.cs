using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class GvGTalentConfigHelper
{
	private static Dictionary<int, GDEGvGTalentConfigData> _data = new Dictionary<int, GDEGvGTalentConfigData>(100);

	private static Dictionary<int, int> _talentPointConsumeConfig;

	public const string GvGTalentPoint = "I32017";

	public const string GvGTalentResetPoint = "I32018";

	public const int GvGMode3C2SActivateTalentResetIsCoolingDown = 813108042;

	public const string GvGResetTalentsTip = "GvGResetTalentsTip";

	public const string GvGTalentUiPrefix = "Talent";

	public static List<eTalent> OuterTechAdditionalStartPoint = new List<eTalent>
	{
		eTalent.扩散增幅,
		eTalent.多劳多得,
		eTalent.因地制宜,
		eTalent.有备无患
	};

	private static Dictionary<int, GDEGvGTalentConfigData> Data
	{
		get
		{
			if (_data.Count > 0)
			{
				return _data;
			}
			IEnumerable<GDEGvGTalentConfigData> allItems = GDMgr.GetAllItems<GDEGvGTalentConfigData>();
			foreach (GDEGvGTalentConfigData item in allItems)
			{
				_data.Add(item.Idx, item);
			}
			return _data;
		}
	}

	public static string GetTalentTypeName(int talentType)
	{
		return $"GvGTalentTypeName_{talentType}".ToLanguage();
	}

	public static GDEGvGTalentConfigData GeTalentConfigData(int idx)
	{
		GDEGvGTalentConfigData value;
		return Data.TryGetValue(idx, out value) ? value : null;
	}

	public static List<GDEGvGTalentConfigData> GetTypeSpecialTalentConfigData(int type)
	{
		return Data.Values.Where((GDEGvGTalentConfigData value) => value.Type == type).ToList();
	}

	public static int GetTalentPointConsume(int talentsNum)
	{
		if (_talentPointConsumeConfig == null)
		{
			_talentPointConsumeConfig = "GvGTalentPointConsumeConfig".ToConfiguration<Dictionary<int, int>>();
		}
		int value;
		return _talentPointConsumeConfig.TryGetValue(talentsNum, out value) ? value : 0;
	}

	public static int GetResetTalentsReturnPoints(int talentsNum)
	{
		if (_talentPointConsumeConfig == null)
		{
			_talentPointConsumeConfig = "GvGTalentPointConsumeConfig".ToConfiguration<Dictionary<int, int>>();
		}
		int num = 0;
		foreach (KeyValuePair<int, int> item in _talentPointConsumeConfig)
		{
			if (item.Key <= talentsNum)
			{
				num += item.Value;
			}
		}
		return num;
	}

	public static eGvGTalentUiState GetState(this GvGTalentUiModel uiModel)
	{
		if (uiModel.Effective)
		{
			return eGvGTalentUiState.Unlocked;
		}
		if (uiModel.ParentTalent == null || uiModel.ParentTalent.Count <= 0)
		{
			return eGvGTalentUiState.Locked;
		}
		if (OuterTechHelper.IsO邪魔外道Active() && OuterTechAdditionalStartPoint.Contains((eTalent)uiModel.Idx))
		{
			return eGvGTalentUiState.ToBeUnlocked;
		}
		bool flag = false;
		foreach (int item in uiModel.ParentTalent)
		{
			if (!Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(item).Effective)
			{
				continue;
			}
			flag = true;
			break;
		}
		return flag ? eGvGTalentUiState.ToBeUnlocked : eGvGTalentUiState.Locked;
	}

	public static eGvGTalentLineUiState GetState(this GvGTalentLine line)
	{
		GvGTalentUiModel gvGTalentUiModel = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(line.SmallerIdx);
		GvGTalentUiModel gvGTalentUiModel2 = Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(line.LargerIdx);
		if (gvGTalentUiModel.Effective && gvGTalentUiModel2.Effective)
		{
			return eGvGTalentLineUiState.Connected;
		}
		if (!gvGTalentUiModel.Effective && !gvGTalentUiModel2.Effective)
		{
			return eGvGTalentLineUiState.Unconnected;
		}
		return eGvGTalentLineUiState.Connectable;
	}
}

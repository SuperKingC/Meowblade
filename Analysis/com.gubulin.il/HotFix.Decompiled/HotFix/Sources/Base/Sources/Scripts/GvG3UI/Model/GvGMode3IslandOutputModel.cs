using Assets.Scripts.UI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGMode3IslandOutputModel
{
	private string _productId;

	public string ItemId;

	public string ModelId;

	public int LimitedTimestamp;

	public int RemainingStock;

	public readonly int ShareUserId;

	public readonly bool IsShared;

	public eIslandOutputModel Type;

	private string _output;

	private const string GVG_MODE3_OUTPUT_SOURCE_EXTRA = "GVG_MODE3_OUTPUT_SOURCE_EXTRA";

	private const string GVG_MODE4_OUTPUT_SOURCE_SHARE = "GVG_MODE4_OUTPUT_SOURCE_SHARE";

	private const string GVG_MODE5_OUTPUT_SOURCE_HIDDEN = "GVG_MODE5_OUTPUT_SOURCE_HIDDEN";

	private const string GVG_MODE6_OUTPUT_SOURCE_MISSION = "GVG_MODE6_OUTPUT_SOURCE_MISSION";

	public string ProductId => _productId;

	public string ItemName => Item.Name(GameManagers.Instance, ItemId);

	public string ItemIcon => "ui://PublicResources/" + UiHelper.GetIcon(ItemId);

	public bool IsMark => Singleton<GvGAmplifierManager>.Instance.CheckIsFormulaConsumeItemFavourite(ItemId);

	public int SourceType => GetSourceType();

	public int SourceInfoDialogType => GetSourceInfoDialogType();

	public string ExpectedOutput
	{
		get
		{
			if (_output == null)
			{
				_output = "+1";
			}
			return _output;
		}
	}

	public string SourceText => GetSourceText();

	public bool HasExtraInfo => (Type == eIslandOutputModel.Extra && RemainingTime > 0) || Type == eIslandOutputModel.Hidden || Type == eIslandOutputModel.Extra || Type == eIslandOutputModel.Share || Type == eIslandOutputModel.Mission;

	public int RemainingTime
	{
		get
		{
			int num = LimitedTimestamp - (int)GameController.Instance.GetServerTime();
			if (num <= 0)
			{
				num = 0;
			}
			return num;
		}
	}

	public GvGMode3IslandOutputModel(CollectingStockModel model)
	{
		ItemId = model.GetItemId();
		ModelId = model.GetModelId();
		_productId = model.ProductId;
		LimitedTimestamp = model.ExpirationTimestamp;
		RemainingStock = model.CurStock;
		ShareUserId = model.SharedByUserId;
		IsShared = model.IsShared;
		switch (model.GetStockType())
		{
		case eCollectingStockType.Mission:
			Type = eIslandOutputModel.Share;
			break;
		case eCollectingStockType.Hidden:
			Type = eIslandOutputModel.Hidden;
			break;
		case eCollectingStockType.Mission_Talent_额外发现:
			Type = eIslandOutputModel.Extra;
			break;
		case eCollectingStockType.Mission_RE_Collecting:
			Type = eIslandOutputModel.Mission;
			break;
		default:
			Type = eIslandOutputModel.Normal;
			break;
		}
	}

	public string GetMiningConfigStr(int prior)
	{
		return CollectingStockModel.GetMiningConfigStr(ModelId, prior);
	}

	private int GetSourceType()
	{
		if (Type == eIslandOutputModel.Extra || Type == eIslandOutputModel.Share)
		{
			return 0;
		}
		if (Type == eIslandOutputModel.Mission)
		{
			return 1;
		}
		if (Type == eIslandOutputModel.Hidden)
		{
			return 2;
		}
		return 0;
	}

	private int GetSourceInfoDialogType()
	{
		switch (Type)
		{
		case eIslandOutputModel.Hidden:
		case eIslandOutputModel.Extra:
			return 0;
		case eIslandOutputModel.Share:
			return 1;
		case eIslandOutputModel.Mission:
			return 2;
		default:
			return 0;
		}
	}

	private string GetSourceText(string skillName = "")
	{
		return Type switch
		{
			eIslandOutputModel.Hidden => string.Format("GVG_MODE5_OUTPUT_SOURCE_HIDDEN".ToLanguage(), new object[1] { skillName }), 
			eIslandOutputModel.Extra => "GVG_MODE3_OUTPUT_SOURCE_EXTRA".ToLanguage(), 
			eIslandOutputModel.Mission => "GVG_MODE6_OUTPUT_SOURCE_MISSION".ToLanguage(), 
			eIslandOutputModel.Share => "GVG_MODE4_OUTPUT_SOURCE_SHARE".ToLanguage(), 
			_ => string.Empty, 
		};
	}

	public static int CompareTo(GvGMode3IslandOutputModel a, GvGMode3IslandOutputModel b)
	{
		int type = (int)a.Type;
		int type2 = (int)b.Type;
		return -(type - type2);
	}
}

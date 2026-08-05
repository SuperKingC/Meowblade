using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.GameEndPanels;
using UI.GvGBattleRecords;
using UI.LordOfDreams;
using UI.MainCity;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shift.Legion.GvG.Common;

public static class GvGConfigHelper
{
	private static object _lock = new object();

	private static GvGConfig _GvGConfig;

	public static readonly string[] WorldBossLevelId = new string[2] { "Eventisland1", "Eventisland2" };

	public static GvGBattleInfo RecordLevelInfo;

	public static readonly List<string> DoNotCloseUis = new List<string>
	{
		UI_GvGSelectIslandPanel.Name,
		UI_GvGBattleRecordsPanel.Name,
		UI_GvGBattleRecordDetailPanel.Name,
		UI_DamageMeter.Name
	};

	public static Dictionary<string, Dictionary<string, object>> ReStartUiParams = new Dictionary<string, Dictionary<string, object>>();

	private const string PassLevelId = "P520";

	private const string PassTip = "请先通关主线5-20来参与活动玩法";

	public static GvGConfig GvGConfig
	{
		get
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			if (_GvGConfig == null)
			{
				string text = Addressables.LoadAssetAsync<TextAsset>((object)"GvGConfig").WaitForCompletion().text;
				_GvGConfig = JsonHelper.ToObject<GvGConfig>(text);
			}
			return _GvGConfig;
		}
	}

	public static GvGWorldBossInfo GetGvGWorldBossInfoByWBId(string WBId)
	{
		int num = WBId.IndexOf('_');
		if (num == -1)
		{
			return null;
		}
		string text = WBId.Substring(num + 1);
		if (GvGConfig.WorldBossInfos.TryGetValue(text, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError("GetGvGWorldBossInfoByWBId: WBId:" + WBId + ", key:" + text);
		return null;
	}

	public static string GetFinalSoldierID(string soldierId)
	{
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(soldierId);
		string text = gDESoldierData.ParentSoldierId;
		if (string.IsNullOrEmpty(text))
		{
			text = soldierId;
		}
		return text;
	}

	public static void ReStartUiParamsAdd(string uiName, Dictionary<string, object> parameters)
	{
		lock (_lock)
		{
			if (!ReStartUiParams.ContainsKey(uiName))
			{
				ReStartUiParams.Add(uiName, parameters);
			}
			else
			{
				ReStartUiParams[uiName] = parameters;
			}
		}
	}

	public static void ReStartUiParamsClear()
	{
		lock (_lock)
		{
			ReStartUiParams.Clear();
		}
	}

	public static void AddDoNotCloseUis()
	{
		GameController.Contexts.Service<IUiService>().AddDontCloseUisOnCloseAll(DoNotCloseUis);
	}

	public static void ClearDoNotCloseUis()
	{
		GameController.Contexts.Service<IUiService>().ClearDontCloseUisOnCloseAll();
	}

	public static void CloseLordOfDreamsPanel()
	{
		if (GameController.Contexts.Service<IUiService>().HasShowingUi(UI_LordOfDreamsPanel.Name) && !((Object)(object)GvGWorldController.Instance == (Object)null))
		{
			GvGWorldController.ReleaseInstance();
			Singleton<CameraService>.Instance.SwitchToScene("MainCity.Right");
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_LordOfDreamsPanel.Name, reservePackageRes: true);
		}
	}

	public static void SetDoNotCloseUisVisible(bool visible)
	{
		for (int i = 0; i < DoNotCloseUis.Count; i++)
		{
			if (DoNotCloseUis[i] == UI_DamageMeter.Name)
			{
				if (visible && FGUIManager.Instance.DamageMeter != null)
				{
					FGUIManager.Instance.DamageMeter.TypeController.selectedIndex = 2;
				}
			}
			else
			{
				GameController.Contexts.Service<IUiService>().SetUiVisible(DoNotCloseUis[i], visible);
			}
		}
		FGUIManager.Instance.OpenIEnumerator(OpenGvGPanels(visible));
	}

	private static IEnumerator OpenGvGPanels(bool visible)
	{
		bool hasMainCityUi = false;
		while (!hasMainCityUi)
		{
			hasMainCityUi = GameController.Contexts.Service<IUiService>().HasShowingUi(UI_MainCity.Name);
			yield return (object)new WaitForSeconds(0.2f);
		}
		if (!visible)
		{
			yield break;
		}
		Dictionary<string, Dictionary<string, object>> reStartUiParams = new Dictionary<string, Dictionary<string, object>>();
		lock (_lock)
		{
			foreach (KeyValuePair<string, Dictionary<string, object>> item in ReStartUiParams)
			{
				reStartUiParams.Add(item.Key, item.Value);
			}
		}
		foreach (KeyValuePair<string, Dictionary<string, object>> item2 in reStartUiParams)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(item2.Key, item2.Value);
		}
	}

	public static bool GvGEnable(out string tipText)
	{
		tipText = "";
		bool flag = GameManagers.Instance.UserArchiveManager.IsLevelCompleted("P520");
		if (!flag)
		{
			tipText = "请先通关主线5-20来参与活动玩法";
		}
		return flag;
	}
}

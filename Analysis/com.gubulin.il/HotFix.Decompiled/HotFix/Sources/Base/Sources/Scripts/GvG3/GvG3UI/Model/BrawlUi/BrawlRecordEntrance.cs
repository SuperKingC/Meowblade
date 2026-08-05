using System;
using System.Collections.Generic;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Services.UiService;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.FullScreenAnimation;
using UI.GvGBrawlFight;
using UI.MilitaryAFKAssistant;
using UI.NewbieMission;
using UI.RollingMarquee;
using UI.Tips;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

public class BrawlRecordEntrance
{
	private const string BRAWL_RESULT = "BrawlResult";

	private const string LAST_BRAWL_RESULT_RECORD = "LAST_BRAWL_RESULT_RECORD";

	private const string NO_BRAWL_BATTLE_RESULT_YET = "NO_BRAWL_BATTLE_RESULT_YET";

	private const string UI_NAME_PREFIX = "UI_";

	private static readonly TipConstants _tipConstants = new TipConstants();

	private static readonly List<string> _ignoreUis = new List<string>
	{
		UI_RollingMarqueePanel.Name.Replace("UI_", ""),
		UI_SomeTipPanel.Name.Replace("UI_", ""),
		UI_FullScreenAnimationPanel.Name.Replace("UI_", ""),
		UI_ShowOfflineEarnings.Name.Replace("UI_", ""),
		UI_main_MilitaryAFKAssistant.Name.Replace("UI_", ""),
		UI_NewbieMissionPanel.Name.Replace("UI_", "")
	};

	public void TryCheckBattleResult(C2S_BrawlEvent_GetInfo.Response brawlEventInfo, Action<int> onClaimed)
	{
		if (CanCheckBattleResult(brawlEventInfo))
		{
			UI_main_BrawlBattleResult.OpenBrawlBattleResultPanel(brawlEventInfo, Singleton<WorldStateManager>.Instance.Data.IZBeginTimestamp, onClaimed);
		}
	}

	public void TryPopupBattleResult(C2S_BrawlEvent_GetInfo.Response brawlEventInfo, Action<int> onClaimed)
	{
		if (CanCheckBattleResult(brawlEventInfo))
		{
			string text = GameLocalDataManager.GetString("LAST_BRAWL_RESULT_RECORD");
			string battleResultRecord = GetBattleResultRecord(brawlEventInfo.MaxCanRecordInLeaderboard);
			if (battleResultRecord != text)
			{
				GameLocalDataManager.SetString("LAST_BRAWL_RESULT_RECORD", battleResultRecord);
				UI_main_BrawlBattleRankInfo.AutoOpenBrawlBattleRankInfo(brawlEventInfo, Singleton<WorldStateManager>.Instance.Data.IZBeginTimestamp, onClaimed, isFirst: true);
			}
		}
	}

	private static string GetBattleResultRecord(int day)
	{
		return string.Format("{0}_{1}_{2}", "BrawlResult", Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId, day);
	}

	private static bool CanCheckBattleResult(C2S_BrawlEvent_GetInfo.Response brawlEventInfo)
	{
		if (brawlEventInfo == null)
		{
			return false;
		}
		if (!brawlEventInfo.HasReplayYesterdayFight())
		{
			return false;
		}
		if (brawlEventInfo.MaxCanRecordInLeaderboard < 0)
		{
			"NO_BRAWL_BATTLE_RESULT_YET".ToShowLanguageTip();
			return false;
		}
		return true;
	}

	private static bool HasUiShownOnTop(string uiName)
	{
		int numChildren = ((GComponent)GRoot.inst).numChildren;
		string text = "HasUiShownOnTop(" + uiName + ")" + Environment.NewLine;
		for (int num = numChildren - 1; num >= 0; num--)
		{
			int numChildren2 = ((GComponent)GRoot.inst).numChildren;
			if (numChildren2 <= num)
			{
				ILRuntimeDebug.LogError($"[BrawlRecordEntrance]HasUiShownOnTop numChildren Changed {num}/{numChildren2}({numChildren})");
			}
			else
			{
				GObject childAt = ((GComponent)GRoot.inst).GetChildAt(num);
				text = text + $"HasUiShownOnTop, WindowLoader@{num} is {childAt.gameObjectName}" + Environment.NewLine;
				if (!_tipConstants.IsTipUi(GameObjectNameToFairyGuiName(childAt.gameObjectName)))
				{
					Window val = (Window)(object)((childAt is Window) ? childAt : null);
					if (val != null)
					{
						GComponent contentPane = val.contentPane;
						if (contentPane == null)
						{
							SentrySdk.AddBreadcrumb(text);
							ILRuntimeDebug.LogError("[BrawlRecordEntrance]HasUiShownOnTop, Exceptional WindowLoader " + ((GObject)val).gameObjectName + " Has No contentPane");
						}
						else
						{
							GObject childAt2 = contentPane.GetChildAt(contentPane.numChildren - 1);
							string gameObjectName = childAt2.gameObjectName;
							text = text + gameObjectName + Environment.NewLine;
							SentrySdk.AddBreadcrumb($"[BrawlRecordEntrance]HasUiShownOnTop, WindowLoader@{num} is {((GObject)val).gameObjectName}, {gameObjectName}");
							string text2 = FairyGuiNameToGameObjectName(uiName);
							if (gameObjectName == text2)
							{
								return true;
							}
							if (!CheckUiIgnore(gameObjectName, text2))
							{
								return false;
							}
						}
					}
				}
			}
		}
		return false;
	}

	private static string FairyGuiNameToGameObjectName(string fairyGuiName)
	{
		return fairyGuiName.Replace("UI_", "");
	}

	private static string GameObjectNameToFairyGuiName(string gameObjectName)
	{
		return "UI_" + gameObjectName;
	}

	private static bool CheckUiIgnore(string checkGameObjectName, string inputGameObjectName)
	{
		if (_ignoreUis.Contains(checkGameObjectName))
		{
			return true;
		}
		return false;
	}
}

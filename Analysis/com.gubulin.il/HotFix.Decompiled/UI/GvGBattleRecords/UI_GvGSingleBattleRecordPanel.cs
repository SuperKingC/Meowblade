using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using UI.LordOfDreams;
using UnityEngine;

namespace UI.GvGBattleRecords;

public class UI_GvGSingleBattleRecordPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_GvGBattleRecordDialog RecordDialog;

	public Transition ShowRecordDialog;

	public const string URL = "ui://dxmilktyj3iw20";

	public static string Name = "UI_GvGSingleBattleRecordPanel";

	private int CurUserId;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private string shipIdStr;

	private string envStr;

	private Coroutine ReplayDetialCoroutine;

	private string RecordDay => LanguagesManager.GetDesc("CsharpCodeZhTcText263");

	public static string GetURL()
	{
		return "ui://dxmilktyj3iw20";
	}

	public static UI_GvGSingleBattleRecordPanel CreateInstance()
	{
		return (UI_GvGSingleBattleRecordPanel)(object)UIPackage.CreateObject("GvGBattleRecords", "GvGSingleBattleRecordPanel");
	}

	public static UI_GvGSingleBattleRecordPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGSingleBattleRecordPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktyj3iw20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		RecordDialog = (UI_GvGBattleRecordDialog)(object)((GComponent)this).GetChild("RecordDialog");
		ShowRecordDialog = ((GComponent)this).GetTransition("ShowRecordDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		envStr = GameDataService.Instance.EnvStr;
		UIObjectFactory.SetPackageItemExtension("ui://LordOfDreams/Loading", typeof(ScrollPaneHeader));
		CurUserId = GameController.Contexts.gameState.user.value.UserId;
		shipIdStr = UI_GvGTotalDamageBattleField.ShipId;
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		RenderGvGShipRecordList(UI_GvGTotalDamageBattleField.ShipRecords);
		loadWebImageTaskQueue?.Start();
		ShowRecordDialog.Play();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderGvGShipRecordList(List<GvGShipRecord> shipRecords)
	{
		GList asList = ((GComponent)RecordDialog).GetChild("BattleLogList").asList;
		asList.RemoveChildrenToPool();
		if (shipRecords == null || shipRecords.Count == 0)
		{
			return;
		}
		List<GvGShipRecord> list = shipRecords.OrderBy((GvGShipRecord sr) => sr.Timestamp).ToList();
		UI_GvGBattleLogInfoResources uI_GvGBattleLogInfoResources = asList.AddItemFromPool() as UI_GvGBattleLogInfoResources;
		((GComponent)uI_GvGBattleLogInfoResources).GetChild("Day").text = RecordDay;
		Controller controller = ((GComponent)uI_GvGBattleLogInfoResources).GetController("Type");
		controller.selectedIndex = 0;
		((GObject)uI_GvGBattleLogInfoResources).x = 0f;
		for (int num = 0; num < list.Count; num++)
		{
			if (((GObject)this).isDisposed)
			{
				break;
			}
			GvGShipRecord gvGShipRecord = list[num];
			int winner = 0;
			if (gvGShipRecord.Winner == 100)
			{
				winner = 0;
			}
			Render(gvGShipRecord.RedUserId, winner, gvGShipRecord.TotalDamage, BtnStyle.Record, null, gvGShipRecord);
		}
	}

	private void Render(int userId, int winner, string totalDamage, BtnStyle btnStyle, List<GvGShipRecord> shipRecords = null, GvGShipRecord recordData = null, string shipId = null, GvGShipRecords recordsData = null)
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		GComponent asCom = ((GObject)RecordDialog).asCom;
		if (((GObject)this).isDisposed || ((GObject)asCom).isDisposed)
		{
			return;
		}
		GList asList = asCom.GetChild("BattleLogList").asList;
		UI_GvGBattleLogInfoResources uI_GvGBattleLogInfoResources = UI_GvGBattleLogInfoResources.CreateInstance_ILRuntime();
		if (uI_GvGBattleLogInfoResources != null)
		{
			Controller controller = ((GComponent)uI_GvGBattleLogInfoResources).GetController("Type");
			controller.selectedIndex = 1;
			Controller controller2 = ((GComponent)uI_GvGBattleLogInfoResources).GetController("Status");
			controller2.selectedIndex = winner;
			Controller controller3 = ((GComponent)uI_GvGBattleLogInfoResources).GetController("Style");
			controller3.selectedIndex = 1;
			uI_GvGBattleLogInfoResources.SetControllerPageText();
			uI_GvGBattleLogInfoResources.MyAvatar.AvatarLoader.Type.selectedIndex = 0;
			loadWebImageTaskQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, uI_GvGBattleLogInfoResources.MyAvatar.AvatarLoader.icon, uI_GvGBattleLogInfoResources.MyName));
			((GComponent)asList).AddChild((GObject)(object)uI_GvGBattleLogInfoResources);
			((GObject)uI_GvGBattleLogInfoResources.TotalDamageValue).text = totalDamage;
			GetEnemyIconAndName(uI_GvGBattleLogInfoResources, recordData, out var recordUserInfo);
			((GObject)uI_GvGBattleLogInfoResources.PlayBtn).data = recordUserInfo;
			((GObject)uI_GvGBattleLogInfoResources.PlayBtn).onClick.Set((EventCallback0)delegate
			{
				OnClickPlayBtn(recordUserInfo, recordData?.WBId);
			});
			((GObject)uI_GvGBattleLogInfoResources).x = 0f;
		}
	}

	private void GetEnemyIconAndName(UI_GvGBattleLogInfoResources gobj, GvGShipRecord recordData, out GvGBattleRecordUserInfo recordUserInfo)
	{
		if (recordData == null)
		{
			recordUserInfo = null;
			return;
		}
		recordUserInfo = new GvGBattleRecordUserInfo
		{
			RedUserId = recordData.RedUserId,
			BlueUserId = recordData.BlueUserId,
			BattleId = recordData.BattleId
		};
		if (recordData.BlueUserId != -1)
		{
			gobj.EnemyAvatar.AvatarLoader.Type.selectedIndex = 0;
			loadWebImageTaskQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, recordData.BlueUserId, gobj.MyAvatar.AvatarLoader.icon, gobj.MyName));
			return;
		}
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(recordData.WBId);
		gobj.EnemyAvatar.AvatarLoader.Type.selectedIndex = 1;
		gobj.EnemyAvatar.AvatarLoader.icon.url = (recordUserInfo.BlueUserIconUrl = "ui://PublicResources/" + gvGWorldBossInfoByWBId.Icon);
		((GObject)gobj.EnemyName).text = (recordUserInfo.BlueUserName = gvGWorldBossInfoByWBId.BossName);
	}

	private void OnClickPlayBtn(GvGBattleRecordUserInfo battleLogUserInfo, string wbId)
	{
		string gVGBattleRecordDetailRedHttpsUrl = UiHelper.GetGVGBattleRecordDetailRedHttpsUrl(CurUserId, envStr, shipIdStr);
		string gVGBattleRecordDetailRedLocalDataKey = UiHelper.GetGVGBattleRecordDetailRedLocalDataKey(CurUserId, envStr, shipIdStr);
		string gVGBattleRecordDetailBlueHttpsUrl = UiHelper.GetGVGBattleRecordDetailBlueHttpsUrl(CurUserId, envStr, shipIdStr, battleLogUserInfo.BattleId);
		string gVGBattleRecordDetailBlueLocalDataKey = UiHelper.GetGVGBattleRecordDetailBlueLocalDataKey(CurUserId, envStr, shipIdStr, battleLogUserInfo.BattleId);
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wbId);
		string levelId = (string.IsNullOrEmpty(gvGWorldBossInfoByWBId.LevelId) ? "RankBattleFieldLevel" : gvGWorldBossInfoByWBId.LevelId);
		Action<BattleRecordDetail, BattleRecordDetail, GetGvGBattleResultResponse> action = delegate(BattleRecordDetail recordRedDetailData, BattleRecordDetail recordBlueDetailData, GetGvGBattleResultResponse recordResultData)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGBattleRecordDetailPanel.Name, new Dictionary<string, object>
			{
				{ "UserInfo", battleLogUserInfo },
				{ "BattleRecordRedDetail", recordRedDetailData },
				{ "BattleRecordBlueDetail", recordBlueDetailData },
				{ "BattleRecordResultData", recordResultData },
				{ "LevelId", levelId },
				{ "WBId", wbId }
			});
		};
		if (ReplayDetialCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(ReplayDetialCoroutine);
			ReplayDetialCoroutine = null;
		}
		ReplayDetialCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetUserGvGBattleRecordDetailData(battleLogUserInfo.BattleId, gVGBattleRecordDetailRedHttpsUrl, gVGBattleRecordDetailRedLocalDataKey, gVGBattleRecordDetailBlueHttpsUrl, gVGBattleRecordDetailBlueLocalDataKey, action));
	}
}

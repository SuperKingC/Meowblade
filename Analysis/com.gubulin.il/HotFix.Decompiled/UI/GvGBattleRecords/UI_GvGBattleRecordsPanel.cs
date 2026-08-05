using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using UnityEngine;

namespace UI.GvGBattleRecords;

public class UI_GvGBattleRecordsPanel : GComponent, IUiController
{
	public Controller Status;

	public GGraph Mask;

	public UI_GvGBattleRecordsDialog RecordsDialog;

	public UI_GvGBattleRecordDialog RecordDialog;

	public Transition ShowRecordDialog;

	public const string URL = "ui://dxmilktydzls1w";

	public static string Name = "UI_GvGBattleRecordsPanel";

	private int CurUserId;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private int GvGGetShipRecordsIdx;

	private string iZConfigId;

	private string iZId;

	private string shipIdStr;

	private string envStr;

	private List<GvGShipRecords> currentRecords = new List<GvGShipRecords>();

	private int SelectedIndex = -1;

	private Coroutine ReplayDetialCoroutine;

	private string RecordDay => LanguagesManager.GetDesc("CsharpCodeZhTcText263");

	public static string GetURL()
	{
		return "ui://dxmilktydzls1w";
	}

	public static UI_GvGBattleRecordsPanel CreateInstance()
	{
		return (UI_GvGBattleRecordsPanel)(object)UIPackage.CreateObject("GvGBattleRecords", "GvGBattleRecordsPanel");
	}

	public static UI_GvGBattleRecordsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleRecordsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzls1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		RecordsDialog = (UI_GvGBattleRecordsDialog)(object)((GComponent)this).GetChild("RecordsDialog");
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
		iZConfigId = (parameters.TryGetValue("IZConfigId", out var value) ? value.ToString() : "");
		iZId = (parameters.TryGetValue("IZId", out var value2) ? value2.ToString() : "");
		currentRecords = new List<GvGShipRecords>();
		UIObjectFactory.SetPackageItemExtension("ui://LordOfDreams/Loading", typeof(ScrollPaneHeader));
		CurUserId = GameController.Contexts.gameState.user.value.UserId;
		BattleLogListInit();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GComponent)((GComponent)RecordsDialog).GetChild("BattleLogList").asList).scrollPane.onPullUpRelease.Add(new EventCallback0(OnPullUpRefresh));
		((GComponent)((GComponent)RecordsDialog).GetChild("BattleLogList").asList).scrollPane.onPullDownRelease.Add(new EventCallback0(OnPullDownRefresh));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GComponent)((GComponent)RecordsDialog).GetChild("BattleLogList").asList).scrollPane.onPullUpRelease.Remove(new EventCallback0(OnPullUpRefresh));
		((GComponent)((GComponent)RecordsDialog).GetChild("BattleLogList").asList).scrollPane.onPullDownRelease.Remove(new EventCallback0(OnPullDownRefresh));
	}

	private async void BattleLogListInit()
	{
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		await RefreshInit();
		loadWebImageTaskQueue?.Start();
	}

	private async Task RefreshInit()
	{
		List<GvGShipRecords> summaries = await GetService(latest: true);
		RemoveDuplicateData(ref summaries);
		RenderAll(summaries);
	}

	public async Task FinalRefreh(bool latest = false)
	{
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		List<GvGShipRecords> summaries = await GetService(latest);
		RemoveDuplicateData(ref summaries);
		RenderAll(summaries);
		loadWebImageTaskQueue?.Start();
	}

	private async Task<List<GvGShipRecords>> GetService(bool latest = false)
	{
		List<GvGShipRecords> recordsList = new List<GvGShipRecords>();
		if (!latest && currentRecords.Count > 0)
		{
			GvGShipRecords minRecord = currentRecords[currentRecords.Count - 1];
			recordsList = GameLocalDataManager.GetUserGvGShipRecordsListData(minRecord);
		}
		if (recordsList != null && recordsList.Count > 0)
		{
			for (int i = 0; i < recordsList.Count; i++)
			{
			}
			return recordsList;
		}
		int idx = ((!latest) ? GvGGetShipRecordsIdx : 0);
		GvGGetShipRecordsResponse dic = await GameController.Contexts.Service<INetworkService>().GvGGetShipRecords(iZConfigId, iZId, idx);
		if (dic.Result)
		{
			recordsList = dic.Records;
			envStr = dic.EnvStr;
			if (recordsList != null)
			{
				GvGGetShipRecordsIdx += recordsList.Count;
				for (int j = 0; j < recordsList.Count; j++)
				{
					GameLocalDataManager.SetUserGvGShipRecordsListData(recordsList[j].RecordId.ToString(), recordsList[j]);
				}
			}
			else
			{
				recordsList = new List<GvGShipRecords>();
			}
		}
		return recordsList;
	}

	private void RemoveDuplicateData(ref List<GvGShipRecords> recordsList)
	{
		if (recordsList.Count <= 0)
		{
			List<GvGShipRecords> userGvGShipRecordsListData = GameLocalDataManager.GetUserGvGShipRecordsListData();
			if (userGvGShipRecordsListData != null)
			{
				recordsList.AddRange(userGvGShipRecordsListData);
			}
		}
		for (int num = recordsList.Count - 1; num >= 0; num--)
		{
			bool flag = true;
			for (int i = 0; i < currentRecords.Count; i++)
			{
				if (currentRecords[i].RecordId == recordsList[num].RecordId)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				recordsList.RemoveAt(num);
			}
			else
			{
				currentRecords.Add(recordsList[num]);
			}
		}
		recordsList.Sort(GameLocalDataManager.GvGShipRecordsSort);
		currentRecords.Sort(GameLocalDataManager.GvGShipRecordsSort);
	}

	private void RenderAll(List<GvGShipRecords> records)
	{
		GList asList = ((GComponent)RecordsDialog).GetChild("BattleLogList").asList;
		if (asList.numItems <= 0)
		{
			UI_GvGBattleLogInfoResources uI_GvGBattleLogInfoResources = asList.AddItemFromPool() as UI_GvGBattleLogInfoResources;
			((GComponent)uI_GvGBattleLogInfoResources).GetChild("Day").text = RecordDay;
			Controller controller = ((GComponent)uI_GvGBattleLogInfoResources).GetController("Type");
			controller.selectedIndex = 0;
			((GObject)uI_GvGBattleLogInfoResources).x = 0f;
		}
		if (records.Count == 0)
		{
			return;
		}
		for (int i = 0; i < records.Count; i++)
		{
			if (((GObject)this).isDisposed)
			{
				break;
			}
			DataProgressAndOutput(records[i]);
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnPullUpRefresh()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		GList _list = ((GComponent)RecordsDialog).GetChild("BattleLogList").asList;
		ScrollPaneHeader footer = (ScrollPaneHeader)(object)((GComponent)_list).scrollPane.footer;
		footer.SetRefreshStatus(2);
		((GComponent)_list).scrollPane.LockFooter(30);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)(object)this).SetTimeout(2f).OnComplete((GTweenCallback)delegate
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_005c: Expected O, but got Unknown
			Task task = FinalRefreh();
			footer.SetRefreshStatus(3);
			((GComponent)_list).scrollPane.LockFooter(35);
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.5f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					footer.SetRefreshStatus(0);
					((GComponent)_list).scrollPane.LockFooter(0);
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	private void OnPullDownRefresh()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		GList _list = ((GComponent)RecordsDialog).GetChild("BattleLogList").asList;
		ScrollPaneHeader header = (ScrollPaneHeader)(object)((GComponent)_list).scrollPane.header;
		header.SetRefreshStatus(2);
		((GComponent)_list).scrollPane.LockHeader(50);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)(object)this).SetTimeout(2f).OnComplete((GTweenCallback)delegate
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_005c: Expected O, but got Unknown
			Task task = FinalRefreh(latest: true);
			header.SetRefreshStatus(3);
			((GComponent)_list).scrollPane.LockHeader(55);
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.5f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					header.SetRefreshStatus(0);
					((GComponent)_list).scrollPane.LockHeader(0);
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	private void DataProgressAndOutput(GvGShipRecords data)
	{
		Render(CurUserId, 1, data.TotalDamage, BtnStyle.ShipRecords, data.ShipRecords, null, data.ShipId, data);
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
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		bool flag = btnStyle == BtnStyle.ShipRecords;
		GComponent val = (flag ? ((GObject)RecordsDialog).asCom : ((GObject)RecordDialog).asCom);
		if (((GObject)this).isDisposed || ((GObject)val).isDisposed)
		{
			return;
		}
		GList asList = val.GetChild("BattleLogList").asList;
		GComponent val2 = (flag ? ((GObject)UI_GvGBattleLogInfoResourcesBig.CreateInstance_ILRuntime()).asCom : ((GObject)UI_GvGBattleLogInfoResources.CreateInstance_ILRuntime()).asCom);
		if (val2 == null)
		{
			return;
		}
		Controller controller = val2.GetController("Type");
		controller.selectedIndex = 1;
		Controller controller2 = val2.GetController("Status");
		controller2.selectedIndex = winner;
		UI_RankingListAvatar uI_RankingListAvatar = (UI_RankingListAvatar)(object)val2.GetChild("MyAvatar");
		GTextField asTextField = val2.GetChild("MyName").asTextField;
		uI_RankingListAvatar.AvatarLoader.Type.selectedIndex = 0;
		loadWebImageTaskQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, uI_RankingListAvatar.AvatarLoader.icon, asTextField));
		if (flag)
		{
			UI_GvGBattleLogInfoResourcesBig uI_GvGBattleLogInfoResourcesBig = (UI_GvGBattleLogInfoResourcesBig)(object)val2;
			int addIndex = GetNewRecordsBtnAddIndex(recordsData);
			((GComponent)asList).AddChildAt((GObject)(object)val2, addIndex);
			((GObject)uI_GvGBattleLogInfoResourcesBig.TotalDamageValue).text = int.Parse(totalDamage).ShortNumberFormat();
			GetEnemyIconAndName(uI_GvGBattleLogInfoResourcesBig, shipRecords);
			((GObject)uI_GvGBattleLogInfoResourcesBig.RecordDetail).onClick.Set((EventCallback0)delegate
			{
				OnClickShowRecordsDetail(shipRecords, shipId, addIndex);
			});
			((GObject)uI_GvGBattleLogInfoResourcesBig).data = recordsData;
		}
		else
		{
			UI_GvGBattleLogInfoResources uI_GvGBattleLogInfoResources = (UI_GvGBattleLogInfoResources)(object)val2;
			Controller controller3 = val2.GetController("Style");
			controller3.selectedIndex = 1;
			uI_GvGBattleLogInfoResources.SetControllerPageText();
			((GComponent)asList).AddChild((GObject)(object)val2);
			((GObject)uI_GvGBattleLogInfoResources.TotalDamageValue).text = totalDamage;
			GetEnemyIconAndName(uI_GvGBattleLogInfoResources, recordData, out var recordUserInfo);
			((GObject)uI_GvGBattleLogInfoResources.PlayBtn).data = recordUserInfo;
			((GObject)uI_GvGBattleLogInfoResources.PlayBtn).onClick.Set((EventCallback0)delegate
			{
				OnClickPlayBtn(recordUserInfo, recordData?.WBId);
			});
		}
		((GObject)val2).x = 0f;
	}

	private int GetNewRecordsBtnAddIndex(GvGShipRecords recordsData)
	{
		int result = 1;
		for (int i = 0; i < RecordsDialog.BattleLogList.numItems; i++)
		{
			if (i == 0)
			{
				continue;
			}
			object data = ((GObject)((GComponent)RecordsDialog.BattleLogList).GetChildAt(i).asCom).data;
			if (data != null)
			{
				GvGShipRecords b = (GvGShipRecords)data;
				if (GameLocalDataManager.GvGShipRecordsSort(recordsData, b) == -1)
				{
					result = i;
					break;
				}
				if (i == RecordsDialog.BattleLogList.numItems - 1)
				{
					result = RecordsDialog.BattleLogList.numItems;
				}
			}
		}
		return result;
	}

	private void GetEnemyIconAndName(UI_GvGBattleLogInfoResourcesBig gobj, List<GvGShipRecord> shipRecords)
	{
		if (shipRecords != null && shipRecords.Count >= 0)
		{
			if (shipRecords[0].BlueUserId != -1)
			{
				gobj.EnemyAvatar.AvatarLoader.Type.selectedIndex = 0;
				loadWebImageTaskQueue?.AddTask(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, shipRecords[0].BlueUserId, gobj.MyAvatar.AvatarLoader.icon, gobj.MyName));
				return;
			}
			GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(shipRecords[0].WBId);
			gobj.EnemyAvatar.AvatarLoader.Type.selectedIndex = 1;
			gobj.EnemyAvatar.AvatarLoader.icon.url = "ui://PublicResources/" + gvGWorldBossInfoByWBId.Icon;
			((GObject)gobj.EnemyName).text = gvGWorldBossInfoByWBId.BossName;
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

	private void OnClickShowRecordsDetail(List<GvGShipRecord> shipRecords, string shipId, int index)
	{
		if (Status.selectedIndex != 1)
		{
			Status.selectedIndex = 1;
		}
		shipIdStr = shipId;
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		RenderGvGShipRecordList(shipRecords);
		loadWebImageTaskQueue?.Start();
		GList asList = ((GComponent)RecordsDialog).GetChild("BattleLogList").asList;
		if (SelectedIndex != -1)
		{
			UI_GvGBattleLogInfoResourcesBig uI_GvGBattleLogInfoResourcesBig = (UI_GvGBattleLogInfoResourcesBig)(object)((GComponent)asList).GetChildAt(SelectedIndex);
			uI_GvGBattleLogInfoResourcesBig.SelectController.selectedIndex = 0;
		}
		SelectedIndex = index;
		UI_GvGBattleLogInfoResourcesBig uI_GvGBattleLogInfoResourcesBig2 = (UI_GvGBattleLogInfoResourcesBig)(object)((GComponent)asList).GetChildAt(SelectedIndex);
		uI_GvGBattleLogInfoResourcesBig2.SelectController.selectedIndex = 1;
	}
}

using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.GvGWorldMap3;
using UnityEngine;

namespace UI.GvGBattleRecord3;

public class UI_com_GvG3BattleResultBonusDialog : GComponent
{
	public class BattleResultBonusLog
	{
		public long Id;

		public long Timestamp;

		public string Message;

		public eChatSystemTemplateType Type;

		public List<Bonus> Bonuses;

		public List<int> TalentSrcList;
	}

	public Controller HasWaitToClaim;

	public GImage Background;

	public GTextField n12;

	public GImage n15;

	public GList BattleResultList;

	public UI_btn_ConfirmClaimAll ConfirmClaimAll;

	public const string URL = "ui://b3fc6085dzdc3i";

	public static string Name = "UI_com_GvG3BattleResultBonusDialog";

	private Vector2 StorehouseEntryPos;

	private List<BattleResultBonusLog> BattleResultLogs;

	private HashSet<long> ExistingLogIds;

	private HashSet<long> WaitToClaimLogIds;

	public static string GetURL()
	{
		return "ui://b3fc6085dzdc3i";
	}

	public static UI_com_GvG3BattleResultBonusDialog CreateInstance()
	{
		return (UI_com_GvG3BattleResultBonusDialog)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_GvG3BattleResultBonusDialog");
	}

	public static UI_com_GvG3BattleResultBonusDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvG3BattleResultBonusDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085dzdc3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasWaitToClaim = ((GComponent)this).GetController("HasWaitToClaim");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id = "ui://b3fc6085dzdc3i".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		BattleResultList = (GList)((GComponent)this).GetChild("BattleResultList");
		ConfirmClaimAll = (UI_btn_ConfirmClaimAll)(object)((GComponent)this).GetChild("ConfirmClaimAll");
	}

	public void Init()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		StorehouseEntryPos = UI_main_GvGWorldMap3.GvGStorehouseBtnWorldPos;
		BattleResultLogs = new List<BattleResultBonusLog>();
		ExistingLogIds = new HashSet<long>();
		WaitToClaimLogIds = new HashSet<long>();
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetSystemMessagesBattleResultBonus(-1L, isGetWaitToClaimIds: true, OnGetData);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)BattleResultList).scrollPane.onPullUpRelease.Add(new EventCallback0(OnPullUpRefresh));
		((GComponent)BattleResultList).scrollPane.onPullDownRelease.Add(new EventCallback0(OnPullDownRefresh));
		((GObject)ConfirmClaimAll).onClick.Add(new EventCallback0(OnClickConfirmClaimAll));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GComponent)BattleResultList).scrollPane.onPullUpRelease.Remove(new EventCallback0(OnPullUpRefresh));
		((GComponent)BattleResultList).scrollPane.onPullDownRelease.Remove(new EventCallback0(OnPullDownRefresh));
		((GObject)ConfirmClaimAll).onClick.Clear();
	}

	private void OnGetData(C2S_GetSystemMessages_BattleResultBonus.Response data)
	{
		if (data.RecordList != null && data.RecordList.Count != 0)
		{
			if (data.IsGetWaitToClaimIds)
			{
				WaitToClaimLogIds = ((data.WaitToClaimIds != null) ? new HashSet<long>(data.WaitToClaimIds) : new HashSet<long>());
			}
			AddNewLogsToList(data.RecordList);
			Update();
		}
	}

	private void OnPullUpRefresh()
	{
		ScrollPane scrollPane = ((GComponent)BattleResultList).scrollPane;
		ScrollPaneHeader footer = (ScrollPaneHeader)(object)scrollPane.footer;
		footer.SetRefreshStatus(2);
		scrollPane.LockFooter(30);
		long startId = ((BattleResultLogs.Count > 0) ? BattleResultLogs[BattleResultLogs.Count - 1].Id : (-1));
		GTweenCallback val = default(GTweenCallback);
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetSystemMessagesBattleResultBonus(startId, isGetWaitToClaimIds: false, delegate(C2S_GetSystemMessages_BattleResultBonus.Response res)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_003c: Expected O, but got Unknown
			OnGetData(res);
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.5f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					footer.SetRefreshStatus(0);
					scrollPane.LockFooter(0);
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
		ScrollPane scrollPane = ((GComponent)BattleResultList).scrollPane;
		ScrollPaneHeader header = (ScrollPaneHeader)(object)scrollPane.header;
		header.SetRefreshStatus(2);
		scrollPane.LockHeader(50);
		GTweenCallback val = default(GTweenCallback);
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetSystemMessagesBattleResultBonus(-1L, isGetWaitToClaimIds: true, delegate(C2S_GetSystemMessages_BattleResultBonus.Response res)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_003c: Expected O, but got Unknown
			OnGetData(res);
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.5f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					header.SetRefreshStatus(0);
					scrollPane.LockHeader(0);
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	private void OnClickConfirmClaimAll()
	{
		HasWaitToClaim.selectedIndex = 0;
		Singleton<GvGMode3BattleRecordsManager>.Instance.ClaimAllBattleResultBonus(OnClaimFinished);
	}

	private void OnClaimFinished(C2S_ClaimAllBattleResultBonus.Response response)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		Dictionary<string, int> curValueChanges = response.StorehouseCurValueChanges ?? new Dictionary<string, int>();
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithCurValueChanges(curValueChanges);
		if (((GObject)this).isDisposed)
		{
			return;
		}
		foreach (Vector2 visibleBonusSlotGlobalPo in GetVisibleBonusSlotGlobalPos())
		{
			GGraph graph = new GGraph();
			((GObject)graph).SetPivot(0.5f, 0.5f);
			((GObject)graph).SetSize(50f, 50f, true);
			graph.DrawRect(50f, 50f, 0, Color.white, Color.white);
			((GComponent)GRoot.inst).AddChild((GObject)(object)graph);
			((GObject)graph).sortingOrder = 99999;
			FGUIManager.Instance.AddTextSpecialEffects(graph, "exp_missile_green", Vector3.zero);
			((GObject)graph).xy = visibleBonusSlotGlobalPo;
			((GObject)graph).TweenMove(StorehouseEntryPos, 1f).OnComplete((GTweenCallback)delegate
			{
				((GObject)graph).Dispose();
			});
		}
		WaitToClaimLogIds.Clear();
		Update();
	}

	private void AddNewLogsToList(List<GvGMode3ChatRecord> records)
	{
		foreach (GvGMode3ChatRecord record in records)
		{
			if (ExistingLogIds.Contains(record.Id))
			{
				continue;
			}
			ExistingLogIds.Add(record.Id);
			ChatSystemMessageBonus chatSystemMessageBonus = GvGMode3MessageConfigHelper.ParseSystemMessageBonus(record.MessageToShow);
			ChatSystemMessageData chatSystemMessageData = GvGMode3MessageConfigHelper.ParseSystemMessageData(record.MessageToShow, eChatThemeType.Dark);
			eChatSystemTemplateType type = (eChatSystemTemplateType)Enum.Parse(typeof(eChatSystemTemplateType), chatSystemMessageData.MessageType);
			List<Bonus> list = new List<Bonus>();
			if (chatSystemMessageBonus.Bonuses != null)
			{
				foreach (RItem bonuse in chatSystemMessageBonus.Bonuses)
				{
					if (chatSystemMessageBonus.IsSplitBonuses)
					{
						for (int i = 0; i < bonuse.cnt; i++)
						{
							list.Add(Bonus.Get(bonuse.ItemId, 1));
						}
					}
					else
					{
						list.Add(Bonus.Get(bonuse.ItemId, bonuse.cnt));
					}
				}
			}
			BattleResultLogs.Add(new BattleResultBonusLog
			{
				Id = record.Id,
				Timestamp = record.Timestamp,
				Message = chatSystemMessageData.MessageText,
				Bonuses = list,
				TalentSrcList = chatSystemMessageBonus.TalentSrcList,
				Type = type
			});
		}
		BattleResultLogs.Sort(LogsSortingFunc);
	}

	private int LogsSortingFunc(BattleResultBonusLog a, BattleResultBonusLog b)
	{
		if (a.Id > b.Id)
		{
			return -1;
		}
		return (a.Id < b.Id) ? 1 : 0;
	}

	private void Update()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		HasWaitToClaim.selectedIndex = ((WaitToClaimLogIds.Count > 0) ? 1 : 0);
		BattleResultList.SetVirtual();
		BattleResultList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			BattleResultListItemRenderer(i, o as UI_btn_BattleResultSlot);
		};
		BattleResultList.numItems = BattleResultLogs.Count;
	}

	private void BattleResultListItemRenderer(int index, UI_btn_BattleResultSlot slot)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		BattleResultBonusLog data = BattleResultLogs[index];
		((GObject)slot.Message).text = data.Message;
		((GObject)slot.Time).text = DateTimeHelper.ParseMillisecondsTimeStamp(data.Timestamp).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
		bool isClaimed = !WaitToClaimLogIds.Contains(data.Id);
		slot.IsClaimed.selectedIndex = (isClaimed ? 1 : 0);
		slot.BonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			BonusListItemRenderer(i, (UI_btn_BattleResultBonus)(object)o, data.Bonuses, isClaimed);
		};
		slot.BonusList.numItems = data.Bonuses.Count;
		if (data.TalentSrcList == null)
		{
			slot.HasTalent.SetSelectedIndex(0);
			return;
		}
		slot.HasTalent.selectedIndex = ((data.TalentSrcList.Count > 0) ? 1 : 0);
		slot.TalentSrcList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			TalentSrcListItemRenderer(i, (UI_com_TalentSrc)(object)o, data.TalentSrcList);
		};
		slot.TalentSrcList.numItems = data.TalentSrcList.Count;
	}

	private void BonusListItemRenderer(int index, UI_btn_BattleResultBonus slot, List<Bonus> bonuses, bool isClaimed)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		Bonus bonusData = bonuses[index];
		slot.IsClaimed.selectedIndex = (isClaimed ? 1 : 0);
		FGUIManager.Instance.SetItemIconAndFrame(slot.Icon, bonusData.ItemId, null, "", frameVisible: true, 1f, bonusData);
		((GObject)slot.Count).text = bonusData.Qty.ShortNumberFormat();
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bonusData.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void TalentSrcListItemRenderer(int index, UI_com_TalentSrc slot, List<int> talentSrcList)
	{
		int idx = talentSrcList[index];
		slot.Icon.url = Singleton<GvGTalentsManager>.Instance.GetTalentUrl(idx);
		((GObject)slot.TalentName).text = Singleton<GvGTalentsManager>.Instance.GetTalentName(idx);
	}

	private List<Vector2> GetVisibleBonusSlotGlobalPos()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		float y = ((GObject)this).LocalToRoot(((GObject)BattleResultList).xy, GRoot.inst).y;
		float num = y + ((GObject)BattleResultList).height;
		List<Vector2> list = new List<Vector2>();
		GObject[] children = ((GComponent)BattleResultList).GetChildren();
		Vector2 val3 = default(Vector2);
		foreach (GObject val in children)
		{
			if (!((GComponent)BattleResultList).IsChildInView((GObject)(object)val.asCom))
			{
				continue;
			}
			UI_btn_BattleResultSlot uI_btn_BattleResultSlot = val as UI_btn_BattleResultSlot;
			GObject[] children2 = ((GComponent)uI_btn_BattleResultSlot.BonusList).GetChildren();
			foreach (GObject val2 in children2)
			{
				UI_btn_BattleResultBonus uI_btn_BattleResultBonus = val2 as UI_btn_BattleResultBonus;
				if (uI_btn_BattleResultBonus.IsClaimed.selectedIndex != 1)
				{
					((Vector2)(ref val3))._002Ector(((GObject)uI_btn_BattleResultBonus).pivotX * ((GObject)uI_btn_BattleResultBonus).width, ((GObject)uI_btn_BattleResultBonus).pivotY * ((GObject)uI_btn_BattleResultBonus).height);
					Vector2 val4 = ((GObject)uI_btn_BattleResultBonus).LocalToRoot(val3, GRoot.inst);
					if (!(val4.y < y) && !(num < val4.y))
					{
						list.Add(val4);
					}
				}
			}
		}
		return list;
	}
}

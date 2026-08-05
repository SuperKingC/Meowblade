using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UI.MonthCard;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GameActivity;

public class UI_OrcActivityPanel : GComponent
{
	public class StoreItemSlot
	{
		public string IconUrl = "";

		public int Num = 0;

		public string ItemId = "";
	}

	public class MissionSlot
	{
		public string BonusIcon = "";

		public int BonusNum = 0;

		public string BonusId = "";

		public string SoldierIcon = "";

		public string FrameUrl;

		public int BuyPrice = 0;

		public string BuyCurrencyIcon = "";

		public int ProgressBgState = 1;

		public List<StoreItemSlot> StoreItemList;

		public List<StoreItemSlot> ExtraList;

		public Mission mission = null;

		public StoreItem storeItem = null;

		public int targetLevel = 0;

		public ProductLocalInfo productLocalInfo = null;

		public bool IsMyth = false;

		public bool IsActive = false;

		public int BuyLimit = 0;

		public int ProgressBarState = 0;

		public int ClaimBtnState = 0;

		public int BuyBtnState = 0;

		public int CurrencyIconY = 33;

		public bool IsSSLIType()
		{
			string triggerPayload = mission.Data.TriggerPayload;
			AchievementManager.Achievements.TryGetValue(triggerPayload, out var value);
			if (value != null)
			{
				return value.Type == AchievementType.SoldierSecondLegendItemSlotUnlocked;
			}
			return false;
		}
	}

	public class PageData
	{
		public string SoldierId = "";

		public string LightBGUrl = "";

		public string DarkBGUrl = "";

		public bool HasRedDot = false;

		public bool isClaimed = false;

		public StoreMissionActivityPayload StorePayload = null;

		public List<MissionSlot> MissionSlots = null;

		public bool isUnlocked = false;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback1 _003C_003E9__35_2;

		internal void _003CMissionRenderer_003Eb__35_2(EventContext context)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass35_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass35_2();
			context.StopPropagation();
			GObject val = (GObject)context.sender;
			CS_0024_003C_003E8__locals2.targetTip = (string)val.data;
			FairyGUITip.ShowTip(val, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = CS_0024_003C_003E8__locals2.targetTip;
			});
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_2
	{
		public string targetTip;

		internal void _003CMissionRenderer_003Eb__9(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = targetTip;
		}
	}

	public GList SoldierTabList;

	public GList MissionList;

	public const string URL = "ui://29q48tv6mbra4d";

	public static string Name = "UI_OrcActivityPanel";

	private bool IsFirstTimeSelectTab;

	public UI_ActivityPanel ActivityPanel;

	private PageData CurPage = null;

	private bool IsUpdatingMissionList = false;

	private bool IsUpdatingTabList = false;

	public static int DataLoadingStatus = 0;

	public static List<PageData> UiData = new List<PageData>();

	public static Activity OrcActivity = null;

	private List<StoreItemSlot> _emptyMain;

	private List<StoreItemSlot> _emptyMain2;

	private List<StoreItemSlot> _emptySub;

	public static bool IsAvailable
	{
		get
		{
			Activity activity = ActivityManager.Activities["OrcTaskActivity"];
			if (activity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled)
			{
				return false;
			}
			Cache_OrcActivityRedDot cache_OrcActivityRedDot = CacheManager.Instance.Get<Cache_OrcActivityRedDot>();
			Dictionary<string, int> ownedSoldiers = GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true);
			Dictionary<string, ActivityContentPayload> dictionary = activity.ContentPayload(GameManagers.Instance);
			int num = 0;
			foreach (KeyValuePair<string, ActivityContentPayload> item in dictionary)
			{
				string key = item.Key;
				if (!ownedSoldiers.ContainsKey(key))
				{
					num++;
				}
			}
			return num != dictionary.Count;
		}
	}

	public static string GetURL()
	{
		return "ui://29q48tv6mbra4d";
	}

	public static UI_OrcActivityPanel CreateInstance()
	{
		return (UI_OrcActivityPanel)(object)UIPackage.CreateObject("GameActivity", "OrcActivityPanel");
	}

	public static UI_OrcActivityPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OrcActivityPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6mbra4d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SoldierTabList = (GList)((GComponent)this).GetChild("SoldierTabList");
		MissionList = (GList)((GComponent)this).GetChild("MissionList");
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<Cache_OrcActivityRedDot>(Cache_OrcActivityRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<Cache_OrcActivityRedDot>(Cache_OrcActivityRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
	}

	public void Init(UI_ActivityPanel activityPanel)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		((GComponent)this).EnsureBoundsCorrect();
		IsFirstTimeSelectTab = true;
		ActivityPanel = activityPanel;
		SoldierTabList.SetVirtual();
		SoldierTabList.itemRenderer = new ListItemRenderer(TabRenderer);
		SoldierTabList.numItems = 0;
		UI_OrcMissionSlot uI_OrcMissionSlot = UI_OrcMissionSlot.CreateInstance();
		UI_OrcMissionSlot.InitHeight = ((GObject)uI_OrcMissionSlot).height;
		((GObject)uI_OrcMissionSlot).Dispose();
		MissionList.itemRenderer = new ListItemRenderer(MissionRenderer);
		MissionList.numItems = 0;
		_emptyMain = new List<StoreItemSlot>();
		_emptyMain2 = new List<StoreItemSlot>();
		_emptySub = new List<StoreItemSlot>();
		_emptyMain.Add(new StoreItemSlot
		{
			IconUrl = GetIconByItemId("I31127"),
			Num = 0,
			ItemId = "I31127"
		});
		_emptyMain2.Add(new StoreItemSlot
		{
			IconUrl = GetIconByItemId("I31128"),
			Num = 0,
			ItemId = "I31128"
		});
		for (int i = 0; i < 3; i++)
		{
			_emptySub.Add(new StoreItemSlot
			{
				IconUrl = GetIconByItemId("I31128"),
				Num = 0,
				ItemId = "I31128"
			});
		}
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetData());
		AchievementManager.GetAchievementsByType(AchievementType.SoldierSecondLegendItemSlotUnlocked);
	}

	private void OnActivityLoaded()
	{
		if (!((GObject)this).isDisposed && UiData.Count > 0)
		{
			CurPage = UiData[0];
			SoldierTabList.numItems = UiData.Count;
		}
	}

	private void OnAllDataLoaded()
	{
		if (!((GObject)this).isDisposed)
		{
			UpdateTabList();
			UpdateMisionList();
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ScrollToCurrentPotentialNode());
		}
	}

	public IEnumerator ScrollToCurrentPotentialNode()
	{
		yield return null;
		List<MissionSlot> missionsData = CurPage.MissionSlots;
		int curPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(CurPage.SoldierId);
		int targetNodeIndex = 0;
		for (int i = 0; i < missionsData.Count; i++)
		{
			MissionSlot missionData = missionsData[i];
			if (missionData.targetLevel == curPotentialLevel)
			{
				targetNodeIndex = i;
				break;
			}
			if (missionData.targetLevel > curPotentialLevel)
			{
				targetNodeIndex = Math.Max(0, i - 1);
				break;
			}
			targetNodeIndex = i;
		}
		targetNodeIndex = Mathf.Min(MissionList.numItems - 1, targetNodeIndex);
		MissionList.ScrollToView(targetNodeIndex, true);
	}

	private IEnumerator GetData()
	{
		if (DataLoadingStatus == 1)
		{
			while (DataLoadingStatus != 2)
			{
				yield return null;
			}
		}
		if (DataLoadingStatus == 2)
		{
			OnActivityLoaded();
			OnAllDataLoaded();
			yield break;
		}
		DataLoadingStatus = 1;
		Activity activity = ActivityManager.Activities["OrcTaskActivity"];
		if (activity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled)
		{
			yield break;
		}
		OrcActivity = activity;
		UiData = new List<PageData>();
		foreach (KeyValuePair<string, ActivityContentPayload> page in activity.ContentPayload(GameManagers.Instance))
		{
			string id = page.Key;
			StoreMissionActivityPayload storePayload = (StoreMissionActivityPayload)page.Value;
			UiData.Add(new PageData
			{
				SoldierId = id,
				LightBGUrl = "ui://GameActivity/" + id + "_light",
				DarkBGUrl = "ui://GameActivity/" + id + "_dark",
				MissionSlots = new List<MissionSlot>(),
				StorePayload = storePayload
			});
		}
		OnActivityLoaded();
		yield return null;
		int pageNum = 0;
		foreach (PageData page2 in UiData)
		{
			List<string> missions = page2.StorePayload.Missions;
			List<string> storeItemConfig = page2.StorePayload.StoreItemsConfig;
			Dictionary<string, StoreItem> storeItems = page2.StorePayload.StoreItems(GameManagers.Instance);
			for (int i = 0; i < missions.Count; i++)
			{
				StoreItem storeItem = null;
				if (i < storeItemConfig.Count)
				{
					string storeItemKey = storeItemConfig[i];
					storeItem = storeItems[storeItemKey];
					if (storeItem.MissionFilter == null || storeItem.MissionFilter.Completed.Count == 0)
					{
						ILRuntimeDebug.LogError("兽族成长礼包无法关联任务 storeItem.MissionFilter={storeItem.MissionFilter} storeItem.MissionFilter.Completed.Count={storeItem.MissionFilter.Completed.Count}");
						DataLoadingStatus = 2;
						yield break;
					}
				}
				string missionId = missions[i];
				MissionManager.Missions.TryGetValue(missionId, out var mission);
				List<StoreItemSlot> storeItemList = new List<StoreItemSlot>();
				List<StoreItemSlot> extraList = new List<StoreItemSlot>();
				if (storeItem != null)
				{
					Dictionary<string, Dictionary<string, int>> displayContent = JsonHelper.ToObject<Dictionary<string, Dictionary<string, int>>>(storeItem.StoreItemData.DisplayContent);
					foreach (KeyValuePair<string, Dictionary<string, int>> ctype in displayContent)
					{
						foreach (KeyValuePair<string, int> item in ctype.Value)
						{
							StoreItemSlot slot = new StoreItemSlot
							{
								IconUrl = GetIconByItemId(item.Key),
								Num = item.Value,
								ItemId = item.Key
							};
							if (ctype.Key == "normal")
							{
								storeItemList.Add(slot);
							}
							else if (ctype.Key == "extra")
							{
								extraList.Add(slot);
							}
						}
					}
				}
				int progressBgState = 2;
				if (i == 0)
				{
					progressBgState = 1;
				}
				else if (i == missions.Count - 1)
				{
					progressBgState = 3;
				}
				int targetLevel = 0;
				string achievementId = mission.Data.TriggerPayload;
				AchievementManager.Achievements.TryGetValue(achievementId, out var achievement);
				if (achievement != null)
				{
					targetLevel = achievement.Target.PotentialLevel;
				}
				Bonus bonus = mission.BonusList[0];
				MissionSlot missionSlot = new MissionSlot
				{
					BonusIcon = GetIconByItemId(bonus.ItemId),
					BonusNum = bonus.Qty,
					BonusId = bonus.ItemId,
					SoldierIcon = "ui://PublicResources/" + UiHelper.GetIconPath(page2.SoldierId, PotentialToItemLevel(targetLevel)),
					FrameUrl = "ui://PublicResources/" + UiHelper.GetIconFrameBorderSoldier(targetLevel),
					StoreItemList = storeItemList,
					ExtraList = extraList,
					ProgressBgState = progressBgState,
					ProgressBarState = 0,
					targetLevel = targetLevel,
					mission = mission,
					storeItem = storeItem,
					IsMyth = CheckMissionIsMyth(targetLevel)
				};
				if (storeItem != null && HotUpdateProcess.Instance.IsRegionOutCN && !string.IsNullOrEmpty(storeItem.ReferenceId))
				{
					if (PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out var productLocalInfo))
					{
						missionSlot.productLocalInfo = productLocalInfo;
					}
					else
					{
						ILRuntimeDebug.LogError(storeItem.StoreItemId + " Find No ProductStr");
					}
					productLocalInfo = null;
				}
				page2.MissionSlots.Add(missionSlot);
				mission = null;
				achievement = null;
			}
			if (!((GObject)this).isDisposed && pageNum == 0)
			{
				MissionList.numItems = page2.MissionSlots.Count;
			}
			int num = pageNum + 1;
			pageNum = num;
			yield return null;
		}
		DataLoadingStatus = 2;
		OnAllDataLoaded();
		static bool CheckMissionIsMyth(int num2)
		{
			return num2 == 9;
		}
	}

	private static int PotentialToItemLevel(int potentialLevel)
	{
		int soldierMaxEvoLevel = GameManagers.Instance.UserArchiveManager.GetSoldierMaxEvoLevel();
		int num = ((potentialLevel == 9) ? 6 : ((potentialLevel + 2) / 2));
		if (num < 1)
		{
			num = 1;
		}
		else if (num > soldierMaxEvoLevel)
		{
			num = soldierMaxEvoLevel;
		}
		return num;
	}

	private KeyValuePair<string, float> GetPriceAndCurrency(StoreItem storeItem, bool isVirtualCurrency = true)
	{
		foreach (Dictionary<string, float> item in storeItem.Price)
		{
			Dictionary<string, float>.Enumerator enumerator2 = item.GetEnumerator();
			enumerator2.MoveNext();
			KeyValuePair<string, float> current2 = enumerator2.Current;
			string key = current2.Key;
			float value = current2.Value;
			if (isVirtualCurrency)
			{
				if (!key.Equals("RMB"))
				{
					return current2;
				}
			}
			else if (key.Equals("RMB"))
			{
				return current2;
			}
		}
		return default(KeyValuePair<string, float>);
	}

	private static string GetIconByItemId(string itemId)
	{
		return "ui://PublicResources/" + UiHelper.GetIcon(itemId);
	}

	private void TabRenderer(int index, GObject obj)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		if (!((GObject)this).isDisposed)
		{
			PageData pageData = UiData[index];
			UI_SoldierTab uI_SoldierTab = (UI_SoldierTab)(object)obj;
			((GObject)uI_SoldierTab).touchable = pageData.isUnlocked;
			((GObject)uI_SoldierTab.RedDot).visible = pageData.HasRedDot;
			((GObject)uI_SoldierTab.AllClaimedIcon).visible = pageData.isClaimed;
			uI_SoldierTab.IsUnlocked.selectedIndex = (pageData.isUnlocked ? 1 : 0);
			uI_SoldierTab.Light.url = pageData.LightBGUrl;
			uI_SoldierTab.Dark.url = pageData.DarkBGUrl;
			((GObject)uI_SoldierTab).onClick.Set((EventCallback1)delegate
			{
				OnClickTab(index);
			});
			if (pageData == CurPage && !IsFirstTimeSelectTab)
			{
				uI_SoldierTab.IsSelected.selectedIndex = 1;
			}
			else
			{
				uI_SoldierTab.IsSelected.selectedIndex = 0;
			}
		}
	}

	private void MissionRenderer(int index, GObject obj)
	{
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected O, but got Unknown
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Expected O, but got Unknown
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Expected O, but got Unknown
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)this).isDisposed || CurPage == null)
		{
			return;
		}
		UI_OrcMissionSlot slot = (UI_OrcMissionSlot)(object)obj;
		if (index >= CurPage.MissionSlots.Count)
		{
			Debug.LogError((object)$"Unknown Index {index} -- {CurPage.MissionSlots.Count}");
			return;
		}
		((GObject)slot).visible = true;
		MissionSlot missionSlot = CurPage.MissionSlots[index];
		bool flag = missionSlot.IsSSLIType();
		slot.showLegendItemSlot.SetSelectedIndex(flag ? 1 : 0);
		slot.IsMyth.SetSelectedIndex(missionSlot.IsMyth ? 1 : 0);
		slot.StoreItemState.selectedIndex = ((missionSlot.ExtraList.Count <= 0) ? 1 : 2);
		slot.ProgressBgState.selectedIndex = missionSlot.ProgressBgState;
		slot.ProgressBarState.selectedIndex = missionSlot.ProgressBarState;
		slot.Icon.url = missionSlot.SoldierIcon;
		slot.Frame.url = missionSlot.FrameUrl;
		UiHelper.LoadSoldierIconFrameMaterial(slot.Frame, missionSlot.targetLevel);
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(CurPage.SoldierId);
		string name = gDESoldierData.Name;
		string data;
		if (flag)
		{
			data = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(LanguagesManager.GetDesc("OrcMissionCompleteTip1"), name);
		}
		else
		{
			string soldierLevelStr = UiHelper.GetSoldierLevelStr(missionSlot.targetLevel);
			data = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(LanguagesManager.GetDesc("OrcMissionCompleteTip2"), name, soldierLevelStr);
		}
		((GObject)slot.Icon).data = data;
		EventListener onClick = ((GObject)slot.Icon).onClick;
		object obj2 = _003C_003Ec._003C_003E9__35_2;
		if (obj2 == null)
		{
			EventCallback1 val = delegate(EventContext context)
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Expected O, but got Unknown
				//IL_003b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0041: Unknown result type (might be due to invalid IL or missing references)
				context.StopPropagation();
				GObject val2 = (GObject)context.sender;
				string targetTip = (string)val2.data;
				FairyGUITip.ShowTip(val2, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
				{
					((GObject)popup.title).text = targetTip;
				});
			};
			_003C_003Ec._003C_003E9__35_2 = val;
			obj2 = (object)val;
		}
		onClick.Set((EventCallback1)obj2);
		slot.Bonus.icon.url = missionSlot.BonusIcon;
		((GObject)slot.Bonus.num).text = missionSlot.BonusNum.ToString();
		((GObject)slot.Bonus).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(missionSlot.BonusId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		((GObject)slot.ClaimBtn).onClick.Set((EventCallback0)delegate
		{
			OnClickClaim(missionSlot.mission, slot);
		});
		slot.ClaimBtn.State.selectedIndex = missionSlot.ClaimBtnState;
		((GObject)slot.BonusClaimed).visible = missionSlot.ClaimBtnState == 2;
		if (HotUpdateProcess.LanguageKey == "eng" && missionSlot.BuyLimit == 1)
		{
			((GObject)slot.LimitText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText966") ?? "";
		}
		else
		{
			((GObject)slot.LimitText).text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText27"), missionSlot.BuyLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
		}
		((GObject)slot.LimitText2).text = ((GObject)slot.LimitText).text;
		((GObject)slot.StoreItemClaimed).visible = missionSlot.BuyBtnState == 2;
		((GObject)slot.cardMask).visible = !missionSlot.IsActive;
		bool flag2 = missionSlot.storeItem == null;
		HashSet<int> hashSet = new HashSet<int> { 4, 5, 6 };
		bool flag3 = false;
		if (!flag2 && GameController.Instance.GetServerTime() < missionSlot.storeItem.KickOffTime.ToUnixTimeSeconds())
		{
			flag3 = true;
			flag2 = true;
		}
		slot.isGiftEmpty.SetSelectedIndex(flag2 ? 1 : 0);
		if (!flag2)
		{
			InitBuyBtn(slot.BuyBtn);
			InitBuyBtn(slot.BuyBtn2);
			if (missionSlot.IsMyth)
			{
				RenderMythStoreItems(missionSlot);
			}
			else
			{
				RenderStoreItems(missionSlot);
			}
		}
		else
		{
			slot.MythSlotEmpty.Type.SetSelectedIndex((!missionSlot.IsMyth) ? 1 : 0);
			slot.MythSlotEmpty.ExtraList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				MythStoreItemRenderer(i, o, _emptyMain);
			};
			slot.MythSlotEmpty.ExtraList.numItems = _emptyMain.Count;
			slot.MythSlotEmpty.ExtraList2.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0077: Expected O, but got Unknown
				UI_OrcStoreItem uI_OrcStoreItem = (UI_OrcStoreItem)(object)o;
				StoreItemSlot itemSlot = _emptyMain2[i];
				FGUIManager.Instance.SetItemIconAndFrame(uI_OrcStoreItem.icon, itemSlot.ItemId, null, "", frameVisible: false);
				((GObject)uI_OrcStoreItem.num).text = string.Empty;
				((GObject)uI_OrcStoreItem).onClick.Set((EventCallback0)delegate
				{
					itemSlot.ItemId.DisplayItemTip();
				});
			};
			slot.MythSlotEmpty.ExtraList2.numItems = _emptyMain2.Count;
			slot.MythSlotEmpty.StoreItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				MythStoreItemRenderer(i, o, _emptySub);
			};
			slot.MythSlotEmpty.StoreItemList.numItems = _emptySub.Count;
		}
		bool flag4 = index == CurPage.MissionSlots.Count - 1;
		List<List<string>> moreStoreItems = CurPage.StorePayload.MoreStoreItems;
		bool flag5 = flag4 && moreStoreItems.Count > index && moreStoreItems[index].Count > 0;
		if (flag5 && !flag3)
		{
			if (slot.moreStoreItemSlots == null)
			{
				slot.moreStoreItemSlots = UI_com_OrcMoreStoreItemSlot.CreateInstance();
				((GComponent)slot).AddChild((GObject)(object)slot.moreStoreItemSlots);
			}
			UI_com_OrcMoreStoreItemSlot moreStoreItemSlots = slot.moreStoreItemSlots;
			((GObject)moreStoreItemSlots).visible = true;
			moreStoreItemSlots.unlocked.SetSelectedIndex(missionSlot.IsActive ? 1 : 0);
			moreStoreItemSlots.storeItemList.numItems = 0;
			List<string> list = CurPage.StorePayload.MoreStoreItems[index];
			moreStoreItemSlots.storeItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject item)
			{
				RenderMoreStoreItemSlot(i, list, (UI_com_OrcGiftPack)(object)item, missionSlot.IsActive);
			};
			moreStoreItemSlots.storeItemList.numItems = list.Count;
			((GObject)moreStoreItemSlots).xy = new Vector2(0f, UI_OrcMissionSlot.InitHeight);
			((GObject)slot).height = UI_OrcMissionSlot.InitHeight + ((GObject)moreStoreItemSlots).height;
		}
		else
		{
			((GObject)slot).height = UI_OrcMissionSlot.InitHeight;
			if (slot.moreStoreItemSlots != null)
			{
				((GObject)slot.moreStoreItemSlots).visible = false;
			}
		}
		void InitBuyBtn(UI_OrcBuyBtn buyBtn)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			((GObject)buyBtn.Price).text = missionSlot.BuyPrice.ToString();
			buyBtn.Currency.url = missionSlot.BuyCurrencyIcon;
			((GObject)buyBtn).onClick.Set((EventCallback0)delegate
			{
				OnClickBuyBtn(missionSlot.storeItem, slot);
			});
			buyBtn.State.selectedIndex = missionSlot.BuyBtnState;
			((GObject)buyBtn.Currency).y = missionSlot.CurrencyIconY;
			((GObject)buyBtn.priceGroup).visible = true;
			((GObject)buyBtn.priceGroupIntl).visible = false;
			if (HotUpdateProcess.Instance.IsRegionOutCN && FGUIManager.Instance.GetPriceItemId(missionSlot.storeItem).Key == "RMB" && !missionSlot.storeItem.IsFree)
			{
				((GObject)buyBtn.priceGroup).visible = false;
				((GObject)buyBtn.priceGroupIntl).visible = true;
				((GObject)buyBtn.PriceIntl).text = ((missionSlot.productLocalInfo != null) ? UI_MonthCardPanel.StripZeros(missionSlot.productLocalInfo.FormattedPrice) : "--");
			}
		}
		void RenderMythStoreItems(MissionSlot missionSlot2)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			slot.MythSlot.StoreItemList.SetVirtual();
			slot.MythSlot.StoreItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				MythStoreItemRenderer(i, o, missionSlot2.StoreItemList);
			};
			slot.MythSlot.StoreItemList.numItems = missionSlot2.StoreItemList.Count;
			slot.MythSlot.ExtraList.SetVirtual();
			slot.MythSlot.ExtraList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				MythStoreItemRenderer(i, o, missionSlot2.ExtraList);
			};
			slot.MythSlot.ExtraList.numItems = missionSlot2.ExtraList.Count;
		}
		void RenderStoreItems(MissionSlot missionSlot2)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			slot.StoreItemList.SetVirtual();
			slot.StoreItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				StoreItemRenderer(i, o, missionSlot2.StoreItemList);
			};
			slot.StoreItemList.numItems = missionSlot2.StoreItemList.Count;
			slot.StoreItemList.ResizeToFit(missionSlot2.StoreItemList.Count, 84);
			slot.ExtraList.SetVirtual();
			slot.ExtraList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				StoreItemRenderer(i, o, missionSlot2.ExtraList);
			};
			slot.ExtraList.numItems = missionSlot2.ExtraList.Count;
			slot.ExtraList.ResizeToFit(missionSlot2.ExtraList.Count, 84);
		}
	}

	private void RenderMoreStoreItemSlot(int index, List<string> storeItems, UI_com_OrcGiftPack obj, bool activated)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		string storeItemId = storeItems[index];
		StoreItem storeItem = StoreItem.Get(GameManagers.Instance, storeItemId);
		UI_com_OrcStoreItemIcon itemIcon = obj.ItemIcon;
		FGUIManager.Instance.SetItemIconAndFrame(itemIcon.itemIcon, storeItem.Icon, null, "", frameVisible: false);
		string itemId = storeItem.Icon;
		itemIcon.Type.SetSelectedIndex((index != 0) ? 1 : 0);
		((GObject)itemIcon).onClick.Set((EventCallback0)delegate
		{
			if (!FGUIManager.TryShowOptionalBlueprint(itemId))
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)ActivityPanel).sortingOrder, noCheckBtn: false, reserveRes: false, ActivityPanel);
			}
		});
		((GObject)obj.Title).text = storeItem.Name;
		InitMoreStoreItemBuyBtn(obj.BuyBtn, storeItem, activated);
	}

	private void InitMoreStoreItemBuyBtn(UI_OrcBuyBtn buyBtn, StoreItem storeItem, bool activated)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		int num = 2;
		if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
		{
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			num = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
		}
		bool canBuy = num > 0 && activated;
		buyBtn.State.SetSelectedIndex(activated ? ((num > 0) ? 1 : 2) : 0);
		((GObject)buyBtn).onClick.Set((EventCallback0)delegate
		{
			if (canBuy)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
				{
					{
						"Name",
						storeItem.Name ?? ""
					},
					{ "CanBuy", true },
					{ "GiftBag", storeItem },
					{ "Parent", this }
				});
			}
		});
		KeyValuePair<string, float> priceAndCurrency = GetPriceAndCurrency(storeItem);
		int num2 = 30;
		if (GameManagers.Instance.StockController.GetStock(priceAndCurrency.Key) < (int)priceAndCurrency.Value)
		{
			num2 = 28;
			priceAndCurrency = GetPriceAndCurrency(storeItem, isVirtualCurrency: false);
		}
		int num3 = (int)priceAndCurrency.Value;
		((GObject)buyBtn.Price).text = num3.ToString();
		buyBtn.Currency.url = "ui://PublicResources/" + priceAndCurrency.Key;
		((GObject)buyBtn.Currency).y = num2;
		((GObject)buyBtn.priceGroup).visible = true;
		((GObject)buyBtn.priceGroupIntl).visible = false;
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return;
		}
		bool flag = FGUIManager.Instance.GetPriceItemId(storeItem).Key == "RMB" && !storeItem.IsFree;
		ProductLocalInfo productLocalInfo = null;
		if (flag)
		{
			((GObject)buyBtn.priceGroup).visible = false;
			((GObject)buyBtn.priceGroupIntl).visible = true;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId))
			{
				if (PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out var value))
				{
					productLocalInfo = value;
				}
				else
				{
					ILRuntimeDebug.LogError(storeItem.StoreItemId + " Find No ProductStr");
				}
			}
		}
		((GObject)buyBtn.PriceIntl).text = ((productLocalInfo != null) ? UI_MonthCardPanel.StripZeros(productLocalInfo.FormattedPrice) : "--");
	}

	private void StoreItemRenderer(int index, GObject obj, List<StoreItemSlot> list)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		UI_OrcStoreItem uI_OrcStoreItem = (UI_OrcStoreItem)(object)obj;
		StoreItemSlot data = list[index];
		FGUIManager.Instance.SetItemIconAndFrame(uI_OrcStoreItem.icon, data.ItemId, null, "", frameVisible: false);
		((GObject)uI_OrcStoreItem.num).text = data.Num.ToString();
		((GObject)uI_OrcStoreItem).onClick.Set((EventCallback0)delegate
		{
			if (!FGUIManager.TryShowOptionalBlueprint(data.ItemId))
			{
				FGUIManager.Instance.ItemTip(data.ItemId, ((GObject)ActivityPanel).sortingOrder, noCheckBtn: false, reserveRes: false, ActivityPanel);
			}
		});
	}

	private void MythStoreItemRenderer(int index, GObject obj, List<StoreItemSlot> list)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		UI_OrcStoreItem uI_OrcStoreItem = (UI_OrcStoreItem)(object)obj;
		StoreItemSlot itemSlot = list[index];
		FGUIManager.Instance.SetItemIconAndFrame(uI_OrcStoreItem.icon, itemSlot.ItemId, null, "", frameVisible: false);
		((GObject)uI_OrcStoreItem.num).text = ((itemSlot.Num > 0) ? itemSlot.Num.ToString() : string.Empty);
		((GObject)uI_OrcStoreItem).onClick.Set((EventCallback0)delegate
		{
			if (!FGUIManager.TryShowOptionalBlueprint(itemSlot.ItemId))
			{
				FGUIManager.Instance.ItemTip(itemSlot.ItemId, ((GObject)ActivityPanel).sortingOrder, noCheckBtn: false, reserveRes: false, ActivityPanel);
			}
		});
	}

	private void GetState()
	{
		bool state = true;
		int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(CurPage.SoldierId);
		for (int i = 0; i < CurPage.MissionSlots.Count; i++)
		{
			MissionSlot missionSlot = CurPage.MissionSlots[i];
			missionSlot.CurrencyIconY = 30;
			StoreItem storeItem = missionSlot.storeItem;
			if (storeItem != null)
			{
				KeyValuePair<string, float> priceAndCurrency = GetPriceAndCurrency(storeItem);
				if (GameManagers.Instance.StockController.GetStock(priceAndCurrency.Key) < (int)priceAndCurrency.Value)
				{
					missionSlot.CurrencyIconY = 28;
					priceAndCurrency = GetPriceAndCurrency(storeItem, isVirtualCurrency: false);
				}
				missionSlot.BuyPrice = (int)priceAndCurrency.Value;
				missionSlot.BuyCurrencyIcon = "ui://PublicResources/" + priceAndCurrency.Key;
				int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
				missionSlot.BuyLimit = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
			}
			if (missionSlot.IsSSLIType())
			{
				missionSlot.IsActive = missionSlot.mission.MissionState(GameManagers.Instance).Status != MissionStatus.Undergoing;
			}
			else
			{
				missionSlot.IsActive = soldierPotentialLevel >= missionSlot.targetLevel;
			}
			MissionStatus status = missionSlot.mission.MissionState(GameManagers.Instance).Status;
			missionSlot.BuyBtnState = ((missionSlot.BuyLimit > 0) ? 1 : 2);
			switch (status)
			{
			case MissionStatus.Completed:
				missionSlot.ClaimBtnState = 1;
				break;
			case MissionStatus.Claimed:
				missionSlot.ClaimBtnState = 2;
				break;
			default:
				missionSlot.ClaimBtnState = 0;
				missionSlot.BuyBtnState = 0;
				break;
			}
			if (status != MissionStatus.Claimed || missionSlot.BuyLimit > 0)
			{
				state = false;
			}
		}
		for (int j = 0; j < CurPage.MissionSlots.Count; j++)
		{
			MissionSlot missionSlot2 = CurPage.MissionSlots[j];
			MissionSlot missionSlot3 = ((j > 0) ? CurPage.MissionSlots[j - 1] : null);
			MissionSlot missionSlot4 = ((j < CurPage.MissionSlots.Count - 1) ? CurPage.MissionSlots[j + 1] : null);
			if (missionSlot3 == null)
			{
				missionSlot2.ProgressBarState = (missionSlot2.IsActive ? 1 : 0);
			}
			else if (missionSlot4 == null)
			{
				missionSlot2.ProgressBarState = (missionSlot2.IsActive ? 3 : 0);
			}
			else if (missionSlot3.IsActive && !missionSlot2.IsActive)
			{
				missionSlot2.ProgressBarState = 3;
			}
			else if (missionSlot3.IsActive && missionSlot2.IsActive)
			{
				missionSlot2.ProgressBarState = 2;
			}
			else
			{
				missionSlot2.ProgressBarState = 0;
			}
		}
		CacheManager.Instance.Get<Cache_OrcActivityRedDot>().SetPageClaimState(CurPage.SoldierId, state);
	}

	private void GetTabState()
	{
		Dictionary<string, int> ownedSoldiers = GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true);
		Cache_OrcActivityRedDot cache_OrcActivityRedDot = CacheManager.Instance.Get<Cache_OrcActivityRedDot>();
		foreach (PageData uiDatum in UiData)
		{
			uiDatum.isUnlocked = ownedSoldiers.ContainsKey(uiDatum.SoldierId);
			if (uiDatum.isUnlocked)
			{
				uiDatum.HasRedDot = cache_OrcActivityRedDot.HasPageRedDot(uiDatum.SoldierId);
				uiDatum.isClaimed = cache_OrcActivityRedDot.IsPageClaimed(uiDatum.SoldierId);
				if (IsFirstTimeSelectTab)
				{
					IsFirstTimeSelectTab = false;
					CurPage = uiDatum;
				}
			}
		}
	}

	private void UpdateMisionList()
	{
		if (!((GObject)this).isDisposed && !IsUpdatingMissionList)
		{
			IsUpdatingMissionList = true;
			if (DataLoadingStatus == 2)
			{
				GetState();
			}
			MissionList.numItems = CurPage.MissionSlots.Count;
			IsUpdatingMissionList = false;
		}
	}

	private void UpdateTabList()
	{
		if (!((GObject)this).isDisposed && !IsUpdatingTabList)
		{
			IsUpdatingTabList = true;
			if (DataLoadingStatus == 2)
			{
				GetTabState();
			}
			SoldierTabList.numItems = UiData.Count;
			SoldierTabList.RefreshVirtualList();
			IsUpdatingTabList = false;
		}
	}

	private void OnClickTab(int index)
	{
		CurPage = UiData[index];
		SoldierTabList.numItems = UiData.Count;
		UpdateMisionList();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ScrollToCurrentPotentialNode());
	}

	private void OnClickBuyBtn(StoreItem storeItem, UI_OrcMissionSlot slot)
	{
		if (!((GObject)this).isDisposed && DataLoadingStatus == 2 && slot.BuyBtn.State.selectedIndex == 1)
		{
			ProductLocalInfo value = null;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId))
			{
				PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value);
			}
			PurchaseManager.Instance.InvokePurchase(storeItem, value, 1, delegate
			{
				UpdateMisionList();
				UpdateTabList();
			}, doubleCheck: true);
		}
	}

	private void OnClickClaim(Mission mission, UI_OrcMissionSlot slot)
	{
		if (((GObject)this).isDisposed || DataLoadingStatus != 2 || slot.ClaimBtn.State.selectedIndex != 1)
		{
			return;
		}
		ILRequestHelper<MissionClaimResponse>.Request((EventContext)null, (Func<Task<MissionClaimResponse>>)(() => Contexts.sharedInstance.Service<INetworkService>().MissionClaim(mission.Id)), (Action<MissionClaimResponse>)delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
				if (response.BonusList != null && response.BonusList.Count > 0)
				{
					FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList);
					UpdateMisionList();
				}
				else
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText234") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
				}
			}
		});
	}

	private void OnPageRedDotChange(Cache_OrcActivityRedDot cache)
	{
		if (DataLoadingStatus == 2 && !IsAvailable)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText235") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
		}
		UpdateTabList();
	}

	public void Destroy()
	{
	}
}

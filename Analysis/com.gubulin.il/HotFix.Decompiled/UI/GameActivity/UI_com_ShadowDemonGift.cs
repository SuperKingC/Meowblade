using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UnityEngine;

namespace UI.GameActivity;

public class UI_com_ShadowDemonGift : GComponent
{
	public Controller TabPage;

	public Controller isLocked;

	public Controller region;

	public Controller purchased;

	public GLoader activityBg;

	public GImage n58;

	public GImage n59;

	public GList AchievementList;

	public UI_dec_01 lockMask;

	public GImage n60;

	public UI_dec_02 n66;

	public GLoader n68;

	public GTextField unlockCoundition;

	public GMovieClip n76;

	public GTextField n61;

	public GTextField n62;

	public GTextField n63;

	public GTextField curPriceTitle;

	public GLoader curCurrencyIcon;

	public GTextField curPrice;

	public GGroup priceGroup;

	public GTextField curIntlPriceText;

	public UI_tab_01 tabBtn1;

	public UI_tab_01 tabBtn2;

	public UI_tab_01 tabBtn3;

	public UI_com_02 reward1;

	public UI_com_03 reward2;

	public UI_com_03 reward3;

	public GLoader n67;

	public GButton buyGiftBtn;

	public GImage n73;

	public GTextField time;

	public Transition unlock;

	public const string URL = "ui://29q48tv6ntoz5f8r";

	public static string Name = "UI_com_ShadowDemonGift";

	private int _currentTab;

	private SoliderDevelopPayload _payload;

	private UI_ActivityPanel _parentPanel;

	private Dictionary<int, List<Mission>> _missionsByTab;

	private List<UI_tab_01> _tabs;

	private long _activityEndTime;

	private bool _isAnimating;

	public static string GetURL()
	{
		return "ui://29q48tv6ntoz5f8r";
	}

	public static UI_com_ShadowDemonGift CreateInstance()
	{
		return (UI_com_ShadowDemonGift)(object)UIPackage.CreateObject("GameActivity", "com_ShadowDemonGift");
	}

	public static UI_com_ShadowDemonGift CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShadowDemonGift).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6ntoz5f8r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TabPage = ((GComponent)this).GetController("TabPage");
		isLocked = ((GComponent)this).GetController("isLocked");
		region = ((GComponent)this).GetController("region");
		purchased = ((GComponent)this).GetController("purchased");
		activityBg = (GLoader)((GComponent)this).GetChild("activityBg");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		AchievementList = (GList)((GComponent)this).GetChild("AchievementList");
		lockMask = (UI_dec_01)(object)((GComponent)this).GetChild("lockMask");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n66 = (UI_dec_02)(object)((GComponent)this).GetChild("n66");
		n68 = (GLoader)((GComponent)this).GetChild("n68");
		unlockCoundition = (GTextField)((GComponent)this).GetChild("unlockCoundition");
		n76 = (GMovieClip)((GComponent)this).GetChild("n76");
		n61 = (GTextField)((GComponent)this).GetChild("n61");
		string id = "ui://29q48tv6ntoz5f8r".Replace("ui://", "") + "-" + ((GObject)n61).id;
		((GObject)n61).text = LanguagesManager.GetDesc(id);
		n62 = (GTextField)((GComponent)this).GetChild("n62");
		string id2 = "ui://29q48tv6ntoz5f8r".Replace("ui://", "") + "-" + ((GObject)n62).id;
		((GObject)n62).text = LanguagesManager.GetDesc(id2);
		n63 = (GTextField)((GComponent)this).GetChild("n63");
		string id3 = "ui://29q48tv6ntoz5f8r".Replace("ui://", "") + "-" + ((GObject)n63).id;
		((GObject)n63).text = LanguagesManager.GetDesc(id3);
		curPriceTitle = (GTextField)((GComponent)this).GetChild("curPriceTitle");
		string id4 = "ui://29q48tv6ntoz5f8r".Replace("ui://", "") + "-" + ((GObject)curPriceTitle).id;
		((GObject)curPriceTitle).text = LanguagesManager.GetDesc(id4);
		curCurrencyIcon = (GLoader)((GComponent)this).GetChild("curCurrencyIcon");
		curPrice = (GTextField)((GComponent)this).GetChild("curPrice");
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
		string id5 = "ui://29q48tv6ntoz5f8r".Replace("ui://", "") + "-" + ((GObject)curIntlPriceText).id;
		((GObject)curIntlPriceText).text = LanguagesManager.GetDesc(id5);
		tabBtn1 = (UI_tab_01)(object)((GComponent)this).GetChild("tabBtn1");
		tabBtn2 = (UI_tab_01)(object)((GComponent)this).GetChild("tabBtn2");
		tabBtn3 = (UI_tab_01)(object)((GComponent)this).GetChild("tabBtn3");
		reward1 = (UI_com_02)(object)((GComponent)this).GetChild("reward1");
		reward2 = (UI_com_03)(object)((GComponent)this).GetChild("reward2");
		reward3 = (UI_com_03)(object)((GComponent)this).GetChild("reward3");
		n67 = (GLoader)((GComponent)this).GetChild("n67");
		buyGiftBtn = (GButton)((GComponent)this).GetChild("buyGiftBtn");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		time = (GTextField)((GComponent)this).GetChild("time");
		unlock = ((GComponent)this).GetTransition("unlock");
	}

	public void Init(UI_ActivityPanel parentPanel, SoliderDevelopPayload payload)
	{
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		_parentPanel = parentPanel;
		_payload = payload;
		_currentTab = 0;
		_isAnimating = false;
		_missionsByTab = new Dictionary<int, List<Mission>>();
		_activityEndTime = payload.Activity.ActivityProgress(GameManagers.Instance).EndAt.ToUnixTimeSeconds();
		for (int i = 0; i < _payload.Stage.Count; i++)
		{
			StageConfig stageConfig = _payload.Stage[i];
			List<Mission> list = new List<Mission>();
			foreach (string item2 in stageConfig.MissionSerial)
			{
				Mission item = MissionManager.Missions[item2];
				list.Add(item);
			}
			list.Sort(delegate(Mission a, Mission b)
			{
				MissionConfig missionConfig = a.MissionState(GameManagers.Instance);
				MissionConfig missionConfig2 = b.MissionState(GameManagers.Instance);
				return missionConfig.Status.GetSortOrder() - missionConfig2.Status.GetSortOrder();
			});
			_missionsByTab[i] = list;
		}
		((GObject)tabBtn1).data = 0;
		((GObject)tabBtn2).data = 1;
		((GObject)tabBtn3).data = 2;
		_tabs = new List<UI_tab_01> { tabBtn1, tabBtn2, tabBtn3 };
		for (int num = 0; num < _payload.Stage.Count; num++)
		{
			StageConfig stageConfig2 = _payload.Stage[num];
			if (stageConfig2.AnimSignal)
			{
				_currentTab = num;
				break;
			}
		}
		TabPage.selectedIndex = _currentTab;
		TabPage.onChanged.Set(new EventCallback1(OnClickChangeTab));
		((GObject)buyGiftBtn).onClick.Set(new EventCallback0(OnClickBuyGiftBag));
		RefreshPage();
		SharedMessenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionCompleted);
		GameManagers.Instance.Messenger.AddListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OrderShipSuccessEvent);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnOtherUiClosed);
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Update());
	}

	private IEnumerator Update()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			UpdateRemainTime();
			yield return wait;
		}
	}

	private void UpdateRemainTime()
	{
		int num = (int)(_activityEndTime - GameController.Instance.GetServerTime());
		num = Mathf.Max(num, 0);
		string arg = UiHelper.ParseTimeChinsesDH(num);
		((GObject)time).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("SpinWeekActivityTimeTip".ToLanguage(), arg);
	}

	private void RefreshPage()
	{
		RefreshAchievements();
		RefreshGiftBag();
		RefreshUnlockState();
	}

	private void RefreshGiftBag()
	{
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		List<string> gift = _payload.Stage[_currentTab].Gift;
		if (gift != null && gift.Count > 0)
		{
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, gift[0]);
			purchased.SetSelectedIndex(storeItem.IsSoldOut ? 1 : 0);
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			string text = $"{Convert.ToInt32(priceItemId.Value)}";
			ProductLocalInfo value = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				region.SetSelectedIndex(1);
				text = ((string.IsNullOrEmpty(storeItem.ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value)) ? "--" : value.FormattedPrice);
			}
			else
			{
				region.SetSelectedIndex(0);
			}
			string key = priceItemId.Key;
			curCurrencyIcon.url = "ui://PublicResources/" + key;
			curCurrencyIcon.url = "ui://PublicResources/" + key;
			((GObject)curPrice).text = text;
			((GObject)curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText958"), text);
			List<string> list = storeItem.Content.Keys.ToList();
			string key2 = list[0];
			string text2 = list[1];
			int num = storeItem.Content[key2];
			int count = storeItem.Content[text2];
			FGUIManager.Instance.SetItemIconAndFrame(reward1.rewardIconAdvance, key2, null, "", frameVisible: false);
			((GObject)reward1.rewardIconAdvance).onClick.Set((EventCallback1)delegate(EventContext x)
			{
				x.StopPropagation();
				FGUIManager.Instance.ItemTip(key2, 2);
			});
			((GObject)reward1.num).text = $"x{num}";
			InitReward(reward2, text2, count);
			if (list.Count > 2)
			{
				string text3 = list[2];
				int count2 = storeItem.Content[text3];
				InitReward(reward3, text3, count2);
			}
		}
		static void InitReward(UI_com_03 btn, string itemId, int num2)
		{
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			FGUIManager.Instance.SetItemIconAndFrame(btn.rewardIconAdvance, itemId, null, "", frameVisible: false);
			((GObject)btn.rewardIconAdvance).onClick.Set((EventCallback1)delegate(EventContext x)
			{
				x.StopPropagation();
				FGUIManager.Instance.ItemTip(itemId, 2);
			});
			((GObject)btn.num).text = $"x{num2}";
		}
	}

	private void OrderShipSuccessEvent(string storeItemId)
	{
		List<string> gift = _payload.Stage[_currentTab].Gift;
		if (gift != null && gift.Count > 0 && storeItemId == gift[0])
		{
			RefreshGiftBag();
			_parentPanel.PushGiftBagOnClose = true;
		}
	}

	private void OnMissionCompleted(Mission mission)
	{
		_parentPanel.RefreshShadowDemonActivityTab();
		RefreshAchievements();
	}

	private void OnOtherUiClosed(string uiName)
	{
		RefreshAchievements();
		RefreshUnlockState();
	}

	private void OnClickChangeTab(EventContext context)
	{
		if (!_isAnimating)
		{
			int selectedIndex = TabPage.selectedIndex;
			if (selectedIndex != _currentTab)
			{
				_currentTab = selectedIndex;
				RefreshPage();
			}
		}
	}

	private void OnClickBuyGiftBag()
	{
		List<string> gift = _payload.Stage[_currentTab].Gift;
		if (gift != null && gift.Count > 0)
		{
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, gift[0]);
			ProductLocalInfo value = null;
			if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(storeItem.ReferenceId))
			{
				PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value);
			}
			PurchaseManager.Instance.InvokePurchase(storeItem, value, 1, (Action)null, doubleCheck: true);
		}
	}

	private void RefreshAchievements()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		List<Mission> list = _missionsByTab[_currentTab];
		AchievementList.itemRenderer = new ListItemRenderer(RenderMissionSlot);
		AchievementList.numItems = list.Count;
		((GObject)unlockCoundition).text = $"ShadowDemonGiftUnlockTip{_currentTab}".ToLanguage();
		RefreshTabNote();
	}

	public void RefreshUnlockState()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		List<Mission> viewModels = _missionsByTab[_currentTab];
		StageConfig stageConfig = _payload.Stage[_currentTab];
		bool flag = stageConfig.IsUnlocked();
		bool flag2 = UnityUiService.Instance.IsOnTop(UI_ActivityPanel.Name);
		if (!(flag2 & (_parentPanel.PageController.selectedIndex == 19)))
		{
			return;
		}
		if (flag && stageConfig.AnimSignal)
		{
			stageConfig.AnimSignal = false;
			isLocked.SetSelectedIndex(1);
			unlock.Play((PlayCompleteCallback)delegate
			{
				//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c9: Expected O, but got Unknown
				if (!((GObject)this).isDisposed)
				{
					unlock.PlayReverse();
					unlock.Stop(true, false);
					lockMask.unlock.PlayReverse();
					lockMask.unlock.Stop(true, false);
					n66.unlock.PlayReverse();
					n66.unlock.Stop(true, false);
					isLocked.SetSelectedIndex(0);
					AchievementList.itemRenderer = new ListItemRenderer(RenderMissionSlot);
					AchievementList.numItems = viewModels.Count;
					RefreshTabNote();
				}
			});
		}
		else
		{
			bool flag3 = !flag;
			isLocked.SetSelectedIndex(flag3 ? 1 : 0);
		}
	}

	private void RefreshTabNote()
	{
		for (int i = 0; i < _tabs.Count; i++)
		{
			UI_tab_01 uI_tab_ = _tabs[i];
			StageConfig stageConfig = _payload.Stage[i];
			((GObject)uI_tab_.note).visible = stageConfig.HasAnyMessage();
		}
	}

	private void RenderMissionSlot(int index, GObject item)
	{
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		List<Mission> list = _missionsByTab[_currentTab];
		bool isCurrentMissionLocked = isLocked.selectedIndex == 1;
		UI_com_missionSlot button = (UI_com_missionSlot)(object)item;
		Mission mission = list[index];
		((GObject)button.title).text = mission.Data.Desc;
		((GObject)button.num).text = $"{mission.CurrentValue(GameManagers.Instance)}/{mission.TargetValue(GameManagers.Instance)}";
		Controller status = button.status;
		if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Undergoing)
		{
			status.selectedIndex = 0;
		}
		if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Completed)
		{
			status.selectedIndex = 1;
		}
		if (mission.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed)
		{
			status.selectedIndex = 2;
		}
		if (mission.BonusList == null || mission.BonusList.Count <= 0)
		{
			return;
		}
		KeyValuePair<string, string> keyValuePair = mission.DisplayBonus.First();
		string itemId = keyValuePair.Key;
		string value = keyValuePair.Value;
		((GObject)button.rewardNum).text = value;
		button.rewardIcon.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		((GObject)button.rewardIcon).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			x.StopPropagation();
			if (button.status.selectedIndex == 1 && !isCurrentMissionLocked)
			{
				GetReward(mission);
			}
			else
			{
				FGUIManager.Instance.ItemTip(itemId, 2);
			}
		});
		((GObject)button.gotoBtn).data = mission;
		((GObject)button).onClick.Set((EventCallback1)delegate
		{
			if (button.status.selectedIndex == 1)
			{
				if (isCurrentMissionLocked)
				{
					"ShadowDemonMissionLockedTip".ToLanguage().ToTip();
				}
				else
				{
					GetReward(mission);
				}
			}
		});
		((GObject)button.gotoBtn).onClick.Set((EventCallback1)delegate(EventContext context)
		{
			context.StopPropagation();
			UI_ActivityPanel.GoToRelativeUi(mission, (GObject)(object)this);
		});
	}

	private void GetReward(Mission mission)
	{
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
		ILRequestHelper<MissionClaimResponse>.Request((EventContext)null, (Func<Task<MissionClaimResponse>>)(() => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id)), (Action<MissionClaimResponse>)delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
				foreach (ModelsBonus bonus2 in response.BonusList)
				{
					Bonus bonus = Bonus.Get(bonus2.ItemId, bonus2.Qty, bonus2.Type, bonus2.IsShining);
					bonus.Claim(GameManagers.Instance);
				}
				if (!((GObject)_parentPanel).isDisposed && response.BonusList.Count > 0)
				{
					RefreshAchievements();
					_parentPanel.RefreshShadowDemonActivityTab();
					_parentPanel.UpdateMoneyAndGemNum(response.BonusList);
				}
			}
		});
	}

	public void OnDestroy()
	{
		GameManagers.Instance.Messenger.RemoveListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OrderShipSuccessEvent);
		SharedMessenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionCompleted);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnOtherUiClosed);
	}
}

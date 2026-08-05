using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Helpers;
using UnityEngine;

namespace UI.GvGRandomEvent3;

public class UI_main_GvG3EventNpcDialog : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_NpcDialog PopUp;

	public UI_com_OuterTechTelecomFinishPopup Confirm;

	public const string URL = "ui://p4ocf6q0dc6m1";

	public static string Name = "UI_main_GvG3EventNpcDialog";

	private IIslandEvent _npcDialog;

	private Coroutine _updateCountdown;

	private List<KeyValuePair<string, int>> _bonusList;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private bool _rpcMode = false;

	private int _rpcMaxTimes;

	private int _rpcRemainingTimes;

	private Action _onFinishDialog;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m1";
	}

	public static UI_main_GvG3EventNpcDialog CreateInstance()
	{
		return (UI_main_GvG3EventNpcDialog)(object)UIPackage.CreateObject("GvGRandomEvent3", "main_GvG3EventNpcDialog");
	}

	public static UI_main_GvG3EventNpcDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3EventNpcDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_NpcDialog)(object)((GComponent)this).GetChild("PopUp");
		Confirm = (UI_com_OuterTechTelecomFinishPopup)(object)((GComponent)this).GetChild("Confirm");
	}

	public void BeforeDestroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_npcDialog = (parameters.TryGetValue("IIslandEvent", out var value) ? (value as IIslandEvent) : null);
		_onFinishDialog = (parameters.TryGetValue("OnFinishDialog", out var value2) ? ((Action)value2) : null);
		_rpcMode = parameters.TryGetValue("RpcMode", out var value3) && (bool)value3;
		ReadEventBonusAndSetPopupDisplayStyle(_npcDialog?.EventConfig);
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(Render);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdateNcpDialog = (Action)Delegate.Combine(instance.UpdateNcpDialog, new Action(Render));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.TakeBonus).onClick.Set(new EventCallback0(OnClickTakeBonus));
		((GObject)Confirm.Dialog.Confirm).onClick.Set(new EventCallback0(ConfirmUseRpc));
		((GObject)Confirm.Dialog.Cancel).onClick.Set(new EventCallback0(CancelUseRpc));
		SharedMessenger.AddListener<int>("ON_GVG3_OUTTERTECH_RESET", UpdateOuterTechBuffs);
	}

	public void UnregisterUiEventListeners()
	{
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdateNcpDialog = (Action)Delegate.Remove(instance.UpdateNcpDialog, new Action(Render));
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.TakeBonus).onClick.Clear();
		((GObject)Confirm.Dialog.Confirm).onClick.Clear();
		((GObject)Confirm.Dialog.Cancel).onClick.Clear();
		SharedMessenger.RemoveListener<int>("ON_GVG3_OUTTERTECH_RESET", UpdateOuterTechBuffs);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void ReadEventBonusAndSetPopupDisplayStyle(GvGMode3EventMissionConfigModel eventConfig)
	{
		_bonusList = eventConfig?.ShowBonus?.ToList();
		PopUp.RewardDisplayController.SetSelectedIndex((_bonusList == null) ? 1 : 0);
	}

	private void Render()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		Render远程通信();
		GvGMode3EventMissionConfigModel eventConfig = _npcDialog.EventConfig;
		((GObject)PopUp.EventName).text = eventConfig.NameLevelTwo;
		((GObject)PopUp.NpcText).text = eventConfig.NpcDialogText1;
		((GObject)PopUp.EventDesc.EventDesc).text = eventConfig.DescLevelTwo;
		PopUp.NpcIcon.url = eventConfig.NpcIconUrl;
		if (_bonusList != null)
		{
			PopUp.Status.selectedIndex = (_npcDialog.HasClaimed ? 1 : 0);
			PopUp.Bonus.itemRenderer = new ListItemRenderer(BonusItemRenderer);
			PopUp.Bonus.numItems = _bonusList.Count;
			if (eventConfig.Cost != null)
			{
				string costItemId = eventConfig.Cost.Keys.ToList()[0];
				int num = eventConfig.Cost.Values.ToList()[0];
				FGUIManager.Instance.SetItemIconAndFrame(PopUp.CostIcon, costItemId, null, "", frameVisible: false);
				int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(costItemId, includingGSStock: true);
				((GObject)PopUp.CostNumber).text = $"{itemCount.ShortNumberFormat()}/{num}";
				((GObject)PopUp.n11).visible = true;
				bool flag = itemCount >= num;
				PopUp.TextColor.SetSelectedIndex((!flag) ? 1 : 0);
				((GObject)PopUp.TakeBonus).enabled = flag;
				((GObject)PopUp.CostIcon).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(costItemId, 1, noCheckBtn: true);
				});
			}
			else
			{
				((GObject)PopUp.TakeBonus).enabled = true;
				((GObject)PopUp.n11).visible = false;
			}
		}
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
		_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
		void BonusItemRenderer(int index, GObject obj)
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			if (obj is UI_com_Bonus2 uI_com_Bonus)
			{
				KeyValuePair<string, int> bonus = _bonusList[index];
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Bonus.ItemIcon, bonus.Key);
				((GObject)uI_com_Bonus.Count).text = bonus.Value.ToString();
				((GObject)uI_com_Bonus).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(bonus.Key, 1, noCheckBtn: true);
				});
			}
		}
		IEnumerator RefreshCountdown()
		{
			while (!((GObject)this).isDisposed)
			{
				int currentTime = CurrentTimestamp;
				bool valid = _npcDialog.StillValid(currentTime);
				int remainingTime = _npcDialog.RemainingTime(currentTime);
				bool hasCountdown = valid && remainingTime > 0;
				PopUp.HasLimitedTime.selectedIndex = (hasCountdown ? 1 : 0);
				if (hasCountdown)
				{
					((GObject)PopUp.Countdown).text = UiHelper.ParseTimeShort(remainingTime);
				}
				yield return _perSecond;
			}
		}
	}

	private void OnClickTakeBonus()
	{
		if (_rpcMode)
		{
			if (_rpcRemainingTimes < 1)
			{
				"GVG3CardI67510UseUpTip".ToLanguage().ToTip();
				return;
			}
			if (!GameLocalDataManager.GetUseRpcTipDontShowAgainByIzId_Dialog(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId.ToString()))
			{
				((GComponent)Confirm.Dialog.CheckBox).GetController("button").SetSelectedIndex(0);
				((GObject)Confirm.Dialog.AvailableCount).text = $"[color=#aef224]{_rpcRemainingTimes}/[/color]{_rpcMaxTimes}";
				((GObject)Confirm).visible = true;
				Confirm.showTip.Play();
				return;
			}
		}
		FinishNpcDialog();
	}

	private void ConfirmUseRpc()
	{
		((GObject)Confirm).visible = false;
		if (((GComponent)Confirm.Dialog.CheckBox).GetController("button").selectedIndex == 1)
		{
			GameLocalDataManager.MarkUseRpcTipDontShowAgainByIzId_Dialog(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId.ToString());
		}
		FinishNpcDialog();
	}

	private void CancelUseRpc()
	{
		((GObject)Confirm).visible = false;
	}

	private void FinishNpcDialog()
	{
		Singleton<GvG3EventMissionManager>.Instance.FinishNpcDialog(_npcDialog.MUID, OnFinishNpcDialog);
	}

	private void OnFinishNpcDialog()
	{
		switch (_npcDialog.EventType)
		{
		case eIslandEvent.TreasureMap_NPCDialog:
			End();
			break;
		case eIslandEvent.RandomEvent_NPCDialog:
			_npcDialog.HasClaimed = true;
			PopUp.Status.selectedIndex = (_npcDialog.HasClaimed ? 1 : 0);
			_onFinishDialog?.Invoke();
			break;
		}
	}

	private void UpdateOuterTechBuffs(int eOuterTechName)
	{
		if (eOuterTechName == 510 && _rpcMode)
		{
			_rpcRemainingTimes = OuterTechHelper.GetTechState().o远程通信_LimitTime;
			((GObject)PopUp.RpcTip.ResRemain).text = $"{_rpcRemainingTimes}";
		}
	}

	private void Render远程通信()
	{
		if (_rpcMode)
		{
			PopUp.hasOuterTech.selectedIndex = 1;
			((GObject)PopUp.RpcTip).visible = true;
			TechData techData = "I67510".GetTechData();
			_rpcRemainingTimes = OuterTechHelper.GetTechState().o远程通信_LimitTime;
			_rpcMaxTimes = ((TechType1_Parser)techData.TechEffectParser).GetX(techData.Level);
			((GObject)PopUp.RpcTip.ResRemain).text = $"{_rpcRemainingTimes}";
			((GObject)PopUp.RpcTip.ResTotal).text = $"{_rpcMaxTimes}";
		}
	}
}

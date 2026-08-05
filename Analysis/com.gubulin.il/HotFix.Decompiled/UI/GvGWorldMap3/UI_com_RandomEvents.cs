using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.GvGRandomEvent3;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_RandomEvents : GComponent, IFairyComponent
{
	public Controller HasEvent;

	public UI_com_RandomEvent EventCard;

	public GList Bubbles;

	public const string URL = "ui://4eq8fgd2mon486";

	public static string Name = "UI_com_RandomEvents";

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private readonly List<IIslandEvent> _islandEvents = new List<IIslandEvent>();

	private int _checkEventIndex;

	private bool _rpcMode;

	public Action CloseIslandDetailUi = delegate
	{
	};

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://4eq8fgd2mon486";
	}

	public static UI_com_RandomEvents CreateInstance()
	{
		return (UI_com_RandomEvents)(object)UIPackage.CreateObject("GvGWorldMap3", "com_RandomEvents");
	}

	public static UI_com_RandomEvents CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RandomEvents).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mon486", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasEvent = ((GComponent)this).GetController("HasEvent");
		EventCard = (UI_com_RandomEvent)(object)((GComponent)this).GetChild("EventCard");
		Bubbles = (GList)((GComponent)this).GetChild("Bubbles");
	}

	public void Destroy()
	{
		_islandEvents.Clear();
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		Bubbles.itemRenderer = new ListItemRenderer(BubbleRenderer);
	}

	public void RegisterUiEvent()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdateIslandEvents = (Action<List<IIslandEvent>>)Delegate.Combine(instance.UpdateIslandEvents, new Action<List<IIslandEvent>>(Render));
		((GObject)EventCard.DestroyEvent).onClick.Set(new EventCallback0(CancelTreasureMapMission));
	}

	public void UnregisterUiEvent()
	{
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdateIslandEvents = (Action<List<IIslandEvent>>)Delegate.Remove(instance.UpdateIslandEvents, new Action<List<IIslandEvent>>(Render));
		((GObject)EventCard.DestroyEvent).onClick.Clear();
	}

	private void Render(List<IIslandEvent> events)
	{
		if (events.Count <= 0)
		{
			HasEvent.selectedIndex = 0;
			return;
		}
		_islandEvents.Clear();
		_islandEvents.AddRange(events);
		HasEvent.selectedIndex = 1;
		RenderBubbles();
		RenderEventCard(_islandEvents[0]);
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
		_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
		IEnumerator RefreshCountdown()
		{
			while (!((GObject)this).isDisposed)
			{
				int currentTime = CurrentTimestamp;
				for (int i = 0; i < Bubbles.numItems; i++)
				{
					GObject childAt = ((GComponent)Bubbles).GetChildAt(i);
					if (childAt is UI_com_RandomEventBubble bubbleUi)
					{
						IIslandEvent islandEvent = _islandEvents[i];
						if (islandEvent.StillValid(currentTime))
						{
							int remainingTime = islandEvent.RemainingTime(currentTime);
							bool bubbleHasCountdown = remainingTime >= 0;
							bubbleUi.HasCountdown.selectedIndex = (bubbleHasCountdown ? 1 : 0);
							if (bubbleHasCountdown)
							{
								((GObject)bubbleUi.Countdown).text = UiHelper.ParseTimeShort(remainingTime);
							}
						}
					}
				}
				IIslandEvent checkIslandEvent = _islandEvents[_checkEventIndex];
				bool valid = checkIslandEvent.StillValid(currentTime);
				int remainingTime2 = checkIslandEvent.RemainingTime(currentTime);
				bool hasCountdown = valid && remainingTime2 > 0;
				EventCard.HasCountdown.selectedIndex = (hasCountdown ? 1 : 0);
				if (hasCountdown)
				{
					((GObject)EventCard.Countdown).text = UiHelper.ParseTimeShort(remainingTime2);
					EventCard.TimerColor.SetSelectedIndex((remainingTime2 < 3600) ? 1 : 0);
				}
				yield return _perSecond;
			}
		}
	}

	private void RenderBubbles()
	{
		_checkEventIndex = 0;
		Bubbles.selectedIndex = _checkEventIndex;
		Bubbles.numItems = _islandEvents.Count;
		Bubbles.ResizeToFit(_islandEvents.Count);
	}

	private void BubbleRenderer(int index, GObject obj)
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		if (obj is UI_com_RandomEventBubble uI_com_RandomEventBubble)
		{
			IIslandEvent islandEvent = _islandEvents[index];
			((GObject)uI_com_RandomEventBubble.Countdown).text = string.Empty;
			switch (islandEvent.EventType)
			{
			case eIslandEvent.TreasureMap_FindIslandBase:
				uI_com_RandomEventBubble.EventType.selectedIndex = 0;
				uI_com_RandomEventBubble.SmallIcontype.selectedIndex = 0;
				break;
			case eIslandEvent.TreasureMap_Base:
				uI_com_RandomEventBubble.EventType.selectedIndex = 0;
				uI_com_RandomEventBubble.SmallIcontype.selectedIndex = 2;
				break;
			case eIslandEvent.TreasureMap_Collecting:
				uI_com_RandomEventBubble.EventType.selectedIndex = 0;
				uI_com_RandomEventBubble.SmallIcontype.selectedIndex = 1;
				break;
			case eIslandEvent.TreasureMap_NPCDialog:
				uI_com_RandomEventBubble.EventType.selectedIndex = 0;
				uI_com_RandomEventBubble.SmallIcontype.selectedIndex = 3;
				break;
			case eIslandEvent.TreasureMap_NPCShop:
				uI_com_RandomEventBubble.EventType.selectedIndex = 0;
				uI_com_RandomEventBubble.SmallIcontype.selectedIndex = 4;
				break;
			case eIslandEvent.RandomEvent_Battle:
				uI_com_RandomEventBubble.EventType.selectedIndex = 1;
				break;
			case eIslandEvent.RandomEvent_Collecting:
				uI_com_RandomEventBubble.EventType.selectedIndex = 2;
				break;
			case eIslandEvent.RandomEvent_NPCDialog:
				uI_com_RandomEventBubble.EventType.selectedIndex = 3;
				break;
			case eIslandEvent.RandomEvent_NPCShop:
				uI_com_RandomEventBubble.EventType.selectedIndex = 4;
				break;
			case eIslandEvent.TreasureMap_FindIsland:
				uI_com_RandomEventBubble.EventType.selectedIndex = 5;
				break;
			case eIslandEvent.RandomEvent_BossEvent:
			case eIslandEvent.RandomEvent_NPCEvent:
				uI_com_RandomEventBubble.EventType.selectedIndex = 1;
				break;
			}
			if (uI_com_RandomEventBubble.EventType.selectedIndex != 0)
			{
				uI_com_RandomEventBubble.Icon.url = islandEvent.EventConfig.IconUrl;
			}
			((GObject)uI_com_RandomEventBubble).data = index;
			((GObject)uI_com_RandomEventBubble).onClick.Set(new EventCallback1(CheckBubble));
		}
	}

	private void CheckBubble(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		_checkEventIndex = (int)((GObject)context.sender).data;
		IIslandEvent islandEvent = _islandEvents[_checkEventIndex];
		RenderEventCard(islandEvent);
	}

	private void RenderEventCard(IIslandEvent islandEvent)
	{
		GvGMode3EventMissionConfigModel eventConfig = islandEvent.EventConfig;
		((GObject)EventCard.EventName).text = eventConfig.NameLevelOne;
		((GObject)EventCard.EventDesc.EventDesc).text = eventConfig.DescLevelOne;
		bool flag = eventConfig.ShowBonus != null && eventConfig.ShowBonus.Count > 0;
		EventCard.HasBonus.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			RenderBonus();
		}
		int currentTimestamp = CurrentTimestamp;
		bool flag2 = islandEvent.StillValid(currentTimestamp);
		int num = islandEvent.RemainingTime(currentTimestamp);
		bool flag3 = flag2 && num > 0;
		EventCard.HasCountdown.selectedIndex = (flag3 ? 1 : 0);
		GGroup val = (flag ? EventCard.n5 : EventCard.n18);
		((GObject)EventCard.EventDesc).height = ((GObject)val).y - ((GObject)EventCard.EventDesc).y - 18f;
		((GComponent)EventCard.EventDesc).scrollPane.ScrollTop();
		RenderActionButton();
		EventCard.AllowDestruction.selectedIndex = ((islandEvent.EventType == eIslandEvent.TreasureMap_Base) ? 1 : 0);
		void CheckNpcDialog()
		{
			if (!ShowClickTip())
			{
				Action value = delegate
				{
					if (!((GObject)this).isDisposed)
					{
						EventCard.ButtonStatus.selectedIndex = 2;
					}
				};
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3EventNpcDialog.Name, new Dictionary<string, object>
				{
					{ "IIslandEvent", islandEvent },
					{ "OnFinishDialog", value },
					{ "RpcMode", _rpcMode }
				});
			}
		}
		void CheckNpcShop()
		{
			if (!ShowClickTip())
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3EventNpcShop.Name, new Dictionary<string, object>
				{
					{ "IIslandEvent", islandEvent },
					{ "RpcMode", _rpcMode }
				});
			}
		}
		void ClaimMission()
		{
			if (!ShowClickTip())
			{
				Singleton<GvG3EventMissionManager>.Instance.ClaimMission(islandEvent.MUID);
			}
		}
		void IslandLocation()
		{
			if (!ShowClickTip() && islandEvent is IEvent_TreasureMap_FindIslandBase event_TreasureMap_FindIslandBase)
			{
				GvGWorldMapController.Instance.FocusIslandById(event_TreasureMap_FindIslandBase.FindIslandId);
				CloseIslandDetailUi?.Invoke();
			}
		}
		void RenderActionButton()
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			_rpcMode = false;
			eIslandEvent eventType = islandEvent.EventType;
			if (eventType == eIslandEvent.TreasureMap_Collecting || eventType == eIslandEvent.RandomEvent_Battle || eventType == eIslandEvent.RandomEvent_Collecting || eventType == eIslandEvent.TreasureMap_FindIsland || eventType == eIslandEvent.RandomEvent_BossEvent || eventType == eIslandEvent.RandomEvent_NPCEvent)
			{
				EventCard.ButtonStatus.selectedIndex = 4;
			}
			else
			{
				bool flag4 = false;
				bool flag5 = false;
				GLoader actionButton = EventCard.ActionButton;
				switch (eventType)
				{
				case eIslandEvent.TreasureMap_Base:
					actionButton.url = "ui://4eq8fgd2dc6m8b";
					((GObject)actionButton).onClick.Set(new EventCallback0(ClaimMission));
					break;
				case eIslandEvent.TreasureMap_NPCDialog:
				case eIslandEvent.RandomEvent_NPCDialog:
					actionButton.url = "ui://4eq8fgd2dc6m8c";
					((GObject)actionButton).onClick.Set(new EventCallback0(CheckNpcDialog));
					flag4 = true;
					break;
				case eIslandEvent.TreasureMap_NPCShop:
				case eIslandEvent.RandomEvent_NPCShop:
					actionButton.url = "ui://4eq8fgd2dc6m8d";
					((GObject)actionButton).onClick.Set(new EventCallback0(CheckNpcShop));
					flag5 = true;
					break;
				case eIslandEvent.TreasureMap_FindIslandBase:
					actionButton.url = "ui://4eq8fgd2dc6m8e";
					((GObject)actionButton).onClick.Set(new EventCallback0(IslandLocation));
					break;
				}
				if (flag4 && islandEvent.HasClaimed && islandEvent.EventConfig.MissionBonus != null)
				{
					EventCard.ButtonStatus.selectedIndex = 2;
				}
				else
				{
					int currentIslandId = Singleton<GvG3EventMissionManager>.Instance.CurrentIslandId;
					IslandStateModel islandState = Singleton<WorldStateManager>.Instance.TryGetIsland(currentIslandId);
					if (islandState.GetBelongStatus() != eGvGMode3IslandBelongStatus.OwnSide)
					{
						EventCard.ButtonStatus.selectedIndex = 0;
					}
					else
					{
						string shipIdStaySomeIsland = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipIdStaySomeIsland(currentIslandId);
						GButton asButton = ((GObject)actionButton.component).asButton;
						if (string.IsNullOrEmpty(shipIdStaySomeIsland))
						{
							if (!(flag4 || flag5))
							{
								EventCard.ButtonStatus.selectedIndex = 1;
								return;
							}
							if (!OuterTechHelper.IsO远程通信Active())
							{
								((GComponent)asButton).GetController("hasOuterTech").selectedIndex = 0;
								EventCard.ButtonStatus.selectedIndex = 1;
								return;
							}
							((GComponent)asButton).GetController("hasOuterTech").selectedIndex = 1;
							_rpcMode = true;
						}
						EventCard.ButtonStatus.selectedIndex = 3;
					}
				}
			}
		}
		void RenderBonus()
		{
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			KeyValuePair<string, int> bigBonus = eventConfig.FirstShowBonus;
			BigBonusItemRenderer((GObject)(object)EventCard.BIgBonus);
			List<KeyValuePair<string, int>> bonusList = eventConfig.GetShowBonusList();
			EventCard.Bonus.itemRenderer = new ListItemRenderer(BonusItemRenderer);
			EventCard.Bonus.numItems = bonusList.Count;
			void BigBonusItemRenderer(GObject obj)
			{
				//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected O, but got Unknown
				if (obj is UI_com_BigBonus uI_com_BigBonus && !(bigBonus.Key == string.Empty))
				{
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_BigBonus.ItemIcon, bigBonus.Key, null, "", frameVisible: false);
					((GObject)uI_com_BigBonus.Count).text = bigBonus.Value.ToString();
					((GObject)uI_com_BigBonus).data = bigBonus.Key;
					((GObject)uI_com_BigBonus).onClick.Set(new EventCallback1(DisplayItemTip));
				}
			}
			void BonusItemRenderer(int index, GObject obj)
			{
				//IL_0087: Unknown result type (might be due to invalid IL or missing references)
				//IL_0091: Expected O, but got Unknown
				if (obj is UI_com_Bonus uI_com_Bonus)
				{
					KeyValuePair<string, int> keyValuePair = bonusList[index];
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_Bonus.ItemIcon, keyValuePair.Key);
					((GObject)uI_com_Bonus.Count).text = keyValuePair.Value.ToString();
					((GObject)uI_com_Bonus).data = keyValuePair.Key;
					((GObject)uI_com_Bonus).onClick.Set(new EventCallback1(DisplayItemTip));
				}
			}
		}
		bool ShowClickTip()
		{
			if (EventCard.ButtonStatus.selectedIndex == 0)
			{
				ILRequestHelper.ShowMessage(((GObject)EventCard.IslandTip).text);
				return true;
			}
			if (EventCard.ButtonStatus.selectedIndex == 1)
			{
				ILRequestHelper.ShowMessage(((GObject)EventCard.ShipTip).text);
				return true;
			}
			return false;
		}
	}

	private void DisplayItemTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		itemId.DisplayItemTip();
	}

	private void CancelTreasureMapMission()
	{
		"GvG3CancelTreasureMapMissionTip".ToLanguage().ToConfirmPopup(OnConfirmClick, null, (AlignType)0, 40, mirrorBtns: true);
		static void OnConfirmClick()
		{
			Singleton<GvG3EventMissionManager>.Instance.CancelTreasureMapMission();
		}
	}
}

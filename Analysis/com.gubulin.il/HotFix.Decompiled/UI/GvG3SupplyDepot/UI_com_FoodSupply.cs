using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.SupplyDepot;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvG3SupplyDepot;

public class UI_com_FoodSupply : GComponent, IFairyComponent
{
	public UI_com_FoodSupplyShipList Ships;

	public UI_com_FoodStore Store;

	public GTextField n3;

	public const string URL = "ui://pobej4q7uado4";

	public static string Name = "UI_com_FoodSupply";

	public int FlagShipMaxFood;

	private int _shipMaxFood;

	public int TweenCount;

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private TechData _techData_旗舰特权;

	private FoodSupplyCallbackQueue _callbackQueue;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://pobej4q7uado4";
	}

	public static UI_com_FoodSupply CreateInstance()
	{
		return (UI_com_FoodSupply)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_FoodSupply");
	}

	public static UI_com_FoodSupply CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FoodSupply).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uado4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Ships = (UI_com_FoodSupplyShipList)(object)((GComponent)this).GetChild("Ships");
		Store = (UI_com_FoodStore)(object)((GComponent)this).GetChild("Store");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://pobej4q7uado4".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}

	public void Destroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init()
	{
		_callbackQueue = new FoodSupplyCallbackQueue(this);
		Singleton<GvG3SupplyDepotManager>.Instance.GetFoodDailySupplyInfo(Renderer);
	}

	public void RegisterUiEvent()
	{
	}

	public void UnregisterUiEvent()
	{
	}

	private void Renderer(C2S_GetFoodDailySupplyInfo.Response response)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		FlagShipMaxFood = response.FlagShipMaxFood;
		_shipMaxFood = response.ShipMaxFood;
		((GProgressBar)Store.Food).value = (double)response.FlagShipCurFood / (double)response.FlagShipMaxFood * 100.0;
		((GObject)Store.Food.FoodNumber).text = $"{response.FlagShipCurFood}/{response.FlagShipMaxFood}";
		List<KeyValuePair<string, int>> shipFoods = response.CurShipFood.ToList();
		Ships.Ships.itemRenderer = new ListItemRenderer(ShipFoodRenderer);
		Ships.Ships.numItems = shipFoods.Count;
		UpdateCountdown();
		_techData_旗舰特权 = "I67411".GetTechData();
		if (_techData_旗舰特权.Level > 0)
		{
			((GObject)Store.Food.BuffsTip).visible = true;
			((GObject)Store.Food.BuffsTip).onClick.Set(new EventCallback1(ShowFlagShipSupplyBuff));
		}
		else
		{
			((GObject)Store.Food.BuffsTip).visible = false;
		}
		void ShipFoodRenderer(int index, GObject obj)
		{
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Expected O, but got Unknown
			if (obj is UI_com_ShipFood uI_com_ShipFood)
			{
				KeyValuePair<string, int> keyValuePair = shipFoods[index];
				int num = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
				((GProgressBar)uI_com_ShipFood.Food).value = (double)keyValuePair.Value / (double)num * 100.0;
				((GObject)uI_com_ShipFood.Food.FoodNumber).text = $"{keyValuePair.Value}/{num}";
				((GObject)uI_com_ShipFood.ShipName).text = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(keyValuePair.Key);
				uI_com_ShipFood.ShipIcon.url = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipRaceIcon(keyValuePair.Key);
				if (keyValuePair.Value >= num)
				{
					uI_com_ShipFood.ShipFoodStatus.selectedIndex = 2;
				}
				else if (keyValuePair.Value <= 0)
				{
					uI_com_ShipFood.ShipFoodStatus.selectedIndex = 1;
				}
				else
				{
					uI_com_ShipFood.ShipFoodStatus.selectedIndex = 0;
				}
				uI_com_ShipFood.Food.ShipFoodStatus.selectedIndex = uI_com_ShipFood.ShipFoodStatus.selectedIndex;
				((GObject)uI_com_ShipFood.Increase).data = keyValuePair.Key;
				((GObject)uI_com_ShipFood.Increase).onClick.Set(new EventCallback1(SupplyToShip));
			}
		}
	}

	public void UpdateUi(C2S_GiveFoodDailySupplyToShip.Response response, string shipId)
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		((GProgressBar)Store.Food).value = (double)response.FlagShipCur / (double)FlagShipMaxFood * 100.0;
		((GObject)Store.Food.FoodNumber).text = $"{response.FlagShipCur}/{FlagShipMaxFood}";
		for (int i = 0; i < Ships.Ships.numItems; i++)
		{
			if (((GComponent)Ships.Ships).GetChildAt(i) is UI_com_ShipFood uI_com_ShipFood && !(((GObject)uI_com_ShipFood.Increase).data.ToString() != shipId))
			{
				int num = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
				((GProgressBar)uI_com_ShipFood.Food).value = (double)response.ShipCur / (double)num * 100.0;
				((GObject)uI_com_ShipFood.Food.FoodNumber).text = $"{response.ShipCur}/{num}";
				if (response.ShipCur >= num)
				{
					uI_com_ShipFood.ShipFoodStatus.selectedIndex = 2;
				}
				else if (response.ShipCur <= 0)
				{
					uI_com_ShipFood.ShipFoodStatus.selectedIndex = 1;
				}
				else
				{
					uI_com_ShipFood.ShipFoodStatus.selectedIndex = 0;
				}
				uI_com_ShipFood.Food.ShipFoodStatus.selectedIndex = uI_com_ShipFood.ShipFoodStatus.selectedIndex;
				break;
			}
		}
	}

	private void SupplyToShip(EventContext context)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		string shipId = ((GObject)context.sender).data.ToString();
		Singleton<GvG3SupplyDepotManager>.Instance.GiveFoodDailySupplyToShip(shipId, delegate(C2S_GiveFoodDailySupplyToShip.Response response)
		{
			if (!((GObject)this).isDisposed)
			{
				_callbackQueue.EnqueueCallback(shipId, response);
			}
		});
	}

	private void ShowFlagShipSupplyBuff(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "GvGSupplyBuff_FlagshipPrivilege".ToLanguage(((TechType6_Parser)_techData_旗舰特权.TechEffectParser).GetX(_techData_旗舰特权.Level));
		});
	}

	private void UpdateCountdown()
	{
		DateTimeOffset dateTimeOffset = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0);
		_updateCountdown = FGUIManager.Instance.OpenIEnumerator(UpdateFoodRefreshCountdown(DateTimeHelper.GetTimeStamp(dateTimeOffset)));
	}

	private IEnumerator UpdateFoodRefreshCountdown(int nextDayRefreshTimestamp)
	{
		while (!((GObject)this).isDisposed)
		{
			((GObject)Store.Countdown).text = UiHelper.ParseTimeShort(nextDayRefreshTimestamp - CurrentTimestamp);
			yield return _perSecond;
		}
	}
}

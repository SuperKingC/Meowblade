using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGBattleRecord3;
using UI.GvGIslandBuff;
using UI.PublicResources;

namespace UI.GvGWorldMap3;

public class UI_com_OtherIslandFunctions : GComponent
{
	public Controller HasInsurance;

	public GImage n4;

	public UI_btn_IslandBuff Buff;

	public UI_btn_IslandRecords CheckRecords;

	public UI_btn_IslandPlayers Players;

	public UI_btn_Insurance Insurance;

	public const string URL = "ui://4eq8fgd2h4tpdz";

	public static string Name = "UI_com_OtherIslandFunctions";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpdz";
	}

	public static UI_com_OtherIslandFunctions CreateInstance()
	{
		return (UI_com_OtherIslandFunctions)(object)UIPackage.CreateObject("GvGWorldMap3", "com_OtherIslandFunctions");
	}

	public static UI_com_OtherIslandFunctions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OtherIslandFunctions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpdz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasInsurance = ((GComponent)this).GetController("HasInsurance");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Buff = (UI_btn_IslandBuff)(object)((GComponent)this).GetChild("Buff");
		CheckRecords = (UI_btn_IslandRecords)(object)((GComponent)this).GetChild("CheckRecords");
		Players = (UI_btn_IslandPlayers)(object)((GComponent)this).GetChild("Players");
		Insurance = (UI_btn_Insurance)(object)((GComponent)this).GetChild("Insurance");
	}

	public void OnRender(IslandStateModel islandState)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)Buff).onClick.Set(new EventCallback0(OnCheckIslandBuff));
		((GObject)CheckRecords).onClick.Set(new EventCallback0(CheckIslandBattleRecords));
		((GObject)Players).onClick.Set(new EventCallback0(CheckIslandPlayers));
		((GObject)Insurance).onClick.Set(new EventCallback0(CheckInsurance));
		RenderInsurance();
		void CheckInsurance()
		{
			List<GvGShipDetailModel> list = (from ship in Singleton<WorldStateManager>.Instance.Data.MyShips
				select Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipDetail(ship.ShipId) into ship
				where ship != null
				select ship).ToList();
			string selectedId = Singleton<WorldStateManager>.Instance.Data.InsuranceShipId;
			GvGShipDetailModel gvGShipDetailModel = list.Find((GvGShipDetailModel ship) => ship.ShipId == selectedId);
			GvGInsuranceShip selectedShip = ((gvGShipDetailModel == null) ? null : new GvGInsuranceShip
			{
				ShipId = gvGShipDetailModel.ShipId,
				ShipRace = gvGShipDetailModel.ShipType
			});
			UI_main_InsuranceShip.OpenInsuranceShipPanel(new UI_main_InsuranceShip.InsuranceShipUiParameters
			{
				SelectedShip = selectedShip,
				ShipsDetail = list,
				UiType = 0,
				OnSelected = UpdateInsuranceState
			});
		}
		void CheckIslandBattleRecords()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandBattleRecordPanel.Name, new Dictionary<string, object> { { "IslandId", islandState.IslandId } });
		}
		void CheckIslandPlayers()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandPlayers.Name, new Dictionary<string, object>
			{
				{
					"PlayerInfos",
					islandState.DetailInfo.PlayerInfos
				},
				{
					"HoldingScore",
					islandState.DetailInfo.HoldingScore()
				},
				{
					"IslandState",
					(int)islandState.State
				}
			});
		}
		void OnCheckIslandBuff()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandBuffPanel.Name, new Dictionary<string, object>
			{
				{ "CurIslandId", islandState.IslandId },
				{
					"ParentUIName",
					UI_main_GvGWorldMap3.Name
				}
			});
		}
		void RenderInsurance()
		{
			bool hasBattlePassPaidCert = Singleton<WorldStateManager>.Instance.Data.HasBattlePassPaidCert;
			bool flag = GvG3InsuranceHelper.IsInsuranceIsland(islandState.IslandId);
			bool flag2 = hasBattlePassPaidCert && flag && Define.IsGvGAutomationOpen();
			HasInsurance.SetSelectedIndex(flag2 ? 1 : 0);
			if (hasBattlePassPaidCert)
			{
				UpdateInsuranceState();
			}
		}
		void UpdateInsuranceState()
		{
			string insuranceShipId = Singleton<WorldStateManager>.Instance.Data.InsuranceShipId;
			bool flag = !string.IsNullOrEmpty(insuranceShipId);
			Insurance.State.SetSelectedIndex(flag ? 1 : 0);
			if (flag)
			{
				GvGShipDetailModel myShipDetail = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipDetail(insuranceShipId);
				((UI_com_ShipSmallIcon)(object)Insurance.ShipIcon).SetShipStyle(myShipDetail.ShipType, Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId);
			}
		}
	}
}

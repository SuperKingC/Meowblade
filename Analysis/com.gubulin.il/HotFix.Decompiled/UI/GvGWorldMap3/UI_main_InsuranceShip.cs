using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;

namespace UI.GvGWorldMap3;

public class UI_main_InsuranceShip : GComponent, IUiController
{
	public class InsuranceShipUiParameters
	{
		public int UiType;

		public GvGInsuranceShip SelectedShip;

		public List<GvGShipDetailModel> ShipsDetail;

		public Action OnSelected;
	}

	public GGraph Mask;

	public UI_com_InsuranceShip Dialog;

	public const string URL = "ui://4eq8fgd2eo52b6sdh";

	public static string Name = "UI_main_InsuranceShip";

	private List<GvGShipDetailModel> _ships;

	private GvGInsuranceShip _selectedShip;

	private int _uiType;

	private Action _onSelected;

	private string _initialSelected;

	private const string GVG_INSURANCE_SHIP = "GvGInsuranceShip";

	private const string SHIP_DETAILS = "SHIP_DETAILS";

	private const string UI_TYPE = "UiType";

	private const string ON_SELECTED = "OnSelected";

	private const string GOTO_SET_INSURANCE_SHIP = "GvGMode3GotoSetInsuranceShipTip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2eo52b6sdh";
	}

	public static UI_main_InsuranceShip CreateInstance()
	{
		return (UI_main_InsuranceShip)(object)UIPackage.CreateObject("GvGWorldMap3", "main_InsuranceShip");
	}

	public static UI_main_InsuranceShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_InsuranceShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2eo52b6sdh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_InsuranceShip)(object)((GComponent)this).GetChild("Dialog");
	}

	public static void OpenInsuranceShipPanel(InsuranceShipUiParameters parameters)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
		{
			{ "GvGInsuranceShip", parameters.SelectedShip },
			{ "SHIP_DETAILS", parameters.ShipsDetail },
			{ "UiType", parameters.UiType },
			{ "OnSelected", parameters.OnSelected }
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.SetInsurance.SetInsurance).onClick.Set(new EventCallback0(OpenSelectInsuranceShipPanel));
		((GObject)Dialog.Confirm).onClick.Set(new EventCallback0(ConfirmInsuranceShip));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Dialog.SetInsurance.SetInsurance).onClick.Clear();
		((GObject)Dialog.Confirm).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ReadParameters(parameters);
		RenderSelectedShip(_selectedShip);
	}

	public void OnShow()
	{
		Dialog.Type.SetSelectedIndex(_uiType);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void ReadParameters(Dictionary<string, object> parameters)
	{
		_selectedShip = (GvGInsuranceShip)parameters["GvGInsuranceShip"];
		_initialSelected = _selectedShip?.ShipId;
		_ships = (List<GvGShipDetailModel>)parameters["SHIP_DETAILS"];
		_uiType = (int)parameters["UiType"];
		_onSelected = (Action)parameters["OnSelected"];
	}

	private void RenderSelectedShip(GvGInsuranceShip selected)
	{
		GvGShipDetailModel selected2 = ((selected == null) ? null : _ships.FirstOrDefault((GvGShipDetailModel ship) => ship.ShipId == selected.ShipId));
		RenderShipBaseInfo(selected2);
		RenderShipGroupInfo(selected2);
	}

	private void RenderShipBaseInfo(GvGShipDetailModel selected)
	{
		if (selected == null)
		{
			Dialog.SetInsurance.State.SetSelectedIndex(0);
			return;
		}
		Dialog.SetInsurance.State.SetSelectedIndex(1);
		RenderBase(selected);
		RenderAmplifiers(selected);
	}

	private void RenderBase(GvGShipDetailModel selected)
	{
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(selected.ShipType);
		Dialog.SetInsurance.ShipIcon.url = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
		((GObject)Dialog.SetInsurance.ShipName).text = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipName(selected.ShipId);
	}

	private void RenderAmplifiers(GvGShipDetailModel selected)
	{
		selected.GetShipData(delegate
		{
			List<eAmplifierType> list = new List<eAmplifierType>
			{
				eAmplifierType.Attack,
				eAmplifierType.Health,
				eAmplifierType.Perks
			};
			Dictionary<eAmplifierType, List<int>> dictionary = new Dictionary<eAmplifierType, List<int>>();
			foreach (eAmplifierType item in list)
			{
				dictionary.Add(item, new List<int>());
			}
			Dictionary<int, int> amplifiers = selected.Amplifiers;
			foreach (KeyValuePair<int, int> item2 in amplifiers)
			{
				int key = item2.Key;
				int value = item2.Value;
				AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(key);
				for (int i = 0; i < value; i++)
				{
					dictionary[amplifierModel.Type].Add(key);
				}
			}
			int num = 0;
			foreach (KeyValuePair<eAmplifierType, List<int>> item3 in dictionary)
			{
				num += item3.Value.Count;
			}
			((GObject)Dialog.SetInsurance.Amplifiers).text = $"{num}/{selected.AmplifierCountLimit}";
		});
	}

	private void RenderShipGroupInfo(GvGShipDetailModel selected)
	{
		if (selected != null)
		{
			ShipStateModel shipState = selected.ShipState;
			Dialog.Legions.PreLoadFormations();
			Dialog.Legions.SetOurPos(shipState.FormationId, shipState.CurrentUnitInfos);
		}
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OpenSelectInsuranceShipPanel()
	{
		List<GvGInsuranceShip> list = _ships.Select((GvGShipDetailModel ship) => new GvGInsuranceShip
		{
			ShipId = ship.ShipId,
			ShipRace = ship.ShipType
		}).ToList();
		int selectedIndex = ((_selectedShip != null) ? list.FindIndex((GvGInsuranceShip ship) => ship.ShipId == _selectedShip.ShipId) : 0);
		UI_main_SelectInsuranceShip.OpenSelectInsuranceShipPanel(new UI_main_SelectInsuranceShip.OpenParameters
		{
			SelectedIndex = selectedIndex,
			Ships = list,
			OnSelect = OnSelectShip
		});
	}

	private void OnSelectShip(GvGInsuranceShip selected)
	{
		if (!(_selectedShip?.ShipId == selected.ShipId))
		{
			_selectedShip = selected;
			RenderSelectedShip(selected);
		}
	}

	private void ConfirmInsuranceShip()
	{
		if (_selectedShip == null)
		{
			"GvGMode3GotoSetInsuranceShipTip".ToShowLanguageTip();
			return;
		}
		if (_initialSelected == _selectedShip.ShipId)
		{
			End();
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ChangeInsuranceShipId
		{
			Req = new C2S_ChangeInsuranceShipId.Request
			{
				ShipId = _selectedShip.ShipId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ChangeInsuranceShipId.Response response = (C2S_ChangeInsuranceShipId.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.SyncInsuranceShipId(_selectedShip.ShipId);
				_onSelected?.Invoke();
				End();
			}
		});
	}
}

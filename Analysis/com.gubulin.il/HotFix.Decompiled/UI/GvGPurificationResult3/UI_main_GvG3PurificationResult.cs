using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

namespace UI.GvGPurificationResult3;

public class UI_main_GvG3PurificationResult : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_PurificationResult PopUp;

	public Transition DisplayResult;

	public const string URL = "ui://l9ol6w5fsmdj0";

	public static string Name = "UI_main_GvG3PurificationResult";

	private static bool _waitToDisplay;

	private S2C_Purification.Request _result;

	public static bool WaitToDisplay
	{
		get
		{
			return _waitToDisplay;
		}
		set
		{
			_waitToDisplay = value;
			if (value)
			{
				GObject showingUi = GameController.Contexts.Service<IUiService>().GetShowingUi(Name);
				((UI_main_GvG3PurificationResult)(object)showingUi)?.DisplayPurificationResult();
			}
		}
	}

	public static string GetURL()
	{
		return "ui://l9ol6w5fsmdj0";
	}

	public static UI_main_GvG3PurificationResult CreateInstance()
	{
		return (UI_main_GvG3PurificationResult)(object)UIPackage.CreateObject("GvGPurificationResult3", "main_GvG3PurificationResult");
	}

	public static UI_main_GvG3PurificationResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3PurificationResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l9ol6w5fsmdj0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_PurificationResult)(object)((GComponent)this).GetChild("PopUp");
		DisplayResult = ((GComponent)this).GetTransition("DisplayResult");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_result = parameters.ReadParamTalentFromParameters<S2C_Purification.Request>("PurificationResult");
		Render();
	}

	public void OnShow()
	{
		if (_waitToDisplay)
		{
			DisplayPurificationResult();
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)PopUp.Confirm).onClick.Set(new EventCallback0(Confirm));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)PopUp.Confirm).onClick.Clear();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private static void Confirm()
	{
		End();
	}

	public void DisplayPurificationResult()
	{
		WaitToDisplay = false;
		DisplayResult.Play();
	}

	private void Render()
	{
		if (_result != null)
		{
			PopUp.Status.selectedIndex = (int)_result.GetUiResultState();
			CostRenderer();
			AllPurifiedRenderer();
			NotPurifiedRenderer();
		}
		void AllPurifiedRenderer()
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			if (_result.AllPurified != null && _result.AllPurified.Count > 0)
			{
				PopUp.PurificationList.itemRenderer = new ListItemRenderer(PurificationItemRenderer);
				PopUp.PurificationList.numItems = _result.AllPurified.Count;
			}
		}
		void CostRenderer()
		{
			if (_result.Cost == null || _result.Cost.Count <= 0)
			{
				((GObject)PopUp.CostNum).text = "0";
				PopUp.CostIcon.url = "Money".ToPublicResourceIcon();
			}
			else
			{
				RItem rItem = _result.Cost[0];
				((GObject)PopUp.CostNum).text = rItem.cnt.ToString();
				FGUIManager.Instance.SetItemIconAndFrame(PopUp.CostIcon, rItem.ItemId, null, "", frameVisible: false);
			}
		}
		void NotPurifiedRenderer()
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			if (_result.NotPurified != null && _result.NotPurified.Count > 0)
			{
				PopUp.PollutantList.itemRenderer = new ListItemRenderer(PollutantItemRenderer);
				PopUp.PollutantList.numItems = _result.NotPurified.Count;
			}
		}
		void PollutantItemRenderer(int index, GObject obj)
		{
			if (obj is UI_com_Item uI_com_Item)
			{
				RItem rItem = _result.NotPurified[index];
				((GObject)uI_com_Item.ItemNumber).text = rItem.cnt.ToString();
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Item.ItemIcon, rItem.ItemId, null, "", frameVisible: false);
			}
		}
		void PurificationItemRenderer(int index, GObject obj)
		{
			if (obj is UI_com_Item uI_com_Item)
			{
				RItem rItem = _result.AllPurified[index];
				((GObject)uI_com_Item.ItemNumber).text = rItem.cnt.ToString();
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Item.ItemIcon, rItem.ItemId, null, "", frameVisible: false);
			}
		}
	}
}

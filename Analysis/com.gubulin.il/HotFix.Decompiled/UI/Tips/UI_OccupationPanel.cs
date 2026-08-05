using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.PublicResources;

namespace UI.Tips;

public class UI_OccupationPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__11_0;

		internal void _003CRegisterUiEventListeners_003Eb__11_0()
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		}
	}

	public GGraph Mask;

	public UI_OccupationDialog DialogOccuption;

	public Transition t0;

	public const string URL = "ui://47lbpgx9gsc75ltd8";

	public static string Name = "UI_OccupationPanel";

	private const string ParamOccupation = "_occupation";

	public static string GetURL()
	{
		return "ui://47lbpgx9gsc75ltd8";
	}

	public static UI_OccupationPanel CreateInstance()
	{
		return (UI_OccupationPanel)(object)UIPackage.CreateObject("Tips", "OccupationPanel");
	}

	public static UI_OccupationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OccupationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gsc75ltd8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		DialogOccuption = (UI_OccupationDialog)(object)((GComponent)this).GetChild("DialogOccuption");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public static void Show(SoldierOccupation occupation)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object> { { "_occupation", occupation } });
	}

	public void RegisterUiEventListeners()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		EventListener onClick = ((GObject)Mask).onClick;
		object obj = _003C_003Ec._003C_003E9__11_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				GameController.Contexts.Service<IUiService>().ClosePanel(Name);
			};
			_003C_003Ec._003C_003E9__11_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		SoldierOccupation soldierOccupation = (SoldierOccupation)parameters["_occupation"];
		DialogOccuption.Status.SetSelectedIndex(soldierOccupation.Index);
		DialogOccuption.SetControllerPageText();
		List<Soldier> soldierList = GameManagers.Instance.SoldierManager.GetPlayerSoldiersByOccupation(soldierOccupation);
		DialogOccuption.soldierList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			Soldier curSoldier = soldierList[index];
			UI_RaceInfoPanel.RenderSoldierIconBtn(item, curSoldier);
		};
		DialogOccuption.soldierList.numItems = soldierList.Count;
		((UI_occupationePicture)(object)DialogOccuption.occupationePicture).Type.SetSelectedIndex(soldierOccupation.Index);
		t0.Play();
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}
}

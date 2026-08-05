using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Services;

namespace UI.GvG3MainStorylineQuest;

public class UI_main_IslandDescription : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_02 PopUp;

	public const string URL = "ui://249h3k3daggos48";

	public static string Name = "UI_main_IslandDescription";

	public static string GetURL()
	{
		return "ui://249h3k3daggos48";
	}

	public static UI_main_IslandDescription CreateInstance()
	{
		return (UI_main_IslandDescription)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "main_IslandDescription");
	}

	public static UI_main_IslandDescription CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandDescription).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3daggos48", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_02)(object)((GComponent)this).GetChild("PopUp");
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
		Render((eIslandType)parameters["IslandType"]);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Render(eIslandType islandType)
	{
		PopUp.Type.SetSelectedIndex((int)(islandType - 1));
		((GObject)PopUp.Description).text = $"{islandType}Island_Description".ToLanguage();
		((GObject)PopUp.IncomeOverview).text = $"{islandType}Island_IncomeOverview".ToLanguage();
		((GObject)PopUp.IncomeDetail).text = $"{islandType}Island_IncomeDetail".ToLanguage();
	}
}

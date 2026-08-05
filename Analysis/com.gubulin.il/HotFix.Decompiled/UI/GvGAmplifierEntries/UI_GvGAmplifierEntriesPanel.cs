using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGAmplifierForge;
using UI.GvGAmplifierOnShip;
using UI.GvGAmplifierStorage;

namespace UI.GvGAmplifierEntries;

public class UI_GvGAmplifierEntriesPanel : GComponent, IUiController
{
	public GLoader background;

	public GButton BackBtn;

	public UI_com_Title Title;

	public UI_btn_StorageEntry StorageEntry;

	public UI_btn_ForgeEntry ForgeEntry;

	public GButton HelpBtn;

	public const string URL = "ui://f1wmtifub4va0";

	public static string Name = "UI_GvGAmplifierEntriesPanel";

	public static string GetURL()
	{
		return "ui://f1wmtifub4va0";
	}

	public static UI_GvGAmplifierEntriesPanel CreateInstance()
	{
		return (UI_GvGAmplifierEntriesPanel)(object)UIPackage.CreateObject("GvGAmplifierEntries", "GvGAmplifierEntriesPanel");
	}

	public static UI_GvGAmplifierEntriesPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGAmplifierEntriesPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifub4va0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		StorageEntry = (UI_btn_StorageEntry)(object)((GComponent)this).GetChild("StorageEntry");
		ForgeEntry = (UI_btn_ForgeEntry)(object)((GComponent)this).GetChild("ForgeEntry");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UpdateForgeRedDot(Singleton<GvGAmplifierManager>.Instance.HasNewAmpFormulas);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)StorageEntry).onClick.Add(new EventCallback1(OpenStoratePanel));
		((GObject)ForgeEntry).onClick.Add(new EventCallback1(OpenForgePanel));
		((GObject)HelpBtn).onClick.Add(new EventCallback0(OnClickHelpBtn));
		GvGAmplifierManager instance = Singleton<GvGAmplifierManager>.Instance;
		instance.OnUpdateTotalAmpFormulaRedDot = (Action<bool>)Delegate.Combine(instance.OnUpdateTotalAmpFormulaRedDot, new Action<bool>(UpdateForgeRedDot));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)StorageEntry).onClick.Clear();
		((GObject)ForgeEntry).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		GvGAmplifierManager instance = Singleton<GvGAmplifierManager>.Instance;
		instance.OnUpdateTotalAmpFormulaRedDot = (Action<bool>)Delegate.Remove(instance.OnUpdateTotalAmpFormulaRedDot, new Action<bool>(UpdateForgeRedDot));
	}

	private void OpenStoratePanel(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGAmplifierStoragePanel.Name, null);
	}

	private void OpenForgePanel(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGAmplifierForgePanel.Name, null);
	}

	private void OnClickHelpBtn()
	{
		UiHelper.OpenHelpPage("增幅器入口", "远征相关", "增幅器");
	}

	private void OpenAmplifierOnShipPanel(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGAmplifierOnShipPanel.Name, null);
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

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void UpdateForgeRedDot(bool hasNewAmpFormulas)
	{
		((GObject)ForgeEntry.RedDot).visible = hasNewAmpFormulas;
	}
}

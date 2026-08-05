using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Services;
using UI.PublicResources;

namespace UI.GvGWorldMap3;

public class UI_main_FireSupportConfirmPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_com_FireSupportConfirmDialog Dialog;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2lpif6sci";

	public static string Name = "UI_main_FireSupportConfirmPanel";

	private int CurIslandId;

	public static string GetURL()
	{
		return "ui://4eq8fgd2lpif6sci";
	}

	public static UI_main_FireSupportConfirmPanel CreateInstance()
	{
		return (UI_main_FireSupportConfirmPanel)(object)UIPackage.CreateObject("GvGWorldMap3", "main_FireSupportConfirmPanel");
	}

	public static UI_main_FireSupportConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FireSupportConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2lpif6sci", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_FireSupportConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		CurIslandId = (parameters.TryGetValue("IslandId", out var value) ? ((int)value) : 0);
		Render();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Buff).onClick.Set(new EventCallback0(OnBuffBtn));
		((GObject)Dialog.Confirm).onClick.Set(new EventCallback0(OnClickConfirmBtn));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.Buff).onClick.Clear();
		((GObject)Dialog.Confirm).onClick.Clear();
	}

	private void OnClickConfirmBtn()
	{
		火力支援Helper.UseSkillForIsland(CurIslandId);
		End();
	}

	private void OnBuffBtn()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip((GObject)(object)Dialog.Buff, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = 火力支援Helper.MaxTimeOfUsageModel.GetText();
		});
	}

	private void Render()
	{
		int curTimeOfUsage = 火力支援Helper.CurTimeOfUsage;
		float total = 火力支援Helper.MaxTimeOfUsageModel.Total;
		string text = $"{curTimeOfUsage}/";
		string text2 = $"{total}";
		if (curTimeOfUsage == 0)
		{
			text = $"[color=#ff1a1a]{curTimeOfUsage}/[/color]";
		}
		if (火力支援Helper.MaxTimeOfUsageModel.HasExtra())
		{
			text2 = $"[color=#aef224]{total}[/color]";
		}
		((GObject)Dialog.TimeOfUsage).text = text + text2;
		((GObject)Dialog.Buff).visible = 火力支援Helper.MaxTimeOfUsageModel.HasExtra();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}

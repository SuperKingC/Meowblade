using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.LordOfDreams;

public class UI_GvGBossDetailsPanel : GComponent, IUiController
{
	public GLoader background;

	public GGraph _mask;

	public UI_GvGBossDetailsDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://0i520nzm9h45ocd";

	public static string Name = "UI_GvGBossDetailsPanel";

	private static string ScoreMultiplier = "";

	private static string DeadCnt = "";

	public static string GetURL()
	{
		return "ui://0i520nzm9h45ocd";
	}

	public static UI_GvGBossDetailsPanel CreateInstance()
	{
		return (UI_GvGBossDetailsPanel)(object)UIPackage.CreateObject("LordOfDreams", "GvGBossDetailsPanel");
	}

	public static UI_GvGBossDetailsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossDetailsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm9h45ocd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		Dialog = (UI_GvGBossDetailsDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public static void SetData(float scoreMultiplier, int deadCnt)
	{
		ScoreMultiplier = $"x{scoreMultiplier + 1f}";
		DeadCnt = $"x{deadCnt}";
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)Dialog.WBScoreMultiplier).text = ScoreMultiplier;
		((GObject)Dialog.KillBossTimes).text = DeadCnt;
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
		Popup.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)_mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)_mask).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}

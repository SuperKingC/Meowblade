using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;

namespace UI.PvpSelectSoldiers;

public class UI_PvpHelpPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_HelpDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://82mo10n5jp4vdny";

	public static string Name = "UI_PvpHelpPanel";

	public const string PvpSelectSoldiersPanel = "PvpSelectSoldiers";

	private UI_FirstThree _parent;

	public static string GetURL()
	{
		return "ui://82mo10n5jp4vdny";
	}

	public static UI_PvpHelpPanel CreateInstance()
	{
		return (UI_PvpHelpPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpHelpPanel");
	}

	public static UI_PvpHelpPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpHelpPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5jp4vdny", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_HelpDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Dialog.goToBtn).onClick.Set(new EventCallback1(OnClickGotoBtn));
		((GObject)Mask).onClick.Set(new EventCallback0(OnClickClose));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((GObject)Dialog.goToBtn).onClick.Clear();
		((GObject)Mask).onClick.Set(new EventCallback0(OnClickClose));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		_parent = (UI_FirstThree)parameters["PvpSelectSoldiers"];
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
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

	private void OnClickGotoBtn(EventContext context)
	{
		if (!UI_FirstThree.IsUnlocked())
		{
			"TopTournamentLogLockedTip".ToLanguage().ToTip();
			return;
		}
		UnityUiService.Instance.ClosePanel(Name);
		_parent.OpenTopTournamentBattlePanel();
	}

	private void OnClickClose()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}

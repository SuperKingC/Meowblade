using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;

namespace UI.LegendItemBlueprint;

public class UI_main_ObtainBlueprintPopup : GComponent, IUiController
{
	public GGraph mask;

	public GMovieClip n1;

	public GImage n11;

	public GImage n12;

	public GImage n3;

	public GImage n4;

	public GImage n6;

	public GImage n14;

	public GImage n10;

	public GLoader blueprintIcon;

	public GMovieClip n5;

	public UI_btn_yes confirmBtn;

	public Transition showAnim;

	public const string URL = "ui://h09dvkcgsc145ltf6";

	public static string Name = "UI_main_ObtainBlueprintPopup";

	public const string BlueprintKey = "Blueprint";

	private Blueprint _blueprint;

	public static string GetURL()
	{
		return "ui://h09dvkcgsc145ltf6";
	}

	public static UI_main_ObtainBlueprintPopup CreateInstance()
	{
		return (UI_main_ObtainBlueprintPopup)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_ObtainBlueprintPopup");
	}

	public static UI_main_ObtainBlueprintPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ObtainBlueprintPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgsc145ltf6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n1 = (GMovieClip)((GComponent)this).GetChild("n1");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		blueprintIcon = (GLoader)((GComponent)this).GetChild("blueprintIcon");
		n5 = (GMovieClip)((GComponent)this).GetChild("n5");
		confirmBtn = (UI_btn_yes)(object)((GComponent)this).GetChild("confirmBtn");
		showAnim = ((GComponent)this).GetTransition("showAnim");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)confirmBtn).onClick.Set(new EventCallback0(End));
		((GObject)blueprintIcon).onClick.Set((EventCallback0)delegate
		{
			UnityUiService.Instance.OpenPanel(UI_main_LegendItemBlueprintInfoPanel.Name, new Dictionary<string, object>
			{
				{ "BlueprintData", _blueprint },
				{ "Type", 1 }
			});
		});
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)confirmBtn).onClick.Clear();
		((GObject)blueprintIcon).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_blueprint = (Blueprint)parameters["Blueprint"];
		blueprintIcon.LoadBlueprintIcon(Blueprint.GetIconName(_blueprint.EvoId));
		showAnim.Play();
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

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}

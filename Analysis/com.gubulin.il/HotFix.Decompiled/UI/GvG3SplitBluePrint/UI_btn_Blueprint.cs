using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.Common.Managers;
using UI.PublicResources;

namespace UI.GvG3SplitBluePrint;

public class UI_btn_Blueprint : GButton
{
	public Controller button;

	public Controller State;

	public Controller isLocked;

	public GImage n6;

	public GImage n5;

	public GButton Loader;

	public GImage n4;

	public GImage bpLock;

	public const string URL = "ui://7uylntmmju1uq";

	public static string Name = "UI_btn_Blueprint";

	public static string GetURL()
	{
		return "ui://7uylntmmju1uq";
	}

	public static UI_btn_Blueprint CreateInstance()
	{
		return (UI_btn_Blueprint)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "btn_Blueprint");
	}

	public static UI_btn_Blueprint CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Blueprint).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmju1uq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		isLocked = ((GComponent)this).GetController("isLocked");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Loader = (GButton)((GComponent)this).GetChild("Loader");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		bpLock = (GImage)((GComponent)this).GetChild("bpLock");
	}

	public void Render(Blueprint blueprint, int stateIndex)
	{
		State.SetSelectedIndex(stateIndex);
		UI_goodItemLarge uI_goodItemLarge = (UI_goodItemLarge)(object)Loader;
		uI_goodItemLarge.frame.url = "ui://PublicResources/kuang_round 2_lv6";
		((GObject)uI_goodItemLarge.max).visible = false;
		uI_goodItemLarge.icon.LoadBlueprintIcon(blueprint.GetIconName());
		((GObject)uI_goodItemLarge.name).visible = false;
		bool flag = GameManagers.Instance.BpLockManager.GetIsLocked(blueprint);
		isLocked.SetSelectedIndex(flag ? 1 : 0);
	}

	public void UpdateState(int stateIndex)
	{
		State.SetSelectedIndex(stateIndex);
	}
}

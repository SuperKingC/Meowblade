using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_btn_SelectedBlueprint : GButton
{
	public Controller button;

	public Controller State;

	public GImage n6;

	public GButton Loader;

	public GTextField n7;

	public Transition t0;

	public const string URL = "ui://7uylntmmkq2ds";

	public static string Name = "UI_btn_SelectedBlueprint";

	public static string GetURL()
	{
		return "ui://7uylntmmkq2ds";
	}

	public static UI_btn_SelectedBlueprint CreateInstance()
	{
		return (UI_btn_SelectedBlueprint)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "btn_SelectedBlueprint");
	}

	public static UI_btn_SelectedBlueprint CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectedBlueprint).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmkq2ds", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Loader = (GButton)((GComponent)this).GetChild("Loader");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://7uylntmmkq2ds".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_LegionsBtn : GButton
{
	public Controller button;

	public Controller Status;

	public UI_LegionBtnContent Content;

	public GImage note;

	public GGraph SfxBack;

	public Transition ShowContent;

	public const string URL = "ui://j611zmym6wel3";

	public static string Name = "UI_LegionsBtn";

	public static string GetURL()
	{
		return "ui://j611zmym6wel3";
	}

	public static UI_LegionsBtn CreateInstance()
	{
		return (UI_LegionsBtn)(object)UIPackage.CreateObject("MainCity", "LegionsBtn");
	}

	public static UI_LegionsBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegionsBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmym6wel3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Content = (UI_LegionBtnContent)(object)((GComponent)this).GetChild("Content");
		note = (GImage)((GComponent)this).GetChild("note");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		ShowContent = ((GComponent)this).GetTransition("ShowContent");
	}
}

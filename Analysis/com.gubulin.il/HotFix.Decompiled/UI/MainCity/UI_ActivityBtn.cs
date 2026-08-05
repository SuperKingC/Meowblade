using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_ActivityBtn : GButton
{
	public Controller button;

	public Controller Status;

	public UI_ActivityBtnContent Content;

	public GImage note;

	public GGraph SfxBack;

	public GGraph effPos;

	public Transition ShowContent;

	public const string URL = "ui://j611zmym6welg";

	public static string Name = "UI_ActivityBtn";

	public static string GetURL()
	{
		return "ui://j611zmym6welg";
	}

	public static UI_ActivityBtn CreateInstance()
	{
		return (UI_ActivityBtn)(object)UIPackage.CreateObject("MainCity", "ActivityBtn");
	}

	public static UI_ActivityBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActivityBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmym6welg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Content = (UI_ActivityBtnContent)(object)((GComponent)this).GetChild("Content");
		note = (GImage)((GComponent)this).GetChild("note");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		effPos = (GGraph)((GComponent)this).GetChild("effPos");
		ShowContent = ((GComponent)this).GetTransition("ShowContent");
	}
}

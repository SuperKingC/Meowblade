using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_ScoutBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GGraph n7;

	public GImage background;

	public GImage n8;

	public GImage n9;

	public const string URL = "ui://twlbabicuv96y";

	public static string Name = "UI_ScoutBtn";

	public static string GetURL()
	{
		return "ui://twlbabicuv96y";
	}

	public static UI_ScoutBtn CreateInstance()
	{
		return (UI_ScoutBtn)(object)UIPackage.CreateObject("Battle", "ScoutBtn");
	}

	public static UI_ScoutBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoutBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicuv96y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		background = (GImage)((GComponent)this).GetChild("background");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}

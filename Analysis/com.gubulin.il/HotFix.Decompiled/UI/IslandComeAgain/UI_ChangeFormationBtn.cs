using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ChangeFormationBtn : GButton
{
	public Controller button;

	public GGraph n7;

	public GImage background;

	public GImage n8;

	public const string URL = "ui://k2sprg26in7b23";

	public static string Name = "UI_ChangeFormationBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b23";
	}

	public static UI_ChangeFormationBtn CreateInstance()
	{
		return (UI_ChangeFormationBtn)(object)UIPackage.CreateObject("IslandComeAgain", "ChangeFormationBtn");
	}

	public static UI_ChangeFormationBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangeFormationBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		background = (GImage)((GComponent)this).GetChild("background");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}

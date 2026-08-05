using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_RetreatBtn : GButton
{
	public Controller button;

	public GImage icon;

	public GImage n6;

	public const string URL = "ui://twlbabicic7j37";

	public static string Name = "UI_RetreatBtn";

	public static string GetURL()
	{
		return "ui://twlbabicic7j37";
	}

	public static UI_RetreatBtn CreateInstance()
	{
		return (UI_RetreatBtn)(object)UIPackage.CreateObject("Battle", "RetreatBtn");
	}

	public static UI_RetreatBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RetreatBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicic7j37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GImage)((GComponent)this).GetChild("icon");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}

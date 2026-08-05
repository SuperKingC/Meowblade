using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_GoToRecruit : GButton
{
	public Controller button;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://twlbabicrl4qm4";

	public static string Name = "UI_GoToRecruit";

	public static string GetURL()
	{
		return "ui://twlbabicrl4qm4";
	}

	public static UI_GoToRecruit CreateInstance()
	{
		return (UI_GoToRecruit)(object)UIPackage.CreateObject("Battle", "GoToRecruit");
	}

	public static UI_GoToRecruit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToRecruit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicrl4qm4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}

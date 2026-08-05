using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_star : GButton
{
	public Controller button;

	public GImage n3;

	public GImage main;

	public Transition disappear;

	public Transition appear;

	public const string URL = "ui://avplaivdkn9kr";

	public static string Name = "UI_star";

	public static string GetURL()
	{
		return "ui://avplaivdkn9kr";
	}

	public static UI_star CreateInstance()
	{
		return (UI_star)(object)UIPackage.CreateObject("Contract", "star");
	}

	public static UI_star CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_star).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdkn9kr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		main = (GImage)((GComponent)this).GetChild("main");
		disappear = ((GComponent)this).GetTransition("disappear");
		appear = ((GComponent)this).GetTransition("appear");
	}
}

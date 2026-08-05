using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_Introduction : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://k2sprg26vfpc9q";

	public static string Name = "UI_Introduction";

	public static string GetURL()
	{
		return "ui://k2sprg26vfpc9q";
	}

	public static UI_Introduction CreateInstance()
	{
		return (UI_Introduction)(object)UIPackage.CreateObject("IslandComeAgain", "Introduction");
	}

	public static UI_Introduction CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Introduction).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26vfpc9q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://k2sprg26vfpc9q".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}

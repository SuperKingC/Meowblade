using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_EnterNeutralDungeon : GButton
{
	public Controller button;

	public GImage n13;

	public GImage n14;

	public const string URL = "ui://kozswd8haxd7f2x";

	public static string Name = "UI_EnterNeutralDungeon";

	public static string GetURL()
	{
		return "ui://kozswd8haxd7f2x";
	}

	public static UI_EnterNeutralDungeon CreateInstance()
	{
		return (UI_EnterNeutralDungeon)(object)UIPackage.CreateObject("SpecialActivity", "EnterNeutralDungeon");
	}

	public static UI_EnterNeutralDungeon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnterNeutralDungeon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8haxd7f2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
	}
}

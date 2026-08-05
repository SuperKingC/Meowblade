using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_EnterBattlefieldBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://c9n2h0ksee14k";

	public static string Name = "UI_EnterBattlefieldBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14k";
	}

	public static UI_EnterBattlefieldBtn CreateInstance()
	{
		return (UI_EnterBattlefieldBtn)(object)UIPackage.CreateObject("WorldMap", "EnterBattlefieldBtn");
	}

	public static UI_EnterBattlefieldBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnterBattlefieldBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}

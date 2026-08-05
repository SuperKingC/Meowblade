using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_StillMatchBtn : GButton
{
	public Controller button;

	public GImage n13;

	public GImage n14;

	public const string URL = "ui://k2sprg26jqfy18";

	public static string Name = "UI_StillMatchBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26jqfy18";
	}

	public static UI_StillMatchBtn CreateInstance()
	{
		return (UI_StillMatchBtn)(object)UIPackage.CreateObject("IslandComeAgain", "StillMatchBtn");
	}

	public static UI_StillMatchBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StillMatchBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26jqfy18", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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

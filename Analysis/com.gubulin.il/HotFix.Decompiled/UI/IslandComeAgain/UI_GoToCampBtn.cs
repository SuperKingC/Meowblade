using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_GoToCampBtn : GButton
{
	public Controller button;

	public GImage n13;

	public GImage n14;

	public const string URL = "ui://k2sprg26jqfy19";

	public static string Name = "UI_GoToCampBtn";

	public static string GetURL()
	{
		return "ui://k2sprg26jqfy19";
	}

	public static UI_GoToCampBtn CreateInstance()
	{
		return (UI_GoToCampBtn)(object)UIPackage.CreateObject("IslandComeAgain", "GoToCampBtn");
	}

	public static UI_GoToCampBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToCampBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26jqfy19", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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

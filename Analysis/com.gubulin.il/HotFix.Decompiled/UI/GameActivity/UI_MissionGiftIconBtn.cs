using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_MissionGiftIconBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n5;

	public GImage n3;

	public GLoader icon;

	public GImage n4;

	public const string URL = "ui://29q48tv6ju9n1v";

	public static string Name = "UI_MissionGiftIconBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6ju9n1v";
	}

	public static UI_MissionGiftIconBtn CreateInstance()
	{
		return (UI_MissionGiftIconBtn)(object)UIPackage.CreateObject("GameActivity", "MissionGiftIconBtn");
	}

	public static UI_MissionGiftIconBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionGiftIconBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6ju9n1v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}

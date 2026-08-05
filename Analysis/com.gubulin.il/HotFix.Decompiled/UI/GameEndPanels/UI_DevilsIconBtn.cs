using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_DevilsIconBtn : GButton
{
	public Controller button;

	public GImage back;

	public GImage icon;

	public const string URL = "ui://hda5vzklo4kt31";

	public static string Name = "UI_DevilsIconBtn";

	public static string GetURL()
	{
		return "ui://hda5vzklo4kt31";
	}

	public static UI_DevilsIconBtn CreateInstance()
	{
		return (UI_DevilsIconBtn)(object)UIPackage.CreateObject("GameEndPanels", "DevilsIconBtn");
	}

	public static UI_DevilsIconBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DevilsIconBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklo4kt31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GImage)((GComponent)this).GetChild("icon");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_restartBtn : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://hda5vzklgb514g";

	public static string Name = "UI_restartBtn";

	public static string GetURL()
	{
		return "ui://hda5vzklgb514g";
	}

	public static UI_restartBtn CreateInstance()
	{
		return (UI_restartBtn)(object)UIPackage.CreateObject("GameEndPanels", "restartBtn");
	}

	public static UI_restartBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_restartBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklgb514g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}

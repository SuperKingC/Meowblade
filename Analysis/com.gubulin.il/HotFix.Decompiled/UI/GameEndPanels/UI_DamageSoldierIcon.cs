using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_DamageSoldierIcon : GComponent
{
	public Controller Type;

	public GImage n8;

	public GLoader Iconloader;

	public const string URL = "ui://hda5vzkldey151";

	public static string Name = "UI_DamageSoldierIcon";

	public static string GetURL()
	{
		return "ui://hda5vzkldey151";
	}

	public static UI_DamageSoldierIcon CreateInstance()
	{
		return (UI_DamageSoldierIcon)(object)UIPackage.CreateObject("GameEndPanels", "DamageSoldierIcon");
	}

	public static UI_DamageSoldierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DamageSoldierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzkldey151", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		Iconloader = (GLoader)((GComponent)this).GetChild("Iconloader");
	}
}

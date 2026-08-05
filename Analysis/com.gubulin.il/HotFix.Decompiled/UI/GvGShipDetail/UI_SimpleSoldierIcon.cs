using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_SimpleSoldierIcon : GButton
{
	public Controller button;

	public GLoader iconFrame;

	public GLoader icon;

	public GComponent SoulStoneLevel;

	public Transition Disappear;

	public const string URL = "ui://u6x0b1gnsj9i2h";

	public static string Name = "UI_SimpleSoldierIcon";

	public static string GetURL()
	{
		return "ui://u6x0b1gnsj9i2h";
	}

	public static UI_SimpleSoldierIcon CreateInstance()
	{
		return (UI_SimpleSoldierIcon)(object)UIPackage.CreateObject("GvGShipDetail", "SimpleSoldierIcon");
	}

	public static UI_SimpleSoldierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SimpleSoldierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsj9i2h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		Disappear = ((GComponent)this).GetTransition("Disappear");
	}
}

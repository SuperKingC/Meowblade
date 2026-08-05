using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_SimpleSoldierSlot : GButton
{
	public Controller button;

	public Controller IsEmpty;

	public GGraph n46;

	public UI_SimpleSoldierIcon Icon;

	public Transition Disappear;

	public const string URL = "ui://u6x0b1gnsj9i2i";

	public static string Name = "UI_SimpleSoldierSlot";

	public static string GetURL()
	{
		return "ui://u6x0b1gnsj9i2i";
	}

	public static UI_SimpleSoldierSlot CreateInstance()
	{
		return (UI_SimpleSoldierSlot)(object)UIPackage.CreateObject("GvGShipDetail", "SimpleSoldierSlot");
	}

	public static UI_SimpleSoldierSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SimpleSoldierSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsj9i2i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		n46 = (GGraph)((GComponent)this).GetChild("n46");
		Icon = (UI_SimpleSoldierIcon)(object)((GComponent)this).GetChild("Icon");
		Disappear = ((GComponent)this).GetTransition("Disappear");
	}
}

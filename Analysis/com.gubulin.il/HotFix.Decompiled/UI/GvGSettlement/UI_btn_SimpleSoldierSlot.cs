using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_btn_SimpleSoldierSlot : GButton
{
	public Controller button;

	public Controller IsEmpty;

	public GGraph n46;

	public UI_btn_SimpleSoldierIcon Icon;

	public Transition Disappear;

	public const string URL = "ui://91jxdrkam9tae";

	public static string Name = "UI_btn_SimpleSoldierSlot";

	public static string GetURL()
	{
		return "ui://91jxdrkam9tae";
	}

	public static UI_btn_SimpleSoldierSlot CreateInstance()
	{
		return (UI_btn_SimpleSoldierSlot)(object)UIPackage.CreateObject("GvGSettlement", "btn_SimpleSoldierSlot");
	}

	public static UI_btn_SimpleSoldierSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SimpleSoldierSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkam9tae", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Icon = (UI_btn_SimpleSoldierIcon)(object)((GComponent)this).GetChild("Icon");
		Disappear = ((GComponent)this).GetTransition("Disappear");
	}
}

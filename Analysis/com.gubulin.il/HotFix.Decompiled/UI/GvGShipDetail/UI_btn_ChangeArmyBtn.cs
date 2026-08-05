using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ChangeArmyBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://u6x0b1gnfdart";

	public static string Name = "UI_btn_ChangeArmyBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnfdart";
	}

	public static UI_btn_ChangeArmyBtn CreateInstance()
	{
		return (UI_btn_ChangeArmyBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ChangeArmyBtn");
	}

	public static UI_btn_ChangeArmyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ChangeArmyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnfdart", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}

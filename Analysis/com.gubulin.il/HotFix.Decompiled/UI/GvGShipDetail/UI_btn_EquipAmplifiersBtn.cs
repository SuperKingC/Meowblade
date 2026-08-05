using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_EquipAmplifiersBtn : GButton
{
	public Controller button;

	public Controller Enable;

	public GLoader n5;

	public GLoader n3;

	public GGroup n6;

	public GImage n4;

	public const string URL = "ui://u6x0b1gnatee1u";

	public static string Name = "UI_btn_EquipAmplifiersBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnatee1u";
	}

	public static UI_btn_EquipAmplifiersBtn CreateInstance()
	{
		return (UI_btn_EquipAmplifiersBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_EquipAmplifiersBtn");
	}

	public static UI_btn_EquipAmplifiersBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_EquipAmplifiersBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnatee1u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Enable = ((GComponent)this).GetController("Enable");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n3 = (GLoader)((GComponent)this).GetChild("n3");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_btn_TypeTab : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n113;

	public GImage n121;

	public GLoader n123;

	public GLoader n124;

	public GLoader n125;

	public GImage RedDot;

	public const string URL = "ui://fpjheycbxe3qa";

	public static string Name = "UI_btn_TypeTab";

	public static string GetURL()
	{
		return "ui://fpjheycbxe3qa";
	}

	public static UI_btn_TypeTab CreateInstance()
	{
		return (UI_btn_TypeTab)(object)UIPackage.CreateObject("GvGAmplifierForge", "btn_TypeTab");
	}

	public static UI_btn_TypeTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TypeTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbxe3qa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		n123 = (GLoader)((GComponent)this).GetChild("n123");
		n124 = (GLoader)((GComponent)this).GetChild("n124");
		n125 = (GLoader)((GComponent)this).GetChild("n125");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}
}

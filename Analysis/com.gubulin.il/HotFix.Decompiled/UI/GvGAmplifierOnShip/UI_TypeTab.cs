using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_TypeTab : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n110;

	public GImage n111;

	public GImage n112;

	public GImage n113;

	public GImage n114;

	public GGroup n115;

	public GImage n116;

	public GImage n117;

	public GImage n118;

	public GGroup n119;

	public UI_com_TypeTabContent TypeTabContent;

	public GTextField Count;

	public const string URL = "ui://pwlamcyxgp164";

	public static string Name = "UI_TypeTab";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp164";
	}

	public static UI_TypeTab CreateInstance()
	{
		return (UI_TypeTab)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "TypeTab");
	}

	public static UI_TypeTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TypeTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp164", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n110 = (GImage)((GComponent)this).GetChild("n110");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		n114 = (GImage)((GComponent)this).GetChild("n114");
		n115 = (GGroup)((GComponent)this).GetChild("n115");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n117 = (GImage)((GComponent)this).GetChild("n117");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n119 = (GGroup)((GComponent)this).GetChild("n119");
		TypeTabContent = (UI_com_TypeTabContent)(object)((GComponent)this).GetChild("TypeTabContent");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_TechSlotBig : GButton
{
	public Controller Rarity;

	public Controller State;

	public GLoader Frame;

	public GLoader n126;

	public GImage n127;

	public GLoader TechIcon;

	public GImage n125;

	public GImage n128;

	public GImage n129;

	public GTextField TechName;

	public GTextField Level;

	public GTextField Effect;

	public GImage n130;

	public GImage n131;

	public GGroup n132;

	public GImage n134;

	public GLoader n138;

	public const string URL = "ui://th385mtty63lg";

	public static string Name = "UI_btn_TechSlotBig";

	public static string GetURL()
	{
		return "ui://th385mtty63lg";
	}

	public static UI_btn_TechSlotBig CreateInstance()
	{
		return (UI_btn_TechSlotBig)(object)UIPackage.CreateObject("GvGOuterTech", "btn_TechSlotBig");
	}

	public static UI_btn_TechSlotBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TechSlotBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty63lg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		State = ((GComponent)this).GetController("State");
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
		n126 = (GLoader)((GComponent)this).GetChild("n126");
		n127 = (GImage)((GComponent)this).GetChild("n127");
		TechIcon = (GLoader)((GComponent)this).GetChild("TechIcon");
		n125 = (GImage)((GComponent)this).GetChild("n125");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n129 = (GImage)((GComponent)this).GetChild("n129");
		TechName = (GTextField)((GComponent)this).GetChild("TechName");
		Level = (GTextField)((GComponent)this).GetChild("Level");
		Effect = (GTextField)((GComponent)this).GetChild("Effect");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		n132 = (GGroup)((GComponent)this).GetChild("n132");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n138 = (GLoader)((GComponent)this).GetChild("n138");
	}
}

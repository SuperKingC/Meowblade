using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_SkillBtnOutside : GButton
{
	public Controller button;

	public Controller Status;

	public GLoader FloorLoader;

	public GLoader IconLoader;

	public GLoader FrameLoader;

	public GImage Select;

	public GGroup n13;

	public UI_SkillBtnInside IconBtn;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GImage n20;

	public GGroup highLight;

	public GImage n16;

	public GImage n22;

	public const string URL = "ui://f4wr270rsbjw42";

	public static string Name = "UI_SkillBtnOutside";

	public static string GetURL()
	{
		return "ui://f4wr270rsbjw42";
	}

	public static UI_SkillBtnOutside CreateInstance()
	{
		return (UI_SkillBtnOutside)(object)UIPackage.CreateObject("InstanceZones", "SkillBtnOutside");
	}

	public static UI_SkillBtnOutside CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillBtnOutside).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rsbjw42", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		FloorLoader = (GLoader)((GComponent)this).GetChild("FloorLoader");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		Select = (GImage)((GComponent)this).GetChild("Select");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		IconBtn = (UI_SkillBtnInside)(object)((GComponent)this).GetChild("IconBtn");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		highLight = (GGroup)((GComponent)this).GetChild("highLight");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n22 = (GImage)((GComponent)this).GetChild("n22");
	}
}

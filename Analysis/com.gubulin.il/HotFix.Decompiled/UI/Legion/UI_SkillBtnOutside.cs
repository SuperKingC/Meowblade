using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_SkillBtnOutside : GButton
{
	public Controller button;

	public GImage Select;

	public UI_SkillBtnInside IconBtn;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GImage n20;

	public GGroup highLight;

	public GImage n16;

	public const string URL = "ui://lrhs6zw7a20545j";

	public static string Name = "UI_SkillBtnOutside";

	public static string GetURL()
	{
		return "ui://lrhs6zw7a20545j";
	}

	public static UI_SkillBtnOutside CreateInstance()
	{
		return (UI_SkillBtnOutside)(object)UIPackage.CreateObject("Legion", "SkillBtnOutside");
	}

	public static UI_SkillBtnOutside CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillBtnOutside).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7a20545j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Select = (GImage)((GComponent)this).GetChild("Select");
		IconBtn = (UI_SkillBtnInside)(object)((GComponent)this).GetChild("IconBtn");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		highLight = (GGroup)((GComponent)this).GetChild("highLight");
		n16 = (GImage)((GComponent)this).GetChild("n16");
	}
}

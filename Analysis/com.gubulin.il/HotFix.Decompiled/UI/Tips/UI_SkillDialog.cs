using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_SkillDialog : GComponent
{
	public Controller Type;

	public Controller SpecialityLevel;

	public GImage n94;

	public GGraph n102;

	public GTextField Name_t;

	public GRichTextField Describe_t;

	public GTextField conditions;

	public GLoader FloorLoader;

	public GLoader SkillIconLoader;

	public UI_com_buff buffIcon;

	public GLoader buffIconScore;

	public GImage frameImage;

	public GRichTextField skillType;

	public GTextField coolingText;

	public GTextField state;

	public GTextField speciality;

	public GImage n97;

	public GImage n98;

	public GImage n99;

	public GImage n103;

	public GGraph specialitySfxBack;

	public GGroup n101;

	public const string URL = "ui://47lbpgx9gs3115";

	public static string Name = "UI_SkillDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9gs3115";
	}

	public static UI_SkillDialog CreateInstance()
	{
		return (UI_SkillDialog)(object)UIPackage.CreateObject("Tips", "SkillDialog");
	}

	public static UI_SkillDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gs3115", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		SpecialityLevel = ((GComponent)this).GetController("SpecialityLevel");
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n102 = (GGraph)((GComponent)this).GetChild("n102");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		string id = "ui://47lbpgx9gs3115".Replace("ui://", "") + "-" + ((GObject)Name_t).id;
		((GObject)Name_t).text = LanguagesManager.GetDesc(id);
		Describe_t = (GRichTextField)((GComponent)this).GetChild("Describe_t");
		conditions = (GTextField)((GComponent)this).GetChild("conditions");
		string id2 = "ui://47lbpgx9gs3115".Replace("ui://", "") + "-" + ((GObject)conditions).id;
		((GObject)conditions).text = LanguagesManager.GetDesc(id2);
		FloorLoader = (GLoader)((GComponent)this).GetChild("FloorLoader");
		SkillIconLoader = (GLoader)((GComponent)this).GetChild("SkillIconLoader");
		buffIcon = (UI_com_buff)(object)((GComponent)this).GetChild("buffIcon");
		buffIconScore = (GLoader)((GComponent)this).GetChild("buffIconScore");
		frameImage = (GImage)((GComponent)this).GetChild("frameImage");
		skillType = (GRichTextField)((GComponent)this).GetChild("skillType");
		string id3 = "ui://47lbpgx9gs3115".Replace("ui://", "") + "-" + ((GObject)skillType).id;
		((GObject)skillType).text = LanguagesManager.GetDesc(id3);
		coolingText = (GTextField)((GComponent)this).GetChild("coolingText");
		state = (GTextField)((GComponent)this).GetChild("state");
		string id4 = "ui://47lbpgx9gs3115".Replace("ui://", "") + "-" + ((GObject)state).id;
		((GObject)state).text = LanguagesManager.GetDesc(id4);
		speciality = (GTextField)((GComponent)this).GetChild("speciality");
		string id5 = "ui://47lbpgx9gs3115".Replace("ui://", "") + "-" + ((GObject)speciality).id;
		((GObject)speciality).text = LanguagesManager.GetDesc(id5);
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		n99 = (GImage)((GComponent)this).GetChild("n99");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		specialitySfxBack = (GGraph)((GComponent)this).GetChild("specialitySfxBack");
		n101 = (GGroup)((GComponent)this).GetChild("n101");
	}
}

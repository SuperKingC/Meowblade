using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_SkillEffectDialog : GComponent
{
	public GImage back;

	public GGraph n96;

	public GRichTextField EffectName;

	public GRichTextField EffectNameDesc;

	public GRichTextField EffectLimit;

	public GRichTextField EffectLimitDesc;

	public GRichTextField Desc;

	public const string URL = "ui://47lbpgx9p37n5o";

	public static string Name = "UI_SkillEffectDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9p37n5o";
	}

	public static UI_SkillEffectDialog CreateInstance()
	{
		return (UI_SkillEffectDialog)(object)UIPackage.CreateObject("Tips", "SkillEffectDialog");
	}

	public static UI_SkillEffectDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillEffectDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9p37n5o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n96 = (GGraph)((GComponent)this).GetChild("n96");
		EffectName = (GRichTextField)((GComponent)this).GetChild("EffectName");
		EffectNameDesc = (GRichTextField)((GComponent)this).GetChild("EffectNameDesc");
		EffectLimit = (GRichTextField)((GComponent)this).GetChild("EffectLimit");
		EffectLimitDesc = (GRichTextField)((GComponent)this).GetChild("EffectLimitDesc");
		Desc = (GRichTextField)((GComponent)this).GetChild("Desc");
	}
}

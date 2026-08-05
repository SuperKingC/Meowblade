using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_ExperienceProcessBar : GProgressBar
{
	public GImage n2;

	public GImage bar;

	public GGraph SfxBack;

	public GTextField curExperience;

	public GTextField experienceIcon;

	public GTextField experience;

	public const string URL = "ui://b9wlonaqlud8r";

	public static string Name = "UI_ExperienceProcessBar";

	public static string GetURL()
	{
		return "ui://b9wlonaqlud8r";
	}

	public static UI_ExperienceProcessBar CreateInstance()
	{
		return (UI_ExperienceProcessBar)(object)UIPackage.CreateObject("LegendItemCultivation", "ExperienceProcessBar");
	}

	public static UI_ExperienceProcessBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExperienceProcessBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlud8r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		bar = (GImage)((GComponent)this).GetChild("bar");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		curExperience = (GTextField)((GComponent)this).GetChild("curExperience");
		experienceIcon = (GTextField)((GComponent)this).GetChild("experienceIcon");
		experience = (GTextField)((GComponent)this).GetChild("experience");
	}
}

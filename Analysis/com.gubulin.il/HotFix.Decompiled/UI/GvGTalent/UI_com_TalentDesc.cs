using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_TalentDesc : GComponent
{
	public GRichTextField Desc;

	public const string URL = "ui://4r1llhd8t0aw5g";

	public static string Name = "UI_com_TalentDesc";

	public static string GetURL()
	{
		return "ui://4r1llhd8t0aw5g";
	}

	public static UI_com_TalentDesc CreateInstance()
	{
		return (UI_com_TalentDesc)(object)UIPackage.CreateObject("GvGTalent", "com_TalentDesc");
	}

	public static UI_com_TalentDesc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TalentDesc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8t0aw5g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Desc = (GRichTextField)((GComponent)this).GetChild("Desc");
	}
}

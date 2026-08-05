using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_Talents : GComponent
{
	public Controller Type;

	public UI_com_TalentsBackground Background;

	public UI_com_TalentsContent Content;

	public const string URL = "ui://4r1llhd8ran31";

	public static string Name = "UI_com_Talents";

	public static string GetURL()
	{
		return "ui://4r1llhd8ran31";
	}

	public static UI_com_Talents CreateInstance()
	{
		return (UI_com_Talents)(object)UIPackage.CreateObject("GvGTalent", "com_Talents");
	}

	public static UI_com_Talents CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Talents).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ran31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Background = (UI_com_TalentsBackground)(object)((GComponent)this).GetChild("Background");
		Content = (UI_com_TalentsContent)(object)((GComponent)this).GetChild("Content");
	}
}

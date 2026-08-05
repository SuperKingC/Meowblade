using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_dec_TalentsArea4 : GComponent
{
	public GImage n4;

	public GImage n2;

	public GImage n3;

	public const string URL = "ui://4r1llhd8ran3b";

	public static string Name = "UI_dec_TalentsArea4";

	public static string GetURL()
	{
		return "ui://4r1llhd8ran3b";
	}

	public static UI_dec_TalentsArea4 CreateInstance()
	{
		return (UI_dec_TalentsArea4)(object)UIPackage.CreateObject("GvGTalent", "dec_TalentsArea4");
	}

	public static UI_dec_TalentsArea4 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_TalentsArea4).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ran3b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}

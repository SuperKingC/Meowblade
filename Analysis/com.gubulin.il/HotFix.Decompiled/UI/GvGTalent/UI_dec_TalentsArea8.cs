using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_dec_TalentsArea8 : GComponent
{
	public GImage n3;

	public GImage n1;

	public GImage n2;

	public const string URL = "ui://4r1llhd8ran39";

	public static string Name = "UI_dec_TalentsArea8";

	public static string GetURL()
	{
		return "ui://4r1llhd8ran39";
	}

	public static UI_dec_TalentsArea8 CreateInstance()
	{
		return (UI_dec_TalentsArea8)(object)UIPackage.CreateObject("GvGTalent", "dec_TalentsArea8");
	}

	public static UI_dec_TalentsArea8 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_TalentsArea8).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ran39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}

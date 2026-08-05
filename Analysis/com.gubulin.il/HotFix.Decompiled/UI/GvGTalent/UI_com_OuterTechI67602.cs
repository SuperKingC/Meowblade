using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_OuterTechI67602 : GComponent
{
	public GImage n2;

	public GImage n0;

	public GTextField n1;

	public const string URL = "ui://4r1llhd8r7y25k";

	public static string Name = "UI_com_OuterTechI67602";

	public static string GetURL()
	{
		return "ui://4r1llhd8r7y25k";
	}

	public static UI_com_OuterTechI67602 CreateInstance()
	{
		return (UI_com_OuterTechI67602)(object)UIPackage.CreateObject("GvGTalent", "com_OuterTechI67602");
	}

	public static UI_com_OuterTechI67602 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OuterTechI67602).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8r7y25k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4r1llhd8r7y25k".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
	}
}

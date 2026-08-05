using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SpecialityBriefInfo : GComponent
{
	public GImage n4;

	public GImage n3;

	public GTextField n5;

	public GList Speciality;

	public GImage n2;

	public const string URL = "ui://4eq8fgd2mdde2p";

	public static string Name = "UI_com_SpecialityBriefInfo";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2p";
	}

	public static UI_com_SpecialityBriefInfo CreateInstance()
	{
		return (UI_com_SpecialityBriefInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SpecialityBriefInfo");
	}

	public static UI_com_SpecialityBriefInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialityBriefInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://4eq8fgd2mdde2p".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		Speciality = (GList)((GComponent)this).GetChild("Speciality");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}

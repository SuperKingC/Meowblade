using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_SeniorKuangKuang : GComponent
{
	public GLoader n0;

	public GMovieClip n1;

	public GImage n2;

	public const string URL = "ui://kt6rg65otkizv4ta";

	public static string Name = "UI_com_SeniorKuangKuang";

	public static string GetURL()
	{
		return "ui://kt6rg65otkizv4ta";
	}

	public static UI_com_SeniorKuangKuang CreateInstance()
	{
		return (UI_com_SeniorKuangKuang)(object)UIPackage.CreateObject("PublicResources", "com_SeniorKuangKuang");
	}

	public static UI_com_SeniorKuangKuang CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SeniorKuangKuang).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65otkizv4ta", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		n1 = (GMovieClip)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}

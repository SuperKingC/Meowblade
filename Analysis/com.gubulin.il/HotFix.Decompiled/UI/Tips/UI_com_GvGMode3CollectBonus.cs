using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_com_GvGMode3CollectBonus : GComponent
{
	public GList materialList;

	public const string URL = "ui://47lbpgx9hmzntb5";

	public static string Name = "UI_com_GvGMode3CollectBonus";

	public static string GetURL()
	{
		return "ui://47lbpgx9hmzntb5";
	}

	public static UI_com_GvGMode3CollectBonus CreateInstance()
	{
		return (UI_com_GvGMode3CollectBonus)(object)UIPackage.CreateObject("Tips", "com_GvGMode3CollectBonus");
	}

	public static UI_com_GvGMode3CollectBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GvGMode3CollectBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9hmzntb5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		materialList = (GList)((GComponent)this).GetChild("materialList");
	}
}

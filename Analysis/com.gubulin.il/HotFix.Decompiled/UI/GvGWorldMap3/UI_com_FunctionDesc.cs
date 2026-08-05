using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FunctionDesc : GComponent
{
	public GImage n0;

	public GTextField Desc;

	public const string URL = "ui://4eq8fgd2h4tpeu";

	public static string Name = "UI_com_FunctionDesc";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpeu";
	}

	public static UI_com_FunctionDesc CreateInstance()
	{
		return (UI_com_FunctionDesc)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FunctionDesc");
	}

	public static UI_com_FunctionDesc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FunctionDesc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpeu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		string id = "ui://4eq8fgd2h4tpeu".Replace("ui://", "") + "-" + ((GObject)Desc).id;
		((GObject)Desc).text = LanguagesManager.GetDesc(id);
	}
}

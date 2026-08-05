using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FlagshipInfoFood : GComponent
{
	public GImage n3;

	public GImage n1;

	public GTextField n0;

	public GTextField Food;

	public const string URL = "ui://4eq8fgd2h4tpey";

	public static string Name = "UI_com_FlagshipInfoFood";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpey";
	}

	public static UI_com_FlagshipInfoFood CreateInstance()
	{
		return (UI_com_FlagshipInfoFood)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FlagshipInfoFood");
	}

	public static UI_com_FlagshipInfoFood CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagshipInfoFood).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpey", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://4eq8fgd2h4tpey".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		Food = (GTextField)((GComponent)this).GetChild("Food");
	}
}

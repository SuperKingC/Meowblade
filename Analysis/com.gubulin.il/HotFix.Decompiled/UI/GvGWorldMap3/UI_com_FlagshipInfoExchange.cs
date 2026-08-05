using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FlagshipInfoExchange : GComponent
{
	public GImage n2;

	public GImage n3;

	public GTextField n4;

	public GTextField Food;

	public const string URL = "ui://4eq8fgd2h4tpf2";

	public static string Name = "UI_com_FlagshipInfoExchange";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpf2";
	}

	public static UI_com_FlagshipInfoExchange CreateInstance()
	{
		return (UI_com_FlagshipInfoExchange)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FlagshipInfoExchange");
	}

	public static UI_com_FlagshipInfoExchange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagshipInfoExchange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpf2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4eq8fgd2h4tpf2".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		Food = (GTextField)((GComponent)this).GetChild("Food");
		string id2 = "ui://4eq8fgd2h4tpf2".Replace("ui://", "") + "-" + ((GObject)Food).id;
		((GObject)Food).text = LanguagesManager.GetDesc(id2);
	}
}

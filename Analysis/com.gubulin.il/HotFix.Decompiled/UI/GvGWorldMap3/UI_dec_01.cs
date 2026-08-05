using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_01 : GComponent
{
	public GImage n3;

	public GTextField n1;

	public GLoader n4;

	public const string URL = "ui://4eq8fgd2pj7ufx";

	public static string Name = "UI_dec_01";

	public static string GetURL()
	{
		return "ui://4eq8fgd2pj7ufx";
	}

	public static UI_dec_01 CreateInstance()
	{
		return (UI_dec_01)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_01");
	}

	public static UI_dec_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2pj7ufx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2pj7ufx".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n4 = (GLoader)((GComponent)this).GetChild("n4");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_FillupSweepCount : GButton
{
	public GTextField n58;

	public GImage n59;

	public const string URL = "ui://4eq8fgd2s80zsae";

	public static string Name = "UI_btn_FillupSweepCount";

	public static string GetURL()
	{
		return "ui://4eq8fgd2s80zsae";
	}

	public static UI_btn_FillupSweepCount CreateInstance()
	{
		return (UI_btn_FillupSweepCount)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_FillupSweepCount");
	}

	public static UI_btn_FillupSweepCount CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FillupSweepCount).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2s80zsae", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n58 = (GTextField)((GComponent)this).GetChild("n58");
		string id = "ui://4eq8fgd2s80zsae".Replace("ui://", "") + "-" + ((GObject)n58).id;
		((GObject)n58).text = LanguagesManager.GetDesc(id);
		n59 = (GImage)((GComponent)this).GetChild("n59");
	}
}

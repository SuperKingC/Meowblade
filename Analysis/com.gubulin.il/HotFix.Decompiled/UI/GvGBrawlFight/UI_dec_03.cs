using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_dec_03 : GComponent
{
	public GImage n94;

	public GTextField n95;

	public const string URL = "ui://hozu168riwm75p";

	public static string Name = "UI_dec_03";

	public static string GetURL()
	{
		return "ui://hozu168riwm75p";
	}

	public static UI_dec_03 CreateInstance()
	{
		return (UI_dec_03)(object)UIPackage.CreateObject("GvGBrawlFight", "dec_03");
	}

	public static UI_dec_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168riwm75p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n95 = (GTextField)((GComponent)this).GetChild("n95");
		string id = "ui://hozu168riwm75p".Replace("ui://", "") + "-" + ((GObject)n95).id;
		((GObject)n95).text = LanguagesManager.GetDesc(id);
	}
}

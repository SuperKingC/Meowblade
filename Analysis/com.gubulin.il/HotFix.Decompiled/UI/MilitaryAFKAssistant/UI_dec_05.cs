using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_dec_05 : GComponent
{
	public GImage n7;

	public GTextField n6;

	public UI_dec_04 n8;

	public const string URL = "ui://8x5gc8j2msbrv4vl";

	public static string Name = "UI_dec_05";

	public static string GetURL()
	{
		return "ui://8x5gc8j2msbrv4vl";
	}

	public static UI_dec_05 CreateInstance()
	{
		return (UI_dec_05)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "dec_05");
	}

	public static UI_dec_05 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_05).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2msbrv4vl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://8x5gc8j2msbrv4vl".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n8 = (UI_dec_04)(object)((GComponent)this).GetChild("n8");
	}
}

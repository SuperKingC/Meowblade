using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_ExchangeItem02 : GComponent
{
	public GLoader Icon;

	public GTextField Num;

	public const string URL = "ui://tt2iq07oj9f82l";

	public static string Name = "UI_com_ExchangeItem02";

	public static string GetURL()
	{
		return "ui://tt2iq07oj9f82l";
	}

	public static UI_com_ExchangeItem02 CreateInstance()
	{
		return (UI_com_ExchangeItem02)(object)UIPackage.CreateObject("GvGExchange3", "com_ExchangeItem02");
	}

	public static UI_com_ExchangeItem02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ExchangeItem02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj9f82l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		string id = "ui://tt2iq07oj9f82l".Replace("ui://", "") + "-" + ((GObject)Num).id;
		((GObject)Num).text = LanguagesManager.GetDesc(id);
	}
}

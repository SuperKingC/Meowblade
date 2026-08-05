using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_dec_QualityTabFrame : GComponent
{
	public GImage n97;

	public const string URL = "ui://tt2iq07oj1h83h";

	public static string Name = "UI_dec_QualityTabFrame";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h83h";
	}

	public static UI_dec_QualityTabFrame CreateInstance()
	{
		return (UI_dec_QualityTabFrame)(object)UIPackage.CreateObject("GvGExchange3", "dec_QualityTabFrame");
	}

	public static UI_dec_QualityTabFrame CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_QualityTabFrame).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h83h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n97 = (GImage)((GComponent)this).GetChild("n97");
	}
}

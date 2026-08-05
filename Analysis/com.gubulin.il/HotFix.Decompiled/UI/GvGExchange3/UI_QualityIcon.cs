using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_QualityIcon : GComponent
{
	public Controller Quatity;

	public GLoader n99;

	public const string URL = "ui://tt2iq07oj1h83k";

	public static string Name = "UI_QualityIcon";

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h83k";
	}

	public static UI_QualityIcon CreateInstance()
	{
		return (UI_QualityIcon)(object)UIPackage.CreateObject("GvGExchange3", "QualityIcon");
	}

	public static UI_QualityIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QualityIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h83k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Quatity = ((GComponent)this).GetController("Quatity");
		n99 = (GLoader)((GComponent)this).GetChild("n99");
	}
}

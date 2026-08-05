using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_integralNodeList : GComponent
{
	public UI_IntegralProgress IntegralProgress;

	public const string URL = "ui://f4wr270rk1jj28";

	public static string Name = "UI_integralNodeList";

	public static string GetURL()
	{
		return "ui://f4wr270rk1jj28";
	}

	public static UI_integralNodeList CreateInstance()
	{
		return (UI_integralNodeList)(object)UIPackage.CreateObject("InstanceZones", "integralNodeList");
	}

	public static UI_integralNodeList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_integralNodeList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rk1jj28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		IntegralProgress = (UI_IntegralProgress)(object)((GComponent)this).GetChild("IntegralProgress");
	}
}

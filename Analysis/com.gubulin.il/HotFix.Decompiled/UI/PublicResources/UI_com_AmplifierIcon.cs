using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_AmplifierIcon : GComponent
{
	public GLoader QualityFrame;

	public GLoader PropIcon;

	public const string URL = "ui://kt6rg65oasnox";

	public static string Name = "UI_com_AmplifierIcon";

	public static string GetURL()
	{
		return "ui://kt6rg65oasnox";
	}

	public static UI_com_AmplifierIcon CreateInstance()
	{
		return (UI_com_AmplifierIcon)(object)UIPackage.CreateObject("PublicResources", "com_AmplifierIcon");
	}

	public static UI_com_AmplifierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oasnox", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		QualityFrame = (GLoader)((GComponent)this).GetChild("QualityFrame");
		PropIcon = (GLoader)((GComponent)this).GetChild("PropIcon");
	}
}

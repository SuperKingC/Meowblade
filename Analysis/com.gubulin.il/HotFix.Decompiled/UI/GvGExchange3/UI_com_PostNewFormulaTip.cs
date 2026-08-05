using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_PostNewFormulaTip : GComponent
{
	public GImage Background;

	public GImage n1;

	public GTextField n4;

	public const string URL = "ui://tt2iq07oxxgp59";

	public static string Name = "UI_com_PostNewFormulaTip";

	public static string GetURL()
	{
		return "ui://tt2iq07oxxgp59";
	}

	public static UI_com_PostNewFormulaTip CreateInstance()
	{
		return (UI_com_PostNewFormulaTip)(object)UIPackage.CreateObject("GvGExchange3", "com_PostNewFormulaTip");
	}

	public static UI_com_PostNewFormulaTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PostNewFormulaTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oxxgp59", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://tt2iq07oxxgp59".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}

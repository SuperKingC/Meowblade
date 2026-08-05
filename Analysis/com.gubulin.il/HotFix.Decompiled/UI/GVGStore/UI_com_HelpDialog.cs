using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_HelpDialog : GComponent
{
	public GImage back;

	public GImage n1;

	public GGraph n5;

	public GGraph n6;

	public UI_CloseBtn Close;

	public const string URL = "ui://fvc33k3gjsii6";

	public static string Name = "UI_com_HelpDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gjsii6";
	}

	public static UI_com_HelpDialog CreateInstance()
	{
		return (UI_com_HelpDialog)(object)UIPackage.CreateObject("GVGStore", "com_HelpDialog");
	}

	public static UI_com_HelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gjsii6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n5 = (GGraph)((GComponent)this).GetChild("n5");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		Close = (UI_CloseBtn)(object)((GComponent)this).GetChild("Close");
	}
}

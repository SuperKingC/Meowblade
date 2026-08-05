using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_Avatar : GComponent
{
	public Controller CampId;

	public GLoader Icon;

	public UI_com_HeadPortrait HeadPortrait;

	public const string URL = "ui://91jxdrkam9tab";

	public static string Name = "UI_com_Avatar";

	public static string GetURL()
	{
		return "ui://91jxdrkam9tab";
	}

	public static UI_com_Avatar CreateInstance()
	{
		return (UI_com_Avatar)(object)UIPackage.CreateObject("GvGSettlement", "com_Avatar");
	}

	public static UI_com_Avatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Avatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkam9tab", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		HeadPortrait = (UI_com_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}

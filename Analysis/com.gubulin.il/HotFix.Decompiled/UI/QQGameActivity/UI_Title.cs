using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_Title : GComponent
{
	public GImage n0;

	public GLoader icon;

	public const string URL = "ui://r1j1a2l0nbmf31";

	public static string Name = "UI_Title";

	public static string GetURL()
	{
		return "ui://r1j1a2l0nbmf31";
	}

	public static UI_Title CreateInstance()
	{
		return (UI_Title)(object)UIPackage.CreateObject("QQGameActivity", "Title");
	}

	public static UI_Title CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Title).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0nbmf31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}

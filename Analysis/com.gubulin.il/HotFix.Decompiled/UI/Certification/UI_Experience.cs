using FairyGUI;
using FairyGUI.Utils;

namespace UI.Certification;

public class UI_Experience : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://56q48tcqm13tt";

	public static string Name = "UI_Experience";

	public static string GetURL()
	{
		return "ui://56q48tcqm13tt";
	}

	public static UI_Experience CreateInstance()
	{
		return (UI_Experience)(object)UIPackage.CreateObject("Certification", "Experience");
	}

	public static UI_Experience CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Experience).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_com_CommandIcon : GComponent
{
	public Controller Type;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public const string URL = "ui://vheg8vabq1hvx";

	public static string Name = "UI_com_CommandIcon";

	public static string GetURL()
	{
		return "ui://vheg8vabq1hvx";
	}

	public static UI_com_CommandIcon CreateInstance()
	{
		return (UI_com_CommandIcon)(object)UIPackage.CreateObject("GvGPlayerCommand3", "com_CommandIcon");
	}

	public static UI_com_CommandIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CommandIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabq1hvx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}

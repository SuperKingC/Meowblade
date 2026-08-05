using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_star : GComponent
{
	public Controller active;

	public GImage n21;

	public GImage n22;

	public const string URL = "ui://8x5gc8j2sy9cq";

	public static string Name = "UI_com_star";

	public static string GetURL()
	{
		return "ui://8x5gc8j2sy9cq";
	}

	public static UI_com_star CreateInstance()
	{
		return (UI_com_star)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_star");
	}

	public static UI_com_star CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_star).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2sy9cq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		active = ((GComponent)this).GetController("active");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_GuaranteedTicket : GComponent
{
	public GImage n3;

	public GLoader Icon;

	public GTextField Count;

	public const string URL = "ui://fvc33k3grm5w3h";

	public static string Name = "UI_com_GuaranteedTicket";

	public static string GetURL()
	{
		return "ui://fvc33k3grm5w3h";
	}

	public static UI_com_GuaranteedTicket CreateInstance()
	{
		return (UI_com_GuaranteedTicket)(object)UIPackage.CreateObject("GVGStore", "com_GuaranteedTicket");
	}

	public static UI_com_GuaranteedTicket CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GuaranteedTicket).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3grm5w3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}

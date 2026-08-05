using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_ReceiveBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage note;

	public GImage n6;

	public const string URL = "ui://f4wr270rk1jj24";

	public static string Name = "UI_ReceiveBtn";

	public static string GetURL()
	{
		return "ui://f4wr270rk1jj24";
	}

	public static UI_ReceiveBtn CreateInstance()
	{
		return (UI_ReceiveBtn)(object)UIPackage.CreateObject("InstanceZones", "ReceiveBtn");
	}

	public static UI_ReceiveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReceiveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rk1jj24", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		note = (GImage)((GComponent)this).GetChild("note");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}

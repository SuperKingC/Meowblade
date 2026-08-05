using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_ReceiveBtn : GButton
{
	public Controller button;

	public GImage n7;

	public GImage n9;

	public const string URL = "ui://72poq8plofha18";

	public static string Name = "UI_ReceiveBtn";

	public static string GetURL()
	{
		return "ui://72poq8plofha18";
	}

	public static UI_ReceiveBtn CreateInstance()
	{
		return (UI_ReceiveBtn)(object)UIPackage.CreateObject("RecyclingCenter", "ReceiveBtn");
	}

	public static UI_ReceiveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReceiveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plofha18", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}

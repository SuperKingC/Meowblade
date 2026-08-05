using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftOfLord;

public class UI_receiveBtn : GButton
{
	public Controller button;

	public GImage back;

	public GImage n5;

	public const string URL = "ui://nz2z1ab8t0xzb";

	public static string Name = "UI_receiveBtn";

	public static string GetURL()
	{
		return "ui://nz2z1ab8t0xzb";
	}

	public static UI_receiveBtn CreateInstance()
	{
		return (UI_receiveBtn)(object)UIPackage.CreateObject("GiftOfLord", "receiveBtn");
	}

	public static UI_receiveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_receiveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xzb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}

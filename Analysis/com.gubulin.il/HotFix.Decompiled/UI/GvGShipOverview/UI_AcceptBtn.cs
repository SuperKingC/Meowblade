using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_AcceptBtn : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://7ymaonxtb2oh2k";

	public static string Name = "UI_AcceptBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtb2oh2k";
	}

	public static UI_AcceptBtn CreateInstance()
	{
		return (UI_AcceptBtn)(object)UIPackage.CreateObject("GvGShipOverview", "AcceptBtn");
	}

	public static UI_AcceptBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AcceptBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtb2oh2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}

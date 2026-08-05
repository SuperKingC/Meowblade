using FairyGUI;
using FairyGUI.Utils;

namespace UI.Friends;

public class UI_CancelBtn : GButton
{
	public Controller button;

	public GImage n0;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public const string URL = "ui://3rz8gv6ct6gt14";

	public static string Name = "UI_CancelBtn";

	public static string GetURL()
	{
		return "ui://3rz8gv6ct6gt14";
	}

	public static UI_CancelBtn CreateInstance()
	{
		return (UI_CancelBtn)(object)UIPackage.CreateObject("Friends", "CancelBtn");
	}

	public static UI_CancelBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CancelBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6ct6gt14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}

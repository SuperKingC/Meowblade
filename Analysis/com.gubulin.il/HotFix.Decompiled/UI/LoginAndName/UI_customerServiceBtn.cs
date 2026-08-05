using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_customerServiceBtn : GButton
{
	public Controller button;

	public GImage n9;

	public GLoader n7;

	public GImage n11;

	public const string URL = "ui://yb3s7uv7qy9w2x";

	public static string Name = "UI_customerServiceBtn";

	public static string GetURL()
	{
		return "ui://yb3s7uv7qy9w2x";
	}

	public static UI_customerServiceBtn CreateInstance()
	{
		return (UI_customerServiceBtn)(object)UIPackage.CreateObject("LoginAndName", "customerServiceBtn");
	}

	public static UI_customerServiceBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_customerServiceBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7qy9w2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}

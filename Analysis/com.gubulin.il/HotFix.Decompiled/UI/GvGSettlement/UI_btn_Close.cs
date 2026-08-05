using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_btn_Close : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://91jxdrkae1a737";

	public static string Name = "UI_btn_Close";

	public static string GetURL()
	{
		return "ui://91jxdrkae1a737";
	}

	public static UI_btn_Close CreateInstance()
	{
		return (UI_btn_Close)(object)UIPackage.CreateObject("GvGSettlement", "btn_Close");
	}

	public static UI_btn_Close CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Close).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkae1a737", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}

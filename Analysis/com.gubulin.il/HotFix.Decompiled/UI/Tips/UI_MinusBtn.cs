using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_MinusBtn : GButton
{
	public Controller button;

	public GImage background;

	public GImage n4;

	public const string URL = "ui://47lbpgx9y40h46";

	public static string Name = "UI_MinusBtn";

	public static string GetURL()
	{
		return "ui://47lbpgx9y40h46";
	}

	public static UI_MinusBtn CreateInstance()
	{
		return (UI_MinusBtn)(object)UIPackage.CreateObject("Tips", "MinusBtn");
	}

	public static UI_MinusBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MinusBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9y40h46", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}

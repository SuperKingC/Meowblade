using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_com_ConfirmBtn : GButton
{
	public Controller button;

	public GImage background;

	public GLoader n6;

	public const string URL = "ui://ia1am3ehheift2b";

	public static string Name = "UI_com_ConfirmBtn";

	public static string GetURL()
	{
		return "ui://ia1am3ehheift2b";
	}

	public static UI_com_ConfirmBtn CreateInstance()
	{
		return (UI_com_ConfirmBtn)(object)UIPackage.CreateObject("UnlockSoldierShow", "com_ConfirmBtn");
	}

	public static UI_com_ConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehheift2b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GLoader)((GComponent)this).GetChild("n6");
	}
}

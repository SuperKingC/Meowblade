using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMBonus3;

public class UI_btn_ConfirmBtn : GButton
{
	public Controller button;

	public GImage n8;

	public GLoader icon;

	public const string URL = "ui://h3bpjkt7pg60b";

	public static string Name = "UI_btn_ConfirmBtn";

	public static string GetURL()
	{
		return "ui://h3bpjkt7pg60b";
	}

	public static UI_btn_ConfirmBtn CreateInstance()
	{
		return (UI_btn_ConfirmBtn)(object)UIPackage.CreateObject("GvGOEMBonus3", "btn_ConfirmBtn");
	}

	public static UI_btn_ConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pg60b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_btn_ConfirmSaveBtn : GButton
{
	public Controller button;

	public GImage n0;

	public GImage n3;

	public const string URL = "ui://pwlamcyxgp168";

	public static string Name = "UI_btn_ConfirmSaveBtn";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp168";
	}

	public static UI_btn_ConfirmSaveBtn CreateInstance()
	{
		return (UI_btn_ConfirmSaveBtn)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "btn_ConfirmSaveBtn");
	}

	public static UI_btn_ConfirmSaveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmSaveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp168", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_btn_FilterBtn : GButton
{
	public GImage n155;

	public const string URL = "ui://pwlamcyxgp16t";

	public static string Name = "UI_btn_FilterBtn";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp16t";
	}

	public static UI_btn_FilterBtn CreateInstance()
	{
		return (UI_btn_FilterBtn)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "btn_FilterBtn");
	}

	public static UI_btn_FilterBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FilterBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp16t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n155 = (GImage)((GComponent)this).GetChild("n155");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_btn_FoodSupply : GButton
{
	public Controller button;

	public GImage n9;

	public GImage n7;

	public GImage n10;

	public const string URL = "ui://tvr786zlkkmw48";

	public static string Name = "UI_btn_FoodSupply";

	public static string GetURL()
	{
		return "ui://tvr786zlkkmw48";
	}

	public static UI_btn_FoodSupply CreateInstance()
	{
		return (UI_btn_FoodSupply)(object)UIPackage.CreateObject("GvGFlagship3", "btn_FoodSupply");
	}

	public static UI_btn_FoodSupply CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FoodSupply).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlkkmw48", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}

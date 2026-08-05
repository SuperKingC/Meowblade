using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_PriceText : GComponent
{
	public GTextField curPrice;

	public UI_StrikeTextField originPrice;

	public UI_ExclamationMarkBtn ExclamationMarkBtn;

	public const string URL = "ui://kt6rg65oiv4jme";

	public static string Name = "UI_PriceText";

	public static string GetURL()
	{
		return "ui://kt6rg65oiv4jme";
	}

	public static UI_PriceText CreateInstance()
	{
		return (UI_PriceText)(object)UIPackage.CreateObject("PublicResources", "PriceText");
	}

	public static UI_PriceText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PriceText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oiv4jme", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		curPrice = (GTextField)((GComponent)this).GetChild("curPrice");
		originPrice = (UI_StrikeTextField)(object)((GComponent)this).GetChild("originPrice");
		ExclamationMarkBtn = (UI_ExclamationMarkBtn)(object)((GComponent)this).GetChild("ExclamationMarkBtn");
	}
}

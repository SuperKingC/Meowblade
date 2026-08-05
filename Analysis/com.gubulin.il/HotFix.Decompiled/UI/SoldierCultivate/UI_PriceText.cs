using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_PriceText : GComponent
{
	public GTextField curPrice;

	public UI_StrikeTextField originPrice;

	public GButton ExclamationMarkBtn;

	public const string URL = "ui://7dantnbin60rtc5";

	public static string Name = "UI_PriceText";

	public static string GetURL()
	{
		return "ui://7dantnbin60rtc5";
	}

	public static UI_PriceText CreateInstance()
	{
		return (UI_PriceText)(object)UIPackage.CreateObject("SoldierCultivate", "PriceText");
	}

	public static UI_PriceText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PriceText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbin60rtc5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		curPrice = (GTextField)((GComponent)this).GetChild("curPrice");
		originPrice = (UI_StrikeTextField)(object)((GComponent)this).GetChild("originPrice");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
	}
}

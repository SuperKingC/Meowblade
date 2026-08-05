using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierPromotionBtn : GButton
{
	public Controller button;

	public const string URL = "ui://7dantnbioomct7p";

	public static string Name = "UI_SoldierPromotionBtn";

	public static string GetURL()
	{
		return "ui://7dantnbioomct7p";
	}

	public static UI_SoldierPromotionBtn CreateInstance()
	{
		return (UI_SoldierPromotionBtn)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierPromotionBtn");
	}

	public static UI_SoldierPromotionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPromotionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbioomct7p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}

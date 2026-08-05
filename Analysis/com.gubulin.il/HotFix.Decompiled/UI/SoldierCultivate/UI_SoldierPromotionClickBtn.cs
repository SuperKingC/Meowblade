using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierPromotionClickBtn : GButton
{
	public Controller button;

	public const string URL = "ui://7dantnbioomct7r";

	public static string Name = "UI_SoldierPromotionClickBtn";

	public static string GetURL()
	{
		return "ui://7dantnbioomct7r";
	}

	public static UI_SoldierPromotionClickBtn CreateInstance()
	{
		return (UI_SoldierPromotionClickBtn)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierPromotionClickBtn");
	}

	public static UI_SoldierPromotionClickBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPromotionClickBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbioomct7r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}

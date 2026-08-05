using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_consumptionBtn : GButton
{
	public Controller button;

	public GImage title;

	public GList consumptionList;

	public const string URL = "ui://7dantnbin23p67";

	public static string Name = "UI_consumptionBtn";

	public static string GetURL()
	{
		return "ui://7dantnbin23p67";
	}

	public static UI_consumptionBtn CreateInstance()
	{
		return (UI_consumptionBtn)(object)UIPackage.CreateObject("SoldierCultivate", "consumptionBtn");
	}

	public static UI_consumptionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_consumptionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbin23p67", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		title = (GImage)((GComponent)this).GetChild("title");
		consumptionList = (GList)((GComponent)this).GetChild("consumptionList");
	}
}

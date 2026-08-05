using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_ConfirmForSoulStoneSelect : GButton
{
	public Controller button;

	public GImage back;

	public GTextField title;

	public GLoader icon;

	public const string URL = "ui://7dantnbibunlt8d";

	public static string Name = "UI_ConfirmForSoulStoneSelect";

	public static string GetURL()
	{
		return "ui://7dantnbibunlt8d";
	}

	public static UI_ConfirmForSoulStoneSelect CreateInstance()
	{
		return (UI_ConfirmForSoulStoneSelect)(object)UIPackage.CreateObject("SoldierCultivate", "ConfirmForSoulStoneSelect");
	}

	public static UI_ConfirmForSoulStoneSelect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmForSoulStoneSelect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbibunlt8d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbibunlt8d".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}

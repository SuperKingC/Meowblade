using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_UpSoldierLevel : GButton
{
	public Controller button;

	public GImage background;

	public GTextField level;

	public GTextField title;

	public GImage redPoint;

	public const string URL = "ui://7dantnbionm23";

	public static string Name = "UI_UpSoldierLevel";

	public static string GetURL()
	{
		return "ui://7dantnbionm23";
	}

	public static UI_UpSoldierLevel CreateInstance()
	{
		return (UI_UpSoldierLevel)(object)UIPackage.CreateObject("SoldierCultivate", "UpSoldierLevel");
	}

	public static UI_UpSoldierLevel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpSoldierLevel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://7dantnbionm23".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://7dantnbionm23".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
	}
}

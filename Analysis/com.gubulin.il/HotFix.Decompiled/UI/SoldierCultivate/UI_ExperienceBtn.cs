using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_ExperienceBtn : GButton
{
	public Controller buttonController;

	public GButton hightLight;

	public GLoader Loader;

	public GLoader icon;

	public GTextField name;

	public GTextField effect;

	public GTextField title;

	public GTextField effectNum;

	public const string URL = "ui://7dantnbionm2p";

	public static string Name = "UI_ExperienceBtn";

	public static string GetURL()
	{
		return "ui://7dantnbionm2p";
	}

	public static UI_ExperienceBtn CreateInstance()
	{
		return (UI_ExperienceBtn)(object)UIPackage.CreateObject("SoldierCultivate", "ExperienceBtn");
	}

	public static UI_ExperienceBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExperienceBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm2p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		buttonController = ((GComponent)this).GetController("buttonController");
		hightLight = (GButton)((GComponent)this).GetChild("hightLight");
		Loader = (GLoader)((GComponent)this).GetChild("Loader");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://7dantnbionm2p".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		effect = (GTextField)((GComponent)this).GetChild("effect");
		string id2 = "ui://7dantnbionm2p".Replace("ui://", "") + "-" + ((GObject)effect).id;
		((GObject)effect).text = LanguagesManager.GetDesc(id2);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id3 = "ui://7dantnbionm2p".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id3);
		effectNum = (GTextField)((GComponent)this).GetChild("effectNum");
	}
}

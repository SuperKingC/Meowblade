using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_breakthroughCodeLast : GButton
{
	public Controller button;

	public GLoader icon;

	public GGraph textGroupSpine;

	public GTextField property;

	public GTextField value;

	public GGroup textGroup;

	public GGraph SfxBack;

	public const string URL = "ui://7dantnbiex2e66";

	public static string Name = "UI_breakthroughCodeLast";

	public static string GetURL()
	{
		return "ui://7dantnbiex2e66";
	}

	public static UI_breakthroughCodeLast CreateInstance()
	{
		return (UI_breakthroughCodeLast)(object)UIPackage.CreateObject("SoldierCultivate", "breakthroughCodeLast");
	}

	public static UI_breakthroughCodeLast CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_breakthroughCodeLast).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbiex2e66", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		textGroupSpine = (GGraph)((GComponent)this).GetChild("textGroupSpine");
		property = (GTextField)((GComponent)this).GetChild("property");
		string id = "ui://7dantnbiex2e66".Replace("ui://", "") + "-" + ((GObject)property).id;
		((GObject)property).text = LanguagesManager.GetDesc(id);
		value = (GTextField)((GComponent)this).GetChild("value");
		string id2 = "ui://7dantnbiex2e66".Replace("ui://", "") + "-" + ((GObject)value).id;
		((GObject)value).text = LanguagesManager.GetDesc(id2);
		textGroup = (GGroup)((GComponent)this).GetChild("textGroup");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}

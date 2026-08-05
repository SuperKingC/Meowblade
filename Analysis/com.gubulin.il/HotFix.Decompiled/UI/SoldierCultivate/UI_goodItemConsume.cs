using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_goodItemConsume : GButton
{
	public Controller button;

	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public GGraph titleSpine;

	public GTextField name;

	public UI_PriceText reqDesc;

	public const string URL = "ui://7dantnbin60rtc4";

	public static string Name = "UI_goodItemConsume";

	public static string GetURL()
	{
		return "ui://7dantnbin60rtc4";
	}

	public static UI_goodItemConsume CreateInstance()
	{
		return (UI_goodItemConsume)(object)UIPackage.CreateObject("SoldierCultivate", "goodItemConsume");
	}

	public static UI_goodItemConsume CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_goodItemConsume).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbin60rtc4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		titleSpine = (GGraph)((GComponent)this).GetChild("titleSpine");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://7dantnbin60rtc4".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		reqDesc = (UI_PriceText)(object)((GComponent)this).GetChild("reqDesc");
	}
}

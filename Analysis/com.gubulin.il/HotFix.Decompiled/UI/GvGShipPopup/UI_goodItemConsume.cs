using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_goodItemConsume : GButton
{
	public Controller button;

	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public GGraph titleSpine;

	public GTextField name;

	public GComponent reqDesc;

	public const string URL = "ui://pwrbvhpvci9l7f";

	public static string Name = "UI_goodItemConsume";

	public static string GetURL()
	{
		return "ui://pwrbvhpvci9l7f";
	}

	public static UI_goodItemConsume CreateInstance()
	{
		return (UI_goodItemConsume)(object)UIPackage.CreateObject("GvGShipPopup", "goodItemConsume");
	}

	public static UI_goodItemConsume CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_goodItemConsume).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvci9l7f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		titleSpine = (GGraph)((GComponent)this).GetChild("titleSpine");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://pwrbvhpvci9l7f".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		reqDesc = (GComponent)((GComponent)this).GetChild("reqDesc");
	}
}

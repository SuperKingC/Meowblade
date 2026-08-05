using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_unlockAreaTip : GButton
{
	public Controller button;

	public GImage n8;

	public GImage n5;

	public GImage n6;

	public GImage arrow;

	public GTextField tipText;

	public GLoader n7;

	public UI_notOccupyLogo n9;

	public Transition t0;

	public const string URL = "ui://c9n2h0kskpq62o";

	public static string Name = "UI_unlockAreaTip";

	public static string GetURL()
	{
		return "ui://c9n2h0kskpq62o";
	}

	public static UI_unlockAreaTip CreateInstance()
	{
		return (UI_unlockAreaTip)(object)UIPackage.CreateObject("WorldMap", "unlockAreaTip");
	}

	public static UI_unlockAreaTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_unlockAreaTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0kskpq62o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		tipText = (GTextField)((GComponent)this).GetChild("tipText");
		string id = "ui://c9n2h0kskpq62o".Replace("ui://", "") + "-" + ((GObject)tipText).id;
		((GObject)tipText).text = LanguagesManager.GetDesc(id);
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		n9 = (UI_notOccupyLogo)(object)((GComponent)this).GetChild("n9");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_rewardBack5 : GButton
{
	public Controller button;

	public GImage n4;

	public GLoader backIcon;

	public GGraph fxBack;

	public GLoader icon;

	public GTextField num;

	public GImage chipNote;

	public const string URL = "ui://c9n2h0ksee14v";

	public static string Name = "UI_rewardBack5";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14v";
	}

	public static UI_rewardBack5 CreateInstance()
	{
		return (UI_rewardBack5)(object)UIPackage.CreateObject("WorldMap", "rewardBack5");
	}

	public static UI_rewardBack5 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_rewardBack5).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		backIcon = (GLoader)((GComponent)this).GetChild("backIcon");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://c9n2h0ksee14v".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
	}
}

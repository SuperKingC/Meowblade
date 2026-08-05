using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_EditModeSwitchBtn : GButton
{
	public Controller button;

	public GImage n9;

	public GImage n4;

	public GImage n5;

	public GImage n3;

	public GTextField n7;

	public GTextField n8;

	public const string URL = "ui://7ymaonxtjjrg27";

	public static string Name = "UI_EditModeSwitchBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtjjrg27";
	}

	public static UI_EditModeSwitchBtn CreateInstance()
	{
		return (UI_EditModeSwitchBtn)(object)UIPackage.CreateObject("GvGShipOverview", "EditModeSwitchBtn");
	}

	public static UI_EditModeSwitchBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EditModeSwitchBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtjjrg27", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://7ymaonxtjjrg27".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://7ymaonxtjjrg27".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
	}
}

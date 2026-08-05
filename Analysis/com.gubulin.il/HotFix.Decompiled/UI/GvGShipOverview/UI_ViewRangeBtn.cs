using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_ViewRangeBtn : GButton
{
	public Controller open;

	public GImage n0;

	public GImage n1;

	public GTextField n2;

	public const string URL = "ui://7ymaonxtjf436x";

	public static string Name = "UI_ViewRangeBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtjf436x";
	}

	public static UI_ViewRangeBtn CreateInstance()
	{
		return (UI_ViewRangeBtn)(object)UIPackage.CreateObject("GvGShipOverview", "ViewRangeBtn");
	}

	public static UI_ViewRangeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ViewRangeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtjf436x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		open = ((GComponent)this).GetController("open");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://7ymaonxtjf436x".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
	}
}

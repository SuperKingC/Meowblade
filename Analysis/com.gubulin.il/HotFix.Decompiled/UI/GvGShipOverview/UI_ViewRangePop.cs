using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_ViewRangePop : GComponent
{
	public Controller ShowViewRange;

	public GGraph Mask;

	public GImage background;

	public GImage n2;

	public GImage n3;

	public UI_ViewRangeSwitchBtn ViewRangeSwitchBtn;

	public GTextField n5;

	public const string URL = "ui://7ymaonxtjf436y";

	public static string Name = "UI_ViewRangePop";

	public static string GetURL()
	{
		return "ui://7ymaonxtjf436y";
	}

	public static UI_ViewRangePop CreateInstance()
	{
		return (UI_ViewRangePop)(object)UIPackage.CreateObject("GvGShipOverview", "ViewRangePop");
	}

	public static UI_ViewRangePop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ViewRangePop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtjf436y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShowViewRange = ((GComponent)this).GetController("ShowViewRange");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		background = (GImage)((GComponent)this).GetChild("background");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		ViewRangeSwitchBtn = (UI_ViewRangeSwitchBtn)(object)((GComponent)this).GetChild("ViewRangeSwitchBtn");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://7ymaonxtjf436y".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}

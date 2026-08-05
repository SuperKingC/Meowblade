using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_again : GButton
{
	public Controller button;

	public GImage n19;

	public GImage n20;

	public GLoader runningTicketIcon;

	public GTextField runningCost;

	public const string URL = "ui://xogvri2hi0qy3";

	public static string Name = "UI_again";

	public static string GetURL()
	{
		return "ui://xogvri2hi0qy3";
	}

	public static UI_again CreateInstance()
	{
		return (UI_again)(object)UIPackage.CreateObject("LegendItemsDraw", "again");
	}

	public static UI_again CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_again).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hi0qy3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		runningTicketIcon = (GLoader)((GComponent)this).GetChild("runningTicketIcon");
		runningCost = (GTextField)((GComponent)this).GetChild("runningCost");
		string id = "ui://xogvri2hi0qy3".Replace("ui://", "") + "-" + ((GObject)runningCost).id;
		((GObject)runningCost).text = LanguagesManager.GetDesc(id);
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_getTicket : GComponent
{
	public Controller showDailyBonus;

	public GImage n45;

	public GImage n46;

	public GRichTextField tipText;

	public UI_GoGetTicketBtn1 goBtn1;

	public UI_GoGetTicketBtn2 goBtn2;

	public const string URL = "ui://jl0c82y5txpa3a";

	public static string Name = "UI_com_getTicket";

	public static string GetURL()
	{
		return "ui://jl0c82y5txpa3a";
	}

	public static UI_com_getTicket CreateInstance()
	{
		return (UI_com_getTicket)(object)UIPackage.CreateObject("WeekActivity", "com_getTicket");
	}

	public static UI_com_getTicket CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_getTicket).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5txpa3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		showDailyBonus = ((GComponent)this).GetController("showDailyBonus");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		tipText = (GRichTextField)((GComponent)this).GetChild("tipText");
		goBtn1 = (UI_GoGetTicketBtn1)(object)((GComponent)this).GetChild("goBtn1");
		goBtn2 = (UI_GoGetTicketBtn2)(object)((GComponent)this).GetChild("goBtn2");
	}
}

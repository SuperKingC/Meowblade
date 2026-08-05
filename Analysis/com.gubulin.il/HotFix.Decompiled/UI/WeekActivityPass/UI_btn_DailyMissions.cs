using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_btn_DailyMissions : GButton
{
	public Controller button;

	public GImage back;

	public GLoader n8;

	public const string URL = "ui://11dkggb8dhmu31";

	public static string Name = "UI_btn_DailyMissions";

	public static string GetURL()
	{
		return "ui://11dkggb8dhmu31";
	}

	public static UI_btn_DailyMissions CreateInstance()
	{
		return (UI_btn_DailyMissions)(object)UIPackage.CreateObject("WeekActivityPass", "btn_DailyMissions");
	}

	public static UI_btn_DailyMissions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DailyMissions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8dhmu31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_storeContent : GComponent
{
	public GList cardList;

	public GTextField ActivityTime;

	public const string URL = "ui://jl0c82y5fmsk7";

	public static string Name = "UI_com_storeContent";

	public static string GetURL()
	{
		return "ui://jl0c82y5fmsk7";
	}

	public static UI_com_storeContent CreateInstance()
	{
		return (UI_com_storeContent)(object)UIPackage.CreateObject("WeekActivity", "com_storeContent");
	}

	public static UI_com_storeContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_storeContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmsk7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		cardList = (GList)((GComponent)this).GetChild("cardList");
		ActivityTime = (GTextField)((GComponent)this).GetChild("ActivityTime");
	}
}

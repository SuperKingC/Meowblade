using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_TodayMyBestSlot : GComponent
{
	public UI_TodayMyBestSlotWrapper Wrapper;

	public Transition Stamp;

	public Transition PushAway;

	public const string URL = "ui://0i520nzmtlapo6u";

	public static string Name = "UI_TodayMyBestSlot";

	public static string GetURL()
	{
		return "ui://0i520nzmtlapo6u";
	}

	public static UI_TodayMyBestSlot CreateInstance()
	{
		return (UI_TodayMyBestSlot)(object)UIPackage.CreateObject("LordOfDreams", "TodayMyBestSlot");
	}

	public static UI_TodayMyBestSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TodayMyBestSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtlapo6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Wrapper = (UI_TodayMyBestSlotWrapper)(object)((GComponent)this).GetChild("Wrapper");
		Stamp = ((GComponent)this).GetTransition("Stamp");
		PushAway = ((GComponent)this).GetTransition("PushAway");
	}
}

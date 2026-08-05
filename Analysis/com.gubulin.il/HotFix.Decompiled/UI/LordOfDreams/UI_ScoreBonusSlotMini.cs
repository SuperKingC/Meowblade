using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ScoreBonusSlotMini : GComponent
{
	public Controller StateController;

	public UI_ScoreBonusSlotWrapperMini Wrapper;

	public Transition Magnify;

	public const string URL = "ui://0i520nzme91so93";

	public static string Name = "UI_ScoreBonusSlotMini";

	public static string GetURL()
	{
		return "ui://0i520nzme91so93";
	}

	public static UI_ScoreBonusSlotMini CreateInstance()
	{
		return (UI_ScoreBonusSlotMini)(object)UIPackage.CreateObject("LordOfDreams", "ScoreBonusSlotMini");
	}

	public static UI_ScoreBonusSlotMini CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreBonusSlotMini).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzme91so93", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		Wrapper = (UI_ScoreBonusSlotWrapperMini)(object)((GComponent)this).GetChild("Wrapper");
		Magnify = ((GComponent)this).GetTransition("Magnify");
	}
}

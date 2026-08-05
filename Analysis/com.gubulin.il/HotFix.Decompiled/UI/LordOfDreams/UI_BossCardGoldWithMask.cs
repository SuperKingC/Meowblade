using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_BossCardGoldWithMask : GComponent
{
	public Controller StageController;

	public UI_BossCardGoldBtn Island7;

	public Transition Appear;

	public const string URL = "ui://0i520nzmdy01od6";

	public static string Name = "UI_BossCardGoldWithMask";

	public static string GetURL()
	{
		return "ui://0i520nzmdy01od6";
	}

	public static UI_BossCardGoldWithMask CreateInstance()
	{
		return (UI_BossCardGoldWithMask)(object)UIPackage.CreateObject("LordOfDreams", "BossCardGoldWithMask");
	}

	public static UI_BossCardGoldWithMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossCardGoldWithMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmdy01od6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		StageController = ((GComponent)this).GetController("StageController");
		Island7 = (UI_BossCardGoldBtn)(object)((GComponent)this).GetChild("Island7");
		Appear = ((GComponent)this).GetTransition("Appear");
	}
}

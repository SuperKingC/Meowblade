using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ScoreBonusSlot : GComponent
{
	public Controller StateController;

	public UI_ScoreBonusSlotWrapper Wrapper;

	public GImage n11;

	public Transition Stamp;

	public Transition PushAway;

	public const string URL = "ui://0i520nzmtajuo8x";

	public static string Name = "UI_ScoreBonusSlot";

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo8x";
	}

	public static UI_ScoreBonusSlot CreateInstance()
	{
		return (UI_ScoreBonusSlot)(object)UIPackage.CreateObject("LordOfDreams", "ScoreBonusSlot");
	}

	public static UI_ScoreBonusSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreBonusSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo8x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		Wrapper = (UI_ScoreBonusSlotWrapper)(object)((GComponent)this).GetChild("Wrapper");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		Stamp = ((GComponent)this).GetTransition("Stamp");
		PushAway = ((GComponent)this).GetTransition("PushAway");
	}
}

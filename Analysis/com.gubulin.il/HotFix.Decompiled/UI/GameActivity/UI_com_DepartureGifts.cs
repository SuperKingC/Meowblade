using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_DepartureGifts : GComponent
{
	public Controller Type;

	public UI_com_DepartureLevelCondition LevelCondition;

	public UI_btn_FreeGift FreeGift;

	public UI_btn_PaidGift PaidGift;

	public GMovieClip n38;

	public Transition t0;

	public const string URL = "ui://29q48tv6jorqay";

	public static string Name = "UI_com_DepartureGifts";

	public static string GetURL()
	{
		return "ui://29q48tv6jorqay";
	}

	public static UI_com_DepartureGifts CreateInstance()
	{
		return (UI_com_DepartureGifts)(object)UIPackage.CreateObject("GameActivity", "com_DepartureGifts");
	}

	public static UI_com_DepartureGifts CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DepartureGifts).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6jorqay", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		LevelCondition = (UI_com_DepartureLevelCondition)(object)((GComponent)this).GetChild("LevelCondition");
		FreeGift = (UI_btn_FreeGift)(object)((GComponent)this).GetChild("FreeGift");
		PaidGift = (UI_btn_PaidGift)(object)((GComponent)this).GetChild("PaidGift");
		n38 = (GMovieClip)((GComponent)this).GetChild("n38");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

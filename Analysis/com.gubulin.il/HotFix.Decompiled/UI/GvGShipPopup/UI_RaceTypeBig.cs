using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_RaceTypeBig : GButton
{
	public Controller button;

	public Controller IsNotAvailable;

	public Controller State;

	public GImage n14;

	public GLoader icon;

	public UI_dec_03 n19;

	public GImage n15;

	public GImage n18;

	public const string URL = "ui://pwrbvhpvlaby37";

	public static string Name = "UI_RaceTypeBig";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlaby37";
	}

	public static UI_RaceTypeBig CreateInstance()
	{
		return (UI_RaceTypeBig)(object)UIPackage.CreateObject("GvGShipPopup", "RaceTypeBig");
	}

	public static UI_RaceTypeBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RaceTypeBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlaby37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsNotAvailable = ((GComponent)this).GetController("IsNotAvailable");
		State = ((GComponent)this).GetController("State");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n19 = (UI_dec_03)(object)((GComponent)this).GetChild("n19");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n18 = (GImage)((GComponent)this).GetChild("n18");
	}
}

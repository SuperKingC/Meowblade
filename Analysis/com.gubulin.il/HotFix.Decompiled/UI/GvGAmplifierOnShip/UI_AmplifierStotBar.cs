using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_AmplifierStotBar : GComponent
{
	public Controller IsShowRace;

	public Controller Quality;

	public Controller IsNewAdded;

	public GLoader n169;

	public GMovieClip n170;

	public GMovieClip n171;

	public GImage n165;

	public UI_btn_UnloadButton UnloadBtn;

	public GComponent AmplifierIcon;

	public GTextField AmpName;

	public GTextField Property;

	public GComponent RaceType;

	public GComponent AffectedSoldier;

	public const string URL = "ui://pwlamcyxw71h12";

	public static string Name = "UI_AmplifierStotBar";

	public static string GetURL()
	{
		return "ui://pwlamcyxw71h12";
	}

	public static UI_AmplifierStotBar CreateInstance()
	{
		return (UI_AmplifierStotBar)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "AmplifierStotBar");
	}

	public static UI_AmplifierStotBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AmplifierStotBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxw71h12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowRace = ((GComponent)this).GetController("IsShowRace");
		Quality = ((GComponent)this).GetController("Quality");
		IsNewAdded = ((GComponent)this).GetController("IsNewAdded");
		n169 = (GLoader)((GComponent)this).GetChild("n169");
		n170 = (GMovieClip)((GComponent)this).GetChild("n170");
		n171 = (GMovieClip)((GComponent)this).GetChild("n171");
		n165 = (GImage)((GComponent)this).GetChild("n165");
		UnloadBtn = (UI_btn_UnloadButton)(object)((GComponent)this).GetChild("UnloadBtn");
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		AmpName = (GTextField)((GComponent)this).GetChild("AmpName");
		Property = (GTextField)((GComponent)this).GetChild("Property");
		RaceType = (GComponent)((GComponent)this).GetChild("RaceType");
		AffectedSoldier = (GComponent)((GComponent)this).GetChild("AffectedSoldier");
	}
}

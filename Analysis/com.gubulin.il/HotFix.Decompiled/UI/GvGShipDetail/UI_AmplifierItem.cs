using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_AmplifierItem : GComponent
{
	public Controller Quality;

	public Controller IsShowRace;

	public GImage n82;

	public GMovieClip n88;

	public GImage n79;

	public GMovieClip n87;

	public GImage n72;

	public GImage n80;

	public GImage n81;

	public GImage n78;

	public GComponent AffectedSoldier;

	public GComponent RaceType;

	public GComponent AmplifierIcon;

	public GTextField EffectRange;

	public GList PropList;

	public const string URL = "ui://u6x0b1gnzpu41r";

	public static string Name = "UI_AmplifierItem";

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41r";
	}

	public static UI_AmplifierItem CreateInstance()
	{
		return (UI_AmplifierItem)(object)UIPackage.CreateObject("GvGShipDetail", "AmplifierItem");
	}

	public static UI_AmplifierItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AmplifierItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Quality = ((GComponent)this).GetController("Quality");
		IsShowRace = ((GComponent)this).GetController("IsShowRace");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n88 = (GMovieClip)((GComponent)this).GetChild("n88");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		n87 = (GMovieClip)((GComponent)this).GetChild("n87");
		n72 = (GImage)((GComponent)this).GetChild("n72");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		AffectedSoldier = (GComponent)((GComponent)this).GetChild("AffectedSoldier");
		RaceType = (GComponent)((GComponent)this).GetChild("RaceType");
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		EffectRange = (GTextField)((GComponent)this).GetChild("EffectRange");
		PropList = (GList)((GComponent)this).GetChild("PropList");
	}
}

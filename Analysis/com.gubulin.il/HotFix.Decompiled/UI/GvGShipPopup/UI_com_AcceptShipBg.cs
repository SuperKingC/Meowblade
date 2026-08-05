using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_com_AcceptShipBg : GComponent
{
	public GGraph n148;

	public GImage n132;

	public GImage n134;

	public GImage n135;

	public UI_dec_light n136;

	public GImage n141;

	public GGraph SpineLoader;

	public GImage n143;

	public GButton ShipRace;

	public GMovieClip n145;

	public GMovieClip n146;

	public GMovieClip n147;

	public GImage n140;

	public GImage n137;

	public GImage n138;

	public GImage n139;

	public GGraph FGSpineLoader;

	public GGraph FGSpineLoader2;

	public Transition ShowShip;

	public const string URL = "ui://pwrbvhpvarhu5z";

	public static string Name = "UI_com_AcceptShipBg";

	public static string GetURL()
	{
		return "ui://pwrbvhpvarhu5z";
	}

	public static UI_com_AcceptShipBg CreateInstance()
	{
		return (UI_com_AcceptShipBg)(object)UIPackage.CreateObject("GvGShipPopup", "com_AcceptShipBg");
	}

	public static UI_com_AcceptShipBg CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AcceptShipBg).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvarhu5z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n148 = (GGraph)((GComponent)this).GetChild("n148");
		n132 = (GImage)((GComponent)this).GetChild("n132");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n136 = (UI_dec_light)(object)((GComponent)this).GetChild("n136");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		ShipRace = (GButton)((GComponent)this).GetChild("ShipRace");
		n145 = (GMovieClip)((GComponent)this).GetChild("n145");
		n146 = (GMovieClip)((GComponent)this).GetChild("n146");
		n147 = (GMovieClip)((GComponent)this).GetChild("n147");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		FGSpineLoader = (GGraph)((GComponent)this).GetChild("FGSpineLoader");
		FGSpineLoader2 = (GGraph)((GComponent)this).GetChild("FGSpineLoader2");
		ShowShip = ((GComponent)this).GetTransition("ShowShip");
	}
}

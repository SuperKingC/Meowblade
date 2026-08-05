using FairyGUI;
using FairyGUI.Utils;

namespace UI.BlueprintGachaDetailInfo;

public class UI_com_BlueprintGachaDetailInfoDIalog : GComponent
{
	public GImage n1;

	public GImage n2;

	public UI_exitBtn close;

	public GGraph star4General;

	public GGraph star4General2;

	public GGraph suitEffect;

	public GGraph star5General;

	public GGraph star5Exclusive;

	public GGraph suitEffect2;

	public GGraph star1General;

	public GGraph star4General3;

	public GGraph star4General4;

	public GGraph star5General2;

	public GGraph star5Exclusive2;

	public GGraph star6General;

	public GGraph star6Exclusive;

	public GGraph GeneralExclusive;

	public GGraph suit;

	public const string URL = "ui://ojhszwlpsxwp2";

	public static string Name = "UI_com_BlueprintGachaDetailInfoDIalog";

	public static string GetURL()
	{
		return "ui://ojhszwlpsxwp2";
	}

	public static UI_com_BlueprintGachaDetailInfoDIalog CreateInstance()
	{
		return (UI_com_BlueprintGachaDetailInfoDIalog)(object)UIPackage.CreateObject("BlueprintGachaDetailInfo", "com_BlueprintGachaDetailInfoDIalog");
	}

	public static UI_com_BlueprintGachaDetailInfoDIalog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BlueprintGachaDetailInfoDIalog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ojhszwlpsxwp2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
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
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		close = (UI_exitBtn)(object)((GComponent)this).GetChild("close");
		star4General = (GGraph)((GComponent)this).GetChild("star4General");
		star4General2 = (GGraph)((GComponent)this).GetChild("star4General2");
		suitEffect = (GGraph)((GComponent)this).GetChild("suitEffect");
		star5General = (GGraph)((GComponent)this).GetChild("star5General");
		star5Exclusive = (GGraph)((GComponent)this).GetChild("star5Exclusive");
		suitEffect2 = (GGraph)((GComponent)this).GetChild("suitEffect2");
		star1General = (GGraph)((GComponent)this).GetChild("star1General");
		star4General3 = (GGraph)((GComponent)this).GetChild("star4General3");
		star4General4 = (GGraph)((GComponent)this).GetChild("star4General4");
		star5General2 = (GGraph)((GComponent)this).GetChild("star5General2");
		star5Exclusive2 = (GGraph)((GComponent)this).GetChild("star5Exclusive2");
		star6General = (GGraph)((GComponent)this).GetChild("star6General");
		star6Exclusive = (GGraph)((GComponent)this).GetChild("star6Exclusive");
		GeneralExclusive = (GGraph)((GComponent)this).GetChild("GeneralExclusive");
		suit = (GGraph)((GComponent)this).GetChild("suit");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_SliverCardFront : GComponent
{
	public GButton specialCard;

	public GLoader icon;

	public GRichTextField title;

	public GRichTextField introduction;

	public GGroup chipContent;

	public GGraph soldier;

	public GImage nameBack;

	public GTextField soldierName;

	public GGroup soldierGroup;

	public GImage chipNote;

	public GTextField chipNum;

	public GGroup chipGroup;

	public GGraph cover;

	public GComponent curLevel;

	public const string URL = "ui://6n2woz97vecs9";

	public static string Name = "UI_SliverCardFront";

	public static string GetURL()
	{
		return "ui://6n2woz97vecs9";
	}

	public static UI_SliverCardFront CreateInstance()
	{
		return (UI_SliverCardFront)(object)UIPackage.CreateObject("DebrisCompound", "SliverCardFront");
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
		((GComponent)this).ConstructFromXML(xml);
		specialCard = (GButton)((GComponent)this).GetChild("specialCard");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		introduction = (GRichTextField)((GComponent)this).GetChild("introduction");
		chipContent = (GGroup)((GComponent)this).GetChild("chipContent");
		soldier = (GGraph)((GComponent)this).GetChild("soldier");
		nameBack = (GImage)((GComponent)this).GetChild("nameBack");
		soldierName = (GTextField)((GComponent)this).GetChild("soldierName");
		soldierGroup = (GGroup)((GComponent)this).GetChild("soldierGroup");
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
		chipNum = (GTextField)((GComponent)this).GetChild("chipNum");
		chipGroup = (GGroup)((GComponent)this).GetChild("chipGroup");
		cover = (GGraph)((GComponent)this).GetChild("cover");
		curLevel = (GComponent)((GComponent)this).GetChild("curLevel");
	}
}

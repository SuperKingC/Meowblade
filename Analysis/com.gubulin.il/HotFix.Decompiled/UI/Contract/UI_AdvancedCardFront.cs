using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_AdvancedCardFront : GComponent
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

	public const string URL = "ui://avplaivdmxsj20";

	public static string Name = "UI_AdvancedCardFront";

	public static string GetURL()
	{
		return "ui://avplaivdmxsj20";
	}

	public static UI_AdvancedCardFront CreateInstance()
	{
		return (UI_AdvancedCardFront)(object)UIPackage.CreateObject("Contract", "AdvancedCardFront");
	}

	public static UI_AdvancedCardFront CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AdvancedCardFront).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdmxsj20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		specialCard = (GButton)((GComponent)this).GetChild("specialCard");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://avplaivdmxsj20".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		introduction = (GRichTextField)((GComponent)this).GetChild("introduction");
		string id2 = "ui://avplaivdmxsj20".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id2);
		chipContent = (GGroup)((GComponent)this).GetChild("chipContent");
		soldier = (GGraph)((GComponent)this).GetChild("soldier");
		nameBack = (GImage)((GComponent)this).GetChild("nameBack");
		soldierName = (GTextField)((GComponent)this).GetChild("soldierName");
		string id3 = "ui://avplaivdmxsj20".Replace("ui://", "") + "-" + ((GObject)soldierName).id;
		((GObject)soldierName).text = LanguagesManager.GetDesc(id3);
		soldierGroup = (GGroup)((GComponent)this).GetChild("soldierGroup");
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
		chipNum = (GTextField)((GComponent)this).GetChild("chipNum");
		chipGroup = (GGroup)((GComponent)this).GetChild("chipGroup");
		cover = (GGraph)((GComponent)this).GetChild("cover");
		curLevel = (GComponent)((GComponent)this).GetChild("curLevel");
	}
}

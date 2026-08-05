using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprintTemplate;

public class UI_com_InfoDialog : GComponent
{
	public Controller Type;

	public Controller isLocked;

	public GImage back;

	public GImage n45;

	public GImage n47;

	public GImage n46;

	public GTextField BlueprintName;

	public GLoader BlueprintIcon;

	public GButton EvoLegendItem;

	public UI_com_RandomLegendItem n48;

	public GTextField n42;

	public GTextField Desc;

	public UI_com_Content Content;

	public UI_com_Scroll ScrollTip;

	public UI_btn_Lock bpLock;

	public const string URL = "ui://se4hok01wrnf1";

	public static string Name = "UI_com_InfoDialog";

	public static string GetURL()
	{
		return "ui://se4hok01wrnf1";
	}

	public static UI_com_InfoDialog CreateInstance()
	{
		return (UI_com_InfoDialog)(object)UIPackage.CreateObject("LegendItemBlueprintTemplate", "com_InfoDialog");
	}

	public static UI_com_InfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_InfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		isLocked = ((GComponent)this).GetController("isLocked");
		back = (GImage)((GComponent)this).GetChild("back");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		BlueprintName = (GTextField)((GComponent)this).GetChild("BlueprintName");
		BlueprintIcon = (GLoader)((GComponent)this).GetChild("BlueprintIcon");
		EvoLegendItem = (GButton)((GComponent)this).GetChild("EvoLegendItem");
		n48 = (UI_com_RandomLegendItem)(object)((GComponent)this).GetChild("n48");
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id = "ui://se4hok01wrnf1".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Content = (UI_com_Content)(object)((GComponent)this).GetChild("Content");
		ScrollTip = (UI_com_Scroll)(object)((GComponent)this).GetChild("ScrollTip");
		bpLock = (UI_btn_Lock)(object)((GComponent)this).GetChild("bpLock");
	}
}

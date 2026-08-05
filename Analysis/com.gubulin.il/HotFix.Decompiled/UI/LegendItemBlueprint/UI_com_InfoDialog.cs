using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

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

	public GTextField n42;

	public GTextField Desc;

	public UI_com_Content Content;

	public UI_btn_forge Forge;

	public UI_com_Scroll ScrollTip;

	public UI_btn_Lock bpLock;

	public const string URL = "ui://h09dvkcgjpqas";

	public static string Name = "UI_com_InfoDialog";

	public static string GetURL()
	{
		return "ui://h09dvkcgjpqas";
	}

	public static UI_com_InfoDialog CreateInstance()
	{
		return (UI_com_InfoDialog)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_InfoDialog");
	}

	public static UI_com_InfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_InfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgjpqas", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
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
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id = "ui://h09dvkcgjpqas".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Content = (UI_com_Content)(object)((GComponent)this).GetChild("Content");
		Forge = (UI_btn_forge)(object)((GComponent)this).GetChild("Forge");
		ScrollTip = (UI_com_Scroll)(object)((GComponent)this).GetChild("ScrollTip");
		bpLock = (UI_btn_Lock)(object)((GComponent)this).GetChild("bpLock");
	}
}

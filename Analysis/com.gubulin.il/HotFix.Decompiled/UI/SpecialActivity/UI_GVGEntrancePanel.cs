using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_GVGEntrancePanel : GComponent
{
	public GImage n15;

	public GImage n19;

	public GImage n14;

	public GImage n17;

	public GImage n18;

	public GGraph DescTitleBack;

	public GLoader DescTitle;

	public GLoader Desc;

	public GLoader Icon;

	public UI_EnterGVG EnterGVGBtn;

	public GTextField Time;

	public const string URL = "ui://kozswd8hrz06f29";

	public static string Name = "UI_GVGEntrancePanel";

	public static string GetURL()
	{
		return "ui://kozswd8hrz06f29";
	}

	public static UI_GVGEntrancePanel CreateInstance()
	{
		return (UI_GVGEntrancePanel)(object)UIPackage.CreateObject("SpecialActivity", "GVGEntrancePanel");
	}

	public static UI_GVGEntrancePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GVGEntrancePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hrz06f29", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		DescTitleBack = (GGraph)((GComponent)this).GetChild("DescTitleBack");
		DescTitle = (GLoader)((GComponent)this).GetChild("DescTitle");
		Desc = (GLoader)((GComponent)this).GetChild("Desc");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		EnterGVGBtn = (UI_EnterGVG)(object)((GComponent)this).GetChild("EnterGVGBtn");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id = "ui://kozswd8hrz06f29".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id);
	}
}

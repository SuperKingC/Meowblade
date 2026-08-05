using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_armItem1 : GButton
{
	public Controller button;

	public Controller Level;

	public Controller Status;

	public GLoader iconFrame;

	public GImage n27;

	public GLoader icon;

	public GComponent PotentialIcon;

	public GComponent SoulStoneLevel;

	public GRichTextField num;

	public GRichTextField title_Max;

	public GRichTextField title;

	public GImage maxIcon;

	public const string URL = "ui://47lbpgx9op6kp";

	public static string Name = "UI_armItem1";

	public static string GetURL()
	{
		return "ui://47lbpgx9op6kp";
	}

	public static UI_armItem1 CreateInstance()
	{
		return (UI_armItem1)(object)UIPackage.CreateObject("Tips", "armItem1");
	}

	public static UI_armItem1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_armItem1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9op6kp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Level = ((GComponent)this).GetController("Level");
		Status = ((GComponent)this).GetController("Status");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		PotentialIcon = (GComponent)((GComponent)this).GetChild("PotentialIcon");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		num = (GRichTextField)((GComponent)this).GetChild("num");
		string id = "ui://47lbpgx9op6kp".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		title_Max = (GRichTextField)((GComponent)this).GetChild("title_Max");
		string id2 = "ui://47lbpgx9op6kp".Replace("ui://", "") + "-" + ((GObject)title_Max).id;
		((GObject)title_Max).text = LanguagesManager.GetDesc(id2);
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id3 = "ui://47lbpgx9op6kp".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id3);
		maxIcon = (GImage)((GComponent)this).GetChild("maxIcon");
	}
}

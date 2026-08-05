using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_MissionTabBtn : GButton
{
	public Controller button;

	public Controller Type;

	public Controller SelectState;

	public GImage n14;

	public GImage n15;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GTextField day;

	public GLoader icon;

	public GGraph SfxBack;

	public GImage note;

	public GImage tick;

	public const string URL = "ui://29q48tv6gawy16";

	public static string Name = "UI_MissionTabBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy16";
	}

	public static UI_MissionTabBtn CreateInstance()
	{
		return (UI_MissionTabBtn)(object)UIPackage.CreateObject("GameActivity", "MissionTabBtn");
	}

	public static UI_MissionTabBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionTabBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		SelectState = ((GComponent)this).GetController("SelectState");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		day = (GTextField)((GComponent)this).GetChild("day");
		string id = "ui://29q48tv6gawy16".Replace("ui://", "") + "-" + ((GObject)day).id;
		((GObject)day).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		note = (GImage)((GComponent)this).GetChild("note");
		tick = (GImage)((GComponent)this).GetChild("tick");
	}
}

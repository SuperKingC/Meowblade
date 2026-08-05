using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_VideoItem : GComponent
{
	public Controller TipController;

	public Controller isShowMedal;

	public GGraph Back;

	public GList Soldiers;

	public UI_InvitationIcon HeadPortrait;

	public GTextField title;

	public GTextField Time;

	public GGraph n15;

	public GImage n11;

	public GImage n9;

	public GImage n10;

	public GGroup n17;

	public GImage n8;

	public GImage n12;

	public GList medalList;

	public const string URL = "ui://9u6qpm6pt6gc5";

	public static string Name = "UI_VideoItem";

	public static string GetURL()
	{
		return "ui://9u6qpm6pt6gc5";
	}

	public static UI_VideoItem CreateInstance()
	{
		return (UI_VideoItem)(object)UIPackage.CreateObject("Playback", "VideoItem");
	}

	public static UI_VideoItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VideoItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6pt6gc5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TipController = ((GComponent)this).GetController("TipController");
		isShowMedal = ((GComponent)this).GetController("isShowMedal");
		Back = (GGraph)((GComponent)this).GetChild("Back");
		Soldiers = (GList)((GComponent)this).GetChild("Soldiers");
		HeadPortrait = (UI_InvitationIcon)(object)((GComponent)this).GetChild("HeadPortrait");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://9u6qpm6pt6gc5".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id2 = "ui://9u6qpm6pt6gc5".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id2);
		n15 = (GGraph)((GComponent)this).GetChild("n15");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		medalList = (GList)((GComponent)this).GetChild("medalList");
	}
}

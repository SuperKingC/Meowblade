using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Video;

public class UI_btn_Reward : GButton
{
	public Controller button;

	public Controller State;

	public GImage Bg;

	public GLoader icon;

	public GTextField Count;

	public GImage n6;

	public GImage n4;

	public GMovieClip n8;

	public GImage n7;

	public GImage n9;

	public const string URL = "ui://2itu6489ezmi6";

	public static string Name = "UI_btn_Reward";

	public static string GetURL()
	{
		return "ui://2itu6489ezmi6";
	}

	public static UI_btn_Reward CreateInstance()
	{
		return (UI_btn_Reward)(object)UIPackage.CreateObject("GvG3Video", "btn_Reward");
	}

	public static UI_btn_Reward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Reward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ezmi6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}

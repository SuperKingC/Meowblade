using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_BrawlEventTip : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n6;

	public GImage n11;

	public GImage n12;

	public GImage n9;

	public GLoader n10;

	public GMovieClip n14;

	public GImage n15;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2j1htqb6sej";

	public static string Name = "UI_btn_BrawlEventTip";

	public static string GetURL()
	{
		return "ui://4eq8fgd2j1htqb6sej";
	}

	public static UI_btn_BrawlEventTip CreateInstance()
	{
		return (UI_btn_BrawlEventTip)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_BrawlEventTip");
	}

	public static UI_btn_BrawlEventTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BrawlEventTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2j1htqb6sej", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GLoader)((GComponent)this).GetChild("n10");
		n14 = (GMovieClip)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

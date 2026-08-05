using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_GVGTip_ScoreInfo : GComponent
{
	public Controller ScoreType;

	public Controller Type;

	public GLoader n1;

	public GTextField Content;

	public GTextField par;

	public GGroup n2;

	public GMovieClip n3;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrhxzyq6f";

	public static string Name = "UI_com_GVGTip_ScoreInfo";

	public static string GetURL()
	{
		return "ui://ebc4ciwrhxzyq6f";
	}

	public static UI_com_GVGTip_ScoreInfo CreateInstance()
	{
		return (UI_com_GVGTip_ScoreInfo)(object)UIPackage.CreateObject("GvGOnIsland3", "com_GVGTip_ScoreInfo");
	}

	public static UI_com_GVGTip_ScoreInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GVGTip_ScoreInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrhxzyq6f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		ScoreType = ((GComponent)this).GetController("ScoreType");
		Type = ((GComponent)this).GetController("Type");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		Content = (GTextField)((GComponent)this).GetChild("Content");
		par = (GTextField)((GComponent)this).GetChild("par");
		n2 = (GGroup)((GComponent)this).GetChild("n2");
		n3 = (GMovieClip)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

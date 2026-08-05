using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_TechCardBig : GComponent
{
	public Controller Rarity;

	public Controller State;

	public GImage n18;

	public GLoader Frame;

	public GLoader n13;

	public GImage n14;

	public GLoader TechIcon;

	public GImage n16;

	public GTextField TechName;

	public GLoader n21;

	public Transition t0;

	public const string URL = "ui://th385mttk19mo2m";

	public static string Name = "UI_com_TechCardBig";

	public static string GetURL()
	{
		return "ui://th385mttk19mo2m";
	}

	public static UI_com_TechCardBig CreateInstance()
	{
		return (UI_com_TechCardBig)(object)UIPackage.CreateObject("GvGOuterTech", "com_TechCardBig");
	}

	public static UI_com_TechCardBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TechCardBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttk19mo2m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Rarity = ((GComponent)this).GetController("Rarity");
		State = ((GComponent)this).GetController("State");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
		n13 = (GLoader)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		TechIcon = (GLoader)((GComponent)this).GetChild("TechIcon");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		TechName = (GTextField)((GComponent)this).GetChild("TechName");
		n21 = (GLoader)((GComponent)this).GetChild("n21");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

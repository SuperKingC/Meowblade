using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoulStoneBtn : GButton
{
	public Controller button;

	public Controller Level;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GImage n20;

	public GImage n21;

	public GImage n22;

	public GImage n23;

	public UI_SoulStoneIconBtn IconBtn;

	public GImage note;

	public const string URL = "ui://kt6rg65obunlt85";

	public static string Name = "UI_SoulStoneBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65obunlt85";
	}

	public static UI_SoulStoneBtn CreateInstance()
	{
		return (UI_SoulStoneBtn)(object)UIPackage.CreateObject("PublicResources", "SoulStoneBtn");
	}

	public static UI_SoulStoneBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulStoneBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65obunlt85", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Level = ((GComponent)this).GetController("Level");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		IconBtn = (UI_SoulStoneIconBtn)(object)((GComponent)this).GetChild("IconBtn");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}

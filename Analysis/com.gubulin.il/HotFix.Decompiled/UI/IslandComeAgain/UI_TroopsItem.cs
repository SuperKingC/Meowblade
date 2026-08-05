using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_TroopsItem : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GLoader FrameLoader;

	public UI_SoldierIconLoader IconLoader;

	public GImage numNote;

	public GRichTextField Amount_t;

	public GComponent SoulStoneLevel;

	public GGroup n24;

	public const string URL = "ui://k2sprg26in7b34";

	public static string Name = "UI_TroopsItem";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b34";
	}

	public static UI_TroopsItem CreateInstance()
	{
		return (UI_TroopsItem)(object)UIPackage.CreateObject("IslandComeAgain", "TroopsItem");
	}

	public static UI_TroopsItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TroopsItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (UI_SoldierIconLoader)(object)((GComponent)this).GetChild("IconLoader");
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		Amount_t = (GRichTextField)((GComponent)this).GetChild("Amount_t");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		n24 = (GGroup)((GComponent)this).GetChild("n24");
	}
}

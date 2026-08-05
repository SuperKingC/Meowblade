using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_TroopsItem : GButton
{
	public Controller button;

	public Controller Type;

	public Controller NumEnough;

	public GImage n3;

	public GLoader FrameLoader;

	public UI_com_SoldierIconLoader IconLoader;

	public GLoader lvFrame;

	public GComponent SoulStoneLevel;

	public GRichTextField Level_t;

	public GImage n37;

	public GImage numNote;

	public GRichTextField Amount_t;

	public GImage RedDot;

	public GGroup InfoGroup;

	public GGroup n24;

	public const string URL = "ui://4eq8fgd2mdde2d";

	public static string Name = "UI_com_TroopsItem";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2d";
	}

	public static UI_com_TroopsItem CreateInstance()
	{
		return (UI_com_TroopsItem)(object)UIPackage.CreateObject("GvGWorldMap3", "com_TroopsItem");
	}

	public static UI_com_TroopsItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TroopsItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		NumEnough = ((GComponent)this).GetController("NumEnough");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (UI_com_SoldierIconLoader)(object)((GComponent)this).GetChild("IconLoader");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		Level_t = (GRichTextField)((GComponent)this).GetChild("Level_t");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		Amount_t = (GRichTextField)((GComponent)this).GetChild("Amount_t");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		InfoGroup = (GGroup)((GComponent)this).GetChild("InfoGroup");
		n24 = (GGroup)((GComponent)this).GetChild("n24");
	}
}

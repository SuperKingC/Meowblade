using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_TroopItemContent : GComponent
{
	public Controller NumEnough;

	public GLoader FrameLoader;

	public UI_com_SoldierIconLoader IconLoader;

	public GLoader lvFrame;

	public GComponent SoulStoneLevel;

	public GRichTextField Level_t;

	public GImage n37;

	public GImage numNote;

	public GRichTextField Amount_t;

	public const string URL = "ui://4eq8fgd2ds7l70";

	public static string Name = "UI_com_TroopItemContent";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ds7l70";
	}

	public static UI_com_TroopItemContent CreateInstance()
	{
		return (UI_com_TroopItemContent)(object)UIPackage.CreateObject("GvGWorldMap3", "com_TroopItemContent");
	}

	public static UI_com_TroopItemContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TroopItemContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ds7l70", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		NumEnough = ((GComponent)this).GetController("NumEnough");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (UI_com_SoldierIconLoader)(object)((GComponent)this).GetChild("IconLoader");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
		Level_t = (GRichTextField)((GComponent)this).GetChild("Level_t");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		Amount_t = (GRichTextField)((GComponent)this).GetChild("Amount_t");
	}
}

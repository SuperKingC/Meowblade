using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_soldierItem : GButton
{
	public Controller button;

	public Controller RedPointController;

	public GImage background;

	public GLoader iconFrame;

	public GLoader icon;

	public UI_SoliderSoulStoneLevel SoulStoneLevel;

	public UI_racePicture racePicture;

	public GImage newIcon;

	public GImage n47;

	public const string URL = "ui://kt6rg65of4sztic";

	public static string Name = "UI_soldierItem";

	public static string GetURL()
	{
		return "ui://kt6rg65of4sztic";
	}

	public static UI_soldierItem CreateInstance()
	{
		return (UI_soldierItem)(object)UIPackage.CreateObject("PublicResources", "soldierItem");
	}

	public static UI_soldierItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_soldierItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65of4sztic", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RedPointController = ((GComponent)this).GetController("RedPointController");
		background = (GImage)((GComponent)this).GetChild("background");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SoulStoneLevel = (UI_SoliderSoulStoneLevel)(object)((GComponent)this).GetChild("SoulStoneLevel");
		racePicture = (UI_racePicture)(object)((GComponent)this).GetChild("racePicture");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		n47 = (GImage)((GComponent)this).GetChild("n47");
	}
}

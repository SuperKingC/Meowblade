using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_SoldierIconOnTouch : GComponent
{
	public GImage soldierIconBack;

	public GLoader iconFrame;

	public GLoader icon;

	public GComponent SoulStoneLevel;

	public const string URL = "ui://0i520nzmb529o7w";

	public static string Name = "UI_SoldierIconOnTouch";

	public static string GetURL()
	{
		return "ui://0i520nzmb529o7w";
	}

	public static UI_SoldierIconOnTouch CreateInstance()
	{
		return (UI_SoldierIconOnTouch)(object)UIPackage.CreateObject("LordOfDreams", "SoldierIconOnTouch");
	}

	public static UI_SoldierIconOnTouch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierIconOnTouch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmb529o7w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		soldierIconBack = (GImage)((GComponent)this).GetChild("soldierIconBack");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
	}
}

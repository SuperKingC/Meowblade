using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_SoldierTab : GButton
{
	public Controller button;

	public Controller IsSelected;

	public Controller IsUnlocked;

	public GLoader Light;

	public GLoader Dark;

	public GImage Mask;

	public GImage RedDot;

	public GImage AllClaimedIcon;

	public const string URL = "ui://29q48tv6u85j5b";

	public static string Name = "UI_SoldierTab";

	public static string GetURL()
	{
		return "ui://29q48tv6u85j5b";
	}

	public static UI_SoldierTab CreateInstance()
	{
		return (UI_SoldierTab)(object)UIPackage.CreateObject("GameActivity", "SoldierTab");
	}

	public static UI_SoldierTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6u85j5b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsSelected = ((GComponent)this).GetController("IsSelected");
		IsUnlocked = ((GComponent)this).GetController("IsUnlocked");
		Light = (GLoader)((GComponent)this).GetChild("Light");
		Dark = (GLoader)((GComponent)this).GetChild("Dark");
		Mask = (GImage)((GComponent)this).GetChild("Mask");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		AllClaimedIcon = (GImage)((GComponent)this).GetChild("AllClaimedIcon");
	}
}

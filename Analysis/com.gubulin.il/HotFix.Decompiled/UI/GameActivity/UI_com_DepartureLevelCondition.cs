using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_DepartureLevelCondition : GComponent
{
	public Controller LevelState;

	public Controller NodeType;

	public GImage n8;

	public GImage n2;

	public GImage n3;

	public GGroup n6;

	public GImage n7;

	public GTextField UnlockTitle;

	public const string URL = "ui://29q48tv6jorqaz";

	public static string Name = "UI_com_DepartureLevelCondition";

	public static string GetURL()
	{
		return "ui://29q48tv6jorqaz";
	}

	public static UI_com_DepartureLevelCondition CreateInstance()
	{
		return (UI_com_DepartureLevelCondition)(object)UIPackage.CreateObject("GameActivity", "com_DepartureLevelCondition");
	}

	public static UI_com_DepartureLevelCondition CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DepartureLevelCondition).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6jorqaz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		LevelState = ((GComponent)this).GetController("LevelState");
		NodeType = ((GComponent)this).GetController("NodeType");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		UnlockTitle = (GTextField)((GComponent)this).GetChild("UnlockTitle");
	}
}

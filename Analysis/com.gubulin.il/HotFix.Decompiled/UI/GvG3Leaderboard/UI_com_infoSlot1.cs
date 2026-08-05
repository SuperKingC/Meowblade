using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_infoSlot1 : GComponent
{
	public GImage n210;

	public GImage n211;

	public GTextField Title;

	public GLoader LevelIcon;

	public GTextField LevelText;

	public const string URL = "ui://ylvfgf90cbjb6q";

	public static string Name = "UI_com_infoSlot1";

	public static string GetURL()
	{
		return "ui://ylvfgf90cbjb6q";
	}

	public static UI_com_infoSlot1 CreateInstance()
	{
		return (UI_com_infoSlot1)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_infoSlot1");
	}

	public static UI_com_infoSlot1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_infoSlot1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90cbjb6q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n210 = (GImage)((GComponent)this).GetChild("n210");
		n211 = (GImage)((GComponent)this).GetChild("n211");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		LevelText = (GTextField)((GComponent)this).GetChild("LevelText");
	}
}

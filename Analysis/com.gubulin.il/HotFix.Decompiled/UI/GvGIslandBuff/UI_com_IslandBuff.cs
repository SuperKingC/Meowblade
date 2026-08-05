using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_com_IslandBuff : GComponent
{
	public Controller IsDebuff;

	public Controller WithBuffName;

	public GComponent icon;

	public GImage n0;

	public GImage n1;

	public GTextField LvNum;

	public GTextField AbName;

	public const string URL = "ui://zh7jgfijnewqfm";

	public static string Name = "UI_com_IslandBuff";

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqfm";
	}

	public static UI_com_IslandBuff CreateInstance()
	{
		return (UI_com_IslandBuff)(object)UIPackage.CreateObject("GvGIslandBuff", "com_IslandBuff");
	}

	public static UI_com_IslandBuff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandBuff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		IsDebuff = ((GComponent)this).GetController("IsDebuff");
		WithBuffName = ((GComponent)this).GetController("WithBuffName");
		icon = (GComponent)((GComponent)this).GetChild("icon");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		LvNum = (GTextField)((GComponent)this).GetChild("LvNum");
		AbName = (GTextField)((GComponent)this).GetChild("AbName");
	}
}

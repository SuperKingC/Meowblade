using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_btn_Daychange : GButton
{
	public Controller button;

	public Controller status;

	public Controller note;

	public GImage n7;

	public GImage n0;

	public GTextField blur_DayNum;

	public GGroup blurDIsplay;

	public GImage n1;

	public GTextField focus_DayNum;

	public GGroup focusDisplay;

	public GImage n8;

	public const string URL = "ui://29q48tv6hvfx83";

	public static string Name = "UI_btn_Daychange";

	public static string GetURL()
	{
		return "ui://29q48tv6hvfx83";
	}

	public static UI_btn_Daychange CreateInstance()
	{
		return (UI_btn_Daychange)(object)UIPackage.CreateObject("GameActivity", "btn_Daychange");
	}

	public static UI_btn_Daychange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Daychange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hvfx83", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		status = ((GComponent)this).GetController("status");
		note = ((GComponent)this).GetController("note");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		blur_DayNum = (GTextField)((GComponent)this).GetChild("blur_DayNum");
		blurDIsplay = (GGroup)((GComponent)this).GetChild("blurDIsplay");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		focus_DayNum = (GTextField)((GComponent)this).GetChild("focus_DayNum");
		focusDisplay = (GGroup)((GComponent)this).GetChild("focusDisplay");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_boundBtn : GButton
{
	public Controller button;

	public Controller Status;

	public Controller hasMsg;

	public GImage back;

	public GLoader icon;

	public GMovieClip n6;

	public GImage note;

	public GImage n7;

	public const string URL = "ui://b9yxt7u0t1jr2";

	public static string Name = "UI_boundBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jr2";
	}

	public static UI_boundBtn CreateInstance()
	{
		return (UI_boundBtn)(object)UIPackage.CreateObject("AccountInfo", "boundBtn");
	}

	public static UI_boundBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_boundBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jr2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Status = ((GComponent)this).GetController("Status");
		hasMsg = ((GComponent)this).GetController("hasMsg");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n6 = (GMovieClip)((GComponent)this).GetChild("n6");
		note = (GImage)((GComponent)this).GetChild("note");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}

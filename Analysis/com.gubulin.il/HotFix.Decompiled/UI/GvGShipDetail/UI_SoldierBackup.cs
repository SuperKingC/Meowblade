using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_SoldierBackup : GButton
{
	public Controller button;

	public Controller Type;

	public Controller hasOuterTech;

	public GImage n9;

	public GLoader back;

	public UI_soliderItem Icon;

	public GTextField num;

	public GImage n7;

	public GTextField SoldierName;

	public UI_com_BuffsTip BuffsTip;

	public Transition Disappear;

	public Transition ShowInfo;

	public Transition Breathe;

	public Transition Red;

	public const string URL = "ui://u6x0b1gnfdarz";

	public static string Name = "UI_SoldierBackup";

	public static string GetURL()
	{
		return "ui://u6x0b1gnfdarz";
	}

	public static UI_SoldierBackup CreateInstance()
	{
		return (UI_SoldierBackup)(object)UIPackage.CreateObject("GvGShipDetail", "SoldierBackup");
	}

	public static UI_SoldierBackup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierBackup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnfdarz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		back = (GLoader)((GComponent)this).GetChild("back");
		Icon = (UI_soliderItem)(object)((GComponent)this).GetChild("Icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		SoldierName = (GTextField)((GComponent)this).GetChild("SoldierName");
		BuffsTip = (UI_com_BuffsTip)(object)((GComponent)this).GetChild("BuffsTip");
		Disappear = ((GComponent)this).GetTransition("Disappear");
		ShowInfo = ((GComponent)this).GetTransition("ShowInfo");
		Breathe = ((GComponent)this).GetTransition("Breathe");
		Red = ((GComponent)this).GetTransition("Red");
	}
}

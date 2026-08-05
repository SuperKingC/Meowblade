using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_SoldierFormation : GButton
{
	public Controller button;

	public Controller Type;

	public GLoader back;

	public UI_btn_soliderItem Icon;

	public GTextField num;

	public GImage n7;

	public Transition Disappear;

	public Transition ShowInfo;

	public Transition Breathe;

	public const string URL = "ui://b3fc6085stwvv";

	public static string Name = "UI_btn_SoldierFormation";

	public static string GetURL()
	{
		return "ui://b3fc6085stwvv";
	}

	public static UI_btn_SoldierFormation CreateInstance()
	{
		return (UI_btn_SoldierFormation)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_SoldierFormation");
	}

	public static UI_btn_SoldierFormation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SoldierFormation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwvv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		back = (GLoader)((GComponent)this).GetChild("back");
		Icon = (UI_btn_soliderItem)(object)((GComponent)this).GetChild("Icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://b3fc6085stwvv".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Disappear = ((GComponent)this).GetTransition("Disappear");
		ShowInfo = ((GComponent)this).GetTransition("ShowInfo");
		Breathe = ((GComponent)this).GetTransition("Breathe");
	}
}

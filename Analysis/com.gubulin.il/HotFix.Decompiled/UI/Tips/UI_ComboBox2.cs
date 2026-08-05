using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ComboBox2 : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Type;

	public GGraph back;

	public GImage arrow;

	public GTextField name;

	public GLoader icon;

	public UI_WorkNum num;

	public UI_ComboList ComboList;

	public Transition disappear;

	public const string URL = "ui://47lbpgx9yzxz3o";

	public static string Name = "UI_ComboBox2";

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3o";
	}

	public static UI_ComboBox2 CreateInstance()
	{
		return (UI_ComboBox2)(object)UIPackage.CreateObject("Tips", "ComboBox2");
	}

	public static UI_ComboBox2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComboBox2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		back = (GGraph)((GComponent)this).GetChild("back");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://47lbpgx9yzxz3o".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (UI_WorkNum)(object)((GComponent)this).GetChild("num");
		ComboList = (UI_ComboList)(object)((GComponent)this).GetChild("ComboList");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}

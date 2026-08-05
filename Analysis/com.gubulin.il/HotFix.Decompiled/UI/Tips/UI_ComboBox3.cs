using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ComboBox3 : GButton
{
	public Controller button;

	public Controller Type;

	public GTextField name;

	public GLoader icon;

	public UI_WorkNum num;

	public UI_MinusBtn MinusBtn;

	public Transition disappear;

	public const string URL = "ui://47lbpgx9yzxz3q";

	public static string Name = "UI_ComboBox3";

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3q";
	}

	public static UI_ComboBox3 CreateInstance()
	{
		return (UI_ComboBox3)(object)UIPackage.CreateObject("Tips", "ComboBox3");
	}

	public static UI_ComboBox3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComboBox3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://47lbpgx9yzxz3q".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (UI_WorkNum)(object)((GComponent)this).GetChild("num");
		MinusBtn = (UI_MinusBtn)(object)((GComponent)this).GetChild("MinusBtn");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}

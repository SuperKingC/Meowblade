using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ComboBoxItem : GButton
{
	public Controller button;

	public GTextField name;

	public GLoader icon;

	public UI_WorkNum num;

	public UI_MinusBtn MinusBtn;

	public Transition disappear;

	public const string URL = "ui://47lbpgx9yzxz3s";

	public static string Name = "UI_ComboBoxItem";

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3s";
	}

	public static UI_ComboBoxItem CreateInstance()
	{
		return (UI_ComboBoxItem)(object)UIPackage.CreateObject("Tips", "ComboBoxItem");
	}

	public static UI_ComboBoxItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ComboBoxItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://47lbpgx9yzxz3s".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (UI_WorkNum)(object)((GComponent)this).GetChild("num");
		MinusBtn = (UI_MinusBtn)(object)((GComponent)this).GetChild("MinusBtn");
		disappear = ((GComponent)this).GetTransition("disappear");
	}
}

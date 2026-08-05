using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_DefaultMessage : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n5;

	public GTextField Desc;

	public GTextField Desc2;

	public const string URL = "ui://vheg8vabeai3a";

	public static string Name = "UI_btn_DefaultMessage";

	public static string GetURL()
	{
		return "ui://vheg8vabeai3a";
	}

	public static UI_btn_DefaultMessage CreateInstance()
	{
		return (UI_btn_DefaultMessage)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_DefaultMessage");
	}

	public static UI_btn_DefaultMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DefaultMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		string id = "ui://vheg8vabeai3a".Replace("ui://", "") + "-" + ((GObject)Desc).id;
		((GObject)Desc).text = LanguagesManager.GetDesc(id);
		Desc2 = (GTextField)((GComponent)this).GetChild("Desc2");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_CancelCommand : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://vheg8vabeai34";

	public static string Name = "UI_btn_CancelCommand";

	public static string GetURL()
	{
		return "ui://vheg8vabeai34";
	}

	public static UI_btn_CancelCommand CreateInstance()
	{
		return (UI_btn_CancelCommand)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_CancelCommand");
	}

	public static UI_btn_CancelCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CancelCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://vheg8vabeai34".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}

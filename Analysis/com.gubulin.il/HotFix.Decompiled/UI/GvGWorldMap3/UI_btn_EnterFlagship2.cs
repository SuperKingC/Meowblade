using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_EnterFlagship2 : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n5;

	public GImage n4;

	public GImage n6;

	public GTextField CoolDown;

	public const string URL = "ui://4eq8fgd2d0fus9t";

	public static string Name = "UI_btn_EnterFlagship2";

	public static string GetURL()
	{
		return "ui://4eq8fgd2d0fus9t";
	}

	public static UI_btn_EnterFlagship2 CreateInstance()
	{
		return (UI_btn_EnterFlagship2)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_EnterFlagship2");
	}

	public static UI_btn_EnterFlagship2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_EnterFlagship2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2d0fus9t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		CoolDown = (GTextField)((GComponent)this).GetChild("CoolDown");
		string id = "ui://4eq8fgd2d0fus9t".Replace("ui://", "") + "-" + ((GObject)CoolDown).id;
		((GObject)CoolDown).text = LanguagesManager.GetDesc(id);
	}
}

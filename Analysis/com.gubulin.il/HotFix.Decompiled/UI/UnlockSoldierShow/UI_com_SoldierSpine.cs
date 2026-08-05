using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_com_SoldierSpine : GComponent
{
	public GImage n76;

	public GGraph Spine;

	public const string URL = "ui://ia1am3ehbutlt20";

	public static string Name = "UI_com_SoldierSpine";

	public static string GetURL()
	{
		return "ui://ia1am3ehbutlt20";
	}

	public static UI_com_SoldierSpine CreateInstance()
	{
		return (UI_com_SoldierSpine)(object)UIPackage.CreateObject("UnlockSoldierShow", "com_SoldierSpine");
	}

	public static UI_com_SoldierSpine CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SoldierSpine).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehbutlt20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n76 = (GImage)((GComponent)this).GetChild("n76");
		Spine = (GGraph)((GComponent)this).GetChild("Spine");
	}
}

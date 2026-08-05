using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_BigRecordsFilter2 : GButton
{
	public Controller button;

	public GImage n5;

	public GImage back;

	public GImage n2;

	public GImage n3;

	public GList Menu;

	public UI_com_RecordsFilter2 CurrentSelected;

	public const string URL = "ui://b3fc6085iaoi2x";

	public static string Name = "UI_com_BigRecordsFilter2";

	public static string GetURL()
	{
		return "ui://b3fc6085iaoi2x";
	}

	public static UI_com_BigRecordsFilter2 CreateInstance()
	{
		return (UI_com_BigRecordsFilter2)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_BigRecordsFilter2");
	}

	public static UI_com_BigRecordsFilter2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BigRecordsFilter2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085iaoi2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		back = (GImage)((GComponent)this).GetChild("back");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Menu = (GList)((GComponent)this).GetChild("Menu");
		CurrentSelected = (UI_com_RecordsFilter2)(object)((GComponent)this).GetChild("CurrentSelected");
	}
}

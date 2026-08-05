using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_btn_LegendItemLock : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n6;

	public GImage n7;

	public GTextField Title;

	public const string URL = "ui://lzvt5p2vaz6vh";

	public static string Name = "UI_btn_LegendItemLock";

	public static string GetURL()
	{
		return "ui://lzvt5p2vaz6vh";
	}

	public static UI_btn_LegendItemLock CreateInstance()
	{
		return (UI_btn_LegendItemLock)(object)UIPackage.CreateObject("LegendItemInfo", "btn_LegendItemLock");
	}

	public static UI_btn_LegendItemLock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LegendItemLock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vaz6vh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://lzvt5p2vaz6vh".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}
}

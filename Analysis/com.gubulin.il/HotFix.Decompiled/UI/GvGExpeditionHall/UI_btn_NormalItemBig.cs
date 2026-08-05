using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_NormalItemBig : GButton
{
	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public GTextField ItemName;

	public const string URL = "ui://k19peou7nroy3f";

	public static string Name = "UI_btn_NormalItemBig";

	public static string GetURL()
	{
		return "ui://k19peou7nroy3f";
	}

	public static UI_btn_NormalItemBig CreateInstance()
	{
		return (UI_btn_NormalItemBig)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_NormalItemBig");
	}

	public static UI_btn_NormalItemBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_NormalItemBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7nroy3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
	}
}

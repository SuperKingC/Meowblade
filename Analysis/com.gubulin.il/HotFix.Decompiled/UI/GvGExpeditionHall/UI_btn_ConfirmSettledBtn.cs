using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_ConfirmSettledBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n126;

	public GImage n122;

	public GLoader icon;

	public const string URL = "ui://k19peou7p3r7p61";

	public static string Name = "UI_btn_ConfirmSettledBtn";

	public static string GetURL()
	{
		return "ui://k19peou7p3r7p61";
	}

	public static UI_btn_ConfirmSettledBtn CreateInstance()
	{
		return (UI_btn_ConfirmSettledBtn)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_ConfirmSettledBtn");
	}

	public static UI_btn_ConfirmSettledBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmSettledBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7p3r7p61", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		n126 = (GImage)((GComponent)this).GetChild("n126");
		n122 = (GImage)((GComponent)this).GetChild("n122");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}

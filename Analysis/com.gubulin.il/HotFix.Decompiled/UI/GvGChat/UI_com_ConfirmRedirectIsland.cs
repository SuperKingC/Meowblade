using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_ConfirmRedirectIsland : GComponent
{
	public GImage back;

	public UI_btn_Confirm Confirm;

	public UI_btn_Cancel Cancel;

	public GRichTextField Tip;

	public const string URL = "ui://e3rxkbaprb0j12";

	public static string Name = "UI_com_ConfirmRedirectIsland";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0j12";
	}

	public static UI_com_ConfirmRedirectIsland CreateInstance()
	{
		return (UI_com_ConfirmRedirectIsland)(object)UIPackage.CreateObject("GvGChat", "com_ConfirmRedirectIsland");
	}

	public static UI_com_ConfirmRedirectIsland CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ConfirmRedirectIsland).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Confirm = (UI_btn_Confirm)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
		Tip = (GRichTextField)((GComponent)this).GetChild("Tip");
	}
}

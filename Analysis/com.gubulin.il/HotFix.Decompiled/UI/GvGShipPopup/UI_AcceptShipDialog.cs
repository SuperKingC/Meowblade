using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_AcceptShipDialog : GComponent
{
	public GImage n111;

	public GImage n133;

	public UI_com_AcceptShipBg Content;

	public GImage n130;

	public GTextField AcceptText;

	public UI_ConfirmAcceptBtn ConfirmAcceptBtn;

	public GTextField Count;

	public const string URL = "ui://pwrbvhpvnbpu3r";

	public static string Name = "UI_AcceptShipDialog";

	public static string GetURL()
	{
		return "ui://pwrbvhpvnbpu3r";
	}

	public static UI_AcceptShipDialog CreateInstance()
	{
		return (UI_AcceptShipDialog)(object)UIPackage.CreateObject("GvGShipPopup", "AcceptShipDialog");
	}

	public static UI_AcceptShipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AcceptShipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvnbpu3r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		Content = (UI_com_AcceptShipBg)(object)((GComponent)this).GetChild("Content");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		AcceptText = (GTextField)((GComponent)this).GetChild("AcceptText");
		ConfirmAcceptBtn = (UI_ConfirmAcceptBtn)(object)((GComponent)this).GetChild("ConfirmAcceptBtn");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}

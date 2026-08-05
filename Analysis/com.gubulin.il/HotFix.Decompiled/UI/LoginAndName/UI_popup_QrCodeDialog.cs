using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_popup_QrCodeDialog : GComponent
{
	public GGraph mask;

	public GLoader QrCode;

	public GTextField Tips;

	public const string URL = "ui://yb3s7uv7pnzr5y";

	public static string Name = "UI_popup_QrCodeDialog";

	public static string GetURL()
	{
		return "ui://yb3s7uv7pnzr5y";
	}

	public static UI_popup_QrCodeDialog CreateInstance()
	{
		return (UI_popup_QrCodeDialog)(object)UIPackage.CreateObject("LoginAndName", "popup_QrCodeDialog");
	}

	public static UI_popup_QrCodeDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_QrCodeDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7pnzr5y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		QrCode = (GLoader)((GComponent)this).GetChild("QrCode");
		Tips = (GTextField)((GComponent)this).GetChild("Tips");
		string id = "ui://yb3s7uv7pnzr5y".Replace("ui://", "") + "-" + ((GObject)Tips).id;
		((GObject)Tips).text = LanguagesManager.GetDesc(id);
	}
}

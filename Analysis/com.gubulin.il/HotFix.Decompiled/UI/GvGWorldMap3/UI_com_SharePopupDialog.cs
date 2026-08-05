using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SharePopupDialog : GComponent
{
	public Controller IsShowChecker;

	public GImage back;

	public GTextField n13;

	public GTextField Message;

	public UI_com_ShareInfoChecker ShareInfoChecker;

	public GTextField n14;

	public GTextField n16;

	public UI_btn_ConfirmShare ConfirmBtn;

	public const string URL = "ui://4eq8fgd2614qf6";

	public static string Name = "UI_com_SharePopupDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2614qf6";
	}

	public static UI_com_SharePopupDialog CreateInstance()
	{
		return (UI_com_SharePopupDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SharePopupDialog");
	}

	public static UI_com_SharePopupDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SharePopupDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2614qf6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowChecker = ((GComponent)this).GetController("IsShowChecker");
		back = (GImage)((GComponent)this).GetChild("back");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://4eq8fgd2614qf6".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		Message = (GTextField)((GComponent)this).GetChild("Message");
		string id2 = "ui://4eq8fgd2614qf6".Replace("ui://", "") + "-" + ((GObject)Message).id;
		((GObject)Message).text = LanguagesManager.GetDesc(id2);
		ShareInfoChecker = (UI_com_ShareInfoChecker)(object)((GComponent)this).GetChild("ShareInfoChecker");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id3 = "ui://4eq8fgd2614qf6".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id3);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id4 = "ui://4eq8fgd2614qf6".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id4);
		ConfirmBtn = (UI_btn_ConfirmShare)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}

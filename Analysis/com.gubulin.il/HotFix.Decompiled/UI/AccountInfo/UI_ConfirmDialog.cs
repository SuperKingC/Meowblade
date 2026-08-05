using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ConfirmDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GGraph SpineBack;

	public GImage n30;

	public GImage n31;

	public GTextField Content;

	public GGroup n33;

	public UI_receiveBtn receiveBtn;

	public UI_TakeItemContent Item;

	public const string URL = "ui://b9yxt7u0t1jrg";

	public static string Name = "UI_ConfirmDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jrg";
	}

	public static UI_ConfirmDialog CreateInstance()
	{
		return (UI_ConfirmDialog)(object)UIPackage.CreateObject("AccountInfo", "ConfirmDialog");
	}

	public static UI_ConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jrg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		Content = (GTextField)((GComponent)this).GetChild("Content");
		string id = "ui://b9yxt7u0t1jrg".Replace("ui://", "") + "-" + ((GObject)Content).id;
		((GObject)Content).text = LanguagesManager.GetDesc(id);
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		receiveBtn = (UI_receiveBtn)(object)((GComponent)this).GetChild("receiveBtn");
		Item = (UI_TakeItemContent)(object)((GComponent)this).GetChild("Item");
	}

	public void SetTypeControllerPageText(int pageIndex)
	{
		string id = string.Format("{0}-{1}-{2}", "ui://b9yxt7u0t1jrg".Replace("ui://", ""), ((GObject)Content).id, pageIndex);
		((GObject)Content).text = LanguagesManager.GetDesc(id);
		((GObject)receiveBtn.title).text = LanguagesManager.GetDesc("AccountInfo-ConfirmDialog-receiveBtn-title");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Restart;

public class UI_ConfirmDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GGraph SpineBack;

	public GImage n30;

	public GImage n31;

	public GTextField Content;

	public GGroup n33;

	public GGroup n41;

	public GTextField n40;

	public UI_RefreshCardConfirmBtn RefreshCardBtn;

	public UI_DialogMiddleContent DialogMiddleContent;

	public GTextField freeText;

	public const string URL = "ui://5mgjx17ngb511";

	public static string Name = "UI_ConfirmDialog";

	public static string GetURL()
	{
		return "ui://5mgjx17ngb511";
	}

	public static UI_ConfirmDialog CreateInstance()
	{
		return (UI_ConfirmDialog)(object)UIPackage.CreateObject("Restart", "ConfirmDialog");
	}

	public static UI_ConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5mgjx17ngb511", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		Content = (GTextField)((GComponent)this).GetChild("Content");
		string id = "ui://5mgjx17ngb511".Replace("ui://", "") + "-" + ((GObject)Content).id;
		((GObject)Content).text = LanguagesManager.GetDesc(id);
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		n41 = (GGroup)((GComponent)this).GetChild("n41");
		n40 = (GTextField)((GComponent)this).GetChild("n40");
		string id2 = "ui://5mgjx17ngb511".Replace("ui://", "") + "-" + ((GObject)n40).id;
		((GObject)n40).text = LanguagesManager.GetDesc(id2);
		RefreshCardBtn = (UI_RefreshCardConfirmBtn)(object)((GComponent)this).GetChild("RefreshCardBtn");
		DialogMiddleContent = (UI_DialogMiddleContent)(object)((GComponent)this).GetChild("DialogMiddleContent");
		freeText = (GTextField)((GComponent)this).GetChild("freeText");
		string id3 = "ui://5mgjx17ngb511".Replace("ui://", "") + "-" + ((GObject)freeText).id;
		((GObject)freeText).text = LanguagesManager.GetDesc(id3);
	}
}

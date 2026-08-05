using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_DO_ListHeader : GComponent
{
	public UI_selected IsShowActivated;

	public GTextField ShowActivatedText;

	public GLoader CurrencyIcon;

	public GTextField CurrencyCount;

	public const string URL = "ui://b9yxt7u0qjbr3l";

	public static string Name = "UI_DO_ListHeader";

	public static string GetURL()
	{
		return "ui://b9yxt7u0qjbr3l";
	}

	public static UI_DO_ListHeader CreateInstance()
	{
		return (UI_DO_ListHeader)(object)UIPackage.CreateObject("AccountInfo", "DO_ListHeader");
	}

	public static UI_DO_ListHeader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DO_ListHeader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0qjbr3l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowActivated = (UI_selected)(object)((GComponent)this).GetChild("IsShowActivated");
		ShowActivatedText = (GTextField)((GComponent)this).GetChild("ShowActivatedText");
		string id = "ui://b9yxt7u0qjbr3l".Replace("ui://", "") + "-" + ((GObject)ShowActivatedText).id;
		((GObject)ShowActivatedText).text = LanguagesManager.GetDesc(id);
		CurrencyIcon = (GLoader)((GComponent)this).GetChild("CurrencyIcon");
		CurrencyCount = (GTextField)((GComponent)this).GetChild("CurrencyCount");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_BuyDialog : GComponent
{
	public Controller BuyControl;

	public GImage Buy_Mask;

	public UI_Buy_Exit Buy_Exit;

	public GTextField Buy_Message;

	public GTextField Buy_Title;

	public UI_BuyBtn Buy_BuyBtn;

	public const string URL = "ui://b9yxt7u0qjbr3m";

	public static string Name = "UI_BuyDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0qjbr3m";
	}

	public static UI_BuyDialog CreateInstance()
	{
		return (UI_BuyDialog)(object)UIPackage.CreateObject("AccountInfo", "BuyDialog");
	}

	public static UI_BuyDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuyDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0qjbr3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BuyControl = ((GComponent)this).GetController("BuyControl");
		Buy_Mask = (GImage)((GComponent)this).GetChild("Buy_Mask");
		Buy_Exit = (UI_Buy_Exit)(object)((GComponent)this).GetChild("Buy_Exit");
		Buy_Message = (GTextField)((GComponent)this).GetChild("Buy_Message");
		string id = "ui://b9yxt7u0qjbr3m".Replace("ui://", "") + "-" + ((GObject)Buy_Message).id;
		((GObject)Buy_Message).text = LanguagesManager.GetDesc(id);
		Buy_Title = (GTextField)((GComponent)this).GetChild("Buy_Title");
		string id2 = "ui://b9yxt7u0qjbr3m".Replace("ui://", "") + "-" + ((GObject)Buy_Title).id;
		((GObject)Buy_Title).text = LanguagesManager.GetDesc(id2);
		Buy_BuyBtn = (UI_BuyBtn)(object)((GComponent)this).GetChild("Buy_BuyBtn");
	}
}

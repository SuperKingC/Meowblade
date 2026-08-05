using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_exchangeBtn : GButton
{
	public Controller button;

	public Controller decorate;

	public GImage back;

	public GLoader icon;

	public GTextField n7;

	public const string URL = "ui://b9yxt7u0t1jr4";

	public static string Name = "UI_exchangeBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jr4";
	}

	public static UI_exchangeBtn CreateInstance()
	{
		return (UI_exchangeBtn)(object)UIPackage.CreateObject("AccountInfo", "exchangeBtn");
	}

	public static UI_exchangeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_exchangeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jr4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		decorate = ((GComponent)this).GetController("decorate");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://b9yxt7u0t1jr4".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
	}
}

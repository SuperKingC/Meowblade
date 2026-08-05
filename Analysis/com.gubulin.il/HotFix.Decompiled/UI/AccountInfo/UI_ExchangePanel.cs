using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ExchangePanel : GComponent
{
	public GGraph mask;

	public UI_ExchangeDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://b9yxt7u0f4szy";

	public static string Name = "UI_ExchangePanel";

	public static string GetURL()
	{
		return "ui://b9yxt7u0f4szy";
	}

	public static UI_ExchangePanel CreateInstance()
	{
		return (UI_ExchangePanel)(object)UIPackage.CreateObject("AccountInfo", "ExchangePanel");
	}

	public static UI_ExchangePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExchangePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0f4szy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ExchangeDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}

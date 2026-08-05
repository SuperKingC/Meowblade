using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_BuyPanel : GComponent
{
	public GGraph Mask;

	public UI_BuyDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://b9yxt7u0qjbr3n";

	public static string Name = "UI_BuyPanel";

	public static string GetURL()
	{
		return "ui://b9yxt7u0qjbr3n";
	}

	public static UI_BuyPanel CreateInstance()
	{
		return (UI_BuyPanel)(object)UIPackage.CreateObject("AccountInfo", "BuyPanel");
	}

	public static UI_BuyPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuyPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0qjbr3n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_BuyDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}
}

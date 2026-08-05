using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ExchangeBtn : GButton
{
	public Controller button;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://82mo10n5t7wpde7";

	public static string Name = "UI_ExchangeBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpde7";
	}

	public static UI_ExchangeBtn CreateInstance()
	{
		return (UI_ExchangeBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ExchangeBtn");
	}

	public static UI_ExchangeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExchangeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpde7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://82mo10n5t7wpde7".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}

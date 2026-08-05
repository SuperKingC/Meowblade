using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ReadMore : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public GTextField n6;

	public const string URL = "ui://82mo10n5uk8wb5";

	public static string Name = "UI_ReadMore";

	public static string GetURL()
	{
		return "ui://82mo10n5uk8wb5";
	}

	public static UI_ReadMore CreateInstance()
	{
		return (UI_ReadMore)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ReadMore");
	}

	public static UI_ReadMore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReadMore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uk8wb5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://82mo10n5uk8wb5".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
	}
}

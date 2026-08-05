using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_GotoBtn : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField n6;

	public const string URL = "ui://11dkggb8dhmu38";

	public static string Name = "UI_GotoBtn";

	public static string GetURL()
	{
		return "ui://11dkggb8dhmu38";
	}

	public static UI_GotoBtn CreateInstance()
	{
		return (UI_GotoBtn)(object)UIPackage.CreateObject("WeekActivityPass", "GotoBtn");
	}

	public static UI_GotoBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GotoBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8dhmu38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://11dkggb8dhmu38".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
	}
}

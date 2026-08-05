using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_CountdownBtn : GButton
{
	public Controller button;

	public GGraph back;

	public GTextField timeTip;

	public const string URL = "ui://82mo10n5qxbi7o";

	public static string Name = "UI_CountdownBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5qxbi7o";
	}

	public static UI_CountdownBtn CreateInstance()
	{
		return (UI_CountdownBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "CountdownBtn");
	}

	public static UI_CountdownBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CountdownBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5qxbi7o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GGraph)((GComponent)this).GetChild("back");
		timeTip = (GTextField)((GComponent)this).GetChild("timeTip");
	}
}

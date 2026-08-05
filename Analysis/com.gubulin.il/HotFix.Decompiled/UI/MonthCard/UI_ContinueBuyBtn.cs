using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_ContinueBuyBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GImage back;

	public GGraph SfxBack;

	public GImage n10;

	public const string URL = "ui://4ctl553sfq9ez";

	public static string Name = "UI_ContinueBuyBtn";

	public static string GetURL()
	{
		return "ui://4ctl553sfq9ez";
	}

	public static UI_ContinueBuyBtn CreateInstance()
	{
		return (UI_ContinueBuyBtn)(object)UIPackage.CreateObject("MonthCard", "ContinueBuyBtn");
	}

	public static UI_ContinueBuyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ContinueBuyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sfq9ez", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}

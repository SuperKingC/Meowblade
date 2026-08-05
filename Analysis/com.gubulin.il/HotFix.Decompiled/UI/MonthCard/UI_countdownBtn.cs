using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MonthCard;

public class UI_countdownBtn : GComponent
{
	public Controller Status;

	public Controller RarityController;

	public GTextField tip3rd;

	public GTextField time1;

	public GTextField time2;

	public GGroup n6;

	public Transition shakeTime2;

	public const string URL = "ui://4ctl553sazqa10";

	public static string Name = "UI_countdownBtn";

	public static string GetURL()
	{
		return "ui://4ctl553sazqa10";
	}

	public static UI_countdownBtn CreateInstance()
	{
		return (UI_countdownBtn)(object)UIPackage.CreateObject("MonthCard", "countdownBtn");
	}

	public static UI_countdownBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_countdownBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553sazqa10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		RarityController = ((GComponent)this).GetController("RarityController");
		tip3rd = (GTextField)((GComponent)this).GetChild("tip3rd");
		string id = "ui://4ctl553sazqa10".Replace("ui://", "") + "-" + ((GObject)tip3rd).id;
		((GObject)tip3rd).text = LanguagesManager.GetDesc(id);
		time1 = (GTextField)((GComponent)this).GetChild("time1");
		string id2 = "ui://4ctl553sazqa10".Replace("ui://", "") + "-" + ((GObject)time1).id;
		((GObject)time1).text = LanguagesManager.GetDesc(id2);
		time2 = (GTextField)((GComponent)this).GetChild("time2");
		string id3 = "ui://4ctl553sazqa10".Replace("ui://", "") + "-" + ((GObject)time2).id;
		((GObject)time2).text = LanguagesManager.GetDesc(id3);
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		shakeTime2 = ((GComponent)this).GetTransition("shakeTime2");
	}
}

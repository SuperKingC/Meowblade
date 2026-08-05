using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ChangeBtn : GButton
{
	public Controller button;

	public GGraph n7;

	public GTextInput level;

	public UI_MakeWar ConfirmBtn;

	public GTextField lockTip;

	public const string URL = "ui://82mo10n5gox2k";

	public static string Name = "UI_ChangeBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5gox2k";
	}

	public static UI_ChangeBtn CreateInstance()
	{
		return (UI_ChangeBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ChangeBtn");
	}

	public static UI_ChangeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gox2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		level = (GTextInput)((GComponent)this).GetChild("level");
		ConfirmBtn = (UI_MakeWar)(object)((GComponent)this).GetChild("ConfirmBtn");
		lockTip = (GTextField)((GComponent)this).GetChild("lockTip");
		string id = "ui://82mo10n5gox2k".Replace("ui://", "") + "-" + ((GObject)lockTip).id;
		((GObject)lockTip).text = LanguagesManager.GetDesc(id);
	}
}

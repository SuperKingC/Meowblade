using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_StartBattleDialog : GComponent
{
	public GImage n0;

	public GButton CloseBtn;

	public UI_StartBattleConfirm Confirm;

	public UI_GoToRecruit GoToRecruit;

	public GTextField n5;

	public const string URL = "ui://twlbabicrl4qm0";

	public static string Name = "UI_StartBattleDialog";

	public static string GetURL()
	{
		return "ui://twlbabicrl4qm0";
	}

	public static UI_StartBattleDialog CreateInstance()
	{
		return (UI_StartBattleDialog)(object)UIPackage.CreateObject("Battle", "StartBattleDialog");
	}

	public static UI_StartBattleDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StartBattleDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicrl4qm0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		CloseBtn = (GButton)((GComponent)this).GetChild("CloseBtn");
		Confirm = (UI_StartBattleConfirm)(object)((GComponent)this).GetChild("Confirm");
		GoToRecruit = (UI_GoToRecruit)(object)((GComponent)this).GetChild("GoToRecruit");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://twlbabicrl4qm0".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}

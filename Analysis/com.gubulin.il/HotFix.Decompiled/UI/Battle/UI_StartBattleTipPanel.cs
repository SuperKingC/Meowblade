using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_StartBattleTipPanel : GComponent
{
	public GGraph Mask;

	public UI_StartBattleDialog Dialog;

	public const string URL = "ui://twlbabicrl4qlz";

	public static string Name = "UI_StartBattleTipPanel";

	public static string GetURL()
	{
		return "ui://twlbabicrl4qlz";
	}

	public static UI_StartBattleTipPanel CreateInstance()
	{
		return (UI_StartBattleTipPanel)(object)UIPackage.CreateObject("Battle", "StartBattleTipPanel");
	}

	public static UI_StartBattleTipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StartBattleTipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicrl4qlz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_StartBattleDialog)(object)((GComponent)this).GetChild("Dialog");
	}
}

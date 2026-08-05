using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_ReplaceSoldierTip : GButton
{
	public Controller button;

	public UI_Tipcontent content;

	public Transition shake;

	public const string URL = "ui://twlbabichbas39";

	public static string Name = "UI_ReplaceSoldierTip";

	public static string GetURL()
	{
		return "ui://twlbabichbas39";
	}

	public static UI_ReplaceSoldierTip CreateInstance()
	{
		return (UI_ReplaceSoldierTip)(object)UIPackage.CreateObject("Battle", "ReplaceSoldierTip");
	}

	public static UI_ReplaceSoldierTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReplaceSoldierTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabichbas39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		content = (UI_Tipcontent)(object)((GComponent)this).GetChild("content");
		shake = ((GComponent)this).GetTransition("shake");
	}
}

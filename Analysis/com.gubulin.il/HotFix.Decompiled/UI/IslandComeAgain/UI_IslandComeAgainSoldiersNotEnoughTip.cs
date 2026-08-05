using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_IslandComeAgainSoldiersNotEnoughTip : GComponent
{
	public GImage n0;

	public GButton CloseBtn;

	public UI_StillMatchBtn MatchBtn;

	public UI_GoToCampBtn GoToCamp;

	public GImage n7;

	public const string URL = "ui://k2sprg26jqfy14";

	public static string Name = "UI_IslandComeAgainSoldiersNotEnoughTip";

	public static string GetURL()
	{
		return "ui://k2sprg26jqfy14";
	}

	public static UI_IslandComeAgainSoldiersNotEnoughTip CreateInstance()
	{
		return (UI_IslandComeAgainSoldiersNotEnoughTip)(object)UIPackage.CreateObject("IslandComeAgain", "IslandComeAgainSoldiersNotEnoughTip");
	}

	public static UI_IslandComeAgainSoldiersNotEnoughTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainSoldiersNotEnoughTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26jqfy14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		MatchBtn = (UI_StillMatchBtn)(object)((GComponent)this).GetChild("MatchBtn");
		GoToCamp = (UI_GoToCampBtn)(object)((GComponent)this).GetChild("GoToCamp");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}

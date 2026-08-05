using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_QuickBattleStage : GComponent
{
	public Controller Type;

	public GImage Background;

	public GImage LeftBackImage;

	public GImage RightBackImage;

	public UI_ArrayIndex EnemyLegionIndex;

	public UI_MyArrayIndex MyLegionIndex;

	public Transition ShowQuickBattleStage;

	public const string URL = "ui://82mo10n5htypdd8";

	public static string Name = "UI_QuickBattleStage";

	public static string GetURL()
	{
		return "ui://82mo10n5htypdd8";
	}

	public static UI_QuickBattleStage CreateInstance()
	{
		return (UI_QuickBattleStage)(object)UIPackage.CreateObject("PvpSelectSoldiers", "QuickBattleStage");
	}

	public static UI_QuickBattleStage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QuickBattleStage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5htypdd8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		Background = (GImage)((GComponent)this).GetChild("Background");
		LeftBackImage = (GImage)((GComponent)this).GetChild("LeftBackImage");
		RightBackImage = (GImage)((GComponent)this).GetChild("RightBackImage");
		EnemyLegionIndex = (UI_ArrayIndex)(object)((GComponent)this).GetChild("EnemyLegionIndex");
		MyLegionIndex = (UI_MyArrayIndex)(object)((GComponent)this).GetChild("MyLegionIndex");
		ShowQuickBattleStage = ((GComponent)this).GetTransition("ShowQuickBattleStage");
	}
}

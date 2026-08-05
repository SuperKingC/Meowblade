using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_UserLevelUpDialog : GComponent
{
	public Controller Type;

	public GGraph interceptBack;

	public GImage tipFrame;

	public GGraph LightSfxBack;

	public GImage n50;

	public GList bonusList;

	public GImage n54;

	public GTextField descTitle;

	public GList descList;

	public GImage tipBg;

	public GGraph SpineBack;

	public GGraph SfxBack;

	public GTextField levelNum;

	public GGraph TitleExplosionSfxBack;

	public GGraph TitleLoopSfxBack;

	public GButton confirmBtn;

	public Transition showConfirmBtn;

	public Transition DevilLevelUp;

	public Transition ShowDialog;

	public Transition ShowBonusIcon;

	public Transition ShowDesc;

	public Transition DisplacementSpine;

	public const string URL = "ui://47lbpgx9f3r62n";

	public static string Name = "UI_UserLevelUpDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9f3r62n";
	}

	public static UI_UserLevelUpDialog CreateInstance()
	{
		return (UI_UserLevelUpDialog)(object)UIPackage.CreateObject("Tips", "UserLevelUpDialog");
	}

	public static UI_UserLevelUpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserLevelUpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9f3r62n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		interceptBack = (GGraph)((GComponent)this).GetChild("interceptBack");
		tipFrame = (GImage)((GComponent)this).GetChild("tipFrame");
		LightSfxBack = (GGraph)((GComponent)this).GetChild("LightSfxBack");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		bonusList = (GList)((GComponent)this).GetChild("bonusList");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		descTitle = (GTextField)((GComponent)this).GetChild("descTitle");
		string id = "ui://47lbpgx9f3r62n".Replace("ui://", "") + "-" + ((GObject)descTitle).id;
		((GObject)descTitle).text = LanguagesManager.GetDesc(id);
		descList = (GList)((GComponent)this).GetChild("descList");
		tipBg = (GImage)((GComponent)this).GetChild("tipBg");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		levelNum = (GTextField)((GComponent)this).GetChild("levelNum");
		string id2 = "ui://47lbpgx9f3r62n".Replace("ui://", "") + "-" + ((GObject)levelNum).id;
		((GObject)levelNum).text = LanguagesManager.GetDesc(id2);
		TitleExplosionSfxBack = (GGraph)((GComponent)this).GetChild("TitleExplosionSfxBack");
		TitleLoopSfxBack = (GGraph)((GComponent)this).GetChild("TitleLoopSfxBack");
		confirmBtn = (GButton)((GComponent)this).GetChild("confirmBtn");
		showConfirmBtn = ((GComponent)this).GetTransition("showConfirmBtn");
		DevilLevelUp = ((GComponent)this).GetTransition("DevilLevelUp");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
		ShowBonusIcon = ((GComponent)this).GetTransition("ShowBonusIcon");
		ShowDesc = ((GComponent)this).GetTransition("ShowDesc");
		DisplacementSpine = ((GComponent)this).GetTransition("DisplacementSpine");
	}
}

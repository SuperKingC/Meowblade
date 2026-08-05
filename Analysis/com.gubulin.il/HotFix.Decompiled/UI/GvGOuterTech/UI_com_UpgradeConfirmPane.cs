using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_UpgradeConfirmPane : GComponent
{
	public Controller CanUpgrade;

	public Controller State;

	public Controller HasEnterIZ;

	public GImage n32;

	public GTextField n21;

	public GImage n27;

	public GLoader PieceIcon;

	public GTextField PieceCost;

	public UI_btn_Upgrade UpgradeBtn;

	public UI_btn_Unlock UnlockBtn;

	public GGroup n29;

	public GTextField n31;

	public const string URL = "ui://th385mtt12fno2g";

	public static string Name = "UI_com_UpgradeConfirmPane";

	public static string GetURL()
	{
		return "ui://th385mtt12fno2g";
	}

	public static UI_com_UpgradeConfirmPane CreateInstance()
	{
		return (UI_com_UpgradeConfirmPane)(object)UIPackage.CreateObject("GvGOuterTech", "com_UpgradeConfirmPane");
	}

	public static UI_com_UpgradeConfirmPane CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UpgradeConfirmPane).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtt12fno2g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CanUpgrade = ((GComponent)this).GetController("CanUpgrade");
		State = ((GComponent)this).GetController("State");
		HasEnterIZ = ((GComponent)this).GetController("HasEnterIZ");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id = "ui://th385mtt12fno2g".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id);
		n27 = (GImage)((GComponent)this).GetChild("n27");
		PieceIcon = (GLoader)((GComponent)this).GetChild("PieceIcon");
		PieceCost = (GTextField)((GComponent)this).GetChild("PieceCost");
		UpgradeBtn = (UI_btn_Upgrade)(object)((GComponent)this).GetChild("UpgradeBtn");
		UnlockBtn = (UI_btn_Unlock)(object)((GComponent)this).GetChild("UnlockBtn");
		n29 = (GGroup)((GComponent)this).GetChild("n29");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id2 = "ui://th385mtt12fno2g".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id2);
	}
}

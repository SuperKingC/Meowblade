using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_BattleRecordSmall : GComponent
{
	public Controller Status;

	public Controller AttackAndDefense;

	public GLoader n60;

	public UI_btn_Play Play;

	public UI_com_UserAvatarBig MyAvatar;

	public UI_com_UserAvatarBig EnemyAvatar;

	public GImage n30;

	public GImage n32;

	public GGroup n38;

	public GImage n31;

	public GImage n33;

	public GGroup n39;

	public GComponent ShipIconLeft;

	public GComponent ShipIconRight;

	public GImage n66;

	public GImage n67;

	public GTextField GvG3TestBattleId;

	public const string URL = "ui://b3fc6085stwv1z";

	public static string Name = "UI_com_BattleRecordSmall";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1z";
	}

	public static UI_com_BattleRecordSmall CreateInstance()
	{
		return (UI_com_BattleRecordSmall)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_BattleRecordSmall");
	}

	public static UI_com_BattleRecordSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BattleRecordSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
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
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		AttackAndDefense = ((GComponent)this).GetController("AttackAndDefense");
		n60 = (GLoader)((GComponent)this).GetChild("n60");
		Play = (UI_btn_Play)(object)((GComponent)this).GetChild("Play");
		MyAvatar = (UI_com_UserAvatarBig)(object)((GComponent)this).GetChild("MyAvatar");
		EnemyAvatar = (UI_com_UserAvatarBig)(object)((GComponent)this).GetChild("EnemyAvatar");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		ShipIconLeft = (GComponent)((GComponent)this).GetChild("ShipIconLeft");
		ShipIconRight = (GComponent)((GComponent)this).GetChild("ShipIconRight");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		GvG3TestBattleId = (GTextField)((GComponent)this).GetChild("GvG3TestBattleId");
	}
}

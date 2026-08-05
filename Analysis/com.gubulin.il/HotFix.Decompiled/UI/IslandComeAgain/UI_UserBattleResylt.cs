using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_UserBattleResylt : GComponent
{
	public Controller RankType;

	public Controller SelfMark;

	public Controller Camp;

	public GImage n13;

	public UI_UserAvatar Avatar;

	public GImage n1;

	public GImage n2;

	public GImage n3;

	public GImage n4;

	public GImage n0;

	public GTextField UserName;

	public GTextField Kill;

	public GTextField Loss;

	public UI_Component3 n9;

	public GImage n11;

	public GTextField MyRank;

	public GGroup n12;

	public const string URL = "ui://k2sprg26uctj8h";

	public static string Name = "UI_UserBattleResylt";

	public static string GetURL()
	{
		return "ui://k2sprg26uctj8h";
	}

	public static UI_UserBattleResylt CreateInstance()
	{
		return (UI_UserBattleResylt)(object)UIPackage.CreateObject("IslandComeAgain", "UserBattleResylt");
	}

	public static UI_UserBattleResylt CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UserBattleResylt).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj8h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankType = ((GComponent)this).GetController("RankType");
		SelfMark = ((GComponent)this).GetController("SelfMark");
		Camp = ((GComponent)this).GetController("Camp");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Avatar = (UI_UserAvatar)(object)((GComponent)this).GetChild("Avatar");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		Kill = (GTextField)((GComponent)this).GetChild("Kill");
		Loss = (GTextField)((GComponent)this).GetChild("Loss");
		n9 = (UI_Component3)(object)((GComponent)this).GetChild("n9");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		MyRank = (GTextField)((GComponent)this).GetChild("MyRank");
		string id = "ui://k2sprg26uctj8h".Replace("ui://", "") + "-" + ((GObject)MyRank).id;
		((GObject)MyRank).text = LanguagesManager.GetDesc(id);
		n12 = (GGroup)((GComponent)this).GetChild("n12");
	}
}

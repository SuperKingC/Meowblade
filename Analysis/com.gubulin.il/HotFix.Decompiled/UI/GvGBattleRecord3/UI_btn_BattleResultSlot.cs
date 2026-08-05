using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_BattleResultSlot : GButton
{
	public Controller button;

	public Controller HasTalent;

	public Controller IsClaimed;

	public GImage n60;

	public GTextField Time;

	public GRichTextField Message;

	public GImage n95;

	public GList BonusList;

	public GTextField n44;

	public GList TalentSrcList;

	public const string URL = "ui://b3fc6085dzdc3d";

	public static string Name = "UI_btn_BattleResultSlot";

	public static string GetURL()
	{
		return "ui://b3fc6085dzdc3d";
	}

	public static UI_btn_BattleResultSlot CreateInstance()
	{
		return (UI_btn_BattleResultSlot)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_BattleResultSlot");
	}

	public static UI_btn_BattleResultSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BattleResultSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085dzdc3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasTalent = ((GComponent)this).GetController("HasTalent");
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		Message = (GRichTextField)((GComponent)this).GetChild("Message");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		n44 = (GTextField)((GComponent)this).GetChild("n44");
		string id = "ui://b3fc6085dzdc3d".Replace("ui://", "") + "-" + ((GObject)n44).id;
		((GObject)n44).text = LanguagesManager.GetDesc(id);
		TalentSrcList = (GList)((GComponent)this).GetChild("TalentSrcList");
	}
}

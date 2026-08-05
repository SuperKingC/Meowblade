using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_DamageRewardSlot2 : GComponent
{
	public Controller RankingController;

	public Controller ShowMyRank;

	public GLoader n10;

	public GLoader n19;

	public GLoader n20;

	public GList BonusList;

	public GImage n23;

	public GTextField n22;

	public GGroup myranking;

	public const string URL = "ui://0i520nzmvrjgocd";

	public static string Name = "UI_DamageRewardSlot2";

	public static string GetURL()
	{
		return "ui://0i520nzmvrjgocd";
	}

	public static UI_DamageRewardSlot2 CreateInstance()
	{
		return (UI_DamageRewardSlot2)(object)UIPackage.CreateObject("LordOfDreams", "DamageRewardSlot2");
	}

	public static UI_DamageRewardSlot2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DamageRewardSlot2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmvrjgocd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankingController = ((GComponent)this).GetController("RankingController");
		ShowMyRank = ((GComponent)this).GetController("ShowMyRank");
		n10 = (GLoader)((GComponent)this).GetChild("n10");
		n19 = (GLoader)((GComponent)this).GetChild("n19");
		n20 = (GLoader)((GComponent)this).GetChild("n20");
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id = "ui://0i520nzmvrjgocd".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id);
		myranking = (GGroup)((GComponent)this).GetChild("myranking");
	}
}

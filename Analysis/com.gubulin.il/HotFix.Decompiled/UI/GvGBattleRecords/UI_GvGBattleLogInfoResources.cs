using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecords;

public class UI_GvGBattleLogInfoResources : GComponent
{
	public Controller Type;

	public Controller Status;

	public Controller AttackAndDefense;

	public Controller Style;

	public GImage n22;

	public GTextField Day;

	public GGraph n52;

	public GLoader n60;

	public GTextField TotalDamageTitle;

	public GTextField TotalDamageValue;

	public UI_RankingListAvatar MyAvatar;

	public GTextField EnemyName;

	public GTextField MyName;

	public UI_RankingListAvatar EnemyAvatar;

	public UI_PlayBtn PlayBtn;

	public UI_RecordDetail RecordDetail;

	public GImage n30;

	public GImage n32;

	public GGroup n38;

	public GImage n31;

	public GImage n33;

	public GGroup n39;

	public GGroup n61;

	public GTextField n59;

	public const string URL = "ui://dxmilktydzlsw";

	public static string Name = "UI_GvGBattleLogInfoResources";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://dxmilktydzlsw".Replace("ui://", ""), ((GObject)TotalDamageTitle).id, Style.selectedIndex);
		((GObject)TotalDamageTitle).text = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://dxmilktydzlsw".Replace("ui://", ""), ((GObject)n59).id, Style.selectedIndex);
		((GObject)n59).text = LanguagesManager.GetDesc(id2);
	}

	public static string GetURL()
	{
		return "ui://dxmilktydzlsw";
	}

	public static UI_GvGBattleLogInfoResources CreateInstance()
	{
		return (UI_GvGBattleLogInfoResources)(object)UIPackage.CreateObject("GvGBattleRecords", "GvGBattleLogInfoResources");
	}

	public static UI_GvGBattleLogInfoResources CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBattleLogInfoResources).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzlsw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Status = ((GComponent)this).GetController("Status");
		AttackAndDefense = ((GComponent)this).GetController("AttackAndDefense");
		Style = ((GComponent)this).GetController("Style");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		Day = (GTextField)((GComponent)this).GetChild("Day");
		string id = "ui://dxmilktydzlsw".Replace("ui://", "") + "-" + ((GObject)Day).id;
		((GObject)Day).text = LanguagesManager.GetDesc(id);
		n52 = (GGraph)((GComponent)this).GetChild("n52");
		n60 = (GLoader)((GComponent)this).GetChild("n60");
		TotalDamageTitle = (GTextField)((GComponent)this).GetChild("TotalDamageTitle");
		string id2 = "ui://dxmilktydzlsw".Replace("ui://", "") + "-" + ((GObject)TotalDamageTitle).id;
		((GObject)TotalDamageTitle).text = LanguagesManager.GetDesc(id2);
		TotalDamageValue = (GTextField)((GComponent)this).GetChild("TotalDamageValue");
		MyAvatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("MyAvatar");
		EnemyName = (GTextField)((GComponent)this).GetChild("EnemyName");
		MyName = (GTextField)((GComponent)this).GetChild("MyName");
		EnemyAvatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("EnemyAvatar");
		PlayBtn = (UI_PlayBtn)(object)((GComponent)this).GetChild("PlayBtn");
		RecordDetail = (UI_RecordDetail)(object)((GComponent)this).GetChild("RecordDetail");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		n61 = (GGroup)((GComponent)this).GetChild("n61");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id3 = "ui://dxmilktydzlsw".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id3);
	}
}

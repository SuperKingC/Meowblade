using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_RankBonusSlot : GComponent
{
	public Controller RankingTopThree;

	public GLoader n171;

	public GImage n188;

	public GImage n189;

	public GLoader n172;

	public GTextField Ranking;

	public GLoader BonusBoxItem;

	public GList ContentList;

	public GTextField BoxName;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2h4tpem";

	public static string Name = "UI_com_RankBonusSlot";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpem";
	}

	public static UI_com_RankBonusSlot CreateInstance()
	{
		return (UI_com_RankBonusSlot)(object)UIPackage.CreateObject("GvGWorldMap3", "com_RankBonusSlot");
	}

	public static UI_com_RankBonusSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RankBonusSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpem", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankingTopThree = ((GComponent)this).GetController("RankingTopThree");
		n171 = (GLoader)((GComponent)this).GetChild("n171");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		n189 = (GImage)((GComponent)this).GetChild("n189");
		n172 = (GLoader)((GComponent)this).GetChild("n172");
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
		BonusBoxItem = (GLoader)((GComponent)this).GetChild("BonusBoxItem");
		ContentList = (GList)((GComponent)this).GetChild("ContentList");
		BoxName = (GTextField)((GComponent)this).GetChild("BoxName");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

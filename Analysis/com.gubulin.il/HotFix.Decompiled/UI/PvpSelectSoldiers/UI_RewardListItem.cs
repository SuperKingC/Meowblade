using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RewardListItem : GComponent
{
	public Controller RankLevel;

	public GLoader ItemFrame;

	public GLoader RankTop3Deco;

	public GList NoList;

	public GLoader RankTop3;

	public GTextField title;

	public const string URL = "ui://82mo10n5svvbjdu7";

	public static string Name = "UI_RewardListItem";

	public static string GetURL()
	{
		return "ui://82mo10n5svvbjdu7";
	}

	public static UI_RewardListItem CreateInstance()
	{
		return (UI_RewardListItem)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RewardListItem");
	}

	public static UI_RewardListItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RewardListItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5svvbjdu7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		RankLevel = ((GComponent)this).GetController("RankLevel");
		ItemFrame = (GLoader)((GComponent)this).GetChild("ItemFrame");
		RankTop3Deco = (GLoader)((GComponent)this).GetChild("RankTop3Deco");
		NoList = (GList)((GComponent)this).GetChild("NoList");
		RankTop3 = (GLoader)((GComponent)this).GetChild("RankTop3");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}

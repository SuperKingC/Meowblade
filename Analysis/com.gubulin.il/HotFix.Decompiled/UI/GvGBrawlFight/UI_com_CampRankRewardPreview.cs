using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_CampRankRewardPreview : GComponent
{
	public Controller Ranking;

	public GLoader n171;

	public GImage n188;

	public GImage n189;

	public GLoader n172;

	public GList Items;

	public Transition t0;

	public const string URL = "ui://hozu168rniiv6r";

	public static string Name = "UI_com_CampRankRewardPreview";

	public static string GetURL()
	{
		return "ui://hozu168rniiv6r";
	}

	public static UI_com_CampRankRewardPreview CreateInstance()
	{
		return (UI_com_CampRankRewardPreview)(object)UIPackage.CreateObject("GvGBrawlFight", "com_CampRankRewardPreview");
	}

	public static UI_com_CampRankRewardPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampRankRewardPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv6r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Ranking = ((GComponent)this).GetController("Ranking");
		n171 = (GLoader)((GComponent)this).GetChild("n171");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		n189 = (GImage)((GComponent)this).GetChild("n189");
		n172 = (GLoader)((GComponent)this).GetChild("n172");
		Items = (GList)((GComponent)this).GetChild("Items");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_CampRankSlot : GComponent
{
	public Controller CampId;

	public Controller Ranking;

	public Controller IsMyCamp;

	public GImage n128;

	public GLoader n134;

	public GLoader n132;

	public GImage n135;

	public GTextField RankData;

	public const string URL = "ui://91jxdrkanc8fo";

	public static string Name = "UI_com_CampRankSlot";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8fo";
	}

	public static UI_com_CampRankSlot CreateInstance()
	{
		return (UI_com_CampRankSlot)(object)UIPackage.CreateObject("GvGSettlement", "com_CampRankSlot");
	}

	public static UI_com_CampRankSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampRankSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8fo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		Ranking = ((GComponent)this).GetController("Ranking");
		IsMyCamp = ((GComponent)this).GetController("IsMyCamp");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n134 = (GLoader)((GComponent)this).GetChild("n134");
		n132 = (GLoader)((GComponent)this).GetChild("n132");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		RankData = (GTextField)((GComponent)this).GetChild("RankData");
	}
}

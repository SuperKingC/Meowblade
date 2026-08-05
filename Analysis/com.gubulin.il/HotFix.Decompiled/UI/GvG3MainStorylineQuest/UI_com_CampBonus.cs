using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_CampBonus : GComponent
{
	public Controller RankPage;

	public GImage n2;

	public GList Bonus;

	public UI_com_CampRank Rank;

	public const string URL = "ui://249h3k3dvihg29";

	public static string Name = "UI_com_CampBonus";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg29";
	}

	public static UI_com_CampBonus CreateInstance()
	{
		return (UI_com_CampBonus)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_CampBonus");
	}

	public static UI_com_CampBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg29", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RankPage = ((GComponent)this).GetController("RankPage");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		Rank = (UI_com_CampRank)(object)((GComponent)this).GetChild("Rank");
	}
}

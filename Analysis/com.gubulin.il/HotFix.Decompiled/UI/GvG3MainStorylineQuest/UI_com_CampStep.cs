using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_CampStep : GComponent
{
	public Controller Camp;

	public Controller IsMe;

	public Controller InCompetition;

	public GImage n8;

	public GLoader n0;

	public GImage n9;

	public GList CurrentStep;

	public GImage n1;

	public GGroup n6;

	public UI_com_CampRank Rank;

	public const string URL = "ui://249h3k3dvihg1q";

	public static string Name = "UI_com_CampStep";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg1q";
	}

	public static UI_com_CampStep CreateInstance()
	{
		return (UI_com_CampStep)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_CampStep");
	}

	public static UI_com_CampStep CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampStep).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		IsMe = ((GComponent)this).GetController("IsMe");
		InCompetition = ((GComponent)this).GetController("InCompetition");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		CurrentStep = (GList)((GComponent)this).GetChild("CurrentStep");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n6 = (GGroup)((GComponent)this).GetChild("n6");
		Rank = (UI_com_CampRank)(object)((GComponent)this).GetChild("Rank");
	}
}

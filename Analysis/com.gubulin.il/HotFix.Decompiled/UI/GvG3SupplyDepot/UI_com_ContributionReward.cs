using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_ContributionReward : GComponent
{
	public GImage n2;

	public GImage n6;

	public GTextField n3;

	public GTextField n4;

	public GList Reward;

	public GTextField n7;

	public GTextField n8;

	public const string URL = "ui://pobej4q7mo53p";

	public static string Name = "UI_com_ContributionReward";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53p";
	}

	public static UI_com_ContributionReward CreateInstance()
	{
		return (UI_com_ContributionReward)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_ContributionReward");
	}

	public static UI_com_ContributionReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ContributionReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://pobej4q7mo53p".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://pobej4q7mo53p".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Reward = (GList)((GComponent)this).GetChild("Reward");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://pobej4q7mo53p".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://pobej4q7mo53p".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
	}
}

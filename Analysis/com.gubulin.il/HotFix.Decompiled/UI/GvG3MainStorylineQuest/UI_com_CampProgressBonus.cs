using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_CampProgressBonus : GComponent
{
	public Controller Progress;

	public GImage n0;

	public GList RewardsConfig;

	public GTextField n2;

	public GTextField n3;

	public GTextField n4;

	public GTextField n7;

	public GTextField n8;

	public GTextField n9;

	public GTextField n6;

	public GGroup n10;

	public const string URL = "ui://249h3k3dvihg28";

	public static string Name = "UI_com_CampProgressBonus";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg28";
	}

	public static UI_com_CampProgressBonus CreateInstance()
	{
		return (UI_com_CampProgressBonus)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_CampProgressBonus");
	}

	public static UI_com_CampProgressBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampProgressBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Progress = ((GComponent)this).GetController("Progress");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		RewardsConfig = (GList)((GComponent)this).GetChild("RewardsConfig");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://249h3k3dvihg28".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://249h3k3dvihg28".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id3 = "ui://249h3k3dvihg28".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id3);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id4 = "ui://249h3k3dvihg28".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id4);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id5 = "ui://249h3k3dvihg28".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id5);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id6 = "ui://249h3k3dvihg28".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id6);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id7 = "ui://249h3k3dvihg28".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id7);
		n10 = (GGroup)((GComponent)this).GetChild("n10");
	}
}

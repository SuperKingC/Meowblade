using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_02 : GComponent
{
	public Controller Type;

	public GImage n0;

	public GImage n1;

	public GImage n4;

	public GLoader n2;

	public GTextField n3;

	public GTextField n5;

	public GTextField Description;

	public GTextField IncomeOverview;

	public GTextField IncomeDetail;

	public const string URL = "ui://249h3k3daggos4a";

	public static string Name = "UI_com_02";

	public static string GetURL()
	{
		return "ui://249h3k3daggos4a";
	}

	public static UI_com_02 CreateInstance()
	{
		return (UI_com_02)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_02");
	}

	public static UI_com_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3daggos4a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://249h3k3daggos4a".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://249h3k3daggos4a".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		Description = (GTextField)((GComponent)this).GetChild("Description");
		IncomeOverview = (GTextField)((GComponent)this).GetChild("IncomeOverview");
		IncomeDetail = (GTextField)((GComponent)this).GetChild("IncomeDetail");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ReplenishTroopsDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GGraph n13;

	public GList OldSoldiers;

	public GList n5;

	public GList n17;

	public GTextField n6;

	public GTextField n7;

	public GTextField Time;

	public GTextField n10;

	public GButton CloseBtn;

	public GList Stock;

	public UI_ConfirmReplenishTroops Confirm;

	public GTextField Tip;

	public const string URL = "ui://k2sprg26in7b3a";

	public static string Name = "UI_ReplenishTroopsDialog";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b3a";
	}

	public static UI_ReplenishTroopsDialog CreateInstance()
	{
		return (UI_ReplenishTroopsDialog)(object)UIPackage.CreateObject("IslandComeAgain", "ReplenishTroopsDialog");
	}

	public static UI_ReplenishTroopsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReplenishTroopsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		n13 = (GGraph)((GComponent)this).GetChild("n13");
		OldSoldiers = (GList)((GComponent)this).GetChild("OldSoldiers");
		n5 = (GList)((GComponent)this).GetChild("n5");
		n17 = (GList)((GComponent)this).GetChild("n17");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://k2sprg26in7b3a".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://k2sprg26in7b3a".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id3 = "ui://k2sprg26in7b3a".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id3);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id4 = "ui://k2sprg26in7b3a".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id4);
		CloseBtn = (GButton)((GComponent)this).GetChild("CloseBtn");
		Stock = (GList)((GComponent)this).GetChild("Stock");
		Confirm = (UI_ConfirmReplenishTroops)(object)((GComponent)this).GetChild("Confirm");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id5 = "ui://k2sprg26in7b3a".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id5);
	}
}

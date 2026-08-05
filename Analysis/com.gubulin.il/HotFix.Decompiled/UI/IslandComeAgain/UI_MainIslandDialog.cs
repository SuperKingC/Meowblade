using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_MainIslandDialog : GComponent
{
	public Controller MainIslandTyoe;

	public GImage back;

	public GGraph n3;

	public UI_UserInfoDetail CheckUserInfoDetail;

	public GLoader n4;

	public GLoader n15;

	public GTextField n7;

	public GTextField n8;

	public GTextField UserNumber;

	public UI_GoToIsland GoToIsland;

	public UI_LegionTroops LegionTroops;

	public UI_ChangeTroops ChangeTroops;

	public UI_ReplenishTroops ReplenishTroops;

	public GLoader logo;

	public GTextField IslandName;

	public GGroup n16;

	public const string URL = "ui://k2sprg26in7b26";

	public static string Name = "UI_MainIslandDialog";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b26";
	}

	public static UI_MainIslandDialog CreateInstance()
	{
		return (UI_MainIslandDialog)(object)UIPackage.CreateObject("IslandComeAgain", "MainIslandDialog");
	}

	public static UI_MainIslandDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MainIslandDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b26", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		MainIslandTyoe = ((GComponent)this).GetController("MainIslandTyoe");
		back = (GImage)((GComponent)this).GetChild("back");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		CheckUserInfoDetail = (UI_UserInfoDetail)(object)((GComponent)this).GetChild("CheckUserInfoDetail");
		n4 = (GLoader)((GComponent)this).GetChild("n4");
		n15 = (GLoader)((GComponent)this).GetChild("n15");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://k2sprg26in7b26".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		UserNumber = (GTextField)((GComponent)this).GetChild("UserNumber");
		string id2 = "ui://k2sprg26in7b26".Replace("ui://", "") + "-" + ((GObject)UserNumber).id;
		((GObject)UserNumber).text = LanguagesManager.GetDesc(id2);
		GoToIsland = (UI_GoToIsland)(object)((GComponent)this).GetChild("GoToIsland");
		LegionTroops = (UI_LegionTroops)(object)((GComponent)this).GetChild("LegionTroops");
		ChangeTroops = (UI_ChangeTroops)(object)((GComponent)this).GetChild("ChangeTroops");
		ReplenishTroops = (UI_ReplenishTroops)(object)((GComponent)this).GetChild("ReplenishTroops");
		logo = (GLoader)((GComponent)this).GetChild("logo");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		string id3 = "ui://k2sprg26in7b26".Replace("ui://", "") + "-" + ((GObject)IslandName).id;
		((GObject)IslandName).text = LanguagesManager.GetDesc(id3);
		n16 = (GGroup)((GComponent)this).GetChild("n16");
	}
}

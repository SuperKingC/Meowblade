using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_com_RebuildShip : GComponent
{
	public Controller IsNotAvailable;

	public GImage n111;

	public GImage n142;

	public GImage n143;

	public GImage n128;

	public GImage n118;

	public GImage n138;

	public GImage n129;

	public GTextField n113;

	public GImage n115;

	public UI_com_RaceName OldRaceName;

	public UI_RaceName NewRaceName;

	public UI_CloseBtn CloseBtn;

	public UI_ConfirmRebuildBtn ConfirmBuildBtn;

	public GList RaceList;

	public GGraph NewSpineLoader;

	public GGraph OldSpineLoader;

	public GTextField n135;

	public GLoader OldRace;

	public GLoader NewRace;

	public GImage n144;

	public const string URL = "ui://pwrbvhpvpglz66";

	public static string Name = "UI_com_RebuildShip";

	public static string GetURL()
	{
		return "ui://pwrbvhpvpglz66";
	}

	public static UI_com_RebuildShip CreateInstance()
	{
		return (UI_com_RebuildShip)(object)UIPackage.CreateObject("GvGShipPopup", "com_RebuildShip");
	}

	public static UI_com_RebuildShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RebuildShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvpglz66", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNotAvailable = ((GComponent)this).GetController("IsNotAvailable");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n129 = (GImage)((GComponent)this).GetChild("n129");
		n113 = (GTextField)((GComponent)this).GetChild("n113");
		string id = "ui://pwrbvhpvpglz66".Replace("ui://", "") + "-" + ((GObject)n113).id;
		((GObject)n113).text = LanguagesManager.GetDesc(id);
		n115 = (GImage)((GComponent)this).GetChild("n115");
		OldRaceName = (UI_com_RaceName)(object)((GComponent)this).GetChild("OldRaceName");
		NewRaceName = (UI_RaceName)(object)((GComponent)this).GetChild("NewRaceName");
		CloseBtn = (UI_CloseBtn)(object)((GComponent)this).GetChild("CloseBtn");
		ConfirmBuildBtn = (UI_ConfirmRebuildBtn)(object)((GComponent)this).GetChild("ConfirmBuildBtn");
		RaceList = (GList)((GComponent)this).GetChild("RaceList");
		NewSpineLoader = (GGraph)((GComponent)this).GetChild("NewSpineLoader");
		OldSpineLoader = (GGraph)((GComponent)this).GetChild("OldSpineLoader");
		n135 = (GTextField)((GComponent)this).GetChild("n135");
		string id2 = "ui://pwrbvhpvpglz66".Replace("ui://", "") + "-" + ((GObject)n135).id;
		((GObject)n135).text = LanguagesManager.GetDesc(id2);
		OldRace = (GLoader)((GComponent)this).GetChild("OldRace");
		NewRace = (GLoader)((GComponent)this).GetChild("NewRace");
		n144 = (GImage)((GComponent)this).GetChild("n144");
	}
}

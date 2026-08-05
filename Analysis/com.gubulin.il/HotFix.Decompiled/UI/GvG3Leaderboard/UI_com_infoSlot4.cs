using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_infoSlot4 : GComponent
{
	public Controller isShowScore;

	public GImage n210;

	public GImage n211;

	public GTextField Title;

	public GLoader LevelIcon;

	public GTextField winCount;

	public GImage n215;

	public GLoader n216;

	public GTextField mainScore;

	public GGroup n218;

	public const string URL = "ui://ylvfgf90cnbr7a";

	public static string Name = "UI_com_infoSlot4";

	public static string GetURL()
	{
		return "ui://ylvfgf90cnbr7a";
	}

	public static UI_com_infoSlot4 CreateInstance()
	{
		return (UI_com_infoSlot4)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_infoSlot4");
	}

	public static UI_com_infoSlot4 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_infoSlot4).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90cnbr7a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isShowScore = ((GComponent)this).GetController("isShowScore");
		n210 = (GImage)((GComponent)this).GetChild("n210");
		n211 = (GImage)((GComponent)this).GetChild("n211");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		winCount = (GTextField)((GComponent)this).GetChild("winCount");
		n215 = (GImage)((GComponent)this).GetChild("n215");
		n216 = (GLoader)((GComponent)this).GetChild("n216");
		mainScore = (GTextField)((GComponent)this).GetChild("mainScore");
		n218 = (GGroup)((GComponent)this).GetChild("n218");
	}
}

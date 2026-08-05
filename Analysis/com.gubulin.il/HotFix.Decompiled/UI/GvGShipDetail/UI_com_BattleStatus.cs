using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_BattleStatus : GComponent
{
	public GImage n71;

	public GTextField n72;

	public GTextField n73;

	public GImage n74;

	public GImage n75;

	public const string URL = "ui://u6x0b1gnwb3q2l";

	public static string Name = "UI_com_BattleStatus";

	public static string GetURL()
	{
		return "ui://u6x0b1gnwb3q2l";
	}

	public static UI_com_BattleStatus CreateInstance()
	{
		return (UI_com_BattleStatus)(object)UIPackage.CreateObject("GvGShipDetail", "com_BattleStatus");
	}

	public static UI_com_BattleStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BattleStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnwb3q2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n72 = (GTextField)((GComponent)this).GetChild("n72");
		string id = "ui://u6x0b1gnwb3q2l".Replace("ui://", "") + "-" + ((GObject)n72).id;
		((GObject)n72).text = LanguagesManager.GetDesc(id);
		n73 = (GTextField)((GComponent)this).GetChild("n73");
		string id2 = "ui://u6x0b1gnwb3q2l".Replace("ui://", "") + "-" + ((GObject)n73).id;
		((GObject)n73).text = LanguagesManager.GetDesc(id2);
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n75 = (GImage)((GComponent)this).GetChild("n75");
	}
}

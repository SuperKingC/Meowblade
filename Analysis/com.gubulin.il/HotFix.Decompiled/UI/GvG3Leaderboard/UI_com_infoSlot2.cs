using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_infoSlot2 : GComponent
{
	public Controller IsNotEmpty;

	public GImage n6;

	public UI_com_ShipIcon ShipIcon;

	public UI_com_Ranking Rank;

	public GImage n2;

	public GTextField Damage;

	public GTextField n5;

	public const string URL = "ui://ylvfgf90ohdk6w";

	public static string Name = "UI_com_infoSlot2";

	public static string GetURL()
	{
		return "ui://ylvfgf90ohdk6w";
	}

	public static UI_com_infoSlot2 CreateInstance()
	{
		return (UI_com_infoSlot2)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_infoSlot2");
	}

	public static UI_com_infoSlot2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_infoSlot2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90ohdk6w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsNotEmpty = ((GComponent)this).GetController("IsNotEmpty");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		ShipIcon = (UI_com_ShipIcon)(object)((GComponent)this).GetChild("ShipIcon");
		Rank = (UI_com_Ranking)(object)((GComponent)this).GetChild("Rank");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Damage = (GTextField)((GComponent)this).GetChild("Damage");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://ylvfgf90ohdk6w".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}

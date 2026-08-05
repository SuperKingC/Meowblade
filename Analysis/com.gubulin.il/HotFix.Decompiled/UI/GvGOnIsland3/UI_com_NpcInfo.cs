using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_NpcInfo : GComponent
{
	public GImage n80;

	public GImage n82;

	public GTextField n77;

	public GTextField SoldierCount;

	public GImage n81;

	public const string URL = "ui://ebc4ciwrl44l1o";

	public static string Name = "UI_com_NpcInfo";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1o";
	}

	public static UI_com_NpcInfo CreateInstance()
	{
		return (UI_com_NpcInfo)(object)UIPackage.CreateObject("GvGOnIsland3", "com_NpcInfo");
	}

	public static UI_com_NpcInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NpcInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n77 = (GTextField)((GComponent)this).GetChild("n77");
		string id = "ui://ebc4ciwrl44l1o".Replace("ui://", "") + "-" + ((GObject)n77).id;
		((GObject)n77).text = LanguagesManager.GetDesc(id);
		SoldierCount = (GTextField)((GComponent)this).GetChild("SoldierCount");
		n81 = (GImage)((GComponent)this).GetChild("n81");
	}
}

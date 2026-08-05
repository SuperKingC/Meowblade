using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_com_BuffListSmall : GComponent
{
	public Controller OccupyStatus;

	public Controller Camp;

	public Controller MyIsland;

	public Controller HasBuff;

	public Controller Type;

	public GImage n5;

	public GList BuffList;

	public GTextField n14;

	public GLoader n7;

	public GImage n9;

	public UI_com_OccupyStatus n10;

	public UI_com_Camp n11;

	public GImage n12;

	public GTextField n13;

	public UI_btn_IslandName btn_IslandName;

	public const string URL = "ui://zh7jgfijnewqft";

	public static string Name = "UI_com_BuffListSmall";

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqft";
	}

	public static UI_com_BuffListSmall CreateInstance()
	{
		return (UI_com_BuffListSmall)(object)UIPackage.CreateObject("GvGIslandBuff", "com_BuffListSmall");
	}

	public static UI_com_BuffListSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuffListSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqft", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OccupyStatus = ((GComponent)this).GetController("OccupyStatus");
		Camp = ((GComponent)this).GetController("Camp");
		MyIsland = ((GComponent)this).GetController("MyIsland");
		HasBuff = ((GComponent)this).GetController("HasBuff");
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		BuffList = (GList)((GComponent)this).GetChild("BuffList");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		n7 = (GLoader)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (UI_com_OccupyStatus)(object)((GComponent)this).GetChild("n10");
		n11 = (UI_com_Camp)(object)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://zh7jgfijnewqft".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		btn_IslandName = (UI_btn_IslandName)(object)((GComponent)this).GetChild("btn_IslandName");
	}
}

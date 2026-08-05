using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ProgressionTabBtn : GButton
{
	public Controller button;

	public Controller SelectState;

	public Controller Index;

	public GImage bgLock;

	public GImage bgUnselect;

	public GImage bgSelect;

	public GTextField dayMini;

	public GTextField day;

	public GImage tick;

	public GImage note;

	public GGraph size;

	public GTextField n22;

	public const string URL = "ui://mapat4i5drlj87";

	public static string Name = "UI_ProgressionTabBtn";

	public static string GetURL()
	{
		return "ui://mapat4i5drlj87";
	}

	public static UI_ProgressionTabBtn CreateInstance()
	{
		return (UI_ProgressionTabBtn)(object)UIPackage.CreateObject("ProgressionMission", "ProgressionTabBtn");
	}

	public static UI_ProgressionTabBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionTabBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5drlj87", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SelectState = ((GComponent)this).GetController("SelectState");
		Index = ((GComponent)this).GetController("Index");
		bgLock = (GImage)((GComponent)this).GetChild("bgLock");
		bgUnselect = (GImage)((GComponent)this).GetChild("bgUnselect");
		bgSelect = (GImage)((GComponent)this).GetChild("bgSelect");
		dayMini = (GTextField)((GComponent)this).GetChild("dayMini");
		string id = "ui://mapat4i5drlj87".Replace("ui://", "") + "-" + ((GObject)dayMini).id;
		((GObject)dayMini).text = LanguagesManager.GetDesc(id);
		day = (GTextField)((GComponent)this).GetChild("day");
		string id2 = "ui://mapat4i5drlj87".Replace("ui://", "") + "-" + ((GObject)day).id;
		((GObject)day).text = LanguagesManager.GetDesc(id2);
		tick = (GImage)((GComponent)this).GetChild("tick");
		note = (GImage)((GComponent)this).GetChild("note");
		size = (GGraph)((GComponent)this).GetChild("size");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id3 = "ui://mapat4i5drlj87".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id3);
	}
}

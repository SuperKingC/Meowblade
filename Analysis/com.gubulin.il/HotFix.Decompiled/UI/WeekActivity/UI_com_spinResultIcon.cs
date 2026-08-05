using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_spinResultIcon : GComponent
{
	public Controller RewardController;

	public Controller Type;

	public Controller FrameType;

	public GLoader Back;

	public GLoader rewardIcon;

	public GTextField Num;

	public GTextField itemName;

	public const string URL = "ui://jl0c82y5fmsk4";

	public static string Name = "UI_com_spinResultIcon";

	public static string GetURL()
	{
		return "ui://jl0c82y5fmsk4";
	}

	public static UI_com_spinResultIcon CreateInstance()
	{
		return (UI_com_spinResultIcon)(object)UIPackage.CreateObject("WeekActivity", "com_spinResultIcon");
	}

	public static UI_com_spinResultIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_spinResultIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmsk4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		RewardController = ((GComponent)this).GetController("RewardController");
		Type = ((GComponent)this).GetController("Type");
		FrameType = ((GComponent)this).GetController("FrameType");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		itemName = (GTextField)((GComponent)this).GetChild("itemName");
		string id = "ui://jl0c82y5fmsk4".Replace("ui://", "") + "-" + ((GObject)itemName).id;
		((GObject)itemName).text = LanguagesManager.GetDesc(id);
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_MissionSlot : GComponent
{
	public Controller IsCompleted;

	public GGraph back;

	public GGraph n14;

	public UI_GotoBtn GotoBtn;

	public GTextField Title;

	public GTextField Progress;

	public GLoader LevelIcon;

	public GTextField LevelText;

	public GGraph mask;

	public GImage n13;

	public const string URL = "ui://ax280w58mmrf3i";

	public static string Name = "UI_MissionSlot";

	public static string GetURL()
	{
		return "ui://ax280w58mmrf3i";
	}

	public static UI_MissionSlot CreateInstance()
	{
		return (UI_MissionSlot)(object)UIPackage.CreateObject("WarOrder", "MissionSlot");
	}

	public static UI_MissionSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58mmrf3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsCompleted = ((GComponent)this).GetController("IsCompleted");
		back = (GGraph)((GComponent)this).GetChild("back");
		n14 = (GGraph)((GComponent)this).GetChild("n14");
		GotoBtn = (UI_GotoBtn)(object)((GComponent)this).GetChild("GotoBtn");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		Progress = (GTextField)((GComponent)this).GetChild("Progress");
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		LevelText = (GTextField)((GComponent)this).GetChild("LevelText");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n13 = (GImage)((GComponent)this).GetChild("n13");
	}
}

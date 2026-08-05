using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_LegendItemForgeCost : GComponent
{
	public Controller State;

	public Controller Level;

	public Controller Type;

	public GLoader Frame;

	public GImage n1;

	public GGroup n2;

	public UI_com_LegendItem FrameIcon;

	public UI_com_SelectForgeUniversalLegendItem UniversalLegendItem;

	public GTextField name;

	public GTextField n19;

	public GGroup n21;

	public Transition t0;

	public const string URL = "ui://h09dvkcgpqzh2p";

	public static string Name = "UI_com_LegendItemForgeCost";

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh2p";
	}

	public static UI_com_LegendItemForgeCost CreateInstance()
	{
		return (UI_com_LegendItemForgeCost)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_LegendItemForgeCost");
	}

	public static UI_com_LegendItemForgeCost CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LegendItemForgeCost).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh2p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		Level = ((GComponent)this).GetController("Level");
		Type = ((GComponent)this).GetController("Type");
		Frame = (GLoader)((GComponent)this).GetChild("Frame");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GGroup)((GComponent)this).GetChild("n2");
		FrameIcon = (UI_com_LegendItem)(object)((GComponent)this).GetChild("FrameIcon");
		UniversalLegendItem = (UI_com_SelectForgeUniversalLegendItem)(object)((GComponent)this).GetChild("UniversalLegendItem");
		name = (GTextField)((GComponent)this).GetChild("name");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id = "ui://h09dvkcgpqzh2p".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id);
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_MainReward : GButton
{
	public Controller button;

	public GImage iconBack;

	public GLoader icon;

	public GRichTextField title;

	public Transition Grayed;

	public const string URL = "ui://hda5vzklic7j2y";

	public static string Name = "UI_MainReward";

	public static string GetURL()
	{
		return "ui://hda5vzklic7j2y";
	}

	public static UI_MainReward CreateInstance()
	{
		return (UI_MainReward)(object)UIPackage.CreateObject("GameEndPanels", "MainReward");
	}

	public static UI_MainReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MainReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklic7j2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		Grayed = ((GComponent)this).GetTransition("Grayed");
	}
}

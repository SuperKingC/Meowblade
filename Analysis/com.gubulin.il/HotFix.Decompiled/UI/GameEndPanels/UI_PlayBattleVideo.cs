using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_PlayBattleVideo : GButton
{
	public Controller button;

	public GGraph n8;

	public GGraph Back;

	public GImage n16;

	public GImage n17;

	public GImage n13;

	public GImage n14;

	public const string URL = "ui://hda5vzklr5kt46";

	public static string Name = "UI_PlayBattleVideo";

	public static string GetURL()
	{
		return "ui://hda5vzklr5kt46";
	}

	public static UI_PlayBattleVideo CreateInstance()
	{
		return (UI_PlayBattleVideo)(object)UIPackage.CreateObject("GameEndPanels", "PlayBattleVideo");
	}

	public static UI_PlayBattleVideo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayBattleVideo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklr5kt46", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		Back = (GGraph)((GComponent)this).GetChild("Back");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
	}
}

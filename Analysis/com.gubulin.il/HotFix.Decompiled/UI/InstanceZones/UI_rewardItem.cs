using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_rewardItem : GButton
{
	public Controller button;

	public GImage Bg;

	public GLoader icon;

	public GRichTextField title;

	public GImage chipNote;

	public const string URL = "ui://f4wr270rmm8nf";

	public static string Name = "UI_rewardItem";

	public static string GetURL()
	{
		return "ui://f4wr270rmm8nf";
	}

	public static UI_rewardItem CreateInstance()
	{
		return (UI_rewardItem)(object)UIPackage.CreateObject("InstanceZones", "rewardItem");
	}

	public static UI_rewardItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_rewardItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rmm8nf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
	}
}

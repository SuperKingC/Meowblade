using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_LegendItemLoader : GButton
{
	public Controller button;

	public GLoader Icon;

	public GGraph MeteorSfxBack;

	public GGraph FlickerSfxBack;

	public Transition Draw;

	public const string URL = "ui://xogvri2hs2vzk";

	public static string Name = "UI_LegendItemLoader";

	public static string GetURL()
	{
		return "ui://xogvri2hs2vzk";
	}

	public static UI_LegendItemLoader CreateInstance()
	{
		return (UI_LegendItemLoader)(object)UIPackage.CreateObject("LegendItemsDraw", "LegendItemLoader");
	}

	public static UI_LegendItemLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hs2vzk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		MeteorSfxBack = (GGraph)((GComponent)this).GetChild("MeteorSfxBack");
		FlickerSfxBack = (GGraph)((GComponent)this).GetChild("FlickerSfxBack");
		Draw = ((GComponent)this).GetTransition("Draw");
	}
}

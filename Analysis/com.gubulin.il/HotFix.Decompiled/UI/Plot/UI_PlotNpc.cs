using FairyGUI;
using FairyGUI.Utils;

namespace UI.Plot;

public class UI_PlotNpc : GComponent
{
	public GImage n35;

	public GLoader NPCL;

	public GGraph backgroundL;

	public GRichTextField nameL;

	public const string URL = "ui://56axd6hevl2ea";

	public static string Name = "UI_PlotNpc";

	public static string GetURL()
	{
		return "ui://56axd6hevl2ea";
	}

	public static UI_PlotNpc CreateInstance()
	{
		return (UI_PlotNpc)(object)UIPackage.CreateObject("Plot", "PlotNpc");
	}

	public static UI_PlotNpc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlotNpc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56axd6hevl2ea", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n35 = (GImage)((GComponent)this).GetChild("n35");
		NPCL = (GLoader)((GComponent)this).GetChild("NPCL");
		backgroundL = (GGraph)((GComponent)this).GetChild("backgroundL");
		nameL = (GRichTextField)((GComponent)this).GetChild("nameL");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_LegionRaceFilters : GComponent
{
	public Controller PageController;

	public GLoader allFaction;

	public GLoader devilFaction;

	public GLoader deathFaction;

	public GLoader goblinFaction;

	public GLoader humanFaction;

	public GLoader orcFaction;

	public GLoader otherFaction;

	public const string URL = "ui://lrhs6zw7ogv945a";

	public static string Name = "UI_LegionRaceFilters";

	public static string GetURL()
	{
		return "ui://lrhs6zw7ogv945a";
	}

	public static UI_LegionRaceFilters CreateInstance()
	{
		return (UI_LegionRaceFilters)(object)UIPackage.CreateObject("Legion", "LegionRaceFilters");
	}

	public static UI_LegionRaceFilters CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegionRaceFilters).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7ogv945a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		allFaction = (GLoader)((GComponent)this).GetChild("allFaction");
		devilFaction = (GLoader)((GComponent)this).GetChild("devilFaction");
		deathFaction = (GLoader)((GComponent)this).GetChild("deathFaction");
		goblinFaction = (GLoader)((GComponent)this).GetChild("goblinFaction");
		humanFaction = (GLoader)((GComponent)this).GetChild("humanFaction");
		orcFaction = (GLoader)((GComponent)this).GetChild("orcFaction");
		otherFaction = (GLoader)((GComponent)this).GetChild("otherFaction");
	}
}

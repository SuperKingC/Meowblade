using FairyGUI;
using FairyGUI.Utils;

namespace UI.EnemyIntroduction;

public class UI_SoldierAnimarion : GComponent
{
	public GGraph Mask;

	public GGraph baseSpine;

	public GGraph icon;

	public GGraph maskSpine;

	public const string URL = "ui://rn232z3eocw1ji";

	public static string Name = "UI_SoldierAnimarion";

	public static string GetURL()
	{
		return "ui://rn232z3eocw1ji";
	}

	public static UI_SoldierAnimarion CreateInstance()
	{
		return (UI_SoldierAnimarion)(object)UIPackage.CreateObject("EnemyIntroduction", "SoldierAnimarion");
	}

	public static UI_SoldierAnimarion CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierAnimarion).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rn232z3eocw1ji", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		baseSpine = (GGraph)((GComponent)this).GetChild("baseSpine");
		icon = (GGraph)((GComponent)this).GetChild("icon");
		maskSpine = (GGraph)((GComponent)this).GetChild("maskSpine");
	}
}

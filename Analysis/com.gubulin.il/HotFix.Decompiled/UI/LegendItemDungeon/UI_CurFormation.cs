using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_CurFormation : GComponent
{
	public Controller Status;

	public GGraph n1;

	public GImage n7;

	public UI_FormationBtn MainFormation;

	public GList Formations;

	public GImage arrowUp;

	public GImage arrowDown;

	public const string URL = "ui://2eraz3j9ldt62f";

	public static string Name = "UI_CurFormation";

	public static string GetURL()
	{
		return "ui://2eraz3j9ldt62f";
	}

	public static UI_CurFormation CreateInstance()
	{
		return (UI_CurFormation)(object)UIPackage.CreateObject("LegendItemDungeon", "CurFormation");
	}

	public static UI_CurFormation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CurFormation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9ldt62f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		MainFormation = (UI_FormationBtn)(object)((GComponent)this).GetChild("MainFormation");
		Formations = (GList)((GComponent)this).GetChild("Formations");
		arrowUp = (GImage)((GComponent)this).GetChild("arrowUp");
		arrowDown = (GImage)((GComponent)this).GetChild("arrowDown");
	}
}

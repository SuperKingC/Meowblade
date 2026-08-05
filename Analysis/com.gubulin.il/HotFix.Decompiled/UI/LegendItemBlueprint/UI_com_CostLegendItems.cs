using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_CostLegendItems : GComponent
{
	public Controller c1;

	public GImage n16;

	public GList Cost;

	public UI_dec_ForgeProgress n20;

	public GImage n21;

	public GImage n18;

	public UI_dec_ForgeProgressFrame n19;

	public GMovieClip n22;

	public Transition t0;

	public const string URL = "ui://h09dvkcgrtmo1x";

	public static string Name = "UI_com_CostLegendItems";

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo1x";
	}

	public static UI_com_CostLegendItems CreateInstance()
	{
		return (UI_com_CostLegendItems)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_CostLegendItems");
	}

	public static UI_com_CostLegendItems CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CostLegendItems).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo1x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		Cost = (GList)((GComponent)this).GetChild("Cost");
		n20 = (UI_dec_ForgeProgress)(object)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (UI_dec_ForgeProgressFrame)(object)((GComponent)this).GetChild("n19");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

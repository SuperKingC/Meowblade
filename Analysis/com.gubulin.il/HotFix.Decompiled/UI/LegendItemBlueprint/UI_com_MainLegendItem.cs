using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_MainLegendItem : GComponent
{
	public Controller c1;

	public GImage n4;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public UI_com_LegendItemForgeCost Main;

	public GTextField n11;

	public Transition t0;

	public const string URL = "ui://h09dvkcgrtmo1q";

	public static string Name = "UI_com_MainLegendItem";

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo1q";
	}

	public static UI_com_MainLegendItem CreateInstance()
	{
		return (UI_com_MainLegendItem)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_MainLegendItem");
	}

	public static UI_com_MainLegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MainLegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Main = (UI_com_LegendItemForgeCost)(object)((GComponent)this).GetChild("Main");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://h09dvkcgrtmo1q".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

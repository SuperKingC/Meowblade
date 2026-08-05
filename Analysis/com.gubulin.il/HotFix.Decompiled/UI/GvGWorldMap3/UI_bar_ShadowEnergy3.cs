using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_bar_ShadowEnergy3 : GProgressBar
{
	public Controller Step;

	public Controller Status;

	public GImage n22;

	public GImage bar;

	public GImage n28;

	public UI_dec_02 n31;

	public GTextField Energy;

	public GImage n27;

	public GImage n23;

	public GImage n26;

	public GTextField n29;

	public UI_btn_BossBreakDownTip BossBreakDownTip;

	public Transition t2;

	public const string URL = "ui://4eq8fgd2zit4ah";

	public static string Name = "UI_bar_ShadowEnergy3";

	public static string GetURL()
	{
		return "ui://4eq8fgd2zit4ah";
	}

	public static UI_bar_ShadowEnergy3 CreateInstance()
	{
		return (UI_bar_ShadowEnergy3)(object)UIPackage.CreateObject("GvGWorldMap3", "bar_ShadowEnergy3");
	}

	public static UI_bar_ShadowEnergy3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_bar_ShadowEnergy3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2zit4ah", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Step = ((GComponent)this).GetController("Step");
		Status = ((GComponent)this).GetController("Status");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		bar = (GImage)((GComponent)this).GetChild("bar");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n31 = (UI_dec_02)(object)((GComponent)this).GetChild("n31");
		Energy = (GTextField)((GComponent)this).GetChild("Energy");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id = "ui://4eq8fgd2zit4ah".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id);
		BossBreakDownTip = (UI_btn_BossBreakDownTip)(object)((GComponent)this).GetChild("BossBreakDownTip");
		t2 = ((GComponent)this).GetTransition("t2");
	}
}

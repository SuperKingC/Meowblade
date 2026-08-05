using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ConfirmCreateRepeatedAttackPlan : GComponent
{
	public GImage back;

	public GImage n23;

	public GTextField Tip;

	public GTextField n15;

	public GLoader n16;

	public GTextField FoodCost;

	public GImage n19;

	public GTextField n20;

	public GGroup n21;

	public GList Legions;

	public UI_btn_yes Confirm;

	public UI_btn_Cancel Cancel;

	public const string URL = "ui://4eq8fgd2efz66sd3";

	public static string Name = "UI_com_ConfirmCreateRepeatedAttackPlan";

	public static string GetURL()
	{
		return "ui://4eq8fgd2efz66sd3";
	}

	public static UI_com_ConfirmCreateRepeatedAttackPlan CreateInstance()
	{
		return (UI_com_ConfirmCreateRepeatedAttackPlan)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ConfirmCreateRepeatedAttackPlan");
	}

	public static UI_com_ConfirmCreateRepeatedAttackPlan CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ConfirmCreateRepeatedAttackPlan).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2efz66sd3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://4eq8fgd2efz66sd3".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n16 = (GLoader)((GComponent)this).GetChild("n16");
		FoodCost = (GTextField)((GComponent)this).GetChild("FoodCost");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id2 = "ui://4eq8fgd2efz66sd3".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id2);
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		Legions = (GList)((GComponent)this).GetChild("Legions");
		Confirm = (UI_btn_yes)(object)((GComponent)this).GetChild("Confirm");
		Cancel = (UI_btn_Cancel)(object)((GComponent)this).GetChild("Cancel");
	}
}

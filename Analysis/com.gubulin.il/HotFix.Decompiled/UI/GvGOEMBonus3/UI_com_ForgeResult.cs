using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMBonus3;

public class UI_com_ForgeResult : GComponent
{
	public Controller hasExtraReward;

	public GImage n191;

	public GImage n225;

	public GImage n206;

	public GImage n222;

	public GImage n223;

	public GImage n209;

	public GImage n224;

	public GImage n210;

	public GImage n205;

	public GTextField n201;

	public GList Amps;

	public GList Bonus;

	public UI_btn_ConfirmBtn Confirm;

	public GLoader Icon;

	public GTextField TotalCount;

	public GTextField n212;

	public GLoader TotalIcon;

	public GGroup n214;

	public GImage n218;

	public GTextField n219;

	public GList ExtraReward;

	public GGroup extraReward;

	public const string URL = "ui://h3bpjkt7pg607";

	public static string Name = "UI_com_ForgeResult";

	public static string GetURL()
	{
		return "ui://h3bpjkt7pg607";
	}

	public static UI_com_ForgeResult CreateInstance()
	{
		return (UI_com_ForgeResult)(object)UIPackage.CreateObject("GvGOEMBonus3", "com_ForgeResult");
	}

	public static UI_com_ForgeResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ForgeResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7pg607", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hasExtraReward = ((GComponent)this).GetController("hasExtraReward");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n225 = (GImage)((GComponent)this).GetChild("n225");
		n206 = (GImage)((GComponent)this).GetChild("n206");
		n222 = (GImage)((GComponent)this).GetChild("n222");
		n223 = (GImage)((GComponent)this).GetChild("n223");
		n209 = (GImage)((GComponent)this).GetChild("n209");
		n224 = (GImage)((GComponent)this).GetChild("n224");
		n210 = (GImage)((GComponent)this).GetChild("n210");
		n205 = (GImage)((GComponent)this).GetChild("n205");
		n201 = (GTextField)((GComponent)this).GetChild("n201");
		string id = "ui://h3bpjkt7pg607".Replace("ui://", "") + "-" + ((GObject)n201).id;
		((GObject)n201).text = LanguagesManager.GetDesc(id);
		Amps = (GList)((GComponent)this).GetChild("Amps");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		Confirm = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("Confirm");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		TotalCount = (GTextField)((GComponent)this).GetChild("TotalCount");
		n212 = (GTextField)((GComponent)this).GetChild("n212");
		string id2 = "ui://h3bpjkt7pg607".Replace("ui://", "") + "-" + ((GObject)n212).id;
		((GObject)n212).text = LanguagesManager.GetDesc(id2);
		TotalIcon = (GLoader)((GComponent)this).GetChild("TotalIcon");
		n214 = (GGroup)((GComponent)this).GetChild("n214");
		n218 = (GImage)((GComponent)this).GetChild("n218");
		n219 = (GTextField)((GComponent)this).GetChild("n219");
		string id3 = "ui://h3bpjkt7pg607".Replace("ui://", "") + "-" + ((GObject)n219).id;
		((GObject)n219).text = LanguagesManager.GetDesc(id3);
		ExtraReward = (GList)((GComponent)this).GetChild("ExtraReward");
		extraReward = (GGroup)((GComponent)this).GetChild("extraReward");
	}
}

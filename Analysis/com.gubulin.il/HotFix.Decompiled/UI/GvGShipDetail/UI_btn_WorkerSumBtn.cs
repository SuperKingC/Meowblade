using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_WorkerSumBtn : GButton
{
	public Controller WokerStatus;

	public Controller button;

	public GImage n75;

	public GImage n112;

	public GTextField n113;

	public GTextField n99;

	public GTextField n102;

	public GImage n114;

	public GImage n115;

	public GImage n116;

	public GTextField n117;

	public GLoader WorkerStatusIcon;

	public GTextField WorkersCount;

	public GImage n118;

	public const string URL = "ui://u6x0b1gnbvnu38";

	public static string Name = "UI_btn_WorkerSumBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnbvnu38";
	}

	public static UI_btn_WorkerSumBtn CreateInstance()
	{
		return (UI_btn_WorkerSumBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_WorkerSumBtn");
	}

	public static UI_btn_WorkerSumBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_WorkerSumBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnbvnu38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		WokerStatus = ((GComponent)this).GetController("WokerStatus");
		button = ((GComponent)this).GetController("button");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		n113 = (GTextField)((GComponent)this).GetChild("n113");
		string id = "ui://u6x0b1gnbvnu38".Replace("ui://", "") + "-" + ((GObject)n113).id;
		((GObject)n113).text = LanguagesManager.GetDesc(id);
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id2 = "ui://u6x0b1gnbvnu38".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id2);
		n102 = (GTextField)((GComponent)this).GetChild("n102");
		string id3 = "ui://u6x0b1gnbvnu38".Replace("ui://", "") + "-" + ((GObject)n102).id;
		((GObject)n102).text = LanguagesManager.GetDesc(id3);
		n114 = (GImage)((GComponent)this).GetChild("n114");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id4 = "ui://u6x0b1gnbvnu38".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id4);
		WorkerStatusIcon = (GLoader)((GComponent)this).GetChild("WorkerStatusIcon");
		WorkersCount = (GTextField)((GComponent)this).GetChild("WorkersCount");
		n118 = (GImage)((GComponent)this).GetChild("n118");
	}
}

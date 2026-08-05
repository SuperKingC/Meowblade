using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_OptionalBlueprintPopup : GComponent
{
	public Controller isPreviewMode;

	public Controller editState;

	public Controller Type;

	public UI_com_OptionalBlueprintPopupPoplist selectPopList;

	public GImage back;

	public GImage n153;

	public GImage n154;

	public UI_com_OptionalBlueprintPopupInfolist InfoList;

	public GImage n155;

	public GImage n156;

	public GImage n159;

	public GImage n160;

	public GImage n162;

	public GImage n161;

	public GImage n169;

	public GImage n170;

	public GImage n157;

	public GImage n158;

	public UI_com_ScrollOptionalBlueprint scrollArrow;

	public UI_btn_no resetBtn;

	public UI_btn_yes generateBtn;

	public GGroup generateBp;

	public GGroup part5;

	public UI_btn_Close exitBtn;

	public UI_btn_yes confirmBtn;

	public GImage n164;

	public UI_dec_block01 n177;

	public GImage n179;

	public GImage n178;

	public GImage n180;

	public GLoader bpTitle;

	public GTextField n168;

	public Transition showPopup;

	public Transition t1;

	public const string URL = "ui://h09dvkcgt49p5ltdr";

	public static string Name = "UI_com_OptionalBlueprintPopup";

	public static string GetURL()
	{
		return "ui://h09dvkcgt49p5ltdr";
	}

	public static UI_com_OptionalBlueprintPopup CreateInstance()
	{
		return (UI_com_OptionalBlueprintPopup)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_OptionalBlueprintPopup");
	}

	public static UI_com_OptionalBlueprintPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OptionalBlueprintPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgt49p5ltdr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isPreviewMode = ((GComponent)this).GetController("isPreviewMode");
		editState = ((GComponent)this).GetController("editState");
		Type = ((GComponent)this).GetController("Type");
		selectPopList = (UI_com_OptionalBlueprintPopupPoplist)(object)((GComponent)this).GetChild("selectPopList");
		back = (GImage)((GComponent)this).GetChild("back");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n154 = (GImage)((GComponent)this).GetChild("n154");
		InfoList = (UI_com_OptionalBlueprintPopupInfolist)(object)((GComponent)this).GetChild("InfoList");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		n161 = (GImage)((GComponent)this).GetChild("n161");
		n169 = (GImage)((GComponent)this).GetChild("n169");
		n170 = (GImage)((GComponent)this).GetChild("n170");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		scrollArrow = (UI_com_ScrollOptionalBlueprint)(object)((GComponent)this).GetChild("scrollArrow");
		resetBtn = (UI_btn_no)(object)((GComponent)this).GetChild("resetBtn");
		generateBtn = (UI_btn_yes)(object)((GComponent)this).GetChild("generateBtn");
		generateBp = (GGroup)((GComponent)this).GetChild("generateBp");
		part5 = (GGroup)((GComponent)this).GetChild("part5");
		exitBtn = (UI_btn_Close)(object)((GComponent)this).GetChild("exitBtn");
		confirmBtn = (UI_btn_yes)(object)((GComponent)this).GetChild("confirmBtn");
		n164 = (GImage)((GComponent)this).GetChild("n164");
		n177 = (UI_dec_block01)(object)((GComponent)this).GetChild("n177");
		n179 = (GImage)((GComponent)this).GetChild("n179");
		n178 = (GImage)((GComponent)this).GetChild("n178");
		n180 = (GImage)((GComponent)this).GetChild("n180");
		bpTitle = (GLoader)((GComponent)this).GetChild("bpTitle");
		n168 = (GTextField)((GComponent)this).GetChild("n168");
		string id = "ui://h09dvkcgt49p5ltdr".Replace("ui://", "") + "-" + ((GObject)n168).id;
		((GObject)n168).text = LanguagesManager.GetDesc(id);
		showPopup = ((GComponent)this).GetTransition("showPopup");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}

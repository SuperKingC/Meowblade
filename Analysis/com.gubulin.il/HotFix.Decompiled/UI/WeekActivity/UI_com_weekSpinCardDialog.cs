using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_weekSpinCardDialog : GComponent
{
	public Controller Mode;

	public GImage n149;

	public GImage n143;

	public GImage n163;

	public GImage n167;

	public GImage n160;

	public GImage n170;

	public GImage n165;

	public GImage n166;

	public GImage n159;

	public GImage n168;

	public GImage n169;

	public GImage n162;

	public GImage n164;

	public UI_ExitAdvancedBtn BackBtn;

	public GList RewardList;

	public GImage n146;

	public UI_BuyAdvancedBtn BuyAdvanceBtn;

	public GImage n147;

	public GImage n148;

	public GImage n155;

	public GImage n156;

	public GTextField Time;

	public GGroup TitleGroup;

	public GTextField tip;

	public GImage n150;

	public GImage n152;

	public GMovieClip n154;

	public GImage n151;

	public const string URL = "ui://jl0c82y5i9x228";

	public static string Name = "UI_com_weekSpinCardDialog";

	public static string GetURL()
	{
		return "ui://jl0c82y5i9x228";
	}

	public static UI_com_weekSpinCardDialog CreateInstance()
	{
		return (UI_com_weekSpinCardDialog)(object)UIPackage.CreateObject("WeekActivity", "com_weekSpinCardDialog");
	}

	public static UI_com_weekSpinCardDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_weekSpinCardDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5i9x228", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mode = ((GComponent)this).GetController("Mode");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		n167 = (GImage)((GComponent)this).GetChild("n167");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n170 = (GImage)((GComponent)this).GetChild("n170");
		n165 = (GImage)((GComponent)this).GetChild("n165");
		n166 = (GImage)((GComponent)this).GetChild("n166");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n168 = (GImage)((GComponent)this).GetChild("n168");
		n169 = (GImage)((GComponent)this).GetChild("n169");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		n164 = (GImage)((GComponent)this).GetChild("n164");
		BackBtn = (UI_ExitAdvancedBtn)(object)((GComponent)this).GetChild("BackBtn");
		RewardList = (GList)((GComponent)this).GetChild("RewardList");
		n146 = (GImage)((GComponent)this).GetChild("n146");
		BuyAdvanceBtn = (UI_BuyAdvancedBtn)(object)((GComponent)this).GetChild("BuyAdvanceBtn");
		n147 = (GImage)((GComponent)this).GetChild("n147");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		TitleGroup = (GGroup)((GComponent)this).GetChild("TitleGroup");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://jl0c82y5i9x228".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n150 = (GImage)((GComponent)this).GetChild("n150");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n154 = (GMovieClip)((GComponent)this).GetChild("n154");
		n151 = (GImage)((GComponent)this).GetChild("n151");
	}
}

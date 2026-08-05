using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_ItemsCounter : GComponent
{
	public GTextField Title;

	public GImage compoundNumBack;

	public GTextField compoundNum;

	public UI_btn_IncreaseButton increaseBtn;

	public UI_btn_ReduceButton reduceBtn;

	public UI_btn_MaxValue MaxValueBtn;

	public GGroup n86;

	public const string URL = "ui://p4ocf6q09ewlg";

	public static string Name = "UI_com_ItemsCounter";

	public static string GetURL()
	{
		return "ui://p4ocf6q09ewlg";
	}

	public static UI_com_ItemsCounter CreateInstance()
	{
		return (UI_com_ItemsCounter)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_ItemsCounter");
	}

	public static UI_com_ItemsCounter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ItemsCounter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q09ewlg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://p4ocf6q09ewlg".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		compoundNumBack = (GImage)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextField)((GComponent)this).GetChild("compoundNum");
		increaseBtn = (UI_btn_IncreaseButton)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_btn_ReduceButton)(object)((GComponent)this).GetChild("reduceBtn");
		MaxValueBtn = (UI_btn_MaxValue)(object)((GComponent)this).GetChild("MaxValueBtn");
		n86 = (GGroup)((GComponent)this).GetChild("n86");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_OemCount : GComponent
{
	public GImage n30;

	public UI_btn_Increase AddBtn;

	public UI_btn_ReduceBtn ReduceBtn;

	public UI_btn_MaxBtn MaxBtn;

	public GTextField AttackCount;

	public const string URL = "ui://4eq8fgd2efz66scv";

	public static string Name = "UI_com_OemCount";

	public static string GetURL()
	{
		return "ui://4eq8fgd2efz66scv";
	}

	public static UI_com_OemCount CreateInstance()
	{
		return (UI_com_OemCount)(object)UIPackage.CreateObject("GvGWorldMap3", "com_OemCount");
	}

	public static UI_com_OemCount CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OemCount).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2efz66scv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n30 = (GImage)((GComponent)this).GetChild("n30");
		AddBtn = (UI_btn_Increase)(object)((GComponent)this).GetChild("AddBtn");
		ReduceBtn = (UI_btn_ReduceBtn)(object)((GComponent)this).GetChild("ReduceBtn");
		MaxBtn = (UI_btn_MaxBtn)(object)((GComponent)this).GetChild("MaxBtn");
		AttackCount = (GTextField)((GComponent)this).GetChild("AttackCount");
	}
}

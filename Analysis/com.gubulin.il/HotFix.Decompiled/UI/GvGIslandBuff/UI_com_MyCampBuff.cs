using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_com_MyCampBuff : GComponent
{
	public Controller DetailsOnorOff;

	public Controller HasBuff;

	public GImage n7;

	public GTextField n0;

	public GList BuffList;

	public GTextField n19;

	public GImage n18;

	public GTextField n14;

	public GList myDetailList;

	public GTextField n1;

	public GTextField n15;

	public GImage n16;

	public UI_btn_LookBuffDetails Btn_ViewDetail;

	public const string URL = "ui://zh7jgfijnewqfl";

	public static string Name = "UI_com_MyCampBuff";

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqfl";
	}

	public static UI_com_MyCampBuff CreateInstance()
	{
		return (UI_com_MyCampBuff)(object)UIPackage.CreateObject("GvGIslandBuff", "com_MyCampBuff");
	}

	public static UI_com_MyCampBuff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MyCampBuff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		DetailsOnorOff = ((GComponent)this).GetController("DetailsOnorOff");
		HasBuff = ((GComponent)this).GetController("HasBuff");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://zh7jgfijnewqfl".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		BuffList = (GList)((GComponent)this).GetChild("BuffList");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id2 = "ui://zh7jgfijnewqfl".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id2);
		myDetailList = (GList)((GComponent)this).GetChild("myDetailList");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id3 = "ui://zh7jgfijnewqfl".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id3);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id4 = "ui://zh7jgfijnewqfl".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id4);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		Btn_ViewDetail = (UI_btn_LookBuffDetails)(object)((GComponent)this).GetChild("Btn_ViewDetail");
	}
}

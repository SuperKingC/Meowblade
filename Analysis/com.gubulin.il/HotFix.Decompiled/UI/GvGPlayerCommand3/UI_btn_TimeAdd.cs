using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_TimeAdd : GButton
{
	public Controller button;

	public Controller ConfigIndex;

	public GImage n13;

	public GTextField Time;

	public GTextField n8;

	public GGroup n9;

	public UI_com_TimeBar n10;

	public UI_com_TimeBar n11;

	public UI_com_TimeBar n12;

	public GImage n14;

	public GImage n15;

	public const string URL = "ui://vheg8vabeai3j";

	public static string Name = "UI_btn_TimeAdd";

	public static string GetURL()
	{
		return "ui://vheg8vabeai3j";
	}

	public static UI_btn_TimeAdd CreateInstance()
	{
		return (UI_btn_TimeAdd)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_TimeAdd");
	}

	public static UI_btn_TimeAdd CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TimeAdd).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ConfigIndex = ((GComponent)this).GetController("ConfigIndex");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://vheg8vabeai3j".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n10 = (UI_com_TimeBar)(object)((GComponent)this).GetChild("n10");
		n11 = (UI_com_TimeBar)(object)((GComponent)this).GetChild("n11");
		n12 = (UI_com_TimeBar)(object)((GComponent)this).GetChild("n12");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_nodeBtn : GComponent
{
	public Controller button;

	public Controller Status;

	public Controller ShowItems;

	public GImage back2;

	public GGraph stroke;

	public GGraph back;

	public UI_nodeRewardIcon leftIcon;

	public UI_nodeRewardIcon rightIcon;

	public UI_nodeRewardIcon middleIcon;

	public GTextField tip;

	public GLoader icon2;

	public GTextField num2;

	public GLoader icon0;

	public GTextField num0;

	public GLoader icon1;

	public GTextField num1;

	public GLoader icon3;

	public GTextField num3;

	public GGroup Items;

	public const string URL = "ui://f4wr270rkpq6z";

	public static string Name = "UI_nodeBtn";

	public static string GetURL()
	{
		return "ui://f4wr270rkpq6z";
	}

	public static UI_nodeBtn CreateInstance()
	{
		return (UI_nodeBtn)(object)UIPackage.CreateObject("InstanceZones", "nodeBtn");
	}

	public static UI_nodeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_nodeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rkpq6z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		ShowItems = ((GComponent)this).GetController("ShowItems");
		back2 = (GImage)((GComponent)this).GetChild("back2");
		stroke = (GGraph)((GComponent)this).GetChild("stroke");
		back = (GGraph)((GComponent)this).GetChild("back");
		leftIcon = (UI_nodeRewardIcon)(object)((GComponent)this).GetChild("leftIcon");
		rightIcon = (UI_nodeRewardIcon)(object)((GComponent)this).GetChild("rightIcon");
		middleIcon = (UI_nodeRewardIcon)(object)((GComponent)this).GetChild("middleIcon");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://f4wr270rkpq6z".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		icon2 = (GLoader)((GComponent)this).GetChild("icon2");
		num2 = (GTextField)((GComponent)this).GetChild("num2");
		string id2 = "ui://f4wr270rkpq6z".Replace("ui://", "") + "-" + ((GObject)num2).id;
		((GObject)num2).text = LanguagesManager.GetDesc(id2);
		icon0 = (GLoader)((GComponent)this).GetChild("icon0");
		num0 = (GTextField)((GComponent)this).GetChild("num0");
		string id3 = "ui://f4wr270rkpq6z".Replace("ui://", "") + "-" + ((GObject)num0).id;
		((GObject)num0).text = LanguagesManager.GetDesc(id3);
		icon1 = (GLoader)((GComponent)this).GetChild("icon1");
		num1 = (GTextField)((GComponent)this).GetChild("num1");
		string id4 = "ui://f4wr270rkpq6z".Replace("ui://", "") + "-" + ((GObject)num1).id;
		((GObject)num1).text = LanguagesManager.GetDesc(id4);
		icon3 = (GLoader)((GComponent)this).GetChild("icon3");
		num3 = (GTextField)((GComponent)this).GetChild("num3");
		string id5 = "ui://f4wr270rkpq6z".Replace("ui://", "") + "-" + ((GObject)num3).id;
		((GObject)num3).text = LanguagesManager.GetDesc(id5);
		Items = (GGroup)((GComponent)this).GetChild("Items");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_RaritySeparator : GComponent
{
	public Controller Rarity;

	public GLoader n133;

	public GLoader n132;

	public GImage n134;

	public GTextField n119;

	public GTextField n120;

	public GTextField n121;

	public GTextField n123;

	public GTextField n124;

	public GTextField n126;

	public GTextField n127;

	public GTextField TechCount;

	public GTextField n129;

	public GTextField n135;

	public GTextField n136;

	public GTextField n137;

	public GTextField n138;

	public GTextField n139;

	public GTextField n140;

	public GLoader PieceIcon;

	public GTextField PieceCount;

	public UI_btn_01 helpBtn;

	public const string URL = "ui://th385mtty63lh";

	public static string Name = "UI_com_RaritySeparator";

	public static string GetURL()
	{
		return "ui://th385mtty63lh";
	}

	public static UI_com_RaritySeparator CreateInstance()
	{
		return (UI_com_RaritySeparator)(object)UIPackage.CreateObject("GvGOuterTech", "com_RaritySeparator");
	}

	public static UI_com_RaritySeparator CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RaritySeparator).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty63lh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected O, but got Unknown
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Expected O, but got Unknown
		//IL_0532: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		n133 = (GLoader)((GComponent)this).GetChild("n133");
		n132 = (GLoader)((GComponent)this).GetChild("n132");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n119 = (GTextField)((GComponent)this).GetChild("n119");
		string id = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n119).id;
		((GObject)n119).text = LanguagesManager.GetDesc(id);
		n120 = (GTextField)((GComponent)this).GetChild("n120");
		string id2 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n120).id;
		((GObject)n120).text = LanguagesManager.GetDesc(id2);
		n121 = (GTextField)((GComponent)this).GetChild("n121");
		string id3 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n121).id;
		((GObject)n121).text = LanguagesManager.GetDesc(id3);
		n123 = (GTextField)((GComponent)this).GetChild("n123");
		string id4 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n123).id;
		((GObject)n123).text = LanguagesManager.GetDesc(id4);
		n124 = (GTextField)((GComponent)this).GetChild("n124");
		string id5 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n124).id;
		((GObject)n124).text = LanguagesManager.GetDesc(id5);
		n126 = (GTextField)((GComponent)this).GetChild("n126");
		string id6 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n126).id;
		((GObject)n126).text = LanguagesManager.GetDesc(id6);
		n127 = (GTextField)((GComponent)this).GetChild("n127");
		string id7 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n127).id;
		((GObject)n127).text = LanguagesManager.GetDesc(id7);
		TechCount = (GTextField)((GComponent)this).GetChild("TechCount");
		n129 = (GTextField)((GComponent)this).GetChild("n129");
		string id8 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n129).id;
		((GObject)n129).text = LanguagesManager.GetDesc(id8);
		n135 = (GTextField)((GComponent)this).GetChild("n135");
		string id9 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n135).id;
		((GObject)n135).text = LanguagesManager.GetDesc(id9);
		n136 = (GTextField)((GComponent)this).GetChild("n136");
		string id10 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n136).id;
		((GObject)n136).text = LanguagesManager.GetDesc(id10);
		n137 = (GTextField)((GComponent)this).GetChild("n137");
		string id11 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n137).id;
		((GObject)n137).text = LanguagesManager.GetDesc(id11);
		n138 = (GTextField)((GComponent)this).GetChild("n138");
		string id12 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n138).id;
		((GObject)n138).text = LanguagesManager.GetDesc(id12);
		n139 = (GTextField)((GComponent)this).GetChild("n139");
		string id13 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n139).id;
		((GObject)n139).text = LanguagesManager.GetDesc(id13);
		n140 = (GTextField)((GComponent)this).GetChild("n140");
		string id14 = "ui://th385mtty63lh".Replace("ui://", "") + "-" + ((GObject)n140).id;
		((GObject)n140).text = LanguagesManager.GetDesc(id14);
		PieceIcon = (GLoader)((GComponent)this).GetChild("PieceIcon");
		PieceCount = (GTextField)((GComponent)this).GetChild("PieceCount");
		helpBtn = (UI_btn_01)(object)((GComponent)this).GetChild("helpBtn");
	}
}

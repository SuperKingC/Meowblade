using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_Output : GButton
{
	public Controller HasExtraInfo;

	public Controller state;

	public Controller Type;

	public Controller StockType;

	public GImage n4;

	public GImage n16;

	public UI_com_IslandSpeciality Icon;

	public GTextField GvGStoreHouseStock;

	public UI_com_SpecialRecource ExtraInfo;

	public GTextField RemainingNumber;

	public GTextField ItemName;

	public GTextField n11;

	public GGroup n8;

	public GImage n6;

	public GImage n17;

	public GGroup n7;

	public GTextField Output;

	public GTextField n12;

	public GTextField n13;

	public GImage n15;

	public const string URL = "ui://4eq8fgd2o8el2y";

	public static string Name = "UI_com_Output";

	public int InitState;

	public bool IsSelected => state.selectedIndex != 0;

	public static string GetURL()
	{
		return "ui://4eq8fgd2o8el2y";
	}

	public static UI_com_Output CreateInstance()
	{
		return (UI_com_Output)(object)UIPackage.CreateObject("GvGWorldMap3", "com_Output");
	}

	public static UI_com_Output CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Output).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2o8el2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasExtraInfo = ((GComponent)this).GetController("HasExtraInfo");
		state = ((GComponent)this).GetController("state");
		Type = ((GComponent)this).GetController("Type");
		StockType = ((GComponent)this).GetController("StockType");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		Icon = (UI_com_IslandSpeciality)(object)((GComponent)this).GetChild("Icon");
		GvGStoreHouseStock = (GTextField)((GComponent)this).GetChild("GvGStoreHouseStock");
		ExtraInfo = (UI_com_SpecialRecource)(object)((GComponent)this).GetChild("ExtraInfo");
		RemainingNumber = (GTextField)((GComponent)this).GetChild("RemainingNumber");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://4eq8fgd2o8el2y".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		Output = (GTextField)((GComponent)this).GetChild("Output");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id2 = "ui://4eq8fgd2o8el2y".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id2);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id3 = "ui://4eq8fgd2o8el2y".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id3);
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}

	public bool IsStateChange()
	{
		return state.selectedIndex != InitState;
	}
}

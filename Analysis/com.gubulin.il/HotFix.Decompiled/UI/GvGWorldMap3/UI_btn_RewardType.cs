using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_RewardType : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n3;

	public GImage n8;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public GGroup n9;

	public GTextField n10;

	public GTextField n11;

	public GTextField n12;

	public GTextField n13;

	public GGroup n14;

	public const string URL = "ui://4eq8fgd2h4tpet";

	public static string Name = "UI_btn_RewardType";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpet";
	}

	public static UI_btn_RewardType CreateInstance()
	{
		return (UI_btn_RewardType)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_RewardType");
	}

	public static UI_btn_RewardType CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RewardType).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpet", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id4 = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id4);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id5 = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id5);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id6 = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id6);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id7 = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id7);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id8 = "ui://4eq8fgd2h4tpet".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id8);
		n14 = (GGroup)((GComponent)this).GetChild("n14");
	}
}

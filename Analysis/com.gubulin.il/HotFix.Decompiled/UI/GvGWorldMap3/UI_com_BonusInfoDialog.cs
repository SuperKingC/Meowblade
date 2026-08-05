using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_BonusInfoDialog : GComponent
{
	public Controller RewardType;

	public GImage n191;

	public GImage n205;

	public GList RankBonusList;

	public GTextField n202;

	public GTextField n203;

	public GTextField n204;

	public GTextField n206;

	public GTextField n207;

	public GTextField n208;

	public GTextField n209;

	public GTextField n210;

	public GTextField n211;

	public GTextField n212;

	public GTextField n213;

	public const string URL = "ui://4eq8fgd2h4tpel";

	public static string Name = "UI_com_BonusInfoDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpel";
	}

	public static UI_com_BonusInfoDialog CreateInstance()
	{
		return (UI_com_BonusInfoDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BonusInfoDialog");
	}

	public static UI_com_BonusInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BonusInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpel", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RewardType = ((GComponent)this).GetController("RewardType");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n205 = (GImage)((GComponent)this).GetChild("n205");
		RankBonusList = (GList)((GComponent)this).GetChild("RankBonusList");
		n202 = (GTextField)((GComponent)this).GetChild("n202");
		string id = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n202).id;
		((GObject)n202).text = LanguagesManager.GetDesc(id);
		n203 = (GTextField)((GComponent)this).GetChild("n203");
		string id2 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n203).id;
		((GObject)n203).text = LanguagesManager.GetDesc(id2);
		n204 = (GTextField)((GComponent)this).GetChild("n204");
		string id3 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n204).id;
		((GObject)n204).text = LanguagesManager.GetDesc(id3);
		n206 = (GTextField)((GComponent)this).GetChild("n206");
		string id4 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n206).id;
		((GObject)n206).text = LanguagesManager.GetDesc(id4);
		n207 = (GTextField)((GComponent)this).GetChild("n207");
		string id5 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n207).id;
		((GObject)n207).text = LanguagesManager.GetDesc(id5);
		n208 = (GTextField)((GComponent)this).GetChild("n208");
		string id6 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n208).id;
		((GObject)n208).text = LanguagesManager.GetDesc(id6);
		n209 = (GTextField)((GComponent)this).GetChild("n209");
		string id7 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n209).id;
		((GObject)n209).text = LanguagesManager.GetDesc(id7);
		n210 = (GTextField)((GComponent)this).GetChild("n210");
		string id8 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n210).id;
		((GObject)n210).text = LanguagesManager.GetDesc(id8);
		n211 = (GTextField)((GComponent)this).GetChild("n211");
		string id9 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n211).id;
		((GObject)n211).text = LanguagesManager.GetDesc(id9);
		n212 = (GTextField)((GComponent)this).GetChild("n212");
		string id10 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n212).id;
		((GObject)n212).text = LanguagesManager.GetDesc(id10);
		n213 = (GTextField)((GComponent)this).GetChild("n213");
		string id11 = "ui://4eq8fgd2h4tpel".Replace("ui://", "") + "-" + ((GObject)n213).id;
		((GObject)n213).text = LanguagesManager.GetDesc(id11);
	}
}

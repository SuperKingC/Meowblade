using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_PostFormulaOemBonus : GComponent
{
	public Controller BonusType;

	public GTextField n0;

	public GTextField BonusValue;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public const string URL = "ui://tt2iq07odip34y";

	public static string Name = "UI_com_PostFormulaOemBonus";

	public static string GetURL()
	{
		return "ui://tt2iq07odip34y";
	}

	public static UI_com_PostFormulaOemBonus CreateInstance()
	{
		return (UI_com_PostFormulaOemBonus)(object)UIPackage.CreateObject("GvGExchange3", "com_PostFormulaOemBonus");
	}

	public static UI_com_PostFormulaOemBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PostFormulaOemBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odip34y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BonusType = ((GComponent)this).GetController("BonusType");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://tt2iq07odip34y".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		BonusValue = (GTextField)((GComponent)this).GetChild("BonusValue");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://tt2iq07odip34y".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://tt2iq07odip34y".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id4 = "ui://tt2iq07odip34y".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id4);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id5 = "ui://tt2iq07odip34y".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id5);
	}
}

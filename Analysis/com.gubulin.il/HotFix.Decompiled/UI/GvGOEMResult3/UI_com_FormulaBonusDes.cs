using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMResult3;

public class UI_com_FormulaBonusDes : GComponent
{
	public Controller Type;

	public Controller Get;

	public Controller hasDebuff;

	public GImage n209;

	public GTextField Count;

	public GTextField n210;

	public GTextField n211;

	public GTextField n212;

	public GTextField n213;

	public GTextField n216;

	public GImage n214;

	public GImage n215;

	public const string URL = "ui://5k1s1pjxt0zv5x";

	public static string Name = "UI_com_FormulaBonusDes";

	public static string GetURL()
	{
		return "ui://5k1s1pjxt0zv5x";
	}

	public static UI_com_FormulaBonusDes CreateInstance()
	{
		return (UI_com_FormulaBonusDes)(object)UIPackage.CreateObject("GvGOEMResult3", "com_FormulaBonusDes");
	}

	public static UI_com_FormulaBonusDes CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaBonusDes).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxt0zv5x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Get = ((GComponent)this).GetController("Get");
		hasDebuff = ((GComponent)this).GetController("hasDebuff");
		n209 = (GImage)((GComponent)this).GetChild("n209");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n210 = (GTextField)((GComponent)this).GetChild("n210");
		string id = "ui://5k1s1pjxt0zv5x".Replace("ui://", "") + "-" + ((GObject)n210).id;
		((GObject)n210).text = LanguagesManager.GetDesc(id);
		n211 = (GTextField)((GComponent)this).GetChild("n211");
		string id2 = "ui://5k1s1pjxt0zv5x".Replace("ui://", "") + "-" + ((GObject)n211).id;
		((GObject)n211).text = LanguagesManager.GetDesc(id2);
		n212 = (GTextField)((GComponent)this).GetChild("n212");
		string id3 = "ui://5k1s1pjxt0zv5x".Replace("ui://", "") + "-" + ((GObject)n212).id;
		((GObject)n212).text = LanguagesManager.GetDesc(id3);
		n213 = (GTextField)((GComponent)this).GetChild("n213");
		string id4 = "ui://5k1s1pjxt0zv5x".Replace("ui://", "") + "-" + ((GObject)n213).id;
		((GObject)n213).text = LanguagesManager.GetDesc(id4);
		n216 = (GTextField)((GComponent)this).GetChild("n216");
		string id5 = "ui://5k1s1pjxt0zv5x".Replace("ui://", "") + "-" + ((GObject)n216).id;
		((GObject)n216).text = LanguagesManager.GetDesc(id5);
		n214 = (GImage)((GComponent)this).GetChild("n214");
		n215 = (GImage)((GComponent)this).GetChild("n215");
	}
}

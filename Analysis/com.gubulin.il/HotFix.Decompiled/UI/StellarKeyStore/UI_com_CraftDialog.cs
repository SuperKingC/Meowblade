using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.StellarKeyStore;

public class UI_com_CraftDialog : GComponent
{
	public GImage n54;

	public GTextField n55;

	public GList FormulaList;

	public const string URL = "ui://khops95lmclp1c";

	public static string Name = "UI_com_CraftDialog";

	public static string GetURL()
	{
		return "ui://khops95lmclp1c";
	}

	public static UI_com_CraftDialog CreateInstance()
	{
		return (UI_com_CraftDialog)(object)UIPackage.CreateObject("StellarKeyStore", "com_CraftDialog");
	}

	public static UI_com_CraftDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CraftDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95lmclp1c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GTextField)((GComponent)this).GetChild("n55");
		string id = "ui://khops95lmclp1c".Replace("ui://", "") + "-" + ((GObject)n55).id;
		((GObject)n55).text = LanguagesManager.GetDesc(id);
		FormulaList = (GList)((GComponent)this).GetChild("FormulaList");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.StellarKeyStore;

public class UI_com_FormulaSlot : GComponent
{
	public GGraph n57;

	public GLoader InputIcon;

	public GTextField InputCount;

	public GLoader OutputIcon;

	public GTextField OutputCount;

	public UI_btn_CraftBtn ConfirmCraftBtn;

	public GImage n65;

	public GTextField n67;

	public GTextField n68;

	public const string URL = "ui://khops95lmclp1e";

	public static string Name = "UI_com_FormulaSlot";

	public static string GetURL()
	{
		return "ui://khops95lmclp1e";
	}

	public static UI_com_FormulaSlot CreateInstance()
	{
		return (UI_com_FormulaSlot)(object)UIPackage.CreateObject("StellarKeyStore", "com_FormulaSlot");
	}

	public static UI_com_FormulaSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95lmclp1e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n57 = (GGraph)((GComponent)this).GetChild("n57");
		InputIcon = (GLoader)((GComponent)this).GetChild("InputIcon");
		InputCount = (GTextField)((GComponent)this).GetChild("InputCount");
		OutputIcon = (GLoader)((GComponent)this).GetChild("OutputIcon");
		OutputCount = (GTextField)((GComponent)this).GetChild("OutputCount");
		ConfirmCraftBtn = (UI_btn_CraftBtn)(object)((GComponent)this).GetChild("ConfirmCraftBtn");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n67 = (GTextField)((GComponent)this).GetChild("n67");
		string id = "ui://khops95lmclp1e".Replace("ui://", "") + "-" + ((GObject)n67).id;
		((GObject)n67).text = LanguagesManager.GetDesc(id);
		n68 = (GTextField)((GComponent)this).GetChild("n68");
		string id2 = "ui://khops95lmclp1e".Replace("ui://", "") + "-" + ((GObject)n68).id;
		((GObject)n68).text = LanguagesManager.GetDesc(id2);
	}
}

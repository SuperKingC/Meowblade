using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_CurNum : GComponent
{
	public GImage n33;

	public GTextField curNum;

	public GGraph curNumSfxBack;

	public GGroup n52;

	public const string URL = "ui://7dantnbis9oft9u";

	public static string Name = "UI_CurNum";

	public static string GetURL()
	{
		return "ui://7dantnbis9oft9u";
	}

	public static UI_CurNum CreateInstance()
	{
		return (UI_CurNum)(object)UIPackage.CreateObject("SoldierCultivate", "CurNum");
	}

	public static UI_CurNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CurNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbis9oft9u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n33 = (GImage)((GComponent)this).GetChild("n33");
		curNum = (GTextField)((GComponent)this).GetChild("curNum");
		curNumSfxBack = (GGraph)((GComponent)this).GetChild("curNumSfxBack");
		n52 = (GGroup)((GComponent)this).GetChild("n52");
	}
}

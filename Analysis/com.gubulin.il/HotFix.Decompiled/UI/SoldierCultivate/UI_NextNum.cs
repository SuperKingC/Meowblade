using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_NextNum : GComponent
{
	public Controller Status;

	public GImage n35;

	public GTextField nextNum;

	public GTextField numLevel;

	public GGraph nextNumSfxBack;

	public GGroup n53;

	public const string URL = "ui://7dantnbis9oft9v";

	public static string Name = "UI_NextNum";

	public static string GetURL()
	{
		return "ui://7dantnbis9oft9v";
	}

	public static UI_NextNum CreateInstance()
	{
		return (UI_NextNum)(object)UIPackage.CreateObject("SoldierCultivate", "NextNum");
	}

	public static UI_NextNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NextNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbis9oft9v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		nextNum = (GTextField)((GComponent)this).GetChild("nextNum");
		numLevel = (GTextField)((GComponent)this).GetChild("numLevel");
		nextNumSfxBack = (GGraph)((GComponent)this).GetChild("nextNumSfxBack");
		n53 = (GGroup)((GComponent)this).GetChild("n53");
	}
}

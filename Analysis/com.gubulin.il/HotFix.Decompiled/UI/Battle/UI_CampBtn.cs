using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_CampBtn : GButton
{
	public Controller button;

	public GGraph n0;

	public GGraph n1;

	public GGraph n2;

	public const string URL = "ui://twlbabicuv96z";

	public static string Name = "UI_CampBtn";

	public static string GetURL()
	{
		return "ui://twlbabicuv96z";
	}

	public static UI_CampBtn CreateInstance()
	{
		return (UI_CampBtn)(object)UIPackage.CreateObject("Battle", "CampBtn");
	}

	public static UI_CampBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicuv96z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
	}
}

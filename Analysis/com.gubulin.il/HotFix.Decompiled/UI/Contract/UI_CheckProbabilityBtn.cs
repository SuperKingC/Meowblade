using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_CheckProbabilityBtn : GButton
{
	public Controller button;

	public GTextField n3;

	public GGraph n4;

	public const string URL = "ui://avplaivd924qt3w";

	public static string Name = "UI_CheckProbabilityBtn";

	public static string GetURL()
	{
		return "ui://avplaivd924qt3w";
	}

	public static UI_CheckProbabilityBtn CreateInstance()
	{
		return (UI_CheckProbabilityBtn)(object)UIPackage.CreateObject("Contract", "CheckProbabilityBtn");
	}

	public static UI_CheckProbabilityBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CheckProbabilityBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivd924qt3w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://avplaivd924qt3w".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GGraph)((GComponent)this).GetChild("n4");
	}
}

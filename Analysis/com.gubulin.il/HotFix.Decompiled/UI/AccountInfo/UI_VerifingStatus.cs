using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_VerifingStatus : GComponent
{
	public GGraph n0;

	public GTextField n1;

	public const string URL = "ui://b9yxt7u0q8mz3d";

	public static string Name = "UI_VerifingStatus";

	public static string GetURL()
	{
		return "ui://b9yxt7u0q8mz3d";
	}

	public static UI_VerifingStatus CreateInstance()
	{
		return (UI_VerifingStatus)(object)UIPackage.CreateObject("AccountInfo", "VerifingStatus");
	}

	public static UI_VerifingStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VerifingStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0q8mz3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://b9yxt7u0q8mz3d".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
	}
}

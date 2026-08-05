using FairyGUI;
using FairyGUI.Utils;

namespace UI.AddCredit;

public class UI_CardLoader : GComponent
{
	public GList cardList;

	public const string URL = "ui://4pot8w0vl1ase";

	public static string Name = "UI_CardLoader";

	public static string GetURL()
	{
		return "ui://4pot8w0vl1ase";
	}

	public static UI_CardLoader CreateInstance()
	{
		return (UI_CardLoader)(object)UIPackage.CreateObject("AddCredit", "CardLoader");
	}

	public static UI_CardLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vl1ase", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		cardList = (GList)((GComponent)this).GetChild("cardList");
	}
}

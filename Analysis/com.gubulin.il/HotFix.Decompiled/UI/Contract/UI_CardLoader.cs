using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_CardLoader : GComponent
{
	public UI_CommonPool card0;

	public UI_ActivityPool card1;

	public GList cardList;

	public const string URL = "ui://avplaivdo5ta2t";

	public static string Name = "UI_CardLoader";

	public static string GetURL()
	{
		return "ui://avplaivdo5ta2t";
	}

	public static UI_CardLoader CreateInstance()
	{
		return (UI_CardLoader)(object)UIPackage.CreateObject("Contract", "CardLoader");
	}

	public static UI_CardLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdo5ta2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		card0 = (UI_CommonPool)(object)((GComponent)this).GetChild("card0");
		card1 = (UI_ActivityPool)(object)((GComponent)this).GetChild("card1");
		cardList = (GList)((GComponent)this).GetChild("cardList");
	}
}

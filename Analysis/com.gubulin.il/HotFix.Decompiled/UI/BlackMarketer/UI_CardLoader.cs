using FairyGUI;
using FairyGUI.Utils;

namespace UI.BlackMarketer;

public class UI_CardLoader : GComponent
{
	public UI_GiftBag entrance0;

	public UI_CardMonth entrance3;

	public UI_CardContract entrance2;

	public UI_CardDiamond entrance1;

	public GGroup n3;

	public GList cardList;

	public const string URL = "ui://036k96hrlkzgw";

	public static string Name = "UI_CardLoader";

	public static string GetURL()
	{
		return "ui://036k96hrlkzgw";
	}

	public static UI_CardLoader CreateInstance()
	{
		return (UI_CardLoader)(object)UIPackage.CreateObject("BlackMarketer", "CardLoader");
	}

	public static UI_CardLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrlkzgw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		entrance0 = (UI_GiftBag)(object)((GComponent)this).GetChild("entrance0");
		entrance3 = (UI_CardMonth)(object)((GComponent)this).GetChild("entrance3");
		entrance2 = (UI_CardContract)(object)((GComponent)this).GetChild("entrance2");
		entrance1 = (UI_CardDiamond)(object)((GComponent)this).GetChild("entrance1");
		n3 = (GGroup)((GComponent)this).GetChild("n3");
		cardList = (GList)((GComponent)this).GetChild("cardList");
	}
}

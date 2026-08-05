using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_no : GButton
{
	public Controller button;

	public GImage background;

	public GTextField title;

	public GGraph n7;

	public GLoader n8;

	public const string URL = "ui://kt6rg65oot911x";

	public static string Name = "UI_no";

	public static string GetURL()
	{
		return "ui://kt6rg65oot911x";
	}

	public static UI_no CreateInstance()
	{
		return (UI_no)(object)UIPackage.CreateObject("PublicResources", "no");
	}

	public static UI_no CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_no).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oot911x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kt6rg65oot911x".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}

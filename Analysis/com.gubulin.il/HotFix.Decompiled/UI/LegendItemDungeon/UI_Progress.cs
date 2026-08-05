using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_Progress : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph Mask;

	public GGraph contentBack;

	public GTextField content;

	public GImage n9;

	public UI_ItemDisplay TreasureMap;

	public GList display;

	public GTextField Tip;

	public GTextField Tip2;

	public const string URL = "ui://2eraz3j9y9rzp";

	public static string Name = "UI_Progress";

	public static string GetURL()
	{
		return "ui://2eraz3j9y9rzp";
	}

	public static UI_Progress CreateInstance()
	{
		return (UI_Progress)(object)UIPackage.CreateObject("LegendItemDungeon", "Progress");
	}

	public static UI_Progress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Progress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9y9rzp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		contentBack = (GGraph)((GComponent)this).GetChild("contentBack");
		content = (GTextField)((GComponent)this).GetChild("content");
		string id = "ui://2eraz3j9y9rzp".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id);
		n9 = (GImage)((GComponent)this).GetChild("n9");
		TreasureMap = (UI_ItemDisplay)(object)((GComponent)this).GetChild("TreasureMap");
		display = (GList)((GComponent)this).GetChild("display");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id2 = "ui://2eraz3j9y9rzp".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id2);
		Tip2 = (GTextField)((GComponent)this).GetChild("Tip2");
		string id3 = "ui://2eraz3j9y9rzp".Replace("ui://", "") + "-" + ((GObject)Tip2).id;
		((GObject)Tip2).text = LanguagesManager.GetDesc(id3);
	}
}

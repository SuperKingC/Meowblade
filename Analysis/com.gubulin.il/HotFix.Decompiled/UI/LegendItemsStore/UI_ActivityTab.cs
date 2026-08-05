using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsStore;

public class UI_ActivityTab : GButton
{
	public Controller button;

	public UI_CutTab n3;

	public GImage n4;

	public GTextField title;

	public const string URL = "ui://i6o930evvltp10";

	public static string Name = "UI_ActivityTab";

	public static string GetURL()
	{
		return "ui://i6o930evvltp10";
	}

	public static UI_ActivityTab CreateInstance()
	{
		return (UI_ActivityTab)(object)UIPackage.CreateObject("LegendItemsStore", "ActivityTab");
	}

	public static UI_ActivityTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActivityTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evvltp10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (UI_CutTab)(object)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://i6o930evvltp10".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}

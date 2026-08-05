using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_DungeonSize : GButton
{
	public Controller button;

	public GImage n8;

	public GLoader icon;

	public GImage n11;

	public GTextField size;

	public GImage redPoint;

	public const string URL = "ui://kt6rg65oee146o";

	public static string Name = "UI_DungeonSize";

	public static string GetURL()
	{
		return "ui://kt6rg65oee146o";
	}

	public static UI_DungeonSize CreateInstance()
	{
		return (UI_DungeonSize)(object)UIPackage.CreateObject("PublicResources", "DungeonSize");
	}

	public static UI_DungeonSize CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DungeonSize).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oee146o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		size = (GTextField)((GComponent)this).GetChild("size");
		string id = "ui://kt6rg65oee146o".Replace("ui://", "") + "-" + ((GObject)size).id;
		((GObject)size).text = LanguagesManager.GetDesc(id);
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
	}
}

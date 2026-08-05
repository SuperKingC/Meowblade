using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_notOccupyLogo : GButton
{
	public Controller button;

	public GTextField areaName;

	public GTextField n4;

	public GLoader icon;

	public GTextField num;

	public Transition shrink;

	public Transition magnify;

	public Transition setInitSize;

	public const string URL = "ui://c9n2h0ksoppx2s";

	public static string Name = "UI_notOccupyLogo";

	public static string GetURL()
	{
		return "ui://c9n2h0ksoppx2s";
	}

	public static UI_notOccupyLogo CreateInstance()
	{
		return (UI_notOccupyLogo)(object)UIPackage.CreateObject("WorldMap", "notOccupyLogo");
	}

	public static UI_notOccupyLogo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_notOccupyLogo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksoppx2s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		areaName = (GTextField)((GComponent)this).GetChild("areaName");
		string id = "ui://c9n2h0ksoppx2s".Replace("ui://", "") + "-" + ((GObject)areaName).id;
		((GObject)areaName).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://c9n2h0ksoppx2s".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		shrink = ((GComponent)this).GetTransition("shrink");
		magnify = ((GComponent)this).GetTransition("magnify");
		setInitSize = ((GComponent)this).GetTransition("setInitSize");
	}
}

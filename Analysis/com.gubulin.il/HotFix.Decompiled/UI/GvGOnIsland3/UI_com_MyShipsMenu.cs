using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_MyShipsMenu : GComponent
{
	public Controller DisplayMode;

	public GImage n84;

	public GImage n85;

	public GTextField n82;

	public UI_btn_SwitchShipMode SwitchShipMode;

	public GList List;

	public const string URL = "ui://ebc4ciwrl44l1v";

	public static string Name = "UI_com_MyShipsMenu";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1v";
	}

	public static UI_com_MyShipsMenu CreateInstance()
	{
		return (UI_com_MyShipsMenu)(object)UIPackage.CreateObject("GvGOnIsland3", "com_MyShipsMenu");
	}

	public static UI_com_MyShipsMenu CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MyShipsMenu).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		DisplayMode = ((GComponent)this).GetController("DisplayMode");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n82 = (GTextField)((GComponent)this).GetChild("n82");
		string id = "ui://ebc4ciwrl44l1v".Replace("ui://", "") + "-" + ((GObject)n82).id;
		((GObject)n82).text = LanguagesManager.GetDesc(id);
		SwitchShipMode = (UI_btn_SwitchShipMode)(object)((GComponent)this).GetChild("SwitchShipMode");
		List = (GList)((GComponent)this).GetChild("List");
	}
}

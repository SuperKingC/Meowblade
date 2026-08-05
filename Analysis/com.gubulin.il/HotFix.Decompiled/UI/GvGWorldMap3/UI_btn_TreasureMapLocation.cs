using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_TreasureMapLocation : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField n4;

	public GLoader n6;

	public const string URL = "ui://4eq8fgd2dc6m8e";

	public static string Name = "UI_btn_TreasureMapLocation";

	public static string GetURL()
	{
		return "ui://4eq8fgd2dc6m8e";
	}

	public static UI_btn_TreasureMapLocation CreateInstance()
	{
		return (UI_btn_TreasureMapLocation)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_TreasureMapLocation");
	}

	public static UI_btn_TreasureMapLocation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_TreasureMapLocation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2dc6m8e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4eq8fgd2dc6m8e".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n6 = (GLoader)((GComponent)this).GetChild("n6");
	}
}

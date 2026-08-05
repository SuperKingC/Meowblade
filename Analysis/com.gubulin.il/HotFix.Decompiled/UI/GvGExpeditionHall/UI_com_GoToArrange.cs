using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_GoToArrange : GComponent
{
	public GTextField n16;

	public GImage n160;

	public const string URL = "ui://k19peou7dnvl1y";

	public static string Name = "UI_com_GoToArrange";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl1y";
	}

	public static UI_com_GoToArrange CreateInstance()
	{
		return (UI_com_GoToArrange)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_GoToArrange");
	}

	public static UI_com_GoToArrange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GoToArrange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://k19peou7dnvl1y".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
		n160 = (GImage)((GComponent)this).GetChild("n160");
	}
}

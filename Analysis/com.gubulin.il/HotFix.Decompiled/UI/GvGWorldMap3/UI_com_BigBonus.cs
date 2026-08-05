using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_BigBonus : GComponent
{
	public GLoader n3;

	public GLoader ItemIcon;

	public GTextField Count;

	public const string URL = "ui://4eq8fgd2r5amav";

	public static string Name = "UI_com_BigBonus";

	public static string GetURL()
	{
		return "ui://4eq8fgd2r5amav";
	}

	public static UI_com_BigBonus CreateInstance()
	{
		return (UI_com_BigBonus)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BigBonus");
	}

	public static UI_com_BigBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BigBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2r5amav", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GLoader)((GComponent)this).GetChild("n3");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}

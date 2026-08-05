using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_BossIslandDisplayReward : GComponent
{
	public GLoader Icon;

	public GTextField Count;

	public const string URL = "ui://4eq8fgd2c6jrs6v";

	public static string Name = "UI_com_BossIslandDisplayReward";

	public static string GetURL()
	{
		return "ui://4eq8fgd2c6jrs6v";
	}

	public static UI_com_BossIslandDisplayReward CreateInstance()
	{
		return (UI_com_BossIslandDisplayReward)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BossIslandDisplayReward");
	}

	public static UI_com_BossIslandDisplayReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossIslandDisplayReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2c6jrs6v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}

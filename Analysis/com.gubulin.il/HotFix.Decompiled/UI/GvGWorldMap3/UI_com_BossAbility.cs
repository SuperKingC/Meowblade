using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_BossAbility : GComponent
{
	public GComponent icon;

	public GImage n9;

	public GTextField Title;

	public GGraph SfxBack;

	public GTextField LvNum;

	public const string URL = "ui://4eq8fgd2mdde28";

	public static string Name = "UI_com_BossAbility";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde28";
	}

	public static UI_com_BossAbility CreateInstance()
	{
		return (UI_com_BossAbility)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BossAbility");
	}

	public static UI_com_BossAbility CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossAbility).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde28", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GComponent)((GComponent)this).GetChild("icon");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		LvNum = (GTextField)((GComponent)this).GetChild("LvNum");
	}
}

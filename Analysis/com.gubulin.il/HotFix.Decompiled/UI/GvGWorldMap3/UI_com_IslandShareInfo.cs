using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_IslandShareInfo : GComponent
{
	public GImage n0;

	public UI_com_ShipAvatarSmall Avatar;

	public GTextField UserName;

	public GTextField n5;

	public const string URL = "ui://4eq8fgd2jxsodr";

	public static string Name = "UI_com_IslandShareInfo";

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodr";
	}

	public static UI_com_IslandShareInfo CreateInstance()
	{
		return (UI_com_IslandShareInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandShareInfo");
	}

	public static UI_com_IslandShareInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandShareInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Avatar = (UI_com_ShipAvatarSmall)(object)((GComponent)this).GetChild("Avatar");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://4eq8fgd2jxsodr".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}

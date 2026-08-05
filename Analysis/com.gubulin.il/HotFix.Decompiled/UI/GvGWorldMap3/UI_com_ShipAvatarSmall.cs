using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ShipAvatarSmall : GComponent
{
	public Controller CampId;

	public GLoader Icon;

	public UI_com_HeadPortrait HeadPortrait;

	public const string URL = "ui://4eq8fgd2ucwa6s";

	public static string Name = "UI_com_ShipAvatarSmall";

	public static string GetURL()
	{
		return "ui://4eq8fgd2ucwa6s";
	}

	public static UI_com_ShipAvatarSmall CreateInstance()
	{
		return (UI_com_ShipAvatarSmall)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipAvatarSmall");
	}

	public static UI_com_ShipAvatarSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipAvatarSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2ucwa6s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		HeadPortrait = (UI_com_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}
}

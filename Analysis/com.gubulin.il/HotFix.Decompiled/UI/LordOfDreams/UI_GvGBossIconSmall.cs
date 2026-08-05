using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGBossIconSmall : GComponent
{
	public Controller button;

	public GImage n4;

	public UI_GvGBossAvatarSmall Avatar;

	public const string URL = "ui://0i520nzmbvziocg";

	public static string Name = "UI_GvGBossIconSmall";

	public static string GetURL()
	{
		return "ui://0i520nzmbvziocg";
	}

	public static UI_GvGBossIconSmall CreateInstance()
	{
		return (UI_GvGBossIconSmall)(object)UIPackage.CreateObject("LordOfDreams", "GvGBossIconSmall");
	}

	public static UI_GvGBossIconSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossIconSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmbvziocg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Avatar = (UI_GvGBossAvatarSmall)(object)((GComponent)this).GetChild("Avatar");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_AvatarLoader : GComponent
{
	public Controller Type;

	public GGraph mask;

	public GImage iconBack;

	public GLoader icon;

	public const string URL = "ui://5xc1njmujjrn29";

	public static string Name = "UI_AvatarLoader";

	public static string GetURL()
	{
		return "ui://5xc1njmujjrn29";
	}

	public static UI_AvatarLoader CreateInstance()
	{
		return (UI_AvatarLoader)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "AvatarLoader");
	}

	public static UI_AvatarLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AvatarLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmujjrn29", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}

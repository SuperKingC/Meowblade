using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_dec_SceneAnimationLight01 : GComponent
{
	public GImage n142;

	public GImage n143;

	public GImage n144;

	public GImage n145;

	public GImage n146;

	public const string URL = "ui://k19peou7mntx3o";

	public static string Name = "UI_dec_SceneAnimationLight01";

	public static string GetURL()
	{
		return "ui://k19peou7mntx3o";
	}

	public static UI_dec_SceneAnimationLight01 CreateInstance()
	{
		return (UI_dec_SceneAnimationLight01)(object)UIPackage.CreateObject("GvGExpeditionHall", "dec_SceneAnimationLight01");
	}

	public static UI_dec_SceneAnimationLight01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_SceneAnimationLight01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7mntx3o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GImage)((GComponent)this).GetChild("n146");
	}
}

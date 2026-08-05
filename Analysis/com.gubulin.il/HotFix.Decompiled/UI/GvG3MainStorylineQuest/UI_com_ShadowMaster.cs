using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_ShadowMaster : GComponent
{
	public GGraph n0;

	public GLoader Icon;

	public const string URL = "ui://249h3k3dzit42q";

	public static string Name = "UI_com_ShadowMaster";

	public static string GetURL()
	{
		return "ui://249h3k3dzit42q";
	}

	public static UI_com_ShadowMaster CreateInstance()
	{
		return (UI_com_ShadowMaster)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_ShadowMaster");
	}

	public static UI_com_ShadowMaster CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShadowMaster).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}
}

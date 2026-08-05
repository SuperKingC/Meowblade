using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurification3;

public class UI_com_PurifyTip : GComponent
{
	public GTextField n3;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://v7vqvgvmsmdjl9";

	public static string Name = "UI_com_PurifyTip";

	public static string GetURL()
	{
		return "ui://v7vqvgvmsmdjl9";
	}

	public static UI_com_PurifyTip CreateInstance()
	{
		return (UI_com_PurifyTip)(object)UIPackage.CreateObject("GvGPurification3", "com_PurifyTip");
	}

	public static UI_com_PurifyTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PurifyTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmsmdjl9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://v7vqvgvmsmdjl9".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://v7vqvgvmsmdjl9".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
	}
}

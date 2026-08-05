using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_com_FloatingText : GComponent
{
	public GGraph n26;

	public GTextField n28;

	public GImage Icon;

	public GTextField Count;

	public GGroup n27;

	public const string URL = "ui://72poq8plaopo2d";

	public static string Name = "UI_com_FloatingText";

	public static string GetURL()
	{
		return "ui://72poq8plaopo2d";
	}

	public static UI_com_FloatingText CreateInstance()
	{
		return (UI_com_FloatingText)(object)UIPackage.CreateObject("RecyclingCenter", "com_FloatingText");
	}

	public static UI_com_FloatingText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FloatingText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plaopo2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n26 = (GGraph)((GComponent)this).GetChild("n26");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id = "ui://72poq8plaopo2d".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id);
		Icon = (GImage)((GComponent)this).GetChild("Icon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n27 = (GGroup)((GComponent)this).GetChild("n27");
	}
}

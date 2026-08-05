using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.CraftItemPopup;

public class UI_com_Consumption : GComponent
{
	public GLoader Icon;

	public GTextField n16;

	public GRichTextField ConsumeNum;

	public const string URL = "ui://4pn38oznnqv8n";

	public static string Name = "UI_com_Consumption";

	public static string GetURL()
	{
		return "ui://4pn38oznnqv8n";
	}

	public static UI_com_Consumption CreateInstance()
	{
		return (UI_com_Consumption)(object)UIPackage.CreateObject("CraftItemPopup", "com_Consumption");
	}

	public static UI_com_Consumption CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Consumption).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38oznnqv8n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id = "ui://4pn38oznnqv8n".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id);
		ConsumeNum = (GRichTextField)((GComponent)this).GetChild("ConsumeNum");
	}
}

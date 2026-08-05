using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_CheckDropDetialBtn : GButton
{
	public GImage n50;

	public GTextField n51;

	public GImage n52;

	public const string URL = "ui://k19peou7qix93l";

	public static string Name = "UI_com_CheckDropDetialBtn";

	public static string GetURL()
	{
		return "ui://k19peou7qix93l";
	}

	public static UI_com_CheckDropDetialBtn CreateInstance()
	{
		return (UI_com_CheckDropDetialBtn)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_CheckDropDetialBtn");
	}

	public static UI_com_CheckDropDetialBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CheckDropDetialBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qix93l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n51 = (GTextField)((GComponent)this).GetChild("n51");
		string id = "ui://k19peou7qix93l".Replace("ui://", "") + "-" + ((GObject)n51).id;
		((GObject)n51).text = LanguagesManager.GetDesc(id);
		n52 = (GImage)((GComponent)this).GetChild("n52");
	}
}

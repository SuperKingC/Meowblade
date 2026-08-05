using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_StoreEntryTip : GComponent
{
	public GImage n7;

	public GTextField n8;

	public Transition t0;

	public const string URL = "ui://k19peou7mclpp6e";

	public static string Name = "UI_com_StoreEntryTip";

	public static string GetURL()
	{
		return "ui://k19peou7mclpp6e";
	}

	public static UI_com_StoreEntryTip CreateInstance()
	{
		return (UI_com_StoreEntryTip)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_StoreEntryTip");
	}

	public static UI_com_StoreEntryTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StoreEntryTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7mclpp6e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://k19peou7mclpp6e".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

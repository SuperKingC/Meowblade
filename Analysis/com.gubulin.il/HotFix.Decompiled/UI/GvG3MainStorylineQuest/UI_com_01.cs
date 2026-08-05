using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_01 : GComponent
{
	public GTextField n35;

	public GLoader n36;

	public Transition t0;

	public const string URL = "ui://249h3k3do25fs44";

	public static string Name = "UI_com_01";

	public static string GetURL()
	{
		return "ui://249h3k3do25fs44";
	}

	public static UI_com_01 CreateInstance()
	{
		return (UI_com_01)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_01");
	}

	public static UI_com_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3do25fs44", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id = "ui://249h3k3do25fs44".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id);
		n36 = (GLoader)((GComponent)this).GetChild("n36");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

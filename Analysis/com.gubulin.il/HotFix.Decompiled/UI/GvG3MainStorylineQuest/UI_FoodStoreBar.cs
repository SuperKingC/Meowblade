using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_FoodStoreBar : GProgressBar
{
	public GImage n8;

	public GImage bar;

	public GImage n14;

	public GLoader n12;

	public GImage n13;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://249h3k3dqf7c1g";

	public static string Name = "UI_FoodStoreBar";

	public static string GetURL()
	{
		return "ui://249h3k3dqf7c1g";
	}

	public static UI_FoodStoreBar CreateInstance()
	{
		return (UI_FoodStoreBar)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "FoodStoreBar");
	}

	public static UI_FoodStoreBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FoodStoreBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dqf7c1g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		bar = (GImage)((GComponent)this).GetChild("bar");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n12 = (GLoader)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_com_TransitionStage : GComponent
{
	public GImage n1;

	public GImage n2;

	public GImage n0;

	public Transition PurificationScale;

	public const string URL = "ui://tvr786zlyqyh12";

	public static string Name = "UI_com_TransitionStage";

	public static string GetURL()
	{
		return "ui://tvr786zlyqyh12";
	}

	public static UI_com_TransitionStage CreateInstance()
	{
		return (UI_com_TransitionStage)(object)UIPackage.CreateObject("GvGFlagship3", "com_TransitionStage");
	}

	public static UI_com_TransitionStage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TransitionStage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlyqyh12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		PurificationScale = ((GComponent)this).GetTransition("PurificationScale");
	}
}

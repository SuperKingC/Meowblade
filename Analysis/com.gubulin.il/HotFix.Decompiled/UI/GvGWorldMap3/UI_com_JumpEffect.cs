using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_JumpEffect : GComponent
{
	public Controller JumpEffectController;

	public GImage n112;

	public UI_eff_SpeedString n120;

	public GGraph SpineLoader;

	public GGraph FxLoader;

	public GGroup Container;

	public Transition In;

	public Transition Out;

	public const string URL = "ui://4eq8fgd2hw8o8i";

	public static string Name = "UI_com_JumpEffect";

	public static string GetURL()
	{
		return "ui://4eq8fgd2hw8o8i";
	}

	public static UI_com_JumpEffect CreateInstance()
	{
		return (UI_com_JumpEffect)(object)UIPackage.CreateObject("GvGWorldMap3", "com_JumpEffect");
	}

	public static UI_com_JumpEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_JumpEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2hw8o8i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		JumpEffectController = ((GComponent)this).GetController("JumpEffectController");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		n120 = (UI_eff_SpeedString)(object)((GComponent)this).GetChild("n120");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		FxLoader = (GGraph)((GComponent)this).GetChild("FxLoader");
		Container = (GGroup)((GComponent)this).GetChild("Container");
		In = ((GComponent)this).GetTransition("In");
		Out = ((GComponent)this).GetTransition("Out");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle_PauseSetEffect;

public class UI_Race_0 : GComponent, IPauseSetEffect
{
	public GGraph n1;

	public UI_dec_01 n2;

	public UI_dec_02 n3;

	public UI_dec_03 n5;

	public GImage n6;

	public UI_dec_04 n7;

	public UI_dec_05 n8;

	public Transition t0;

	public const string URL = "ui://e9jxbc7wh7t30";

	public static string Name = "UI_Race_0";

	public Transition Animation => t0;

	public static string GetURL()
	{
		return "ui://e9jxbc7wh7t30";
	}

	public static UI_Race_0 CreateInstance()
	{
		return (UI_Race_0)(object)UIPackage.CreateObject("Battle_PauseSetEffect", "Race_0");
	}

	public static UI_Race_0 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Race_0).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e9jxbc7wh7t30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n2 = (UI_dec_01)(object)((GComponent)this).GetChild("n2");
		n3 = (UI_dec_02)(object)((GComponent)this).GetChild("n3");
		n5 = (UI_dec_03)(object)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (UI_dec_04)(object)((GComponent)this).GetChild("n7");
		n8 = (UI_dec_05)(object)((GComponent)this).GetChild("n8");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

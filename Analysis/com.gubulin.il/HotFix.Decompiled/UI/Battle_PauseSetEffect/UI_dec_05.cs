using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle_PauseSetEffect;

public class UI_dec_05 : GComponent
{
	public Controller c1;

	public UI_dec_bar01 n8;

	public UI_dec_bar02 n10;

	public UI_dec_bar03 n11;

	public GImage n9;

	public GImage n12;

	public GImage n13;

	public Transition t1;

	public Transition t0;

	public const string URL = "ui://e9jxbc7wwt9zo";

	public static string Name = "UI_dec_05";

	public static string GetURL()
	{
		return "ui://e9jxbc7wwt9zo";
	}

	public static UI_dec_05 CreateInstance()
	{
		return (UI_dec_05)(object)UIPackage.CreateObject("Battle_PauseSetEffect", "dec_05");
	}

	public static UI_dec_05 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_05).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e9jxbc7wwt9zo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n8 = (UI_dec_bar01)(object)((GComponent)this).GetChild("n8");
		n10 = (UI_dec_bar02)(object)((GComponent)this).GetChild("n10");
		n11 = (UI_dec_bar03)(object)((GComponent)this).GetChild("n11");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		t1 = ((GComponent)this).GetTransition("t1");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

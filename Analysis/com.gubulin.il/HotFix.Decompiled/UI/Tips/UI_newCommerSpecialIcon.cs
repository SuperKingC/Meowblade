using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_newCommerSpecialIcon : GComponent
{
	public Controller Status;

	public GGraph bg;

	public GImage n10;

	public GImage n1;

	public GLoader n2;

	public GMovieClip n3;

	public GImage n5;

	public GTextField n7;

	public GLoader n8;

	public GGroup n9;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://47lbpgx9ru7mj5ltez";

	public static string Name = "UI_newCommerSpecialIcon";

	public static string GetURL()
	{
		return "ui://47lbpgx9ru7mj5ltez";
	}

	public static UI_newCommerSpecialIcon CreateInstance()
	{
		return (UI_newCommerSpecialIcon)(object)UIPackage.CreateObject("Tips", "newCommerSpecialIcon");
	}

	public static UI_newCommerSpecialIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_newCommerSpecialIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ru7mj5ltez", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		bg = (GGraph)((GComponent)this).GetChild("bg");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		n3 = (GMovieClip)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://47lbpgx9ru7mj5ltez".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n8 = (GLoader)((GComponent)this).GetChild("n8");
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_07 : GComponent
{
	public Controller c1;

	public GImage n3;

	public GImage n4;

	public UI_dec_02 n5;

	public UI_dec_03 n7;

	public GImage n8;

	public GTextField n9;

	public GGroup n10;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://8x5gc8j2jz2uv4vb";

	public static string Name = "UI_com_07";

	public static string GetURL()
	{
		return "ui://8x5gc8j2jz2uv4vb";
	}

	public static UI_com_07 CreateInstance()
	{
		return (UI_com_07)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_07");
	}

	public static UI_com_07 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_07).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2jz2uv4vb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (UI_dec_02)(object)((GComponent)this).GetChild("n5");
		n7 = (UI_dec_03)(object)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://8x5gc8j2jz2uv4vb".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}

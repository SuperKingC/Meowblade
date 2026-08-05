using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_btn_LookBuffDetails : GButton
{
	public Controller button;

	public GImage n14;

	public GImage n15;

	public GTextField n11;

	public GImage n12;

	public GImage n13;

	public GGroup n16;

	public GImage n17;

	public GImage n18;

	public const string URL = "ui://zh7jgfijnewqg0";

	public static string Name = "UI_btn_LookBuffDetails";

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqg0";
	}

	public static UI_btn_LookBuffDetails CreateInstance()
	{
		return (UI_btn_LookBuffDetails)(object)UIPackage.CreateObject("GvGIslandBuff", "btn_LookBuffDetails");
	}

	public static UI_btn_LookBuffDetails CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_LookBuffDetails).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqg0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://zh7jgfijnewqg0".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
	}
}

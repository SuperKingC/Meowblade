using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_TitleGroup : GComponent
{
	public Controller isUnlocked;

	public GImage n17;

	public GImage titleBack2;

	public GTextField n21;

	public GLoader n18;

	public GImage n19;

	public GImage n20;

	public GTextField n22;

	public const string URL = "ui://c9n2h0ksee14i";

	public static string Name = "UI_TitleGroup";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14i";
	}

	public static UI_TitleGroup CreateInstance()
	{
		return (UI_TitleGroup)(object)UIPackage.CreateObject("WorldMap", "TitleGroup");
	}

	public static UI_TitleGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TitleGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		isUnlocked = ((GComponent)this).GetController("isUnlocked");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		titleBack2 = (GImage)((GComponent)this).GetChild("titleBack2");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id = "ui://c9n2h0ksee14i".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id);
		n18 = (GLoader)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id2 = "ui://c9n2h0ksee14i".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id2);
	}
}

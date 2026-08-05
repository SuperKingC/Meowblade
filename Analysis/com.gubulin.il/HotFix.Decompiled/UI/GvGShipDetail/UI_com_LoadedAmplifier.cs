using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_com_LoadedAmplifier : GComponent
{
	public Controller 增幅器属性;

	public Controller IsEmpty;

	public GImage n71;

	public GImage n75;

	public GImage n82;

	public GImage n72;

	public GImage n76;

	public GImage n77;

	public GTextField Total;

	public GList List;

	public GTextField n78;

	public GLoader n79;

	public GTextField n80;

	public GTextField n81;

	public const string URL = "ui://u6x0b1gnzpu41q";

	public static string Name = "UI_com_LoadedAmplifier";

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41q";
	}

	public static UI_com_LoadedAmplifier CreateInstance()
	{
		return (UI_com_LoadedAmplifier)(object)UIPackage.CreateObject("GvGShipDetail", "com_LoadedAmplifier");
	}

	public static UI_com_LoadedAmplifier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LoadedAmplifier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		增幅器属性 = ((GComponent)this).GetController("增幅器属性");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n72 = (GImage)((GComponent)this).GetChild("n72");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		Total = (GTextField)((GComponent)this).GetChild("Total");
		List = (GList)((GComponent)this).GetChild("List");
		n78 = (GTextField)((GComponent)this).GetChild("n78");
		string id = "ui://u6x0b1gnzpu41q".Replace("ui://", "") + "-" + ((GObject)n78).id;
		((GObject)n78).text = LanguagesManager.GetDesc(id);
		n79 = (GLoader)((GComponent)this).GetChild("n79");
		n80 = (GTextField)((GComponent)this).GetChild("n80");
		string id2 = "ui://u6x0b1gnzpu41q".Replace("ui://", "") + "-" + ((GObject)n80).id;
		((GObject)n80).text = LanguagesManager.GetDesc(id2);
		n81 = (GTextField)((GComponent)this).GetChild("n81");
		string id3 = "ui://u6x0b1gnzpu41q".Replace("ui://", "") + "-" + ((GObject)n81).id;
		((GObject)n81).text = LanguagesManager.GetDesc(id3);
	}
}

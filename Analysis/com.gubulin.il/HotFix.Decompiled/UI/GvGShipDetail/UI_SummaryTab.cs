using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_SummaryTab : GButton
{
	public Controller button;

	public GImage n2;

	public GImage n0;

	public GTextField n3;

	public const string URL = "ui://u6x0b1gnfdar1";

	public static string Name = "UI_SummaryTab";

	public static string GetURL()
	{
		return "ui://u6x0b1gnfdar1";
	}

	public static UI_SummaryTab CreateInstance()
	{
		return (UI_SummaryTab)(object)UIPackage.CreateObject("GvGShipDetail", "SummaryTab");
	}

	public static UI_SummaryTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SummaryTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnfdar1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://u6x0b1gnfdar1".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
	}
}

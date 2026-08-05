using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_02 : GComponent
{
	public Controller c1;

	public GImage n151;

	public GImage n154;

	public GImage n152;

	public GTextField n153;

	public Transition t0;

	public const string URL = "ui://k19peou7qyfw6p8r";

	public static string Name = "UI_com_02";

	public static string GetURL()
	{
		return "ui://k19peou7qyfw6p8r";
	}

	public static UI_com_02 CreateInstance()
	{
		return (UI_com_02)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_02");
	}

	public static UI_com_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qyfw6p8r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n151 = (GImage)((GComponent)this).GetChild("n151");
		n154 = (GImage)((GComponent)this).GetChild("n154");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n153 = (GTextField)((GComponent)this).GetChild("n153");
		string id = "ui://k19peou7qyfw6p8r".Replace("ui://", "") + "-" + ((GObject)n153).id;
		((GObject)n153).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

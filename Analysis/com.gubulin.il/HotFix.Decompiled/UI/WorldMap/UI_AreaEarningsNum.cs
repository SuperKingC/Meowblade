using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_AreaEarningsNum : GButton
{
	public Controller button;

	public GTextField num;

	public Transition DisAppear;

	public const string URL = "ui://c9n2h0ksm7wz91";

	public static string Name = "UI_AreaEarningsNum";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz91";
	}

	public static UI_AreaEarningsNum CreateInstance()
	{
		return (UI_AreaEarningsNum)(object)UIPackage.CreateObject("WorldMap", "AreaEarningsNum");
	}

	public static UI_AreaEarningsNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AreaEarningsNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz91", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://c9n2h0ksm7wz91".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		DisAppear = ((GComponent)this).GetTransition("DisAppear");
	}
}

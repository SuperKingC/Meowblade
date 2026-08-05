using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_ChangePropetryCancel : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField Title;

	public GGraph n5;

	public const string URL = "ui://b9wlonaqmpf91g";

	public static string Name = "UI_ChangePropetryCancel";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91g";
	}

	public static UI_ChangePropetryCancel CreateInstance()
	{
		return (UI_ChangePropetryCancel)(object)UIPackage.CreateObject("LegendItemCultivation", "ChangePropetryCancel");
	}

	public static UI_ChangePropetryCancel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangePropetryCancel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqmpf91g".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		n5 = (GGraph)((GComponent)this).GetChild("n5");
	}
}

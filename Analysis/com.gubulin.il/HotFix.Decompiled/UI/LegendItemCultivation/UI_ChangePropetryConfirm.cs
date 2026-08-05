using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_ChangePropetryConfirm : GButton
{
	public Controller button;

	public GImage n6;

	public GTextField Title;

	public GGraph n7;

	public const string URL = "ui://b9wlonaqmpf91h";

	public static string Name = "UI_ChangePropetryConfirm";

	public static string GetURL()
	{
		return "ui://b9wlonaqmpf91h";
	}

	public static UI_ChangePropetryConfirm CreateInstance()
	{
		return (UI_ChangePropetryConfirm)(object)UIPackage.CreateObject("LegendItemCultivation", "ChangePropetryConfirm");
	}

	public static UI_ChangePropetryConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangePropetryConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmpf91h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqmpf91h".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		n7 = (GGraph)((GComponent)this).GetChild("n7");
	}
}

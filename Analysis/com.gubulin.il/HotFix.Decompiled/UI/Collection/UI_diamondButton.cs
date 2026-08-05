using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_diamondButton : GButton
{
	public Controller button;

	public GImage back;

	public GImage diamond;

	public GTextField DiamondAmount;

	public GButton addButton;

	public const string URL = "ui://ehe4tm5zb8chx";

	public static string Name = "UI_diamondButton";

	public static string GetURL()
	{
		return "ui://ehe4tm5zb8chx";
	}

	public static UI_diamondButton CreateInstance()
	{
		return (UI_diamondButton)(object)UIPackage.CreateObject("Collection", "diamondButton");
	}

	public static UI_diamondButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_diamondButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zb8chx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		diamond = (GImage)((GComponent)this).GetChild("diamond");
		DiamondAmount = (GTextField)((GComponent)this).GetChild("DiamondAmount");
		string id = "ui://ehe4tm5zb8chx".Replace("ui://", "") + "-" + ((GObject)DiamondAmount).id;
		((GObject)DiamondAmount).text = LanguagesManager.GetDesc(id);
		addButton = (GButton)((GComponent)this).GetChild("addButton");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ProductionNumFloating : GButton
{
	public Controller button;

	public GTextField Title;

	public GLoader Icon;

	public Transition DisAppear;

	public const string URL = "ui://kt6rg65omol0if";

	public static string Name = "UI_ProductionNumFloating";

	public static string GetURL()
	{
		return "ui://kt6rg65omol0if";
	}

	public static UI_ProductionNumFloating CreateInstance()
	{
		return (UI_ProductionNumFloating)(object)UIPackage.CreateObject("PublicResources", "ProductionNumFloating");
	}

	public static UI_ProductionNumFloating CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProductionNumFloating).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0if", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		DisAppear = ((GComponent)this).GetTransition("DisAppear");
	}
}

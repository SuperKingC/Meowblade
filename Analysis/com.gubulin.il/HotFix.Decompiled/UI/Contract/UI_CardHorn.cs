using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_CardHorn : GComponent
{
	public Controller Type;

	public GGraph HornWrapperFoo;

	public GGraph HornWrapperBar;

	public const string URL = "ui://avplaivdicfotn8";

	public static string Name = "UI_CardHorn";

	public static string GetURL()
	{
		return "ui://avplaivdicfotn8";
	}

	public static UI_CardHorn CreateInstance()
	{
		return (UI_CardHorn)(object)UIPackage.CreateObject("Contract", "CardHorn");
	}

	public static UI_CardHorn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardHorn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdicfotn8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		HornWrapperFoo = (GGraph)((GComponent)this).GetChild("HornWrapperFoo");
		HornWrapperBar = (GGraph)((GComponent)this).GetChild("HornWrapperBar");
	}
}

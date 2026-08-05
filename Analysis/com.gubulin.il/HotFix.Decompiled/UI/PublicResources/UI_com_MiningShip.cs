using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_MiningShip : GComponent
{
	public GLoader ShipLoader;

	public Transition FloatingTrans;

	public const string URL = "ui://kt6rg65odg4uv4ly";

	public static string Name = "UI_com_MiningShip";

	public static string GetURL()
	{
		return "ui://kt6rg65odg4uv4ly";
	}

	public static UI_com_MiningShip CreateInstance()
	{
		return (UI_com_MiningShip)(object)UIPackage.CreateObject("PublicResources", "com_MiningShip");
	}

	public static UI_com_MiningShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MiningShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65odg4uv4ly", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShipLoader = (GLoader)((GComponent)this).GetChild("ShipLoader");
		FloatingTrans = ((GComponent)this).GetTransition("FloatingTrans");
	}
}

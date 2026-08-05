using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoldierPotentialIcon19 : GComponent
{
	public Controller PageController;

	public GLoader levelIcon;

	public GLoader levelLogo;

	public const string URL = "ui://kt6rg65oic7jt7r";

	public static string Name = "UI_SoldierPotentialIcon19";

	public static string GetURL()
	{
		return "ui://kt6rg65oic7jt7r";
	}

	public static UI_SoldierPotentialIcon19 CreateInstance()
	{
		return (UI_SoldierPotentialIcon19)(object)UIPackage.CreateObject("PublicResources", "SoldierPotentialIcon19");
	}

	public static UI_SoldierPotentialIcon19 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPotentialIcon19).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oic7jt7r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		levelIcon = (GLoader)((GComponent)this).GetChild("levelIcon");
		levelLogo = (GLoader)((GComponent)this).GetChild("levelLogo");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ScoreChest : GButton
{
	public Controller Status;

	public GImage Chest;

	public GGraph n12;

	public const string URL = "ui://avplaivdnacht6f";

	public static string Name = "UI_ScoreChest";

	public static string GetURL()
	{
		return "ui://avplaivdnacht6f";
	}

	public static UI_ScoreChest CreateInstance()
	{
		return (UI_ScoreChest)(object)UIPackage.CreateObject("Contract", "ScoreChest");
	}

	public static UI_ScoreChest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreChest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdnacht6f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Chest = (GImage)((GComponent)this).GetChild("Chest");
		n12 = (GGraph)((GComponent)this).GetChild("n12");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_IslandsMapPic : GComponent
{
	public Controller StageController;

	public GLoader n81;

	public GLoader n83;

	public Transition TurnDark;

	public Transition TurnLight;

	public const string URL = "ui://0i520nzmdy01ocx";

	public static string Name = "UI_IslandsMapPic";

	public static string GetURL()
	{
		return "ui://0i520nzmdy01ocx";
	}

	public static UI_IslandsMapPic CreateInstance()
	{
		return (UI_IslandsMapPic)(object)UIPackage.CreateObject("LordOfDreams", "IslandsMapPic");
	}

	public static UI_IslandsMapPic CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandsMapPic).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmdy01ocx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StageController = ((GComponent)this).GetController("StageController");
		n81 = (GLoader)((GComponent)this).GetChild("n81");
		n83 = (GLoader)((GComponent)this).GetChild("n83");
		TurnDark = ((GComponent)this).GetTransition("TurnDark");
		TurnLight = ((GComponent)this).GetTransition("TurnLight");
	}
}

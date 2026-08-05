using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_com_PropState : GComponent
{
	public Controller State;

	public GImage n183;

	public GImage n184;

	public const string URL = "ui://pwlamcyxusns1r";

	public static string Name = "UI_com_PropState";

	public static string GetURL()
	{
		return "ui://pwlamcyxusns1r";
	}

	public static UI_com_PropState CreateInstance()
	{
		return (UI_com_PropState)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "com_PropState");
	}

	public static UI_com_PropState CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PropState).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxusns1r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n183 = (GImage)((GComponent)this).GetChild("n183");
		n184 = (GImage)((GComponent)this).GetChild("n184");
	}
}

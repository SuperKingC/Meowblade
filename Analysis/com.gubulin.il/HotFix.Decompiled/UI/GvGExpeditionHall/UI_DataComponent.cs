using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_DataComponent : GComponent
{
	public GTextField ToCloseSignIn_Days;

	public GTextField ToCloseSignIn_Hours;

	public GTextField ToCloseSignIn_Minutes;

	public GTextField ToCloseSignIn_Seconds;

	public GTextField ToStartRoom_Days;

	public GTextField ToStartRoom_Hours;

	public GTextField ToStartRoom_Minutes;

	public GTextField ToStartRoom_Seconds;

	public GTextField RequirementText;

	public GTextField EnterRoomText;

	public GTextField MakeShipReady;

	public GTextField BuildShip;

	public GTextField ToStartSignIn_Days;

	public GTextField ToStartSignIn_Hours;

	public GTextField ToStartSignIn_Minutes;

	public GTextField ToStartSignIn_Seconds;

	public const string URL = "ui://k19peou7bnyk33";

	public static string Name = "UI_DataComponent";

	public static string GetURL()
	{
		return "ui://k19peou7bnyk33";
	}

	public static UI_DataComponent CreateInstance()
	{
		return (UI_DataComponent)(object)UIPackage.CreateObject("GvGExpeditionHall", "DataComponent");
	}

	public static UI_DataComponent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DataComponent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7bnyk33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected O, but got Unknown
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ToCloseSignIn_Days = (GTextField)((GComponent)this).GetChild("ToCloseSignIn_Days");
		string id = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToCloseSignIn_Days).id;
		((GObject)ToCloseSignIn_Days).text = LanguagesManager.GetDesc(id);
		ToCloseSignIn_Hours = (GTextField)((GComponent)this).GetChild("ToCloseSignIn_Hours");
		string id2 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToCloseSignIn_Hours).id;
		((GObject)ToCloseSignIn_Hours).text = LanguagesManager.GetDesc(id2);
		ToCloseSignIn_Minutes = (GTextField)((GComponent)this).GetChild("ToCloseSignIn_Minutes");
		string id3 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToCloseSignIn_Minutes).id;
		((GObject)ToCloseSignIn_Minutes).text = LanguagesManager.GetDesc(id3);
		ToCloseSignIn_Seconds = (GTextField)((GComponent)this).GetChild("ToCloseSignIn_Seconds");
		string id4 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToCloseSignIn_Seconds).id;
		((GObject)ToCloseSignIn_Seconds).text = LanguagesManager.GetDesc(id4);
		ToStartRoom_Days = (GTextField)((GComponent)this).GetChild("ToStartRoom_Days");
		string id5 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartRoom_Days).id;
		((GObject)ToStartRoom_Days).text = LanguagesManager.GetDesc(id5);
		ToStartRoom_Hours = (GTextField)((GComponent)this).GetChild("ToStartRoom_Hours");
		string id6 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartRoom_Hours).id;
		((GObject)ToStartRoom_Hours).text = LanguagesManager.GetDesc(id6);
		ToStartRoom_Minutes = (GTextField)((GComponent)this).GetChild("ToStartRoom_Minutes");
		string id7 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartRoom_Minutes).id;
		((GObject)ToStartRoom_Minutes).text = LanguagesManager.GetDesc(id7);
		ToStartRoom_Seconds = (GTextField)((GComponent)this).GetChild("ToStartRoom_Seconds");
		string id8 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartRoom_Seconds).id;
		((GObject)ToStartRoom_Seconds).text = LanguagesManager.GetDesc(id8);
		RequirementText = (GTextField)((GComponent)this).GetChild("RequirementText");
		string id9 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)RequirementText).id;
		((GObject)RequirementText).text = LanguagesManager.GetDesc(id9);
		EnterRoomText = (GTextField)((GComponent)this).GetChild("EnterRoomText");
		string id10 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)EnterRoomText).id;
		((GObject)EnterRoomText).text = LanguagesManager.GetDesc(id10);
		MakeShipReady = (GTextField)((GComponent)this).GetChild("MakeShipReady");
		string id11 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)MakeShipReady).id;
		((GObject)MakeShipReady).text = LanguagesManager.GetDesc(id11);
		BuildShip = (GTextField)((GComponent)this).GetChild("BuildShip");
		string id12 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)BuildShip).id;
		((GObject)BuildShip).text = LanguagesManager.GetDesc(id12);
		ToStartSignIn_Days = (GTextField)((GComponent)this).GetChild("ToStartSignIn_Days");
		string id13 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartSignIn_Days).id;
		((GObject)ToStartSignIn_Days).text = LanguagesManager.GetDesc(id13);
		ToStartSignIn_Hours = (GTextField)((GComponent)this).GetChild("ToStartSignIn_Hours");
		string id14 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartSignIn_Hours).id;
		((GObject)ToStartSignIn_Hours).text = LanguagesManager.GetDesc(id14);
		ToStartSignIn_Minutes = (GTextField)((GComponent)this).GetChild("ToStartSignIn_Minutes");
		string id15 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartSignIn_Minutes).id;
		((GObject)ToStartSignIn_Minutes).text = LanguagesManager.GetDesc(id15);
		ToStartSignIn_Seconds = (GTextField)((GComponent)this).GetChild("ToStartSignIn_Seconds");
		string id16 = "ui://k19peou7bnyk33".Replace("ui://", "") + "-" + ((GObject)ToStartSignIn_Seconds).id;
		((GObject)ToStartSignIn_Seconds).text = LanguagesManager.GetDesc(id16);
	}
}

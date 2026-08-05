using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_QuickStart : GButton
{
	public Controller button;

	public Controller State;

	public GImage n158;

	public GImage n159;

	public GTextField n160;

	public GImage n161;

	public const string URL = "ui://k19peou795pe6p8x";

	public static string Name = "UI_btn_QuickStart";

	public static string GetURL()
	{
		return "ui://k19peou795pe6p8x";
	}

	public static UI_btn_QuickStart CreateInstance()
	{
		return (UI_btn_QuickStart)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_QuickStart");
	}

	public static UI_btn_QuickStart CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_QuickStart).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou795pe6p8x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n160 = (GTextField)((GComponent)this).GetChild("n160");
		string id = "ui://k19peou795pe6p8x".Replace("ui://", "") + "-" + ((GObject)n160).id;
		((GObject)n160).text = LanguagesManager.GetDesc(id);
		n161 = (GImage)((GComponent)this).GetChild("n161");
	}
}

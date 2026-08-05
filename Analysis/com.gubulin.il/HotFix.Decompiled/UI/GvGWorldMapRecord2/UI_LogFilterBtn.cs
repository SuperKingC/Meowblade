using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMapRecord2;

public class UI_LogFilterBtn : GButton
{
	public Controller button;

	public Controller Type;

	public UI_show switcj;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://5xc1njmuqyk93e";

	public static string Name = "UI_LogFilterBtn";

	public static string GetURL()
	{
		return "ui://5xc1njmuqyk93e";
	}

	public static UI_LogFilterBtn CreateInstance()
	{
		return (UI_LogFilterBtn)(object)UIPackage.CreateObject("GvGWorldMapRecord2", "LogFilterBtn");
	}

	public static UI_LogFilterBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LogFilterBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5xc1njmuqyk93e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		switcj = (UI_show)(object)((GComponent)this).GetChild("switcj");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}

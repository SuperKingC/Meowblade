using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_com_GetMore : GComponent
{
	public Controller button;

	public UI_dec_02 n182;

	public GTextField n183;

	public GImage n184;

	public const string URL = "ui://fpjheycbej1av4g0";

	public static string Name = "UI_com_GetMore";

	public static string GetURL()
	{
		return "ui://fpjheycbej1av4g0";
	}

	public static UI_com_GetMore CreateInstance()
	{
		return (UI_com_GetMore)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_GetMore");
	}

	public static UI_com_GetMore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_GetMore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbej1av4g0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n182 = (UI_dec_02)(object)((GComponent)this).GetChild("n182");
		n183 = (GTextField)((GComponent)this).GetChild("n183");
		string id = "ui://fpjheycbej1av4g0".Replace("ui://", "") + "-" + ((GObject)n183).id;
		((GObject)n183).text = LanguagesManager.GetDesc(id);
		n184 = (GImage)((GComponent)this).GetChild("n184");
	}
}

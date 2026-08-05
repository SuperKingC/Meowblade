using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_com_ForgeResultContent : GComponent
{
	public Controller Count;

	public GList AmplifierList_big;

	public GList AmplifierList;

	public UI_com_ExtraAmps Extras;

	public const string URL = "ui://fpjheycbrxgdv4fd";

	public static string Name = "UI_com_ForgeResultContent";

	public static string GetURL()
	{
		return "ui://fpjheycbrxgdv4fd";
	}

	public static UI_com_ForgeResultContent CreateInstance()
	{
		return (UI_com_ForgeResultContent)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_ForgeResultContent");
	}

	public static UI_com_ForgeResultContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ForgeResultContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbrxgdv4fd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Count = ((GComponent)this).GetController("Count");
		AmplifierList_big = (GList)((GComponent)this).GetChild("AmplifierList_big");
		AmplifierList = (GList)((GComponent)this).GetChild("AmplifierList");
		Extras = (UI_com_ExtraAmps)(object)((GComponent)this).GetChild("Extras");
	}
}

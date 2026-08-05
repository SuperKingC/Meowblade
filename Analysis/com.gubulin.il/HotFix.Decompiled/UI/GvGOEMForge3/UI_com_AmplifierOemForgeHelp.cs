using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMForge3;

public class UI_com_AmplifierOemForgeHelp : GComponent
{
	public GImage Background;

	public GImage n9;

	public GTextField qulityDes;

	public GGroup n11;

	public const string URL = "ui://hotvoz3prne565";

	public static string Name = "UI_com_AmplifierOemForgeHelp";

	public static string GetURL()
	{
		return "ui://hotvoz3prne565";
	}

	public static UI_com_AmplifierOemForgeHelp CreateInstance()
	{
		return (UI_com_AmplifierOemForgeHelp)(object)UIPackage.CreateObject("GvGOEMForge3", "com_AmplifierOemForgeHelp");
	}

	public static UI_com_AmplifierOemForgeHelp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierOemForgeHelp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hotvoz3prne565", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		qulityDes = (GTextField)((GComponent)this).GetChild("qulityDes");
		string id = "ui://hotvoz3prne565".Replace("ui://", "") + "-" + ((GObject)qulityDes).id;
		((GObject)qulityDes).text = LanguagesManager.GetDesc(id);
		n11 = (GGroup)((GComponent)this).GetChild("n11");
	}
}

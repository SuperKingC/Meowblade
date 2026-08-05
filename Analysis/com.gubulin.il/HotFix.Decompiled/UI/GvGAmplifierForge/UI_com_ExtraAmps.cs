using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_com_ExtraAmps : GComponent
{
	public GImage n193;

	public GTextField n191;

	public GList ExtraList;

	public GButton Tips;

	public const string URL = "ui://fpjheycbrxgdv4fe";

	public static string Name = "UI_com_ExtraAmps";

	public static string GetURL()
	{
		return "ui://fpjheycbrxgdv4fe";
	}

	public static UI_com_ExtraAmps CreateInstance()
	{
		return (UI_com_ExtraAmps)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_ExtraAmps");
	}

	public static UI_com_ExtraAmps CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ExtraAmps).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbrxgdv4fe", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n193 = (GImage)((GComponent)this).GetChild("n193");
		n191 = (GTextField)((GComponent)this).GetChild("n191");
		string id = "ui://fpjheycbrxgdv4fe".Replace("ui://", "") + "-" + ((GObject)n191).id;
		((GObject)n191).text = LanguagesManager.GetDesc(id);
		ExtraList = (GList)((GComponent)this).GetChild("ExtraList");
		Tips = (GButton)((GComponent)this).GetChild("Tips");
	}
}

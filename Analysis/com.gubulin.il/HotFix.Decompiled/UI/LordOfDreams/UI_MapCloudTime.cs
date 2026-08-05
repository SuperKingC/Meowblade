using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_MapCloudTime : GComponent
{
	public GGraph n91;

	public GTextField n86;

	public GGraph n93;

	public GTextField Time;

	public GTextField n92;

	public const string URL = "ui://0i520nzmh82loea";

	public static string Name = "UI_MapCloudTime";

	public static string GetURL()
	{
		return "ui://0i520nzmh82loea";
	}

	public static UI_MapCloudTime CreateInstance()
	{
		return (UI_MapCloudTime)(object)UIPackage.CreateObject("LordOfDreams", "MapCloudTime");
	}

	public static UI_MapCloudTime CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MapCloudTime).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmh82loea", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n91 = (GGraph)((GComponent)this).GetChild("n91");
		n86 = (GTextField)((GComponent)this).GetChild("n86");
		string id = "ui://0i520nzmh82loea".Replace("ui://", "") + "-" + ((GObject)n86).id;
		((GObject)n86).text = LanguagesManager.GetDesc(id);
		n93 = (GGraph)((GComponent)this).GetChild("n93");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id2 = "ui://0i520nzmh82loea".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id2);
		n92 = (GTextField)((GComponent)this).GetChild("n92");
		string id3 = "ui://0i520nzmh82loea".Replace("ui://", "") + "-" + ((GObject)n92).id;
		((GObject)n92).text = LanguagesManager.GetDesc(id3);
	}
}

using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_com_AmpListContent : GComponent
{
	public GTextField n146;

	public GTextField n147;

	public GImage n148;

	public GImage n149;

	public GList RecommendList;

	public GList OthersList;

	public UI_com_ContentBottom ContentBottom;

	public GImage n152;

	public const string URL = "ui://pwlamcyxgp16p";

	public static string Name = "UI_com_AmpListContent";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp16p";
	}

	public static UI_com_AmpListContent CreateInstance()
	{
		return (UI_com_AmpListContent)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "com_AmpListContent");
	}

	public static UI_com_AmpListContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmpListContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp16p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n146 = (GTextField)((GComponent)this).GetChild("n146");
		string id = "ui://pwlamcyxgp16p".Replace("ui://", "") + "-" + ((GObject)n146).id;
		((GObject)n146).text = LanguagesManager.GetDesc(id);
		n147 = (GTextField)((GComponent)this).GetChild("n147");
		string id2 = "ui://pwlamcyxgp16p".Replace("ui://", "") + "-" + ((GObject)n147).id;
		((GObject)n147).text = LanguagesManager.GetDesc(id2);
		n148 = (GImage)((GComponent)this).GetChild("n148");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		RecommendList = (GList)((GComponent)this).GetChild("RecommendList");
		OthersList = (GList)((GComponent)this).GetChild("OthersList");
		ContentBottom = (UI_com_ContentBottom)(object)((GComponent)this).GetChild("ContentBottom");
		n152 = (GImage)((GComponent)this).GetChild("n152");
	}
}

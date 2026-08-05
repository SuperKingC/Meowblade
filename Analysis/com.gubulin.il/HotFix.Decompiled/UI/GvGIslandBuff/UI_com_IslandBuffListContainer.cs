using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_com_IslandBuffListContainer : GComponent
{
	public Controller Camp;

	public Controller HaveBuff;

	public GImage n17;

	public GTextField n0;

	public GLoader n9;

	public GList BuffList;

	public GTextField n19;

	public const string URL = "ui://zh7jgfijsch5s5t";

	public static string Name = "UI_com_IslandBuffListContainer";

	public static string GetURL()
	{
		return "ui://zh7jgfijsch5s5t";
	}

	public static UI_com_IslandBuffListContainer CreateInstance()
	{
		return (UI_com_IslandBuffListContainer)(object)UIPackage.CreateObject("GvGIslandBuff", "com_IslandBuffListContainer");
	}

	public static UI_com_IslandBuffListContainer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandBuffListContainer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijsch5s5t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		HaveBuff = ((GComponent)this).GetController("HaveBuff");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://zh7jgfijsch5s5t".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n9 = (GLoader)((GComponent)this).GetChild("n9");
		BuffList = (GList)((GComponent)this).GetChild("BuffList");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id2 = "ui://zh7jgfijsch5s5t".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id2);
	}
}

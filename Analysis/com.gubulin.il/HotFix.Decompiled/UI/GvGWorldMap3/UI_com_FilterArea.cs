using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FilterArea : GComponent, IFairyGuiPageTurner
{
	public GImage n6;

	public UI_btn_LastFilter Last;

	public UI_btn_NextFilter Next;

	public GTextField AreaName;

	public const string URL = "ui://4eq8fgd2kivrsbr";

	public static string Name = "UI_com_FilterArea";

	public GButton ToLast => (GButton)(object)Last;

	public GButton ToNext => (GButton)(object)Next;

	public static string GetURL()
	{
		return "ui://4eq8fgd2kivrsbr";
	}

	public static UI_com_FilterArea CreateInstance()
	{
		return (UI_com_FilterArea)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FilterArea");
	}

	public static UI_com_FilterArea CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FilterArea).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kivrsbr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Last = (UI_btn_LastFilter)(object)((GComponent)this).GetChild("Last");
		Next = (UI_btn_NextFilter)(object)((GComponent)this).GetChild("Next");
		AreaName = (GTextField)((GComponent)this).GetChild("AreaName");
	}

	public void RenderTitle(string title)
	{
		((GObject)AreaName).text = title;
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChat;

public class UI_com_Loading : GComponent
{
	public Controller c1;

	public GMovieClip n11;

	public const string URL = "ui://e3rxkbaprb0j13";

	public static string Name = "UI_com_Loading";

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0j13";
	}

	public static UI_com_Loading CreateInstance()
	{
		return (UI_com_Loading)(object)UIPackage.CreateObject("GvGChat", "com_Loading");
	}

	public static UI_com_Loading CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Loading).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
	}
}

using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivityMainCity;

public class UI_QQGameBigPlayerCom : GComponent
{
	public Controller c1;

	public GImage n131;

	public GLoader n132;

	public const string URL = "ui://z947bpf8iianv45o";

	public static string Name = "UI_QQGameBigPlayerCom";

	public static string GetURL()
	{
		return "ui://z947bpf8iianv45o";
	}

	public static UI_QQGameBigPlayerCom CreateInstance()
	{
		return (UI_QQGameBigPlayerCom)(object)UIPackage.CreateObject("QQGameActivityMainCity", "QQGameBigPlayerCom");
	}

	public static UI_QQGameBigPlayerCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QQGameBigPlayerCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8iianv45o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		n132 = (GLoader)((GComponent)this).GetChild("n132");
	}
}

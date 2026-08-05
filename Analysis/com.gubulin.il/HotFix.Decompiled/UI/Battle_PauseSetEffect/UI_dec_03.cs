using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle_PauseSetEffect;

public class UI_dec_03 : GComponent
{
	public Controller c1;

	public GImage n5;

	public GTextField n6;

	public GImage n7;

	public Transition t0;

	public const string URL = "ui://e9jxbc7wh7t3j";

	public static string Name = "UI_dec_03";

	public static string GetURL()
	{
		return "ui://e9jxbc7wh7t3j";
	}

	public static UI_dec_03 CreateInstance()
	{
		return (UI_dec_03)(object)UIPackage.CreateObject("Battle_PauseSetEffect", "dec_03");
	}

	public static UI_dec_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e9jxbc7wh7t3j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://e9jxbc7wh7t3j".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

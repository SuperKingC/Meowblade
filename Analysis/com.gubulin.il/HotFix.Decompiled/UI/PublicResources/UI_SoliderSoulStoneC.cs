using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_SoliderSoulStoneC : GComponent
{
	public Controller SoulStoneIllume;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public GGraph sfxBack0;

	public GGraph sfxBack1;

	public GGraph sfxBack2;

	public Transition activate;

	public const string URL = "ui://kt6rg65obunltb5";

	public static string Name = "UI_SoliderSoulStoneC";

	public static string GetURL()
	{
		return "ui://kt6rg65obunltb5";
	}

	public static UI_SoliderSoulStoneC CreateInstance()
	{
		return (UI_SoliderSoulStoneC)(object)UIPackage.CreateObject("PublicResources", "SoliderSoulStoneC");
	}

	public static UI_SoliderSoulStoneC CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoliderSoulStoneC).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65obunltb5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SoulStoneIllume = ((GComponent)this).GetController("SoulStoneIllume");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		sfxBack0 = (GGraph)((GComponent)this).GetChild("sfxBack0");
		sfxBack1 = (GGraph)((GComponent)this).GetChild("sfxBack1");
		sfxBack2 = (GGraph)((GComponent)this).GetChild("sfxBack2");
		activate = ((GComponent)this).GetTransition("activate");
	}
}

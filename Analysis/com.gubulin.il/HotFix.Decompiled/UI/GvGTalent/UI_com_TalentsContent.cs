using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_TalentsContent : GComponent
{
	public Controller hasOuterTech;

	public GImage n75;

	public GImage n76;

	public GImage n77;

	public GImage n78;

	public GImage n79;

	public UI_btn_Talent Talent0;

	public UI_btn_Talent Talent311;

	public UI_btn_Talent Talent125;

	public UI_btn_Talent Talent611;

	public UI_btn_Talent Talent425;

	public UI_btn_Talent Talent911;

	public UI_btn_Talent Talent126;

	public UI_btn_Talent Talent1211;

	public UI_btn_Talent Talent426;

	public UI_btn_Talent Talent141;

	public UI_btn_Talent Talent441;

	public UI_btn_Talent Talent151;

	public UI_btn_Talent Talent451;

	public UI_btn_Talent Talent122;

	public UI_btn_Talent Talent123;

	public UI_btn_Talent Talent422;

	public UI_btn_Talent Talent423;

	public UI_btn_Talent Talent127;

	public UI_btn_Talent Talent128;

	public UI_btn_Talent Talent427;

	public UI_btn_Talent Talent428;

	public UI_btn_Talent Talent132;

	public UI_btn_Talent Talent133;

	public UI_btn_Talent Talent432;

	public UI_btn_Talent Talent433;

	public UI_btn_Talent Talent131;

	public UI_btn_Talent Talent134;

	public UI_btn_Talent Talent431;

	public UI_btn_Talent Talent434;

	public UI_btn_Talent Talent124;

	public UI_btn_Talent Talent121;

	public UI_btn_Talent Talent424;

	public UI_btn_Talent Talent421;

	public UI_btn_Talent Talent912;

	public UI_btn_Talent Talent312;

	public UI_btn_Talent Talent226;

	public UI_btn_Talent Talent825;

	public UI_btn_Talent Talent225;

	public UI_btn_Talent Talent612;

	public UI_btn_Talent Talent826;

	public UI_btn_Talent Talent1212;

	public UI_btn_Talent Talent313;

	public UI_btn_Talent Talent224;

	public UI_btn_Talent Talent913;

	public UI_btn_Talent Talent821;

	public UI_btn_Talent Talent613;

	public UI_btn_Talent Talent221;

	public UI_btn_Talent Talent1213;

	public UI_btn_Talent Talent824;

	public UI_btn_Talent Talent827;

	public UI_btn_Talent Talent828;

	public UI_btn_Talent Talent228;

	public UI_btn_Talent Talent227;

	public UI_btn_Talent Talent234;

	public UI_btn_Talent Talent231;

	public UI_btn_Talent Talent831;

	public UI_btn_Talent Talent834;

	public UI_btn_Talent Talent841;

	public UI_btn_Talent Talent851;

	public UI_btn_Talent Talent251;

	public UI_btn_Talent Talent241;

	public UI_btn_Talent Talent223;

	public UI_btn_Talent Talent222;

	public UI_btn_Talent Talent822;

	public UI_btn_Talent Talent823;

	public UI_btn_Talent Talent341;

	public UI_btn_Talent Talent641;

	public UI_btn_Talent Talent941;

	public UI_btn_Talent Talent1241;

	public UI_btn_Talent Talent832;

	public UI_btn_Talent Talent833;

	public UI_btn_Talent Talent233;

	public UI_btn_Talent Talent232;

	public Transition t0;

	public const string URL = "ui://4r1llhd8ran34";

	public static string Name = "UI_com_TalentsContent";

	public static string GetURL()
	{
		return "ui://4r1llhd8ran34";
	}

	public static UI_com_TalentsContent CreateInstance()
	{
		return (UI_com_TalentsContent)(object)UIPackage.CreateObject("GvGTalent", "com_TalentsContent");
	}

	public static UI_com_TalentsContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TalentsContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8ran34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		Talent0 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent0");
		Talent311 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent311");
		Talent125 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent125");
		Talent611 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent611");
		Talent425 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent425");
		Talent911 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent911");
		Talent126 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent126");
		Talent1211 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent1211");
		Talent426 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent426");
		Talent141 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent141");
		Talent441 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent441");
		Talent151 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent151");
		Talent451 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent451");
		Talent122 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent122");
		Talent123 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent123");
		Talent422 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent422");
		Talent423 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent423");
		Talent127 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent127");
		Talent128 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent128");
		Talent427 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent427");
		Talent428 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent428");
		Talent132 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent132");
		Talent133 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent133");
		Talent432 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent432");
		Talent433 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent433");
		Talent131 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent131");
		Talent134 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent134");
		Talent431 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent431");
		Talent434 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent434");
		Talent124 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent124");
		Talent121 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent121");
		Talent424 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent424");
		Talent421 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent421");
		Talent912 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent912");
		Talent312 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent312");
		Talent226 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent226");
		Talent825 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent825");
		Talent225 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent225");
		Talent612 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent612");
		Talent826 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent826");
		Talent1212 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent1212");
		Talent313 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent313");
		Talent224 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent224");
		Talent913 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent913");
		Talent821 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent821");
		Talent613 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent613");
		Talent221 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent221");
		Talent1213 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent1213");
		Talent824 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent824");
		Talent827 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent827");
		Talent828 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent828");
		Talent228 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent228");
		Talent227 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent227");
		Talent234 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent234");
		Talent231 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent231");
		Talent831 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent831");
		Talent834 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent834");
		Talent841 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent841");
		Talent851 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent851");
		Talent251 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent251");
		Talent241 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent241");
		Talent223 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent223");
		Talent222 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent222");
		Talent822 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent822");
		Talent823 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent823");
		Talent341 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent341");
		Talent641 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent641");
		Talent941 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent941");
		Talent1241 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent1241");
		Talent832 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent832");
		Talent833 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent833");
		Talent233 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent233");
		Talent232 = (UI_btn_Talent)(object)((GComponent)this).GetChild("Talent232");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}

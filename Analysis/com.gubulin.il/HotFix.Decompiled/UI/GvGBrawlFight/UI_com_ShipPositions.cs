using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_ShipPositions : GComponent
{
	public Controller slotMode;

	public UI_com_ShipPositionSlot n0;

	public UI_com_ShipPositionSlot n1;

	public UI_com_ShipPositionSlot n2;

	public UI_com_ShipPositionSlot n3;

	public UI_com_ShipPositionSlot n4;

	public UI_com_ShipPositionSlot n5;

	public UI_com_ShipPositionSlot n6;

	public UI_com_ShipPositionSlot n7;

	public UI_com_ShipPositionSlot n8;

	public UI_com_ShipPositionSlot n9;

	public UI_com_ShipPositionSlot n10;

	public UI_com_ShipPositionSlot n11;

	public UI_com_ShipPositionSlot n12;

	public UI_com_ShipPositionSlot n13;

	public UI_com_ShipPositionSlot n14;

	public UI_com_ShipPositionSlot n15;

	public UI_com_ShipPositionSlot n16;

	public UI_com_ShipPositionSlot n17;

	public UI_com_ShipPositionSlot n18;

	public UI_com_ShipPositionSlot n19;

	public UI_com_ShipPositionSlot n20;

	public UI_com_ShipPositionSlot n21;

	public UI_com_ShipPositionSlot n22;

	public UI_com_ShipPositionSlot n23;

	public UI_com_ShipPositionSlot n24;

	public GGroup group5x5;

	public UI_com_ShipPositionSlot02 n26;

	public UI_com_ShipPositionSlot02 n27;

	public UI_com_ShipPositionSlot02 n28;

	public UI_com_ShipPositionSlot02 n29;

	public UI_com_ShipPositionSlot02 n30;

	public UI_com_ShipPositionSlot02 n31;

	public UI_com_ShipPositionSlot02 n32;

	public UI_com_ShipPositionSlot02 n33;

	public UI_com_ShipPositionSlot02 n34;

	public UI_com_ShipPositionSlot02 n35;

	public UI_com_ShipPositionSlot02 n36;

	public UI_com_ShipPositionSlot02 n37;

	public UI_com_ShipPositionSlot02 n38;

	public UI_com_ShipPositionSlot02 n39;

	public UI_com_ShipPositionSlot02 n40;

	public UI_com_ShipPositionSlot02 n41;

	public UI_com_ShipPositionSlot02 n42;

	public UI_com_ShipPositionSlot02 n43;

	public UI_com_ShipPositionSlot02 n44;

	public UI_com_ShipPositionSlot02 n45;

	public UI_com_ShipPositionSlot02 n46;

	public UI_com_ShipPositionSlot02 n47;

	public UI_com_ShipPositionSlot02 n48;

	public UI_com_ShipPositionSlot02 n49;

	public UI_com_ShipPositionSlot02 n50;

	public UI_com_ShipPositionSlot02 n51;

	public UI_com_ShipPositionSlot02 n52;

	public UI_com_ShipPositionSlot02 n53;

	public UI_com_ShipPositionSlot02 n54;

	public UI_com_ShipPositionSlot02 n55;

	public UI_com_ShipPositionSlot02 n56;

	public UI_com_ShipPositionSlot02 n57;

	public UI_com_ShipPositionSlot02 n58;

	public UI_com_ShipPositionSlot02 n59;

	public UI_com_ShipPositionSlot02 n60;

	public UI_com_ShipPositionSlot02 n61;

	public GGroup group6x6;

	public const string URL = "ui://hozu168rt2ex3e";

	public static string Name = "UI_com_ShipPositions";

	public static string GetURL()
	{
		return "ui://hozu168rt2ex3e";
	}

	public static UI_com_ShipPositions CreateInstance()
	{
		return (UI_com_ShipPositions)(object)UIPackage.CreateObject("GvGBrawlFight", "com_ShipPositions");
	}

	public static UI_com_ShipPositions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipPositions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rt2ex3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		slotMode = ((GComponent)this).GetController("slotMode");
		n0 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n0");
		n1 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n1");
		n2 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n2");
		n3 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n3");
		n4 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n4");
		n5 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n5");
		n6 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n6");
		n7 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n7");
		n8 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n8");
		n9 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n9");
		n10 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n10");
		n11 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n11");
		n12 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n12");
		n13 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n13");
		n14 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n14");
		n15 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n15");
		n16 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n16");
		n17 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n17");
		n18 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n18");
		n19 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n19");
		n20 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n20");
		n21 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n21");
		n22 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n22");
		n23 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n23");
		n24 = (UI_com_ShipPositionSlot)(object)((GComponent)this).GetChild("n24");
		group5x5 = (GGroup)((GComponent)this).GetChild("group5x5");
		n26 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n26");
		n27 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n27");
		n28 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n28");
		n29 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n29");
		n30 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n30");
		n31 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n31");
		n32 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n32");
		n33 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n33");
		n34 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n34");
		n35 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n35");
		n36 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n36");
		n37 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n37");
		n38 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n38");
		n39 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n39");
		n40 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n40");
		n41 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n41");
		n42 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n42");
		n43 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n43");
		n44 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n44");
		n45 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n45");
		n46 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n46");
		n47 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n47");
		n48 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n48");
		n49 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n49");
		n50 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n50");
		n51 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n51");
		n52 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n52");
		n53 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n53");
		n54 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n54");
		n55 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n55");
		n56 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n56");
		n57 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n57");
		n58 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n58");
		n59 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n59");
		n60 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n60");
		n61 = (UI_com_ShipPositionSlot02)(object)((GComponent)this).GetChild("n61");
		group6x6 = (GGroup)((GComponent)this).GetChild("group6x6");
	}
}

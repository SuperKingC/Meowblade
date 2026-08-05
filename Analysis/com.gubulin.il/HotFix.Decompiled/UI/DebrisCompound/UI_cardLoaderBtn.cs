using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_cardLoaderBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public GImage newIcon;

	public GGraph specialEffectsBack;

	public Transition bounce;

	public Transition overturn;

	public const string URL = "ui://6n2woz97o4kt2";

	public static string Name = "UI_cardLoaderBtn";

	public static string GetURL()
	{
		return "ui://6n2woz97o4kt2";
	}

	public static UI_cardLoaderBtn CreateInstance()
	{
		return (UI_cardLoaderBtn)(object)UIPackage.CreateObject("DebrisCompound", "cardLoaderBtn");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		specialEffectsBack = (GGraph)((GComponent)this).GetChild("specialEffectsBack");
		bounce = ((GComponent)this).GetTransition("bounce");
		overturn = ((GComponent)this).GetTransition("overturn");
	}
}

using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;

namespace UI.GvGOuterTech;

public class UI_com_DrawingCard : GComponent
{
	public Controller State;

	public UI_com_NewCardDescWrapper NewCardDescWrapper;

	public UI_com_TechCardBig TechCard;

	public UI_dec_01 n7;

	public Transition NormalTrans;

	public Transition NewTransIn;

	public Transition NewTransOut;

	public const string URL = "ui://th385mttk19mo2j";

	public static string Name = "UI_com_DrawingCard";

	public static string GetURL()
	{
		return "ui://th385mttk19mo2j";
	}

	public static UI_com_DrawingCard CreateInstance()
	{
		return (UI_com_DrawingCard)(object)UIPackage.CreateObject("GvGOuterTech", "com_DrawingCard");
	}

	public static UI_com_DrawingCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DrawingCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttk19mo2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		NewCardDescWrapper = (UI_com_NewCardDescWrapper)(object)((GComponent)this).GetChild("NewCardDescWrapper");
		TechCard = (UI_com_TechCardBig)(object)((GComponent)this).GetChild("TechCard");
		n7 = (UI_dec_01)(object)((GComponent)this).GetChild("n7");
		NormalTrans = ((GComponent)this).GetTransition("NormalTrans");
		NewTransIn = ((GComponent)this).GetTransition("NewTransIn");
		NewTransOut = ((GComponent)this).GetTransition("NewTransOut");
	}

	public void RenderNormalCard(DrawTechItem card)
	{
		TechData techData = card.TechData;
		State.selectedIndex = 0;
		TechCard.Rarity.selectedIndex = techData.Rarity;
		TechCard.TechIcon.url = techData.TechIconUrl;
		((GObject)TechCard.TechName).text = techData.Name;
	}

	public void RenderNewCard(DrawTechItem card)
	{
		TechData techData = card.TechData;
		State.selectedIndex = 1;
		TechCard.Rarity.selectedIndex = techData.Rarity;
		TechCard.TechIcon.url = techData.TechIconUrl;
		((GObject)TechCard.TechName).text = techData.Name;
		UI_com_NewCardDesc newCardDesc = NewCardDescWrapper.NewCardDesc;
		newCardDesc.Rarity.selectedIndex = techData.Rarity;
		((GObject)newCardDesc.Desc).text = techData.Desc;
		((GObject)newCardDesc.MaxEffect).text = techData.MaxLevelEffectDesc;
	}
}

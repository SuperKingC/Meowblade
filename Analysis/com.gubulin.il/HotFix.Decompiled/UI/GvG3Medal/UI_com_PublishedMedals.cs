using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;
using UnityEngine;

namespace UI.GvG3Medal;

public class UI_com_PublishedMedals : GComponent
{
	public GImage n1;

	public UI_btn_Confirm Publish;

	public GTextField UserName;

	public UI_com_UserAvatarBig Avatar;

	public GList Medals;

	public const string URL = "ui://g5hi1peon4czm";

	public static string Name = "UI_com_PublishedMedals";

	public static string GetURL()
	{
		return "ui://g5hi1peon4czm";
	}

	public static UI_com_PublishedMedals CreateInstance()
	{
		return (UI_com_PublishedMedals)(object)UIPackage.CreateObject("GvG3Medal", "com_PublishedMedals");
	}

	public static UI_com_PublishedMedals CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PublishedMedals).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peon4czm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Publish = (UI_btn_Confirm)(object)((GComponent)this).GetChild("Publish");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		Avatar = (UI_com_UserAvatarBig)(object)((GComponent)this).GetChild("Avatar");
		Medals = (GList)((GComponent)this).GetChild("Medals");
	}

	public void Init(EventCallback0 changeMedals)
	{
		((GObject)Publish).onClick.Set(changeMedals);
		int userId = GameController.Contexts.gameState.user.value.UserId;
		FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(userId, UserName));
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, Avatar.HeadPortrait.icon));
	}

	public void Update(List<GvG3MedalSimplifiedModel> medals)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		Medals.itemRenderer = new ListItemRenderer(Render);
		Medals.numItems = medals.Count;
		void Render(int index, GObject obj)
		{
			if (!(obj is UI_com_MedalSmall uI_com_MedalSmall))
			{
				throw new Exception("UI_com_PublishedMedals.Update.Render medalUi is not UI_com_MedalSmall");
			}
			GvG3MedalSimplifiedModel gvG3MedalSimplifiedModel = medals[index];
			uI_com_MedalSmall.Type.SetSelectedIndex(gvG3MedalSimplifiedModel.State);
			if (gvG3MedalSimplifiedModel.State == 1)
			{
				((GObject)uI_com_MedalSmall.MedalLevel).text = gvG3MedalSimplifiedModel.MedalLevel.ToString();
				uI_com_MedalSmall.MedalIcon.url = gvG3MedalSimplifiedModel.Config.SmallIcon;
			}
		}
	}
}

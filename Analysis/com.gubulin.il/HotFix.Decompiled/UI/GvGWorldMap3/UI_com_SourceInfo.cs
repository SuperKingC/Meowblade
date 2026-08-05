using System.Collections;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_SourceInfo : GComponent
{
	public Controller LimitedTime;

	public Controller Source;

	public GImage n9;

	public GTextField n0;

	public GTextField SourceText;

	public GTextField CountDown;

	public GLoader Icon;

	public GTextField ShareUserName;

	public UI_com_HeadPortrait HeadPortrait;

	public const string URL = "ui://4eq8fgd2o8el34";

	public static string Name = "UI_com_SourceInfo";

	private GvGMode3IslandOutputModel _uiModel;

	private Coroutine _updateLimitedTimestamp;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	public static string GetURL()
	{
		return "ui://4eq8fgd2o8el34";
	}

	public static UI_com_SourceInfo CreateInstance()
	{
		return (UI_com_SourceInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SourceInfo");
	}

	public static UI_com_SourceInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SourceInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2o8el34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		LimitedTime = ((GComponent)this).GetController("LimitedTime");
		Source = ((GComponent)this).GetController("Source");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://4eq8fgd2o8el34".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		SourceText = (GTextField)((GComponent)this).GetChild("SourceText");
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		ShareUserName = (GTextField)((GComponent)this).GetChild("ShareUserName");
		HeadPortrait = (UI_com_HeadPortrait)(object)((GComponent)this).GetChild("HeadPortrait");
	}

	private void Destroy()
	{
		if (_updateLimitedTimestamp != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateLimitedTimestamp);
		}
	}

	public void Init(GvGMode3IslandOutputModel itemModel)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		_uiModel = itemModel;
		RenderDialog();
		_updateLimitedTimestamp = FGUIManager.Instance.OpenIEnumerator(UpdateLimitedTimestamp());
		((GObject)this).onRemovedFromStage.Set(new EventCallback0(Destroy));
	}

	private void RenderDialog()
	{
		LimitedTime.selectedIndex = ((_uiModel.RemainingTime > 0) ? 1 : 0);
		((GObject)CountDown).text = UiHelper.ParseTime(_uiModel.RemainingTime);
		Source.selectedIndex = _uiModel.SourceInfoDialogType;
		((GObject)SourceText).text = _uiModel.SourceText;
		if (Source.selectedIndex == 1)
		{
			GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", _uiModel.ShareUserId, delegate(UserProfile profile)
			{
				((GObject)ShareUserName).text = profile.Name;
			}, delegate(Sprite sprite)
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_001c: Expected O, but got Unknown
				HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}));
		}
	}

	private IEnumerator UpdateLimitedTimestamp()
	{
		while (_uiModel.RemainingTime > 0)
		{
			((GObject)CountDown).text = UiHelper.ParseTime(_uiModel.RemainingTime);
			yield return _perSecond;
		}
	}
}

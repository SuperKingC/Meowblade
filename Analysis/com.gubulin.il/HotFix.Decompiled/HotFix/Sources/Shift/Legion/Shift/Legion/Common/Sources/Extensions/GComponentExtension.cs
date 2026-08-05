using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using Shift.Legion.ClientApi.Protocol;
using UI.PublicResources;
using UnityEngine;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;

public static class GComponentExtension
{
	public static void RenderPlayerProfileGvG3<T>(this GComponent source, PlayerProfileParams<T> param, int sourceData = -1) where T : GComponent
	{
		if (((GObject)source).name != "ProfileDisplay")
		{
			throw new Exception("GComponentExtension.RenderPlayerProfile：source is not ProfileDisplay");
		}
		GList medals = source.GetChild("Medals").asList;
		GObject playerName = source.GetChild("PlayerName");
		UI_com_ShipAvatar avatar = source.GetChild("Avatar") as UI_com_ShipAvatar;
		if (medals == null || playerName == null || avatar == null)
		{
			throw new Exception("GComponentExtension.RenderPlayerProfile：source child is null");
		}
		if (sourceData > 0)
		{
			((GObject)source).data = sourceData;
		}
		avatar.HeadPortrait.icon.url = "";
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(param.CacheVersion, param.UserId, LoadProfileCallback, LoadSpriteCallback));
		bool IsCorrect()
		{
			if (((GObject)source).data == null)
			{
				return true;
			}
			if (((GObject)source).data is int num)
			{
				return num == param.UserId;
			}
			return true;
		}
		void LoadProfileCallback(UserProfile profile)
		{
			if (IsCorrect() && !((GObject)source).isDisposed)
			{
				playerName.text = profile.Name;
				RenderMedals(medals, profile.MergedMedalRecords);
				param.OnProfileLoaded?.Invoke((T)(object)((source is T) ? source : null));
			}
		}
		void LoadSpriteCallback(Sprite sprite)
		{
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			if (IsCorrect() && !((GObject)avatar).isDisposed && !((GObject)avatar.HeadPortrait).isDisposed && !((GObject)avatar.HeadPortrait.icon).isDisposed)
			{
				bool flag = (Object)(object)sprite != (Object)null;
				if (flag)
				{
					avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
				}
				((GObject)avatar.DefaultAvatar).visible = !flag;
				avatar.CampId.SetSelectedIndex(param.CampId);
			}
		}
	}

	public static void RenderMedals(GList medals, List<GvGMedalRecord> medalRecords)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		if (!((GObject)medals).isDisposed)
		{
			medals.itemRenderer = new ListItemRenderer(Render);
			if (medalRecords == null || !medalRecords.Any())
			{
				medals.numItems = 0;
			}
			else
			{
				medals.numItems = medalRecords.Count;
			}
		}
		void Render(int index, GObject obj)
		{
			if (!(obj is UI_com_Medal uI_com_Medal))
			{
				throw new Exception("GComponentExtension.RenderMedals：medalUi is not UI_com_Medal");
			}
			GvGMedalRecord gvGMedalRecord = medalRecords[index];
			uI_com_Medal.MedalIcon.url = gvGMedalRecord.Config.SmallIcon;
			((GObject)uI_com_Medal.MedalLevel).text = gvGMedalRecord.Level.ToString();
		}
	}

	public static void BindText(this GComponent source, string parentPanelUrl)
	{
		string id = parentPanelUrl.Replace("ui://", "") + "-" + ((GObject)source).id;
		((GObject)source).text = LanguagesManager.GetDesc(id);
	}

	public static void BindText(this GComponent source, string parentPanelUrl, int stateIndex)
	{
		string id = string.Format("{0}-{1}-{2}", parentPanelUrl.Replace("ui://", ""), ((GObject)source).id, stateIndex);
		((GObject)source).text = LanguagesManager.GetDesc(id);
	}
}

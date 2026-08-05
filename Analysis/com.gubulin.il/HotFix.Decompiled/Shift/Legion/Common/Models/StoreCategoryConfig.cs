using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class StoreCategoryConfig
{
	public StoreCategory Category;

	public string Name;

	public string Desc;

	public string Poster;

	public List<string> Tags;

	public DateTimeOffset PhaseEndAt;

	public List<string> ExpoIcon;

	public List<string> ExpoName;

	public List<string> ExpoDesc;

	public StoreCategoryConfig(GDEStoreCategoryData data)
	{
		Category = (StoreCategory)data.Category;
		Name = data.Name;
		Desc = data.Desc;
		Tags = data.Tags;
		ExpoIcon = data.ExpoIcon;
		ExpoName = data.ExpoName;
		ExpoDesc = data.ExpoDesc;
		if (!string.IsNullOrEmpty(data.PhaseEndAt))
		{
			PhaseEndAt = DateTimeHelper.Parse(data.PhaseEndAt, DateTimeHelper.Now);
		}
	}
}

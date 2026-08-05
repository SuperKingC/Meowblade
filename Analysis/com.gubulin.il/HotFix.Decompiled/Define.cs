using HotFix;

public static class Define
{
	public static bool GvGMode3UnderTesting => false;

	public static bool IsGvgAvatarMedalOpen => true;

	public static bool PostProcessingCameraEnabled()
	{
		return false;
	}

	public static bool BlueprintUnderDevelopment()
	{
		return true;
	}

	public static bool SoldierMythUnderDevelopment()
	{
		return true;
	}

	public static bool GvGMode3UnderDevelopment()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return false;
		}
		return true;
	}

	public static bool GvGMode3OuterTechAvailable()
	{
		return true;
	}

	public static bool WeaponMaxDisplayLevel6UnderDevelopment()
	{
		return true;
	}

	public static bool IsWarehouseCollectionsOpen()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return false;
		}
		return true;
	}

	public static bool IsClickAssistantOpen()
	{
		return true;
	}

	public static bool IsGvGAutomationOpen()
	{
		string value;
		return HotUpdateProcess.Instance.Configs.TryGetValue("GvGAutomation", out value) && value == "1";
	}

	public static bool IsPlatformQQ()
	{
		return false;
	}
}

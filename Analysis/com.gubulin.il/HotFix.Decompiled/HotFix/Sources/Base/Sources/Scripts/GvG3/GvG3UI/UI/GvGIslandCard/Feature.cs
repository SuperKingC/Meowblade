using HotFix.Sources.Base.Scripts.Helper;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGIslandCard;

public class Feature
{
	private string _featureUiName;

	private string _featureDesc;

	public string FeatureName { get; set; }

	public string FeatureLangId { get; set; }

	public string FeatureUiName => _featureUiName ?? (_featureUiName = FeatureName.ToLanguage());

	public string FeatureDesc => _featureDesc ?? (_featureDesc = FeatureLangId.ToLanguage());
}

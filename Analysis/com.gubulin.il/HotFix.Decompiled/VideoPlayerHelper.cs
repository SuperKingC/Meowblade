using FairyGUI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Video;

public static class VideoPlayerHelper
{
	private static VideoPlayerController vpc;

	public static VideoPlayerController Get(GLoader gloader)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)vpc == (Object)null)
		{
			GameObject val = Addressables.LoadAssetAsync<GameObject>((object)"Video_VP").WaitForCompletion();
			GameObject val2 = Object.Instantiate<GameObject>(val);
			((Object)val2).name = "Video_VP";
			val2.AddComponent<VideoPlayerController>();
			vpc = val2.GetComponent<VideoPlayerController>();
			vpc.Player = val2.GetComponent<VideoPlayer>();
		}
		vpc.Loader = gloader;
		vpc.Loader.texture = new NTexture((Texture)(object)vpc.Player.targetTexture);
		((GObject)vpc.Loader).visible = false;
		return vpc;
	}
}

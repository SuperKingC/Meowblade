#if UNITY_EDITOR
using UnityEditor;

namespace Meowblade.Editor
{
    public sealed class ArtTexturePostprocessor : AssetPostprocessor
    {
        private const string RuntimeArtRoot = "Assets/Resources/Art/";

        private void OnPreprocessTexture()
        {
            if (!assetPath.StartsWith(RuntimeArtRoot, System.StringComparison.Ordinal))
            {
                return;
            }

            TextureImporter importer = (TextureImporter)assetImporter;
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Single;
            importer.mipmapEnabled = false;
            importer.wrapMode = UnityEngine.TextureWrapMode.Clamp;
            importer.filterMode = UnityEngine.FilterMode.Bilinear;
            importer.sRGBTexture = true;
            importer.alphaIsTransparency = !assetPath.Contains("/Backgrounds/");
            importer.textureCompression = TextureImporterCompression.Compressed;
            importer.maxTextureSize = 2048;
        }
    }
}
#endif

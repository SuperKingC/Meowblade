using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Meowblade
{
    public static class UiPalette
    {
        public static readonly Color Background = new Color(0.075f, 0.065f, 0.09f, 1f);
        public static readonly Color BackgroundLight = new Color(0.11f, 0.095f, 0.13f, 1f);
        public static readonly Color Panel = new Color(0.15f, 0.125f, 0.17f, 0.98f);
        public static readonly Color PanelLight = new Color(0.22f, 0.18f, 0.24f, 1f);
        public static readonly Color PanelWarm = new Color(0.30f, 0.22f, 0.19f, 1f);
        public static readonly Color Cream = new Color(1f, 0.91f, 0.75f, 1f);
        public static readonly Color Muted = new Color(0.74f, 0.70f, 0.76f, 1f);
        public static readonly Color Accent = new Color(1f, 0.62f, 0.25f, 1f);
        public static readonly Color AccentGreen = new Color(0.45f, 0.83f, 0.52f, 1f);
        public static readonly Color Danger = new Color(0.95f, 0.32f, 0.32f, 1f);
        public static readonly Color Blue = new Color(0.34f, 0.68f, 0.94f, 1f);
    }

    public static class UiFactory
    {
        private static Font _font;

        public static Font Font
        {
            get
            {
                if (_font == null)
                {
                    try
                    {
                        _font = UnityEngine.Font.CreateDynamicFontFromOSFont(
                            new[]
                            {
                                "Microsoft YaHei UI",
                                "Microsoft YaHei",
                                "Noto Sans CJK SC",
                                "Noto Sans SC",
                                "Droid Sans Fallback",
                                "SimHei",
                                "Arial"
                            },
                            28);
                    }
                    catch
                    {
                        _font = null;
                    }

                    if (_font == null)
                    {
                        _font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
                    }
                }

                return _font;
            }
        }

        public static Canvas CreateCanvas(string name)
        {
            GameObject canvasObject = new GameObject(name, typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            Canvas canvas = canvasObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 0;

            CanvasScaler scaler = canvasObject.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = GameDisplay.ReferenceResolution;
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 0.5f;

            if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
            {
                GameObject eventObject = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
                UnityEngine.Object.DontDestroyOnLoad(eventObject);
            }

            return canvas;
        }

        public static RectTransform CreateStretchRect(Transform parent, string name)
        {
            GameObject gameObject = new GameObject(name, typeof(RectTransform));
            RectTransform rect = gameObject.GetComponent<RectTransform>();
            rect.SetParent(parent, false);
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            return rect;
        }

        public static RectTransform CreateRect(Transform parent, string name, Vector2 position, Vector2 size)
        {
            GameObject gameObject = new GameObject(name, typeof(RectTransform));
            RectTransform rect = gameObject.GetComponent<RectTransform>();
            rect.SetParent(parent, false);
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = position;
            rect.sizeDelta = size;
            return rect;
        }

        public static RectTransform CreatePanel(Transform parent, string name, Vector2 position, Vector2 size, Color color)
        {
            RectTransform rect = CreateRect(parent, name, position, size);
            Image image = rect.gameObject.AddComponent<Image>();
            image.color = color;
            return rect;
        }

        public static RectTransform CreateStretchPanel(Transform parent, string name, Color color)
        {
            RectTransform rect = CreateStretchRect(parent, name);
            Image image = rect.gameObject.AddComponent<Image>();
            image.color = color;
            return rect;
        }

        public static Image CreateImage(
            Transform parent,
            string name,
            Vector2 position,
            Vector2 size,
            Sprite sprite,
            Color color,
            bool preserveAspect = true)
        {
            RectTransform rect = CreateRect(parent, name, position, size);
            Image image = rect.gameObject.AddComponent<Image>();
            image.sprite = sprite;
            image.color = color;
            image.preserveAspect = preserveAspect;
            image.raycastTarget = false;
            return image;
        }

        public static Image CreateStretchImage(
            Transform parent,
            string name,
            Sprite sprite,
            Color color,
            bool preserveAspect = false)
        {
            RectTransform rect = CreateStretchRect(parent, name);
            Image image = rect.gameObject.AddComponent<Image>();
            image.sprite = sprite;
            image.color = color;
            image.preserveAspect = preserveAspect;
            image.raycastTarget = false;
            return image;
        }

        public static Text CreateText(
            Transform parent,
            string name,
            string value,
            Vector2 position,
            Vector2 size,
            int fontSize,
            TextAnchor alignment,
            Color color,
            FontStyle style = FontStyle.Normal)
        {
            RectTransform rect = CreateRect(parent, name, position, size);
            Text text = rect.gameObject.AddComponent<Text>();
            text.font = Font;
            text.text = value;
            text.fontSize = fontSize;
            text.alignment = alignment;
            text.color = color;
            text.fontStyle = style;
            text.resizeTextForBestFit = false;
            text.horizontalOverflow = HorizontalWrapMode.Wrap;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            text.supportRichText = true;
            return text;
        }

        public static Button CreateButton(
            Transform parent,
            string name,
            string label,
            Vector2 position,
            Vector2 size,
            Color color,
            Action onClick,
            int fontSize = 26)
        {
            RectTransform rect = CreatePanel(parent, name, position, size, color);
            Button button = rect.gameObject.AddComponent<Button>();
            button.targetGraphic = rect.GetComponent<Image>();
            ColorBlock colors = button.colors;
            colors.normalColor = color;
            colors.highlightedColor = Color.Lerp(color, Color.white, 0.15f);
            colors.pressedColor = Color.Lerp(color, Color.black, 0.18f);
            colors.selectedColor = colors.highlightedColor;
            colors.disabledColor = new Color(color.r * 0.45f, color.g * 0.45f, color.b * 0.45f, 0.65f);
            colors.colorMultiplier = 1f;
            button.colors = colors;
            if (onClick != null)
            {
                button.onClick.AddListener(delegate { onClick(); });
            }

            Text text = CreateText(rect, "Label", label, Vector2.zero, size - new Vector2(12f, 8f), fontSize, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            text.raycastTarget = false;
            return button;
        }

        public static RectTransform CreateProgressBar(
            Transform parent,
            string name,
            Vector2 position,
            Vector2 size,
            Color background,
            Color fillColor,
            out Image fill)
        {
            RectTransform root = CreatePanel(parent, name, position, size, background);
            RectTransform fillRect = CreateStretchPanel(root, "Fill", fillColor);
            fillRect.anchorMax = new Vector2(0f, 1f);
            fillRect.pivot = new Vector2(0f, 0.5f);
            fill = fillRect.GetComponent<Image>();
            return root;
        }

        public static void SetProgress(Image fill, float value)
        {
            if (fill == null)
            {
                return;
            }

            RectTransform rect = fill.rectTransform;
            rect.anchorMax = new Vector2(Mathf.Clamp01(value), 1f);
        }

        public static RectTransform CreateCatToken(
            Transform parent,
            string name,
            Vector2 position,
            float size,
            Color color,
            string centerText,
            bool animated)
        {
            RectTransform root = CreatePanel(parent, name, position, new Vector2(size, size), color);
            root.gameObject.AddComponent<CanvasGroup>();

            RectTransform leftEar = CreatePanel(root, "LeftEar", new Vector2(-size * 0.24f, size * 0.38f), new Vector2(size * 0.25f, size * 0.25f), color);
            leftEar.localEulerAngles = new Vector3(0f, 0f, 45f);
            RectTransform rightEar = CreatePanel(root, "RightEar", new Vector2(size * 0.24f, size * 0.38f), new Vector2(size * 0.25f, size * 0.25f), color);
            rightEar.localEulerAngles = new Vector3(0f, 0f, 45f);

            Text face = CreateText(root, "Face", centerText, Vector2.zero, new Vector2(size * 0.9f, size * 0.9f), Mathf.RoundToInt(size * 0.42f), TextAnchor.MiddleCenter, new Color(0.12f, 0.09f, 0.10f), FontStyle.Bold);
            face.raycastTarget = false;

            if (animated)
            {
                BobAnimation bob = root.gameObject.AddComponent<BobAnimation>();
                bob.Amplitude = 7f;
                bob.Speed = 2f + UnityEngine.Random.Range(-0.25f, 0.25f);
                bob.Phase = UnityEngine.Random.Range(0f, 6.28f);
            }

            return root;
        }

        public static RectTransform CreateModalBackdrop(Transform parent, string name)
        {
            RectTransform backdrop = CreateStretchPanel(parent, name, new Color(0.02f, 0.015f, 0.03f, 0.86f));
            backdrop.SetAsLastSibling();
            Image image = backdrop.GetComponent<Image>();
            image.raycastTarget = true;
            return backdrop;
        }

        public static string FormatCosts(ResourceCost[] costs)
        {
            if (costs == null || costs.Length == 0)
            {
                return "免费";
            }

            string result = string.Empty;
            for (int i = 0; i < costs.Length; i++)
            {
                if (i > 0)
                {
                    result += "  ";
                }

                result += GameBalance.ResourceGlyph(costs[i].Resource) + costs[i].Amount;
            }

            return result;
        }
    }

    public sealed class BobAnimation : MonoBehaviour
    {
        public float Amplitude = 5f;
        public float Speed = 2f;
        public float Phase;

        private RectTransform _rect;
        private Vector2 _basePosition;

        private void Awake()
        {
            _rect = transform as RectTransform;
            if (_rect != null)
            {
                _basePosition = _rect.anchoredPosition;
            }
        }

        private void OnEnable()
        {
            if (_rect == null)
            {
                _rect = transform as RectTransform;
            }

            if (_rect != null)
            {
                _basePosition = _rect.anchoredPosition;
            }
        }

        private void Update()
        {
            if (_rect != null)
            {
                _rect.anchoredPosition = _basePosition + Vector2.up * Mathf.Sin(Time.unscaledTime * Speed + Phase) * Amplitude;
            }
        }
    }
}

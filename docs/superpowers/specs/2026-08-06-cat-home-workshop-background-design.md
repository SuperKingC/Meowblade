# 猫宅工坊纯场景背景设计

## 1. 目标

为《喵剑奇箱》生成一张可直接作为 Unity 猫宅主界面底图使用的横屏纯场景背景。场景必须延续三名主将设定图中的温暖手绘纸箱幻想风，并通过纸板、鱼干和毛线三组材料语言，让玩家在没有角色和文字说明的情况下也能理解空间用途。

本次仅交付单张合成背景图，不包含角色、UI、文字、分层源文件、动画拆件或碰撞数据。

## 2. 输出规格

- 资产类型：Unity 主界面背景图。
- 母版尺寸：`3200 x 1440`，横向约 `20:9`。
- 核心安全区：画面中央 `2560 x 1440`，覆盖标准 `16:9` 构图。
- 两侧扩展区：仅放允许在窄屏设备上裁切的墙面、纸箱、布帘和工具等装饰。
- 文件格式：PNG，RGB 或 RGBA 均可；不要求透明背景。
- 目标路径：`Assets/Art/Production/Backgrounds/home_workshop_background_v01.png`。

## 3. 构图

采用轻微俯视的横向剖面式室内视角，整体接近精致的童话舞台布景。画面上下边缘由纸板屋顶、木梁、地板和少量前景物形成自然框景，中下部保留一条连续、清晰、不会被高大物体截断的角色行走带。

三个功能区按从左到右的顺序组织：

1. 纸板工坊：瓦楞纸板墙、纸板切割台、胶带架、折叠盾牌、纸板箱和裁切余料，对应纸箱骑士的装备来源。
2. 鱼干厨房：猫爪形烤炉、鱼干晾绳、陶碗、木架与温暖炉火，作为画面主要光源和视觉中心，对应鱼干猎手。
3. 毛线研究角：紫色毛线球、线轴、编织工具、简易木杖与柔和微光装置，对应毛线法师。

中央区域以猫爪形旧地毯或低矮休息垫连接三个区域，但不得形成遮挡角色的高大前景。三个区域的道具密度由中央向外侧适度增加，使核心安全区保持可读和可用。

## 4. 视觉语言

- 风格：温暖、精致、轻喜剧感的手绘童话插画。
- 表面表现：柔和水彩铺色结合清晰彩铅边缘，轮廓自然，不使用生硬矢量描边。
- 主要材质：可辨认的瓦楞纸切面、胶带褶皱、纤维毛线、旧木纹、陶器与少量磨旧金属。
- 主色：奶油黄、蜂蜜橙、纸板棕和旧木色。
- 辅色：少量低饱和蓝绿色工具墙或织物，以及集中在右侧的毛线紫。
- 光线：奶油色日光与橙色炉火共同照明，阴影柔和，室内温暖但不能过暗。
- 细节等级：在 `3200 x 1440` 下能看清主要材质和功能，但不堆叠会干扰角色与 UI 的微小杂物。

## 5. 游戏可用性约束

- 不出现猫、老鼠、昆虫、人物剪影或任何其他角色。
- 不出现文字、数字、Logo、UI、按钮、招牌或水印。
- 不在核心安全区两侧放置会截断行走带的高大障碍。
- 不使用照片写实、3D 塑料玩具质感、重度电影景深或过黑暗恐怖氛围。
- 不让整张图只剩单一棕色；蓝绿色和紫色必须形成有限但清晰的色彩平衡。
- 道具不得悬浮，透视、接触阴影和尺度关系需要一致。
- 纸板工坊、鱼干厨房、毛线研究角必须在缩小到 `1920 x 864` 左右时仍能被区分。

## 6. 生成提示规格

```text
Use case: stylized-concept
Asset type: production-ready Unity 2D home-screen background
Primary request: Create an empty cat home workshop environment that matches the supplied three-cat character reference through its warm hand-painted cardboard fantasy style. The scene must contain no characters.
Input images: Image 1 is a style and material reference only; do not copy or insert its three cat characters.
Scene/backdrop: A cozy handmade cat workshop built from corrugated cardboard, old wood, tape, yarn, ceramic bowls, and a few worn metal parts. Left zone is a cardboard craft station with a cutting bench, tape rack, folded shields, cardboard boxes, and scraps. Center zone is a dried-fish kitchen with a cat-paw-shaped oven, hanging dried fish, bowls, shelves, and a warm hearth. Right zone is a yarn research corner with purple yarn balls, spools, knitting tools, a simple wooden staff, and a subtle magical device.
Style/medium: polished warm storybook illustration, soft watercolor fills with crisp colored-pencil edges, tactile handmade materials, whimsical but production-readable, consistent with the reference image.
Composition/framing: 3200 x 1440 panoramic horizontal composition, slight top-down cutaway interior view, central 2560 x 1440 safe composition, expendable decorative extensions at both sides, clear uninterrupted walkable band across the lower middle, no tall foreground obstruction in the central safe area.
Lighting/mood: creamy daylight mixed with an amber hearth glow, cozy, industrious, gentle, inviting, soft grounded shadows, clearly readable interior.
Color palette: cream, honey amber, cardboard brown, old wood, restrained teal accents, concentrated purple yarn accents.
Materials/textures: visible corrugated cardboard edges, folded paper seams, wrinkled tape, fibrous yarn, worn timber, matte ceramics, sparing aged metal.
Constraints: environment only; keep all major functional stations inside the central safe area; preserve open space for characters and game UI; consistent perspective and scale; no text.
Avoid: cats, mice, people, creatures, silhouettes, UI, buttons, labels, signs, logos, watermark, photorealism, glossy plastic 3D rendering, extreme depth of field, horror mood, monochrome brown palette, floating props, cluttered center, tall central obstacles.
```

## 7. 验收标准

生成结果必须同时满足以下条件：

- 画面为横向猫宅工坊纯背景，且不存在任何角色或角色剪影。
- 左、中、右三个区域分别清晰表达纸板、鱼干和毛线主题。
- 中央安全区保留连续的角色活动空间，没有明显遮挡。
- 风格、材质、色彩和光线与三主将参考图处于同一视觉世界。
- 在 `16:9` 中心裁切和约 `20:9` 完整显示下均保持构图完整。
- 不含文字、UI、Logo 或水印。
- 最终 PNG 被保存到约定的 Unity 项目目录，并经过一次人工视觉检查。

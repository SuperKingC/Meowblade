# 美术派生工具

`process_concept_assets.py` 将 `Assets/Art/Concept/VisualDirection/` 下已经确认的概念图，派生为当前 Demo 可以通过 `Resources.Load` 读取的 PNG 资源。

```powershell
python Tools/Art/process_concept_assets.py
```

脚本只覆盖它自己生成的文件，不修改四张概念母图。输出路径固定为：

- `Assets/Resources/Art/Backgrounds/`
- `Assets/Resources/Art/Characters/`
- `Assets/Resources/Art/Portraits/`
- `Assets/Resources/Art/Stations/`
- `Assets/Resources/Art/UI/Resources/`

脚本当前生成 20 张运行时 PNG 和一张资源总览。其中 `battle_alley_temp_v01` 保留原始概念画面，`battle_alley_temp_v02` 通过模糊和降对比作为战术背景，避免静态概念角色与运行时单位争夺视觉层级。

透明角色图使用纸张背景边缘连通区域识别并保留奶油色纸边，适合 Demo 的深色战斗背景；如果后续拿到正式透明原画，可以保留 `ArtLibrary` 的运行时接口，只替换资源路径或文件。

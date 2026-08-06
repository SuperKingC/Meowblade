"""Build temporary runtime art from the approved Meowblade concept sheets.

The generated files are derivatives for the playable prototype. Source concept
art remains untouched under Assets/Art/Concept/VisualDirection.
"""

from collections import deque
from pathlib import Path

import numpy as np
from PIL import Image, ImageDraw, ImageFilter, ImageOps


PROJECT_ROOT = Path(__file__).resolve().parents[2]
CONCEPT_ROOT = PROJECT_ROOT / "Assets" / "Art" / "Concept" / "VisualDirection"
RUNTIME_ROOT = PROJECT_ROOT / "Assets" / "Resources" / "Art"
PREVIEW_ROOT = PROJECT_ROOT / "Assets" / "Art" / "Production" / "Preview"

HERO_SHEET = CONCEPT_ROOT / "art_concept_heroes_lineup_v01.png"
HOME_SHEET = CONCEPT_ROOT / "art_concept_home_workshop_v01.png"
BATTLE_SHEET = CONCEPT_ROOT / "art_concept_battle_alley_v01.png"
UI_SHEET = CONCEPT_ROOT / "art_concept_ui_styleboard_v01.png"


def ensure_directories() -> None:
    for relative in ("Backgrounds", "Characters", "Portraits", "Stations", "UI/Resources"):
        (RUNTIME_ROOT / relative).mkdir(parents=True, exist_ok=True)
    PREVIEW_ROOT.mkdir(parents=True, exist_ok=True)


def save_png(image: Image.Image, path: Path) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    image.save(path, "PNG", optimize=True)


def fit(image: Image.Image, size: tuple[int, int], centering=(0.5, 0.5)) -> Image.Image:
    return ImageOps.fit(image, size, method=Image.Resampling.LANCZOS, centering=centering)


def connected_component(mask: np.ndarray) -> np.ndarray:
    """Keep the largest foreground island without requiring OpenCV/SciPy."""
    height, width = mask.shape
    visited = np.zeros_like(mask, dtype=bool)
    best: list[tuple[int, int]] = []

    for y in range(height):
        for x in range(width):
            if not mask[y, x] or visited[y, x]:
                continue

            queue = deque([(x, y)])
            visited[y, x] = True
            component: list[tuple[int, int]] = []
            while queue:
                px, py = queue.popleft()
                component.append((px, py))
                for nx, ny in ((px - 1, py), (px + 1, py), (px, py - 1), (px, py + 1)):
                    if 0 <= nx < width and 0 <= ny < height and mask[ny, nx] and not visited[ny, nx]:
                        visited[ny, nx] = True
                        queue.append((nx, ny))

            if len(component) > len(best):
                best = component

    result = np.zeros_like(mask, dtype=np.uint8)
    for x, y in best:
        result[y, x] = 255
    return result


def extract_paper_sticker(source: Image.Image, box: tuple[int, int, int, int], output_size=1024) -> Image.Image:
    """Extract one connected character and retain a small cream paper rim."""
    crop = source.crop(box).convert("RGB")
    pixels = np.asarray(crop, dtype=np.int16)
    red, green, blue = pixels[..., 0], pixels[..., 1], pixels[..., 2]

    # The lineup uses a light warm paper background. Flood only paper-like
    # pixels connected to the crop boundary so light fur inside the outline is
    # preserved as foreground.
    paper = (
        (red > 158)
        & (green > 125)
        & (blue > 78)
        & ((red - green) > 5)
        & ((red - green) < 75)
        & ((green - blue) > 4)
        & ((green - blue) < 85)
        & ((red + green + blue) > 465)
    )

    height, width = paper.shape
    background = np.zeros_like(paper, dtype=bool)
    queue: deque[tuple[int, int]] = deque()

    for x in range(width):
        for y in (0, height - 1):
            if paper[y, x] and not background[y, x]:
                background[y, x] = True
                queue.append((x, y))
    for y in range(height):
        for x in (0, width - 1):
            if paper[y, x] and not background[y, x]:
                background[y, x] = True
                queue.append((x, y))

    while queue:
        x, y = queue.popleft()
        for nx, ny in ((x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1)):
            if 0 <= nx < width and 0 <= ny < height and paper[ny, nx] and not background[ny, nx]:
                background[ny, nx] = True
                queue.append((nx, ny))

    foreground = connected_component(~background)
    mask = Image.fromarray(foreground, mode="L")
    mask = mask.filter(ImageFilter.MaxFilter(11)).filter(ImageFilter.GaussianBlur(1.4))

    rgba = crop.convert("RGBA")
    rgba.putalpha(mask)
    alpha_box = mask.getbbox()
    if alpha_box is None:
        raise RuntimeError(f"Character extraction produced an empty mask for crop {box}")

    rgba = rgba.crop(alpha_box)
    padding = max(32, output_size // 18)
    target = output_size - padding * 2
    scale = min(target / rgba.width, target / rgba.height)
    resized = rgba.resize(
        (max(1, round(rgba.width * scale)), max(1, round(rgba.height * scale))),
        Image.Resampling.LANCZOS,
    )
    canvas = Image.new("RGBA", (output_size, output_size), (0, 0, 0, 0))
    canvas.alpha_composite(resized, ((output_size - resized.width) // 2, output_size - padding - resized.height))
    return canvas


def circle_crop(source: Image.Image, box: tuple[int, int, int, int], output_size=512) -> Image.Image:
    crop = fit(source.crop(box).convert("RGBA"), (output_size, output_size))
    mask = Image.new("L", (output_size, output_size), 0)
    inset = max(4, output_size // 64)
    ImageDraw.Draw(mask).ellipse((inset, inset, output_size - inset, output_size - inset), fill=255)
    mask = mask.filter(ImageFilter.GaussianBlur(max(0.8, output_size / 512)))
    crop.putalpha(mask)
    return crop


def rounded_crop(source: Image.Image, box: tuple[int, int, int, int], size=(640, 360), radius=28) -> Image.Image:
    crop = fit(source.crop(box).convert("RGBA"), size)
    mask = Image.new("L", size, 0)
    ImageDraw.Draw(mask).rounded_rectangle((0, 0, size[0] - 1, size[1] - 1), radius=radius, fill=255)
    crop.putalpha(mask)
    return crop


def build_backgrounds() -> list[Path]:
    home = Image.open(HOME_SHEET).convert("RGB")
    battle = Image.open(BATTLE_SHEET).convert("RGB")
    battle_frame = fit(battle, (1920, 760), centering=(0.5, 0.54))
    battle_tactical = battle_frame.filter(ImageFilter.GaussianBlur(7.5))
    battle_tactical = Image.blend(
        battle_tactical,
        Image.new("RGB", battle_tactical.size, (24, 25, 30)),
        0.18,
    )
    outputs = [
        RUNTIME_ROOT / "Backgrounds" / "home_workshop_temp_v01.png",
        RUNTIME_ROOT / "Backgrounds" / "battle_alley_temp_v01.png",
        RUNTIME_ROOT / "Backgrounds" / "battle_alley_temp_v02.png",
    ]
    save_png(fit(home, (1920, 1080), centering=(0.5, 0.5)), outputs[0])
    save_png(battle_frame, outputs[1])
    save_png(battle_tactical, outputs[2])
    return outputs


def build_characters() -> list[Path]:
    sheet = Image.open(HERO_SHEET).convert("RGB")
    specs = (
        ("hero_cardboard_knight_temp_v01.png", (90, 150, 620, 835)),
        ("hero_fish_hunter_temp_v01.png", (585, 165, 1140, 835)),
        ("hero_yarn_mage_temp_v01.png", (1080, 135, 1605, 835)),
    )
    outputs: list[Path] = []
    for name, box in specs:
        output = RUNTIME_ROOT / "Characters" / name
        save_png(extract_paper_sticker(sheet, box), output)
        outputs.append(output)
    return outputs


def build_portraits() -> list[Path]:
    heroes = Image.open(HERO_SHEET).convert("RGB")
    battle = Image.open(BATTLE_SHEET).convert("RGB")
    specs = (
        (heroes, "hero_cardboard_knight_portrait_v01.png", (190, 205, 540, 555)),
        (heroes, "hero_fish_hunter_portrait_v01.png", (690, 215, 1035, 560)),
        (heroes, "hero_yarn_mage_portrait_v01.png", (1165, 195, 1505, 535)),
        (battle, "kitten_cardboard_squad_portrait_temp_v01.png", (250, 480, 450, 680)),
        (battle, "kitten_fish_squad_portrait_temp_v01.png", (360, 530, 555, 725)),
        (battle, "kitten_yarn_squad_portrait_temp_v01.png", (0, 440, 205, 645)),
        (battle, "enemy_cardboard_mouse_portrait_temp_v01.png", (1160, 170, 1405, 415)),
        (battle, "enemy_tape_captain_portrait_temp_v01.png", (1140, 310, 1460, 630)),
    )
    outputs: list[Path] = []
    for source, name, box in specs:
        output = RUNTIME_ROOT / "Portraits" / name
        save_png(circle_crop(source, box), output)
        outputs.append(output)
    return outputs


def build_station_thumbnails() -> list[Path]:
    sheet = Image.open(HOME_SHEET).convert("RGB")
    specs = (
        ("station_cardboard_recycling_v01.png", (0, 230, 570, 825)),
        ("station_dried_fish_kitchen_v01.png", (500, 190, 1165, 810)),
        ("station_mystic_parts_v01.png", (1050, 190, 1672, 810)),
    )
    outputs: list[Path] = []
    for name, box in specs:
        output = RUNTIME_ROOT / "Stations" / name
        save_png(rounded_crop(sheet, box), output)
        outputs.append(output)
    return outputs


def build_resource_icons() -> list[Path]:
    sheet = Image.open(UI_SHEET).convert("RGB")
    specs = (
        ("resource_cardboard_v01.png", (185, 38, 330, 183)),
        ("resource_dried_fish_v01.png", (530, 38, 675, 183)),
        ("resource_mystic_part_v01.png", (885, 38, 1030, 183)),
    )
    outputs: list[Path] = []
    for name, box in specs:
        output = RUNTIME_ROOT / "UI" / "Resources" / name
        save_png(circle_crop(sheet, box, output_size=256), output)
        outputs.append(output)
    return outputs


def build_preview(paths: list[Path]) -> Path:
    cards: list[tuple[str, Image.Image]] = []
    for path in paths:
        image = Image.open(path).convert("RGBA")
        thumb = fit(image, (320, 220))
        cards.append((path.stem, thumb))

    columns = 4
    card_width, card_height = 360, 280
    rows = (len(cards) + columns - 1) // columns
    sheet = Image.new("RGB", (columns * card_width, rows * card_height), (38, 32, 38))
    draw = ImageDraw.Draw(sheet)
    for index, (name, image) in enumerate(cards):
        x = (index % columns) * card_width
        y = (index // columns) * card_height
        checker = Image.new("RGBA", image.size, (226, 215, 190, 255))
        checker.alpha_composite(image)
        sheet.paste(checker.convert("RGB"), (x + 20, y + 15))
        draw.text((x + 20, y + 242), name[:42], fill=(244, 228, 193))

    output = PREVIEW_ROOT / "production_asset_sheet_v01.png"
    save_png(sheet, output)
    return output


def main() -> None:
    ensure_directories()
    generated = []
    generated.extend(build_backgrounds())
    generated.extend(build_characters())
    generated.extend(build_portraits())
    generated.extend(build_station_thumbnails())
    generated.extend(build_resource_icons())
    preview = build_preview(generated)

    print(f"Generated {len(generated)} runtime assets")
    for path in generated:
        print(path.relative_to(PROJECT_ROOT))
    print(preview.relative_to(PROJECT_ROOT))


if __name__ == "__main__":
    main()

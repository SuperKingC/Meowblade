#!/usr/bin/env python3
"""Generate deterministic Spine 4.3 JSON skeleton sources for Meowblade heroes."""

from __future__ import annotations

import argparse
import json
import shutil
from pathlib import Path


HERO_NAMES = ("cardboard_knight", "fish_hunter", "yarn_mage")
LAYER_SLOTS = (
    ("equipment_back", "body"),
    ("tail", "tail"),
    ("body", "body"),
    ("arm_back", "arm_back"),
    ("arm_front", "arm_front"),
    ("head", "head"),
    ("weapon", "weapon"),
    ("equipment_front", "body"),
)
EFFECT_ATTACHMENTS = (
    "shield_anchor",
    "fishbone_anchor",
    "yarn_anchor",
    "hit_anchor",
)
ANIMATION_NAMES = ("idle", "move", "attack", "skill", "hit", "retreat", "victory")


def project_root() -> Path:
    return Path(__file__).resolve().parents[2]


def default_manifest_path() -> Path:
    return project_root() / "Assets/Art/Production/SpineReady/hero_layer_manifest.json"


def default_output_dir() -> Path:
    return project_root() / "Assets/Art/Production/Spine/Generated"


def load_manifest(path: Path) -> dict:
    with path.open("r", encoding="utf-8") as stream:
        manifest = json.load(stream)
    missing = [hero for hero in HERO_NAMES if hero not in manifest.get("heroes", {})]
    if missing:
        raise ValueError(f"Manifest is missing heroes: {', '.join(missing)}")
    return manifest


def key(time: float | None = None, **values: float | str) -> dict:
    result: dict[str, float | str] = {}
    if time is not None:
        result["time"] = time
    result.update(values)
    return result


def animations() -> dict:
    return {
        "idle": {
            "bones": {
                "body": {
                    "translate": [
                        key(y=0),
                        key(1.0, y=8),
                        key(2.0, y=0),
                    ],
                    "scale": [
                        key(x=1, y=1),
                        key(1.0, x=1.015, y=0.985),
                        key(2.0, x=1, y=1),
                    ],
                },
                "head": {
                    "rotate": [
                        key(value=-2),
                        key(1.0, value=2),
                        key(2.0, value=-2),
                    ]
                },
            }
        },
        "move": {
            "bones": {
                "body": {
                    "translate": [
                        key(y=0),
                        key(0.15, y=10),
                        key(0.3, y=0),
                        key(0.45, y=8),
                        key(0.6, y=0),
                    ],
                    "rotate": [
                        key(value=-4),
                        key(0.3, value=4),
                        key(0.6, value=-4),
                    ],
                }
            }
        },
        "attack": {
            "bones": {
                "arm_front": {
                    "rotate": [
                        key(value=0),
                        key(0.12, value=-18),
                        key(0.24, value=24),
                        key(0.45, value=0),
                    ]
                },
                "weapon": {
                    "rotate": [
                        key(value=0),
                        key(0.12, value=-30),
                        key(0.24, value=42),
                        key(0.45, value=0),
                    ]
                },
                "body": {
                    "translate": [
                        key(x=0),
                        key(0.12, x=-10),
                        key(0.24, x=20),
                        key(0.45, x=0),
                    ]
                },
            }
        },
        "skill": {
            "bones": {
                "arm_front": {
                    "rotate": [
                        key(value=0),
                        key(0.25, value=-28),
                        key(0.55, value=20),
                        key(0.8, value=0),
                    ]
                },
                "effects": {
                    "scale": [
                        key(x=0.5, y=0.5),
                        key(0.4, x=1.25, y=1.25),
                        key(0.8, x=1, y=1),
                    ]
                },
                "body": {
                    "translate": [
                        key(y=0),
                        key(0.4, y=12),
                        key(0.8, y=0),
                    ]
                },
            }
        },
        "hit": {
            "bones": {
                "body": {
                    "translate": [
                        key(x=0),
                        key(0.08, x=-22),
                        key(0.25, x=0),
                    ],
                    "rotate": [
                        key(value=0),
                        key(0.08, value=-6),
                        key(0.25, value=0),
                    ],
                }
            }
        },
        "retreat": {
            "bones": {
                "body": {
                    "translate": [
                        key(x=0, y=0),
                        key(0.3, x=-18, y=-16),
                        key(0.6, x=-48, y=-24),
                    ],
                    "scale": [
                        key(x=1, y=1),
                        key(0.3, x=1.05, y=0.9),
                        key(0.6, x=0.95, y=0.82),
                    ],
                }
            },
            "slots": {
                slot: {
                    "rgba": [
                        key(color="ffffffff"),
                        key(0.6, color="ffffff00"),
                    ]
                }
                for slot, _ in LAYER_SLOTS
            },
        },
        "victory": {
            "bones": {
                "body": {
                    "translate": [
                        key(y=0),
                        key(0.3, y=18),
                        key(0.6, y=0),
                        key(0.9, y=14),
                        key(1.2, y=0),
                    ],
                    "scale": [
                        key(x=1, y=1),
                        key(0.3, x=1.04, y=0.96),
                        key(0.6, x=1, y=1),
                        key(0.9, x=1.03, y=0.97),
                        key(1.2, x=1, y=1),
                    ],
                },
                "head": {
                    "rotate": [
                        key(value=-4),
                        key(0.3, value=5),
                        key(0.6, value=-4),
                        key(0.9, value=5),
                        key(1.2, value=-4),
                    ]
                },
                "arm_front": {
                    "rotate": [
                        key(value=0),
                        key(0.3, value=16),
                        key(0.6, value=0),
                        key(0.9, value=16),
                        key(1.2, value=0),
                    ]
                },
            }
        },
    }


def build_skeleton(hero_name: str, hero: dict) -> dict:
    width, height = hero["output_dimensions"]
    attachments: dict[str, dict] = {}
    slots = []

    for slot_name, bone_name in LAYER_SLOTS:
        layer_name = "equipment_back" if slot_name == "equipment_back" else slot_name
        layer = hero[layer_name]
        attachment_name = layer_name
        slots.append({"name": slot_name, "bone": bone_name, "attachment": attachment_name})
        attachment = {
            "path": f"{hero_name}/full_body",
            "width": width,
            "height": height,
        }
        if layer.get("shared"):
            attachment["name"] = f"{layer_name}_shared_full_body"
        attachments[slot_name] = {attachment_name: attachment}

    slots.append({"name": "effects", "bone": "effects"})
    attachments["effects"] = {
        name: {"type": "point", "name": name} for name in EFFECT_ATTACHMENTS
    }

    return {
        "skeleton": {
            "spine": "4.3.23",
            "x": -(width / 2),
            "y": -(height / 2),
            "width": width,
            "height": height,
            "images": "./Images/",
        },
        "bones": [
            {"name": "root"},
            {"name": "body", "parent": "root"},
            {"name": "head", "parent": "body"},
            {"name": "arm_back", "parent": "body"},
            {"name": "arm_front", "parent": "body"},
            {"name": "weapon", "parent": "body"},
            {"name": "tail", "parent": "body"},
            {"name": "effects", "parent": "root"},
        ],
        "slots": slots,
        "skins": [{"name": "default", "attachments": attachments}],
        "animations": animations(),
    }


def validate_skeleton(data: dict, hero_name: str) -> None:
    bone_names = [bone["name"] for bone in data["bones"]]
    expected_bones = [
        "root",
        "body",
        "head",
        "arm_back",
        "arm_front",
        "weapon",
        "tail",
        "effects",
    ]
    if bone_names != expected_bones:
        raise ValueError(f"{hero_name}: unexpected bones: {bone_names}")
    slot_names = [slot["name"] for slot in data["slots"]]
    expected_slots = [slot for slot, _ in LAYER_SLOTS] + ["effects"]
    if slot_names != expected_slots:
        raise ValueError(f"{hero_name}: unexpected slots: {slot_names}")
    if tuple(data["animations"]) != ANIMATION_NAMES:
        raise ValueError(f"{hero_name}: unexpected animations: {list(data['animations'])}")
    effect_attachments = data["skins"][0]["attachments"]["effects"]
    if tuple(effect_attachments) != EFFECT_ATTACHMENTS:
        raise ValueError(f"{hero_name}: unexpected effect attachments")


def write_hero(manifest_path: Path, output_dir: Path, hero_name: str, hero: dict) -> Path:
    data = build_skeleton(hero_name, hero)
    validate_skeleton(data, hero_name)
    output_dir.mkdir(parents=True, exist_ok=True)
    json_path = output_dir / f"{hero_name}.json"
    with json_path.open("w", encoding="utf-8", newline="\n") as stream:
        json.dump(data, stream, indent=2)
        stream.write("\n")

    source_image = manifest_path.parent / hero["body"]["path"]
    image_dir = output_dir.parent / "Images" / hero_name
    image_dir.mkdir(parents=True, exist_ok=True)
    shutil.copy2(source_image, image_dir / "full_body.png")
    return json_path


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser()
    parser.add_argument("--manifest", type=Path, default=default_manifest_path())
    parser.add_argument("--output-dir", type=Path, default=default_output_dir())
    parser.add_argument("--hero", choices=HERO_NAMES)
    return parser.parse_args()


def main() -> int:
    args = parse_args()
    manifest_path = args.manifest.resolve()
    output_dir = args.output_dir.resolve()
    manifest = load_manifest(manifest_path)
    selected = (args.hero,) if args.hero else HERO_NAMES
    for hero_name in selected:
        output = write_hero(
            manifest_path,
            output_dir,
            hero_name,
            manifest["heroes"][hero_name],
        )
        print(f"generated {hero_name}: {output}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

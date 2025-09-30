English | [한국어](./README-ko.md)
# MapleStory Ring Assets Extractor

[![GitHub license](https://img.shields.io/github/license/SpiralMoon/maplestory-ring-assets-extractor.svg)](https://github.com/SpiralMoon/maplestory-ring-assets-extractor/blob/master/LICENSE)

A script that analyzes MapleStory client data files (.wz) to extract asset information for name tag rings and chat balloon rings, then outputs them as files.

Uses the [WzLib](https://github.com/Kagamia/WzComparerR2/tree/master/WzComparerR2.WzLib) library from [WzComparerR2](https://github.com/Kagamia/WzComparerR2) to analyze .wz files.

## Get Started

### Initialize SubModule

Before starting the project, you need to initialize the submodule.

```bash
git submodule update --init --recursive
```

### Configuration

You can configure the path to the data file (Base.wz) to be extracted and the directory path where the extraction results will be saved.

```json
{
  "Paths": {
    "WzFilePath": "C:\\Nexon\\Maple\\Data\\Base\\Base.wz",
    "OutputDirectory": "../output"
  }
}
```

The configuration file path is `RingAssetsExtractor/appsettings.json`.

### How to execute?

A batch file (run.bat) is provided for quick execution.

```bash
$ run.bat
```
Alternatively, you can run it directly with dotnet commands from the RingAssetsExtractor directory.
```bash
$ cd RingAssetsExtractor
$ dotnet run
```

## Output Results
### Image File Output
- Output location: `output/images/`
- Ring item icon image files
  <img width="912" height="541" alt="image" src="https://github.com/user-attachments/assets/315ba262-c1c4-4211-ac78-a0b8dce8bd54" />
- Chat balloon slice image files (head, nw, n, ne, w, c, e, sw, s, se, arrow)
  <img width="912" height="541" alt="image" src="https://github.com/user-attachments/assets/50829117-1d96-4dc9-9c5b-a0eb9c750e5e" />
- Name tag slice image files (w, c, e)
  <img width="912" height="541" alt="image" src="https://github.com/user-attachments/assets/b0bfb2d6-42ad-4271-9c30-be45bb065d8f" />

### Ring Information
- Output location: `output/ring.json`

The JSON structure contains different types of ring data. Click each section below to see examples:

<details>
<summary><b>Chat Balloon (Non-Animation)</b></summary>

```json
{
  "rings": [
    {
      "eqp_code": "01115652",
      "type": "ChatBalloon",
      "ring_code": "516",
      "name": "최초의 대적자 말풍선 반지",
      "desc": "캐릭터가 대화를 할 때, 최초의 대적자 말풍선이 나타난다. ",
      "color": "#FFC6C4CC",
      "is_animation": false,
      "height_offset": null,
      "bottom_offset": null,
      "images": {
        "nw": {
          "origin": {
            "x": 41,
            "y": 27
          },
          "size": {
            "w": 41,
            "h": 27
          }
        },
        "n": {
          "origin": {
            "x": 0,
            "y": 14
          },
          "size": {
            "w": 14,
            "h": 14
          }
        },
        "head": {
          "origin": {
            "x": 0,
            "y": 14
          },
          "size": {
            "w": 14,
            "h": 14
          }
        },
        "ne": {
          "origin": {
            "x": 0,
            "y": 27
          },
          "size": {
            "w": 47,
            "h": 27
          }
        },
        "w": {
          "origin": {
            "x": 21,
            "y": 0
          },
          "size": {
            "w": 21,
            "h": 14
          }
        },
        "c": {
          "origin": {
            "x": 0,
            "y": 0
          },
          "size": {
            "w": 14,
            "h": 14
          }
        },
        "e": {
          "origin": {
            "x": 0,
            "y": 0
          },
          "size": {
            "w": 21,
            "h": 14
          }
        },
        "sw": {
          "origin": {
            "x": 21,
            "y": 0
          },
          "size": {
            "w": 21,
            "h": 14
          }
        },
        "s": {
          "origin": {
            "x": 0,
            "y": 0
          },
          "size": {
            "w": 14,
            "h": 14
          }
        },
        "arrow": {
          "origin": {
            "x": 0,
            "y": 0
          },
          "size": {
            "w": 14,
            "h": 18
          }
        },
        "se": {
          "origin": {
            "x": 0,
            "y": 0
          },
          "size": {
            "w": 21,
            "h": 14
          }
        }
      }
    },
    ... other rings
  ]
}
```

</details>

<details>
<summary><b>Chat Balloon (Animation)</b></summary>

```json
{
  "rings": [
    {
      "eqp_code": "01115609",
      "type": "ChatBalloon",
      "ring_code": "472",
      "name": "MVP 블랙 말풍선 반지",
      "desc": "#cMVP 블랙# 등급에 주어지는 말풍선 반지다.",
      "color": "#FFFFFFFF",
      "is_animation": true,
      "height_offset": null,
      "bottom_offset": null,
      "images": {
        "0": {
          "nw": {
            "origin": {
              "x": 24,
              "y": 26
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "n": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "head": {
            "origin": {
              "x": 0,
              "y": 29
            },
            "size": {
              "w": 14,
              "h": 29
            }
          },
          "ne": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 23,
              "h": 26
            }
          },
          "w": {
            "origin": {
              "x": 22,
              "y": 0
            },
            "size": {
              "w": 22,
              "h": 14
            }
          },
          "c": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 14
            }
          },
          "e": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 21,
              "h": 14
            }
          },
          "sw": {
            "origin": {
              "x": 23,
              "y": 0
            },
            "size": {
              "w": 23,
              "h": 27
            }
          },
          "s": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "se": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "arrow": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          }
        },
        "1": {
          "nw": {
            "origin": {
              "x": 24,
              "y": 26
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "n": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "head": {
            "origin": {
              "x": 0,
              "y": 28
            },
            "size": {
              "w": 14,
              "h": 28
            }
          },
          "ne": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 23,
              "h": 26
            }
          },
          "w": {
            "origin": {
              "x": 22,
              "y": 0
            },
            "size": {
              "w": 22,
              "h": 14
            }
          },
          "c": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 14
            }
          },
          "e": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 21,
              "h": 14
            }
          },
          "sw": {
            "origin": {
              "x": 24,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 27
            }
          },
          "s": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "se": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "arrow": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          }
        },
        "2": {
          "nw": {
            "origin": {
              "x": 24,
              "y": 26
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "n": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "head": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "ne": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "w": {
            "origin": {
              "x": 22,
              "y": 0
            },
            "size": {
              "w": 22,
              "h": 14
            }
          },
          "c": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 14
            }
          },
          "e": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 21,
              "h": 14
            }
          },
          "sw": {
            "origin": {
              "x": 24,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 27
            }
          },
          "s": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "se": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "arrow": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          }
        },
        "3": {
          "nw": {
            "origin": {
              "x": 24,
              "y": 26
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "n": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "head": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "ne": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 23,
              "h": 26
            }
          },
          "w": {
            "origin": {
              "x": 22,
              "y": 0
            },
            "size": {
              "w": 22,
              "h": 14
            }
          },
          "c": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 14
            }
          },
          "e": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 21,
              "h": 14
            }
          },
          "sw": {
            "origin": {
              "x": 23,
              "y": 0
            },
            "size": {
              "w": 23,
              "h": 27
            }
          },
          "s": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "se": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "arrow": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 27
            }
          }
        },
        "4": {
          "nw": {
            "origin": {
              "x": 24,
              "y": 26
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "n": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "head": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "ne": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 23,
              "h": 26
            }
          },
          "w": {
            "origin": {
              "x": 22,
              "y": 0
            },
            "size": {
              "w": 22,
              "h": 14
            }
          },
          "c": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 14
            }
          },
          "e": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 21,
              "h": 14
            }
          },
          "sw": {
            "origin": {
              "x": 23,
              "y": 0
            },
            "size": {
              "w": 23,
              "h": 27
            }
          },
          "s": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "se": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "arrow": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 27
            }
          }
        },
        "5": {
          "nw": {
            "origin": {
              "x": 24,
              "y": 26
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "n": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "head": {
            "origin": {
              "x": 0,
              "y": 28
            },
            "size": {
              "w": 14,
              "h": 28
            }
          },
          "ne": {
            "origin": {
              "x": 0,
              "y": 26
            },
            "size": {
              "w": 23,
              "h": 26
            }
          },
          "w": {
            "origin": {
              "x": 22,
              "y": 0
            },
            "size": {
              "w": 22,
              "h": 14
            }
          },
          "c": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 14
            }
          },
          "e": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 21,
              "h": 14
            }
          },
          "sw": {
            "origin": {
              "x": 23,
              "y": 0
            },
            "size": {
              "w": 23,
              "h": 29
            }
          },
          "s": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 26
            }
          },
          "se": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 24,
              "h": 26
            }
          },
          "arrow": {
            "origin": {
              "x": 0,
              "y": 0
            },
            "size": {
              "w": 14,
              "h": 27
            }
          }
        }
      }
    },
    ... other rings
  ]
}
```

</details>

<details>
<summary><b>Name Tag (Non-Animation)</b></summary>

```json
{
  "rings": [
    {
      "eqp_code": "01115755",
      "type": "NameTag",
      "ring_code": "534",
      "name": "최초의 대적자 명찰 반지",
      "desc": "캐릭터 이름이 최초의 대적자 명찰에 나타난다. ",
      "color": "#FFC6C4CC",
      "is_animation": false,
      "height_offset": null,
      "bottom_offset": null,
      "images": {
        "w": {
          "origin": {
            "x": 46,
            "y": 7
          },
          "size": {
            "w": 46,
            "h": 24
          }
        },
        "c": {
          "origin": {
            "x": 0,
            "y": 7
          },
          "size": {
            "w": 2,
            "h": 24
          }
        },
        "e": {
          "origin": {
            "x": 0,
            "y": 7
          },
          "size": {
            "w": 53,
            "h": 24
          }
        }
      }
    },
    ... other rings
  ]
}
```

</details>

<details>
<summary><b>Name Tag (Animation)</b></summary>

```json
{
  "rings": [
    {
      "eqp_code": "01115712",
      "type": "NameTag",
      "ring_code": "490",
      "name": "MVP 블랙 명찰 반지",
      "desc": "#cMVP 블랙# 등급에 주어지는 명찰 반지다.",
      "color": "#FFFFFFFF",
      "is_animation": true,
      "height_offset": 10,
      "bottom_offset": 0,
      "images": {
        "0": {
          "0": {
            "origin": {
              "x": 42,
              "y": 9
            },
            "size": {
              "w": 84,
              "h": 28
            }
          },
          "1": {
            "origin": {
              "x": 42,
              "y": 8
            },
            "size": {
              "w": 84,
              "h": 27
            }
          },
          "2": {
            "origin": {
              "x": 42,
              "y": 8
            },
            "size": {
              "w": 84,
              "h": 28
            }
          }
        },
        "1": {
          "0": {
            "origin": {
              "x": 54,
              "y": 9
            },
            "size": {
              "w": 108,
              "h": 28
            }
          },
          "1": {
            "origin": {
              "x": 54,
              "y": 8
            },
            "size": {
              "w": 108,
              "h": 27
            }
          },
          "2": {
            "origin": {
              "x": 54,
              "y": 8
            },
            "size": {
              "w": 108,
              "h": 28
            }
          }
        },
        "2": {
          "0": {
            "origin": {
              "x": 66,
              "y": 9
            },
            "size": {
              "w": 132,
              "h": 28
            }
          },
          "1": {
            "origin": {
              "x": 66,
              "y": 8
            },
            "size": {
              "w": 132,
              "h": 27
            }
          },
          "2": {
            "origin": {
              "x": 66,
              "y": 8
            },
            "size": {
              "w": 132,
              "h": 28
            }
          }
        },
        "3": {
          "0": {
            "origin": {
              "x": 76,
              "y": 16
            },
            "size": {
              "w": 172,
              "h": 43
            }
          },
          "1": {
            "origin": {
              "x": 76,
              "y": 16
            },
            "size": {
              "w": 169,
              "h": 43
            }
          },
          "2": {
            "origin": {
              "x": 76,
              "y": 16
            },
            "size": {
              "w": 170,
              "h": 43
            }
          }
        }
      }
    },
    ... other rings
  ]
}
```

</details>

## Dependencies

- [WzComparerR2](https://github.com/SpiralMoon/WzComparerR2)
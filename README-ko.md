한국어 | [English](./README.md) 
# MapleStory Ring Assets Extractor

[![GitHub license](https://img.shields.io/github/license/SpiralMoon/maplestory-ring-assets-extractor.svg)](https://github.com/SpiralMoon/maplestory-ring-assets-extractor/blob/master/LICENSE)

메이플스토리의 클라이언트 데이터 파일(.wz)을 분석하여 명찰 반지, 말풍선 반지의 에셋 정보를 추출하여 파일로 출력하는 스크립트입니다.

.wz 파일을 분석하기 위해 [WzComparerR2](https://github.com/Kagamia/WzComparerR2)의 [WzLib](https://github.com/Kagamia/WzComparerR2/tree/master/WzComparerR2.WzLib) 라이브러리를 사용합니다.

## Get Started

### Initialize SubModule

프로젝트를 시작하기 전, submodule을 초기화 해야합니다.

```bash
git submodule update --init --recursive
```

### Configuration

추출 대상이 될 데이터 파일(Base.wz)의 경로와 추출 결과물이 저장될 디렉토리 경로를 설정할 수 있습니다.

```json
{
  "Paths": {
    "WzFilePath": "C:\\Nexon\\Maple\\Data\\Base\\Base.wz",
    "OutputDirectory": "../output"
  }
}
```

설정 파일 경로는 `RingAssetsExtractor/appsettings.json` 입니다.

### How to execute?

빠른 실행을 위해 즉시 실행 가능한 배치파일(run.bat)을 제공하고 있습니다.

```bash
$ run.bat
```
또는 RingAssetsExtractor 디렉토리에서 직접 dotnet 명령어로 실행할 수 있습니다.
```bash
$ cd RingAssetsExtractor
$ dotnet run
```

## Output Results
### Image File Output
- 출력 위치 : `output/images/`
- 반지 아이템 아이콘 이미지 파일
  <img width="912" height="541" alt="image" src="https://github.com/user-attachments/assets/315ba262-c1c4-4211-ac78-a0b8dce8bd54" />
- 말풍선 슬라이스 이미지 파일 (head, nw, n, ne, w, c, e, sw, s, se, arrow)
  <img width="912" height="541" alt="image" src="https://github.com/user-attachments/assets/50829117-1d96-4dc9-9c5b-a0eb9c750e5e" />
- 명찰 슬라이스 이미지 파일 (w, c, e)
  <img width="912" height="541" alt="image" src="https://github.com/user-attachments/assets/b0bfb2d6-42ad-4271-9c30-be45bb065d8f" />

**참고**: 애니메이션이 포함된 이미지의 경우 첫 번째 프레임만 추출되어 저장됩니다. (예시, 01115609)
### Ring Information
- 출력 위치 : `output/ring.json`
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
      "slices": {
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
    {
      "eqp_code": "01115755",
      "type": "NameTag",
      "ring_code": "534",
      "name": "최초의 대적자 명찰 반지",
      "desc": "캐릭터 이름이 최초의 대적자 명찰에 나타난다. ",
      "color": "#FFC6C4CC",
      "slices": {
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

## Dependencies

- [WzComparerR2](https://github.com/SpiralMoon/WzComparerR2)
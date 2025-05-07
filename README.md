# MySpartaMetabus2D
## 프로젝트 개요
MySpartaMetabus2D는 Unity로 개발된 2D 게임입니다. 플레이어는 다양한 무기와 상호작용 오브젝트, 상점, 미니게임(FlappyBird 등)을 경험할 수 있습니다.

## 개발 환경
**Unity**: 2022.3.24f1

##프로젝트 구조
```
Assets/
├── Animations/                # 애니메이션 클립 및 컨트롤러
├── Input/                     # Unity Input System 설정
├── MiniGames/                 # 미니게임(FlappyBird 등) 리소스 및 스크립트
├── Prefabs/                   # 재사용 가능한 프리팹(문, UI, 아이템 등)
├── Resources/
│   └── Items/Weapon/          # 무기 ScriptableObject 데이터
├── Scenes/                    # 메인 월드 씬
├── Scripts/
│   ├── Core/                  # 게임 매니저, UI 매니저, 카메라 등 핵심 시스템
│   ├── Entity/                # 플레이어 등 엔티티 컨트롤러
│   ├── Interactables/         # 상호작용 오브젝트 및 NPC
│   ├── Item/                  # 아이템 및 무기 데이터 구조
│   ├── Shop/                  # 상점 UI 및 로직
│   └── Constant/              # 공통 상수 정의
├── Sounds/                    # 효과음(SFX), 배경음악(BGM)
└── Sprites/                   # 2D 스프라이트 리소스
```
## 주요 기능

**플레이어 컨트롤:** PlayerController를 통한 이동, 상호작용 등

**상점 시스템:** ShopManager, ShopItemUI 등으로 구현된 아이템 구매/판매

**아이템/무기 시스템:** ScriptableObject(Weapon, ItemData) 기반 데이터 관리

**상호작용 오브젝트:** 문, NPC, 미니게임 스테이션 등 다양한 상호작용 요소

**미니게임:** FlappyBird 등 별도 미니게임 구현


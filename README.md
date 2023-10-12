# B11(강성호)-Forest Survival
 Chapter 3-3 Unity 게임개발 심화 개인과제입니다.
<p>
</p>

## 무정무계획팀 조 Team Notion
URL : [011 - 무정무계획팀 노션 (notion.site)](https://teamsparta.notion.site/07-b2e6e4b62af14ed59cb65651acd9286f?pvs=25)
 ## :one: 프로젝트 소개
 플레이어가 숲에서 자원을 구하여 생존하는 게임입니다.
## :two: 개발기간
- 23.10.10(화) ~ 23.10.12(목)

### :raising_hand: 멤버구성
- 강성호 - UI, 시작화면, 게임화면, 게임오버화면, 제작창, 인벤토리, 자원 채취, 아이템 사용, 아이템 버리기, 아이템 데이터, 캐릭터 컨디션(체력, 배고픔), 캐릭터 행동(이동, 점프, 달리기)

### :hammer: 개발 환경 
- Unity
- VisualStudio2022
- Size : 1920 x 1080
- Target Platform : PC

## :clipboard: 구현 목록

### 1. 시작화면
하단의 시작하기 버튼을 누르면 게임에 진입할 수 있습니다.

![image](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/22bdc675-bc12-4127-8f29-83f1e6e1aa7c)

### 2. 플레이어 컨디션
플레이어는 체력과 배고픔을 가지고 있습니다. 

배고픔은 실시간으로 감소하고 0이 될 시 체력이 감소하게 됩니다.

![Animation](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/fbbfebef-4e3d-457f-b13c-960de547beb4)

### 3. 캐릭터 행동
플레이어는 걷기, 달리기, 점프, 공격을 가지고 있습니다.

![Animation](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/6065c560-2176-4ba0-9d41-14576ea17d25)

### 4. 자원 채취
자원의 종류로는 나무와 돌이 있습니다. 

캐릭터의 공격으로 자원을 채취할 수 있습니다.

채취한 자원은 인벤토리로 들어오게 됩니다.

![Animation](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/9211dde5-566b-4ffd-bca2-12907b59d6f2)

### 5. 음식 채취
음식의 종류로는 버섯이 있습니다.

캐릭터의 몸과 닿으면 자동으로 채취됩니다.

사용버튼 클릭 시 배고픔과 체력이 증가합니다.

![Animation](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/ad18f432-2038-416f-92e1-e9c79ac64652)

### 5. 제작창 
나무로 이루어진 제작대가 존재합니다.

제작창은 제작대와 상호작용(키보드 E) 시 활성화됩니다.

![Animation](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/61c4f559-6276-40ed-8363-a7c9c84ca2c2)

### 6. 버리기
획득한 아이템은 버리기가 가능합니다.

하나씩 버려지고 필드에 드랍되지 않습니다.

![Animation](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/b245e6a6-aac8-4b7d-ad15-22a85690aa0c)

### 7. 게임오버
체력이 0이 된다면  게임오버 화면이 활성화됩니다.

게임오버 화면에서는 메인화면으로 되돌아가기와 다시하기 버튼이 있습니다.

![Animation](https://github.com/tjdgh7419/DOWA_TeamProject/assets/70570791/7b2e81bc-9534-4b29-93c5-d2b2d0ff8341)
## 🟥 구현하지 못한 부분
- 제작 아이템, 제작 기능
- 건축 기능


## :sob: 어려웠던 점

- 상태머신을 확실히 이해하고 사용하는 부분에 어려움이 있었습니다. 

## 느낀 점
- 이번 개인과제  목표는 두 가지가 있었습니다. 첫 번째로는 상태머신 이해하기, 두 번째로는 바로 직전 팀 프로젝트 코드 사용해 보기였습니다. 코드 분석에 걸린 시간으로 원하는 퀄리티의 게임이 나오진 않았지만 학습에 있어서 많은 것을 배운 시간이었습니다.

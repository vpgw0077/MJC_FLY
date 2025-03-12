# FLY!
![Image](https://github.com/user-attachments/assets/72dec600-0399-4ecf-9e20-4c7e5d7a603c)

## 개요
- 프로젝트 이름 : FLY!
- 장르 : 사이드 스크롤, 런
- 플랫폼 : Android
- 개발 도구 : Unity ver.2019.4.9f1, C#
- 개발 인원 : 4명
- 담당 역할 : 게임 기획, 플레이어, 데이터 매니저 등 핵심 기능 개발, 레벨 디자인, 리팩토링
- [플레이 영상](https://youtu.be/K7kEzqsor7M)

## 구동 방법
프로젝트를 열고 Assets -> Scenes -> MainTitle 씬을 열고 플레이하면 됩니다.

## 프로젝트 설명
- 이제 막 날기 시작한 아기 새의 비행을 도와주세요!
- FLY!는 사이드 스크롤 런 게임으로 최대한 멀리 날아가는 게 목표입니다.
- 비행을 하며 얻은 코인으로 캐릭터를 구매하고 능력을 업그레이드 할 수 있습니다.
- 플레이어가 땅에 닿으면 게임 오버 됩니다.

## 인 게임 요소

### UI
![Image](https://github.com/user-attachments/assets/48582cfb-9cea-437c-ac41-c5c10b01ce33)

- ${\textsf{\color{red}일시정지 버튼}}$ - 누르면 게임이 일시 정지되고 다시 게임을 재개하거나 메인 타이틀로 돌아갈 수 있습니다.
- ${\textsf{\color{blue}거리 표시}}$ - 날아온 거리를 표시합니다.
- ${\textsf{\color{green}획득한 코인}}$ - 획득한 코인량을 나타냅니다.
- ${\textsf{\color{magenta}점프 버튼}}$ - 버튼을 누르면 위로 점프를 하며 남아있는 점프 횟수를 보여줍니다.
- ${\textsf{\color{brown}미니맵}}$ - 플레이어의 현재 위치(높이)를 보여줍니다.

### 게임 오브젝트
- 코인
  <details>
  <summary>이미지</summary>
  접은 내용(ex 소스 코드)
  </details>


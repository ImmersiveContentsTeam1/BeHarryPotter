# BeHarryPotter

## Voice Command(박지후)
Oculus voice SDK with Wit.ai

Wit.ai 
https://wit.ai/apps/184718221171935/understanding

### 구현 기능
1. **Wit Activation(scripit)** : event(wand button click)에 따른 음성 인식 시작/종료 (현재는 space bar)
2. **VisualFeedback** :  Wit event(시작, 종료, 처리 중, 버튼 안 누르고 있을 때, 에러) 사용자에게 보여주는 text canvas
3. **Wit.ai training** : 

  * Wingardium Leviosa - levitate(띄우기)  
  * protego - 일반방어
  * Incendio - flame(화염 방사)
  * Immobulus - freeze(얼리기)
 
4. **Response Handler** : 음성인식 결과(intent)가 training한 값에 있다면 Magic Handler에 intent 전달   
5. **Magic Handler(script)** : 음성인식 결과(intent)와 모션인식 결과(?)가 정답과 일치한다면 마법 실행

### 참고 자료
https://developer.oculus.com/documentation/unity/voice-sdk-overview/

https://github.com/wit-ai/wit-unity

https://www.youtube.com/watch?v=SJ96P-ZhBoc&themeRefresh=1

## Bhaptics(박지후)
Tactsuit X40

Bhaptics developer portal
https://developer.bhaptics.com/application/S7To1fRZxc79JUkIQoPn

* 주의 사항 : This is DontDestroyOnLoad, so you only need to put it in the first scene.

### 참고 자료
https://bhaptics.notion.site/Plug-in-deployed-events-to-Unity-33cc33dcfa44426899a3f21c62adf66d

https://github.com/bhaptics/haptic-guide

## 오류
warning: LF will be replaced by CRLF in bora.txt.
The file will have its original line endings in your working directory
```
git config --global core.autocrlf true
```

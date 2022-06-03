# PpangPpangVirus
2022년 1학기 가상현실 15조 Project 15 기말 프로젝트  
  
##파일설명  
- Assets > Scenes 폴더: Stage3_test 씬 외에는 전부 테스트용 씬. 추후 Stage3로 이름 변경예정  
- Assets > Prefabs 폴더  
 - Ailen: Stage3용 외계인 프리팹  
 - bullet: 테스트용 총알  
 - Envirionment: Stage3의 맵 프리팹  
 - Gun: 총 프리팹(총알 발사 위치, 남은 총알 개수 텍스트, 발사 시 불꽃과 궤적 효과, 소리 모두 포함)  
 - OVRPlayerController: VR용 플레이어 프리팹(왼손에 HP바, 오른속에 총 장비)  
 - Target: 테스트용 타겟 프리팹(HP바 포함)  
  
- Assets > Scripts 폴더  
 - BulletCtrl: 테스트용 총알 발사 스크립트(사용하지 않음)  
 - GunScript: 총 관련 스크립트(발사:Fire, Shot, 재장전:Reload)  
 - IDamageable: 대미지를 받을 수 있는 것들의 인터페이스(OnDamage함수 필수)  
 - HitBox: 프리팹 폴더의 Target관련 스크립트, HP관리(IDamageable 인터페이스 이용)  
 - PlayerScript: 플레이어 HP관리(IDamageable 인터페이스 이용)  
 - ControllerInput: VR컨트롤러 입력에 따른 이동, 점프, 발사, 재장전 스크립트  

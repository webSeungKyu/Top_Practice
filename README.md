탑뷰 게임 만들기    

<br/>

PlayerPrefs 활용하여 데이터 저장 간단 구현<br/>




https://github.com/webSeungKyu/Top_Practice/assets/112837427/13363fdf-82ee-47cc-b6d0-6de9c951d9a4



<br/>




https://github.com/webSeungKyu/Top_Practice/assets/112837427/0606ab26-7226-4efc-8f0c-523ca7891f35



<br/>


※ 나에게 유용했던 내용들     
<함수>
[ OnTrigger ] / [OnCollision ]
 - 두 물체에 Collider컴포넌트가 있어야 한다.

[ Trigger 체크 ]
 - OnCollision함수는 IsTrigger 체크가 없어야 하고
 - OnTrigger함수는 한 개 이상의 Collider컴포넌트의 IsTrigger가 활성화가 필요.

[사용 예시]
 - 물리적 충돌이 필요한 경우엔 OnCollision 사용
 - 뚫고 지나가는 것처럼 물리적 충돌이 필요 없을 시 OnTrigger 사용
 


<캐릭터 사망 연출 시>
1. 캐릭터 움직임을 멈춘다.
 - rigidbody.velocity = new Vector2(0, 0);  
2. 물리 충돌 처리 콜라이더는 끈다.
 - Collider.enabled = false;
3. 중력을 줘서 아래로 떨어지게 한다.
 - rigidbody.gravityScale = 1;
4. 떨어지는 캐릭터에게 위로 튀어오르게 한다.
 - rigidbody.AddForce(new Vector2(0, 0.5f), ForceMode2D.Impulse);
5. 이후 캐릭터 제거나 사망하는 애니메이션까지?
 - Destroy / GetComponent<Animator>().Play;

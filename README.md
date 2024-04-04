탑뷰 게임 만들기  


※ 나에게 유용했던 내용들  


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

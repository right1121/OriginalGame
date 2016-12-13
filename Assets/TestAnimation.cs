using UnityEngine;
using System.Collections;

public class TestAnimation : MonoBehaviour {
	Animator anim;
	AnimatorStateInfo animS;

	// Use this for initialization
	void Start () {
		this.anim = this.gameObject.GetComponent<Animator>();
		this.anim.speed = 0;
		animS = anim.GetCurrentAnimatorStateInfo(0);
		
		anim.Play(1,0,10);
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown (KeyCode.Space)){
				this.anim.speed += 0.001f;
		}else if(Input.GetKeyDown(KeyCode.LeftAlt)) {
				this.anim.speed -= 0.001f;
		}
	}
}

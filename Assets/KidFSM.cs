using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidFSM : StateMachineBehaviour {

	public GameObject Kid;
	public GameObject opponent;
	public static float SPEED = 0.95f;
	public static float ROTSPEED = 1.0f;
	public static float ACCURACY = 0.3f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Kid = animator.gameObject;
		opponent = Kid.GetComponent<KidAI> ().GetPlayer ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : KidFSM {
	GameObject[] waypoints;
	int currentWPIndex;

	void Awake()
	{
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		currentWPIndex = 0;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (waypoints.Length == 0)
			return;

		if(Vector3.Distance(waypoints[currentWPIndex].transform.position, 
							Kid.transform.position) < ACCURACY)
		{
			currentWPIndex++;
			if(currentWPIndex >= waypoints.Length)
			{
				currentWPIndex = 0;
			}
		}

		var direction = waypoints [currentWPIndex].transform.position - Kid.transform.position;
		Kid.transform.rotation = Quaternion.Slerp (Kid.transform.rotation,
												   Quaternion.LookRotation(direction),
												   ROTSPEED * Time.deltaTime);
		Kid.transform.Translate (0, 0, Time.deltaTime * SPEED);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}
}

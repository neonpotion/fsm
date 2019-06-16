/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using UnityEngine;

/// <summary>
/// This state makes the character idle
/// </summary>
public class IdleState : BaseActorState {
	public IdleState(PlayerStateController controller) : base(StateType.IDLE, controller) {
	}

	public override void OnStateEnter() {
		Debug.Log("Entered idle state.");
	}

	public override void OnStateExit() {
		// 		throw new System.NotImplementedException();
	}

	protected override void Action() {

	}

	protected override void InitializeTransitionRules() {
		AddTransitionRule(new FSM.Transition<StateType>(TransitionToRagdoll, StateType.RAGDOLL));
	}

}

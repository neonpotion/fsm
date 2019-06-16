/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using FSM;
using UnityEngine;

/// <summary>
/// A component that manages the player state behaviours
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerStateController : MonoBehaviour {

	Rigidbody _rigidBody;
	public StateMachine<StateType> stateController {
		get; protected set;
	}

	public bool isRagdoll {
		get { return !_rigidBody.isKinematic; }
		set { _rigidBody.isKinematic = !value; }
	}

	/// <summary>
	/// The delta time for the state machine. 
	/// This is a property because you can update the state machine in fixed update
	/// </summary>
	public float deltaTime {
		get { return Time.deltaTime; }
	}

	/// <summary>
	/// Initialize component references
	/// </summary>
	void Awake() {
		_rigidBody = GetComponent<Rigidbody>();
		//Initialize the states and initialize the state machine
		IdleState idle = new IdleState(this);
		RagdollState ragdoll = new RagdollState(this);
		RecoveryState recovery = new RecoveryState(this);
		stateController = new StateMachine<StateType>(idle, ragdoll, recovery);
	}

	void Start() {

		//Initialize the rigidBody state
		isRagdoll = false;

		//Set the initial state
		stateController.ChangeState(StateType.IDLE);

	}

	void Update() {
		//input to simulate character knockdown
		if (Input.GetKeyDown(KeyCode.Space) && stateController.currentState.stateType == StateType.IDLE) {
			Debug.Log("Hitting the player");
			isRagdoll = true;
			_rigidBody.AddForce((Vector3.up * 3f) + (Vector3.forward * 2f), ForceMode.Impulse);
		}

		// Update the state machine
		stateController.UpdateTick();
	}




}

public enum StateType {
	IDLE,
	RAGDOLL,
	RECOVERY
}
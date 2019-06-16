/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using System.Collections.Generic;
using UnityEngine;

namespace FSM {
	public class StateMachine<T> {

		protected State<T> _currentState;
		protected Dictionary<T, State<T>> _stateList = new Dictionary<T, State<T>>();

		/// <summary>
		/// The active state of this state machine.
		/// </summary>
		public State<T> currentState {
			get {
				return _currentState;
			}
		}

		public event System.Action<T> EventStateChange = (T c) => { };

		/// <summary>
		/// Initializes the state machine.
		/// </summary>
		/// <param name="t"> The states</param>
		public StateMachine(params State<T>[] t) {
			for (int i = 0; i < t.Length; i++) {
				_stateList.Add(t[i].stateType, t[i]);
			}
		}

		/// <summary>
		/// Update the state
		/// </summary>
		public void UpdateTick() {
			if (_currentState != null) {
				_currentState.UpdateState(this);
			}
		}

		/// <summary>
		/// Transitions to the specified state if it exists
		/// </summary>
		/// <param name="nextState"></param>
		public void ChangeState(T nextState) {
			State<T> t;
			if (_stateList.TryGetValue(nextState, out t)) {
				if (_currentState != null) {
					_currentState.OnStateExit();
				}
				_currentState = t;
				_currentState.OnStateEnter();
				EventStateChange(_currentState.stateType);
			} else {
				Debug.LogWarning("Could not find state " + nextState.ToString());
			}
		}
	}
}
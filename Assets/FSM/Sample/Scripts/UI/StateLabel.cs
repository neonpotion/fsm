/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A simple label script that tracks the state of the specified player state machine
/// </summary>
public class StateLabel : MonoBehaviour {

	const string LABEL_DESCRIPTION = "Current state : ";

	[SerializeField] PlayerStateController _stateController;

	Text _textUI;

	void Start() {
		_textUI = GetComponent<Text>();
		_stateController.stateController.EventStateChange += OnStateChange;
	}

	void OnDestroy() {
		_stateController.stateController.EventStateChange -= OnStateChange;
	}

	void OnStateChange(StateType t) {
		_textUI.text = LABEL_DESCRIPTION + t.ToString();
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	string preState, afterState;

	void Start ()
	{
		var gameController = GameController.Instance;
		ChangeGameState(gameController.gameState.Value);

		preState = "add event before: " + gameController.gameState.Value;
		Debug.Log(preState);

		gameController.gameState.changed += ChangeGameState;

		afterState = "add event after: " + gameController.gameState.Value;
		Debug.Log(afterState);
	}
	
	void OnDestroy ()
	{
		if (GameController.Instance != null)
			GameController.Instance.gameState.changed -= ChangeGameState;
	}

	void ChangeGameState (GameController.GameState state){}

	void OnGUI()
	{
		GUILayout.Label(preState);
		GUILayout.Label(afterState);
	}
}

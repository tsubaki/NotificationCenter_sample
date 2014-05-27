using UnityEngine;
using System.Collections;

public class GameController : SingletonMonoBehaviour<GameController> 
{
	public NotificationObject<int> score = new NotificationObject<int>(0);

	public enum GameState
	{
		Title,
		Play,
		GameOver
	}

	public NotificationObject<GameState> gameState = new NotificationObject<GameState>(GameState.Title);

	void OnDestroy()
	{
		score.Dispose();
		gameState.Dispose();
	}

}

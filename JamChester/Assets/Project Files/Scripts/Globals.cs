using UnityEngine;
using System.Collections;


public enum GameState { PLAYING, LOST, WON};


public class Globals : MonoBehaviour
{
    public static GameState game_state = GameState.PLAYING;

	
}

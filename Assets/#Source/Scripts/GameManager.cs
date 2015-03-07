using UnityEngine;
using System.Collections;

public enum GameState {
    Play,
    End
}

public class GameManager : MonoBehaviour {


    public GameState GS;

    public GUIText Text_Meter, Text_Gold;

    public GameObject Final_GUI;

    public GUIText Final_Meter, Final_Gold;

    public float speed, meter;
    public int gold;

	public void Update () {

        if(GS == GameState.Play) {
            meter += Time.deltaTime * speed;

            Text_Meter.text = string.Format("{0:N0}m", meter);
        }
	}

    public void GetCoin() {
        gold++;
        Text_Gold.text = string.Format("{0}", gold);
    }

    public void GameOver() {

        Final_Meter.text = string.Format("{0:N1}", meter);
        Final_Gold.text = string.Format("{0}", gold);
        GS = GameState.End;
        Final_GUI.SetActive(true);
    }

    public void Replay() {
        Application.LoadLevel("PlayScene");
    }
}

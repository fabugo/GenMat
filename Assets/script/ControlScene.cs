using UnityEngine;
using System.Collections;

public class ControlScene : MonoBehaviour {
    public void Play()
    {
        Application.LoadLevel("game0");
    }
    public void ShowScore()
    {
        Application.LoadLevel("score");
    }
    public void FinishGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        Application.LoadLevel("menu");
    }
    public void Map()
    {
        Application.LoadLevel("map");
    }
}

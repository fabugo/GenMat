using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlScene : MonoBehaviour {
    public void Play(Text txt)
    {
        Application.LoadLevel(txt.text);
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

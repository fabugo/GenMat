using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class ScoreController : MonoBehaviour {
    string score;
    // Use this for initialization
    void Start()
    {
        score = "SCORE: " + PlayerPrefs.GetInt("score").ToString();
        GetComponent<Text>().text = score;
    }
}

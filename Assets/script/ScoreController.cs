using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class ScoreController : MonoBehaviour {
    string score;
	// Use this for initialization
	void Start () {
        //score = File.ReadAllText(@"Assets\\script\\score");
        score = "985461\n1976\n2";
        ListScore();
    }
    void ListScore()
    {
        GetComponent<Text>().text = score;
    }
}

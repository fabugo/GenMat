using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlText : MonoBehaviour {
    public GameObject gc;
    public int type;
	
	// Update is called once per frame
	void Update () {
        switch (type)
        {
            case 1:
                GetComponent<Text>().text = "" + gc.GetComponent<GameController>().getSum();
                break;
            case 2:
                GetComponent<Text>().text = "" + gc.GetComponent<GameController>().getLimit();
                break;
            case 3:
                GetComponent<Text>().text = "" + gc.GetComponent<GameController>().getGoal();
                break;
        }
    }
}

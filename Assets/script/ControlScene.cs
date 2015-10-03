using UnityEngine;
using System.Collections;

public class ControlScene : MonoBehaviour {

    public void ChangeScene()
    {
        Debug.Log("Mudar para scene game");
        Application.LoadLevel("game");
    }

}

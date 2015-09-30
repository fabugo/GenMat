using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBoard : MonoBehaviour
{
    private Text btTex;
    public GameObject controller;
    private GameController gmControl;
	// Use this for initialization
	void Start ()
    {
        gmControl = controller.GetComponent<GameController>();
        btTex = GetComponentInChildren<Text>();
	}

    public void enviarTex()
    {
        gmControl.receberTex(btTex.text);
    }

    public void desligarBt()
    {
        GetComponent<Button>().interactable = false;
    }
}

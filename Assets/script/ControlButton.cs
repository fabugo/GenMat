using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlButton : MonoBehaviour
{
    private bool hasNumber;                 //define se o botao ja tem um numero ou nao
    public bool isOP;                       //define o tipo de botao, true:é um botao que contem um caracter de operacao
    public GameObject gc;                   // link para o controlador do jogo
	// Use this for initialization
	void Start () {
        switch(gc.GetComponent<GameController>().scale)
        {
            case 3:
                if(GetComponentInChildren<Text>().text == "e")
                {
                    GetComponentInChildren<Text>().text = "" + gc.GetComponent<GameController>().numberInit;
                    hasNumber = true;
                }
                break;
            case 5:

                break;
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isOP)
        {
            switch (gc.GetComponent<GameController>().getState() % 2)
            {
                case 0:
                    GetComponent<Button>().interactable = false;
                    break;
                case 1:
                    GetComponent<Button>().interactable = true;
                    break;
            }
        }
        else
        {
            if (hasNumber)
            {
                switch (gc.GetComponent<GameController>().getState() % 2)
                {
                    case 0:
                        GetComponent<Button>().interactable = true;
                        break;
                    case 1:
                        GetComponent<Button>().interactable = false;
                        break;
                }
            }
            else
            {
                GetComponent<Button>().interactable = false;

            }
        }
	}
    //envia o texto do botao para o controlador do jogo
    public void SendText()
    {
        gc.GetComponent<GameController>().ReceiveText(GetComponentInChildren<Text>().text);
    }
    public void RecieveText(string text)
    {
            GetComponentInChildren<Text>().text = text;
            hasNumber = true;
    }
}

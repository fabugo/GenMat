using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    private string[] op;
    private int count;
    private int newBtvalue;
    // Use this for initialization
    void Start ()
    {
        count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (count)
        {
            case 0:
                Debug.Log("Desabilitar Operandos");
                Debug.Log("Habilitar Numeros");
                break;
            case 1:
                Debug.Log("Habilitar Operandos");
                Debug.Log("Desabilitar Numeros");
                break;
            case 2:
                Debug.Log("Desabilitar Operandos");
                Debug.Log("Habilitar Numeros");
                break;
            case 3:
                efetuarOp();
                break;
        }
	}

    public void receberTex(string tex)
    {
        if(count < 3)
        {
            op [count] = tex;
            count++;
        }
    }
    private void efetuarOp()
    {
        if (op[1] == "+")
        {
            newBtvalue = int.Parse(op[0]) + int.Parse(op[2]);
        }
        if (op[1] == "-")
        {
            newBtvalue = int.Parse(op[0]) + int.Parse(op[2]);
        }
        if (op[1] == "x")
        {
            newBtvalue = int.Parse(op[0]) + int.Parse(op[2]);
        }
        if (op[1] == "/")
        {
            newBtvalue = int.Parse(op[0]) + int.Parse(op[2]);
        }
    }
}

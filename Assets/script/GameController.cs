using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameController : MonoBehaviour {
    public int  scale,
                numberInit,                             //Numero que a fase se inicia
                goal;                                   //Numero de objetivo do jogador
    private int sumBoard,                               //Soma de todos os valores do quadro, caso seja igual ao objetivo o jogador ganha
                state,                                  //Inteiro q habilita os botoes especificos
                limit;                                  //Numero limite de movimentos
    private string[] equation;                          //String que recebe valores dos textos dos botoes, formando uma equacao
    // Use this for initialization
    void Start ()
    {
        equation = new string[4] { "0", "0", "0", " "};
        state = 10;
        sumBoard = numberInit;
        limit = (scale*scale)-1;
    }
	// Update is called once per frame
	void Update ()
    {
        if (state == 13)
        {
            int tempInt = ExecuteOp();
            Debug.Log(tempInt);
            if (tempInt == -1)
            {
                state--;
            }
            else
            {
                state = 10;
            }
            sumBoard = sumBoard + tempInt;
            equation [3] = "" + tempInt;
            NewText();
            Debug.Log(state);
        }
        if (sumBoard == goal)
        {
            Debug.Log("Win");
        }
        if (limit == 0)
        {
            Debug.Log("Lose");
        }
    }
    //Recebe um texto enviado por um botao, e altera os estados e a equacao
    public void ReceiveText(string text)
    {
        Debug.Log("Recebendo texto de algum botao: " + text);
        Debug.Log(state);
        switch (state)
        {
            case 10://bloqueia os operandos e libera os numeros
                equation[0] = text;
                state++;
                Debug.Log(state);
                break;
            case 11://bloqueia os numeros e libera os operandos
                equation[1] = text;
                state++;
                Debug.Log(state);
                break;
            case 12://bloqueia os operandos e libera os numeros
                equation[2] = text;
                state++;
                Debug.Log(state);
                break;
        }
            
    }
    //Desfaz o array de strings enviadas pelos botoes e realiza a equacao retornando o valor
    private int ExecuteOp()
    {
        Debug.Log("Calculando equacao: " + equation[0] + equation[1] + equation[2]);
        switch (equation[1])
        {
            case "+":
                return int.Parse(equation[0]) + int.Parse(equation[2]);
            case "-":
                return int.Parse(equation[0]) - int.Parse(equation[2]);
            case "x":
                return int.Parse(equation[0]) * int.Parse(equation[2]);
            case "/":
                if (equation[2] == "0")
                    return 0;
                return int.Parse(equation[0]) / int.Parse(equation[2]);
        }
        return -1;
    }
    public int getSum()
    {
        return sumBoard;
    }
    public int getState()
    {
        return state;
    }
    public int getLimit()
    {
        return limit;
    }
    public int getGoal()
    {
        return goal;
    }
    private void NewText()
    {
        System.Random rnd = new System.Random();
        int auxRnd = rnd.Next();
        string tag = "" + auxRnd % 8;
        Debug.Log(tag);
        GameObject auxObj = GameObject.FindGameObjectWithTag(tag);
        auxObj.GetComponentInChildren<ControlButton>().RecieveText(equation[3]);
        limit--;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameController : MonoBehaviour {
    public int          scale,              //indica a escala do tabuleiro
                        numberInit,         //numero que inicia no jogo
                        timeMaxBonus;       //maximo de time para ganhar bonus
    private double      sumBoard;           //soma de todos os valores no quadro
    private int         state,              //estado atual dos clicks
                        limit,              //limite de espaços usado para condição de derrota
                        indexRands,         //index para navegar no vetor em posição gerada
                        indexWin,           //index para navegar no board e comparar com o objetivo
                        gg,                 //indica que o jogo acabou
                        score;              //score final da partida
    public double       goal;               //valor de objetivo do jogo
    private string[]    equation;           //string q forma a equacao dos valores dos botoes
    public int[]        rands;              //posicoes aleatorias do quadro
    //inicializacao dos valores
    void Start ()
    {
        score = 0;
        gg = 0;
        indexRands = 0;
        rands = new int[8] {8,8,8,8,8,8,8,8};
        equation = new string[4] { "0", "0", "0", " "};
        state = 10;
        sumBoard = numberInit;
        limit = (scale*scale)-1;
    }
	//atualizado em cada frame
	void Update ()
    {
        if (goal.ToString().Length <= sumBoard.ToString().Length)
        {
            int i = 0;
            for(indexWin = sumBoard.ToString().Length - goal.ToString().Length ; indexWin < sumBoard.ToString().Length ; indexWin++)
            {
                if(sumBoard.ToString()[indexWin] == goal.ToString()[i])
                    gg++;
                if (gg == goal.ToString().Length)
                {
                    genScore();
                    Application.LoadLevel("map");
                }
                else if (limit == 0)
                    Application.LoadLevel("map");
                i++;
            }
            gg = 0;
        }
        if (state == 13)
        {
            double tempInt = ExecuteOp();
            if (tempInt == -1.23456789f)
                state--;
            else
                state = 10;
            sumBoard = sumBoard + tempInt;
            equation [3] = "" + tempInt;
            NewText();
        }
    }
    //Recebe um texto enviado por um botao, e altera os estados e a equacao
    public void ReceiveText(string text)
    {
        switch (state)
        {
            case 10://bloqueia os operandos e libera os numeros
                equation[0] = text;
                state++;
                break;
            case 11://bloqueia os numeros e libera os operandos
                equation[1] = text;
                state++;
                break;
            case 12://bloqueia os operandos e libera os numeros
                equation[2] = text;
                state++;
                break;
        }
            
    }
    //Desfaz o array de strings enviadas pelos botoes e realiza a equacao retornando o valor
    private double ExecuteOp()
    {
        Debug.Log("Calculando equacao: " + equation[0] + equation[1] + equation[2]);
        switch (equation[1])
        {
            case "+":
                score = score + 1;
                return double.Parse(equation[0]) + double.Parse(equation[2]);
            case "-":
                score = score + 2;
                return double.Parse(equation[0]) - double.Parse(equation[2]);
            case "x":
                score = score + 3;
                return double.Parse(equation[0]) * double.Parse(equation[2]);
            case "/":
                score = score + 4;
                if (equation[2] == "0")
                    limit = 1;
                return double.Parse(equation[0]) / double.Parse(equation[2]);
        }
        return -1.23456789f;
    }
    //cria novo texto para um botao aleatorio
    private void NewText()
    {
        System.Random rnd = new System.Random();
        int auxRnd = rnd.Next() % 8;
        while (ExistInRands(auxRnd))
        {
            auxRnd = rnd.Next() % 8;
        }
        string tag = "" + auxRnd;
        GameObject auxObj = GameObject.FindGameObjectWithTag(tag);
        auxObj.GetComponentInChildren<ControlButton>().RecieveText(equation[3]);
        limit--;
    }
    //verifica se o valor aleatorio é um local ja ocupado
    private bool ExistInRands(int auxRnd)
    {
        for (int i = 0; i < rands.Length; i++)
        {
            if (rands[i] == auxRnd)
                return true;
        }
        rands[indexRands] = auxRnd;
        indexRands++;
        return false;
    }
    //geracalculo de score final
    private void genScore()
    {
        score = score * limit;
        if (sumBoard.ToString().Contains("."))
            score = score + 10;
        if (sumBoard == goal)
            score = score - 5;
        if (Time.time < timeMaxBonus)
            score = score + 15;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }
    //getters para variaveis privadas acessadas de fora
    public double getSum()
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
    public double getGoal()
    {
        return goal;
    }
}

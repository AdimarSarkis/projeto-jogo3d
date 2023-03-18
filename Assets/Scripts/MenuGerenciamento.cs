using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGerenciamento : MonoBehaviour
{
    [SerializeField] private string nomeFase;

    public void CarregarCena(string nomeFase){
        SceneManager.LoadScene(nomeFase);
    }
    
    public void SairJogo(){
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_jogo : MonoBehaviour
{
    private static GameObject txtPlacar;
    private bool pausado = false;
    private static int placar;
    public void iniciar()
    {
        //Carrega a cena de indice 1 - configurada em build settings
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("coins", 0);
        txtPlacar = GameObject.Find("txtFinal");
        placar = PlayerPrefs.GetInt("coins");
    }

    public void sair()
    {
        //funciona apenas quando ja tem o executável
        Application.Quit();
    }

    private void verificaPausa()
    {
        //verificando se apertou ESC
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pausado)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            }
            else
            {
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
                Time.timeScale = 0;
            }
            pausado = !pausado;
        }
    }

    private void placarGameOver()
    {
        placar = script_respawn_placar.retornaPlacar();
        PlayerPrefs.SetInt("coins", placar);
        txtPlacar.GetComponent<Text>().text = "Coins Coletadas: " + placar;
    }

    void Update()
    {
        verificaPausa();
        placarGameOver();
    }
}

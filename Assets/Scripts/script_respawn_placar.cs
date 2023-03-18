using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_respawn_placar : MonoBehaviour
{
    private static GameObject txtPlacar;
    private static int placar;
    private static int vidas = 3;
    private static int auxiliar = 0;
    public GameObject coin;
    public GameObject[] respawnPoints = new GameObject[72];
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("coins", 0);
        txtPlacar = GameObject.Find("txtCoins");
        placar = PlayerPrefs.GetInt("coins");
        respawnCoins();
    }

    void respawnCoins()
    {
        int i;
        for(i = 0; i < respawnPoints.Length; i++)
        {
            Instantiate(coin, respawnPoints[i].transform.position, Quaternion.identity);
        }

    }

    public static void incrementarPlacar(int inc)
    {
        placar = placar + inc;
        auxiliar = auxiliar + inc;

        PlayerPrefs.SetInt("coins", placar);
        txtPlacar.GetComponent<Text>().text = "Coins: " + placar + "	       Vidas: " + vidas;
    }

    public static void setVidas(int vida)
    {
        vidas = vida;

        PlayerPrefs.SetInt("coins", placar);
        txtPlacar.GetComponent<Text>().text = "Coins: " + placar + "	       Vidas: " + vidas;
    }

    public static int retornaPlacar()
    {
        return placar;
    }

    private void verificaQtdCoins()
    {
        if (auxiliar == respawnPoints.Length)
        {
            auxiliar = 0;
            respawnCoins();
        }
    }
    // Update is called once per frame
    void Update()
    {
        verificaQtdCoins();
    }
}

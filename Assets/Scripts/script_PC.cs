using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_PC : MonoBehaviour
{
    private Rigidbody rbd;
    public float velocidade = 4;
    public float velRot = 80;
    private Quaternion rotOriginal;
    private float rotMouseX = 0;
    private int rotTeclado = 0;
    private int vidas = 3;
    public GameObject respawnPoints;
    [SerializeField] GameObject palyer;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rbd = GetComponent<Rigidbody>();
        rotOriginal = transform.localRotation;
    }

    private void OnTriggerEnter(Collider col)
    {
        //coletando as coins
        if (col.gameObject.layer == LayerMask.NameToLayer("moeda"))
        {
            Destroy(col.gameObject);
            script_respawn_placar.incrementarPlacar(1);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        //colisao com NPC
        if (col.gameObject.layer == LayerMask.NameToLayer("inimigo"))
        {
            vidas--;
            script_respawn_placar.setVidas(vidas);
            if (vidas > 0)
            {
                RespawnPoint();
            }
            else
            {
                script_respawn_placar.setVidas(3);
                Destroy(this.gameObject);
                SceneManager.LoadScene(2);
                Time.timeScale = 1;
            }
        }
    }

    private void verificaMovimentacao()
    {
        float moveLado = Input.GetAxis("Horizontal");
        float moveFrente = Input.GetAxis("Vertical");

        Vector3 vel = transform.TransformDirection(new Vector3(moveLado * velocidade,
                                                                rbd.velocity.y,
                                                                moveFrente * velocidade));

        rotMouseX += Input.GetAxis("Mouse X");

        rbd.velocity = vel;

        if (Input.GetKey(KeyCode.Q))
        {
            rotTeclado -= 1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotTeclado += 1;
        }

        Quaternion lado = Quaternion.AngleAxis(rotMouseX + rotTeclado, Vector3.up);
        transform.localRotation = rotOriginal * lado;
    }

    // Update is called once per frame
    void Update()
    {
        verificaMovimentacao();
    }

    void RespawnPoint(){
        transform.position = spawnPoint.position;
    }
}

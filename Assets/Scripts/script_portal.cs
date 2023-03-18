using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        //Verifica a distancia do portal e joga o PC ele pro outro lado do mapa
        if (col.gameObject.layer == LayerMask.NameToLayer("pc"))
        {
            float x = col.transform.position.x;
            if (x < 0)
            {
                x += 1;
            }
            else
            {
                x -= 1;
            }
            col.transform.position = new Vector3(-x, col.transform.position.y, col.transform.position.z);
        }
    }
}

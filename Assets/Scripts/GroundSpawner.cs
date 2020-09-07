using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    
    void OnBecameInvisible(){
        transform.position += new Vector3(60,0,0);
    }
}

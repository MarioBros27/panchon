using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour
{
    private GameObject player;
    public GameObject jorge;
    public GameObject jorgeLeft;
    public float minTime;
    public float maxTime;

    public float minDistance;
    public float maxDistance;

    private float spawnTime;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        time = 0;

    }
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            spawnJorge();
            setRandomTime();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    void setRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);

    }
    void spawnJorge()
    {
        time = 0;
        int directionRandom = Random.Range(1, 10);
        //float direction = directionRandom > 5 ? 1f : -1f;
        float randomRange = Random.Range(minDistance, maxDistance);

        Transform me = player.GetComponent<Transform>();

        if (directionRandom > 3)
        {
            //Spawn to the right
            GameObject jorgito = (GameObject)Instantiate(jorge, new Vector3(me.position.x + randomRange, -1.9f, 0f), Quaternion.identity);

        }
        else
        {
            //spawn to the left
            GameObject jorgito = (GameObject)Instantiate(jorgeLeft, new Vector3(me.position.x - randomRange, -1.9f, 0f), Quaternion.identity);

            Transform transform = jorgito.GetComponent<Transform>();
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }



    }
}

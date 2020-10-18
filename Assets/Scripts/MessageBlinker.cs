using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBlinker : MonoBehaviour
{

    private float blinkTime = 0.5f;
    private float time;
    bool flag = true;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= blinkTime)
        {
            if (flag)
            {
                text.SetActive(false);
                flag = false;
            }
            else
            {
                text.SetActive(true);
                flag = true;
            }
                time = 0;
        }

    }
}

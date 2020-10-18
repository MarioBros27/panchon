using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image fill;
    [SerializeField]
    private GameObject factory;
    [SerializeField]
    public GameObject pancho;
    private float factoryPosition;
    private float panchoStartingPosition;
    private float totalDistance;
    void Start()
    {
        factoryPosition = factory.transform.position.x;
        panchoStartingPosition = pancho.transform.position.x;
        totalDistance = factoryPosition-panchoStartingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float currentPosition = pancho.transform.position.x;
        float distanceWalked = currentPosition-panchoStartingPosition;
        float fillA = fill.fillAmount;
        float percentageWalked = distanceWalked/totalDistance;
        if(fillA!=percentageWalked && percentageWalked>0){
            fill.fillAmount = percentageWalked;
        }
        if(factoryPosition-currentPosition<1){
            SceneManager.LoadScene("Start");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GPS : MonoBehaviour
{
    public float longitue;
    public float latitude;

    public TextMeshProUGUI longitudeText;
    public TextMeshProUGUI latitudeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("No dice");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed Out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("No Location Found");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitue = Input.location.lastData.longitude;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        longitudeText.text = longitue.ToString();
        latitudeText.text = latitude.ToString();
    }
}

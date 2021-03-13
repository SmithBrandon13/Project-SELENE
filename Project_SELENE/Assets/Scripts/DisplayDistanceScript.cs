using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDistanceScript : MonoBehaviour
{
    private Transform userPos;

    private float distance;

    public TextMeshPro distText;

    // Start is called before the first frame update
    void Start()
    {
        userPos = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(userPos.position, transform.position);
        int dist = Mathf.RoundToInt(distance);
        distText.text = dist.ToString() + "m";
        //print(dist);
    }

    public void SetPosition()
    {
        transform.position = userPos.position;
    }
}
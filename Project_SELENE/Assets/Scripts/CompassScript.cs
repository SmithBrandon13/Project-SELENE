using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    public RawImage compassVisual;
    public Transform user;

    float compassUnit; 

    // Start is called before the first frame update
    void Start()
    {
        compassUnit = compassVisual.rectTransform.rect.width / 360f;
    }

    // Update is called once per frame
    void Update()
    {
        compassVisual.uvRect = new Rect(user.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}

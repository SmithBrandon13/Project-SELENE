using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

public class MarkerController : MonoBehaviour
{
    public GameObject markerPrefab;

    public Transform user;

    WorldAnchorStore store;

    // Start is called before the first frame update
    void Start()
    {
        WorldAnchorStore.GetAsync(StoreLoaded);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetMarker();
        }
    }

    public void SetMarker()
    {
        var newMarker = Instantiate(markerPrefab, user.transform.position, Quaternion.identity);
        newMarker.transform.parent = GameObject.Find("MarkerController").transform;
    }

    private void StoreLoaded(WorldAnchorStore store)
    {
        this.store = store;
    }
}

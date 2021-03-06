﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;
using UnityEngine.XR.WSA;

public class MarkerController : MonoBehaviour
{
    public GameObject markerPrefab;

    public Transform user;

    public Transform worldSpaceGO;

    WorldAnchorStore store;

    WorldAnchor anchor;

    // Start is called before the first frame update
    // Tells the store to start itself.
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
            //Runs the function.
        }
    }

   //Sets a marker at the position of the user and passes real world info
    public void SetMarker()
    {
        var newMarker = Instantiate(markerPrefab, user.transform.position, Quaternion.identity);
        newMarker.transform.parent = worldSpaceGO;
        newMarker.name = newMarker.name + transform.position.ToString();

        var newMarkerWA = newMarker.GetComponent<WorldAnchor>();

        SaveGame(newMarker.name, newMarkerWA);
        //Saves spatial anchor HoloLens
    }

    public void SetMarkerFromLoad(WorldAnchor thisAcnor)
    {

    }

    private void StoreLoaded(WorldAnchorStore store)
    {
        this.store = store;
        
        LoadDataFromWorldStore();
        //if this is ready, then we need to load all the data that we had before
    }

    private void SaveGame(string id, WorldAnchor thisWorldAnchor)
    {
        store.Save(id, thisWorldAnchor);
    }

    public void LoadDataFromWorldStore()
    {
        var currentStores = store.GetAllIds();

        //Grab all markers in scene to be loaded and saved
        for(int i = 0; i < currentStores.Length; i++)
        {
            var loadedMarker = store.Load(currentStores[i], worldSpaceGO.gameObject).gameObject;
            Instantiate(markerPrefab, loadedMarker.transform.position, Quaternion.identity);
        }

        
    }
}
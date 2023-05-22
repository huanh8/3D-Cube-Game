using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//click this gameobject to switch camera by change the property of camera1
public class CameraSwitch : MonoBehaviour
{
    // get cinemachine virtual camera
    [SerializeField]private Camera _mainCamera;
    [SerializeField]private Cinemachine.CinemachineVirtualCamera _mapCamera;
    [SerializeField]private Cinemachine.CinemachineVirtualCamera _followCamera;
    [SerializeField]private GameObject _spawnPoint;
    [SerializeField]private GameObject _ship;


    // Update is called once per frame
    void Start()
    {   //get spawn point from its children
        _spawnPoint =  transform.GetChild(0).gameObject;
        _mainCamera = Camera.main;
        _mapCamera = GameObject.Find("MapCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        _followCamera = GameObject.Find("FollowCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        _ship = GameObject.Find("Submarine");
    }

    void Update()
    {
        SwitchCamera();
    }

    private void SwitchCamera()
    {
        if (_mapCamera == null)
        {
            Debug.Log("Map camera is null");
            return;
        }
        
        // click this gameObject to switch camera by change the property of camera1
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                if (hit.collider.gameObject == this.gameObject)
                {
                    SwitchToFollow();
                }
        
            }
        }
  
        //if we press ESC key to switch to map camera
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToMap();
        }
    }

    private void SwitchToMap()
    {
        if (!_mapCamera.enabled)
        {
            _mapCamera.enabled = true;
            _mapCamera.Priority = 1;
            _followCamera.Priority = 0;
        }
    }

    private void SwitchToFollow()
    {
        if (_mapCamera.enabled)
        {
            _mapCamera.Priority = 0;
            _followCamera.Priority = 1;
            _mapCamera.enabled = false;
            SpawnShip();
        }
    }

    private void SpawnShip()
    {
        if (_spawnPoint == null)
        {
            Debug.Log("Spawn point is null");
            return;
        }
        //spawn ship at spawn point
        if (_ship == null)
        {
            Debug.Log("Ship is null");
            return;
        }
        _ship.transform.position = _spawnPoint.transform.position;
    }

}

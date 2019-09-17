using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {



	public PlayerController player;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

	private int playerSkin;
	
    // Use this for initialization
    void Start () {

	//	checkForCorrectCameraTarget ();

	
        lastPlayerPosition = player.transform.position;
    }
	
    // Update is called once per frame
    void Update () {
        
	//	checkForCorrectCameraTarget ();

	
        distanceToMove = player.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = player.transform.position;

    }

}
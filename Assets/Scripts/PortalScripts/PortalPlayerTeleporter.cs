//Written by Marnix Licht - Last Updated 21/05/19

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPlayerTeleporter : MonoBehaviour
{
    //Portal Data
    public GameObject PortalOut;
    private GameObject PortalIn;
    private GameObject localPortalMarker;
    private bool playerIsOverlapping = false;

    //StencilBuffer Data
    public Transform Level;
    public GameObject LevelPrefab;
    public int maxPortalDepth = 1;
    private GameObject localLevelMarker;
    //private List<GameObject> PortalDepthList = new List<GameObject>();

    //Player Data
    private GameObject player;
    private GameObject playerCamera;
    private GameObject velocityMarker;

    //Player TeleportTarget
    private Transform bodyCam;
    private Vector3 velocityOut;
          
    void Start()
    {
        //Find some game objects
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("MainCamera");
        bodyCam = PortalOut.transform.Find("CamBodyOther Layer 0").transform;
        PortalIn = transform.parent.gameObject;

        //Create Markers
        velocityMarker = new GameObject("velocityMarker");
        localPortalMarker = new GameObject("localPortalMarker");
        localLevelMarker = new GameObject("localLevelMarker");

        //Set LevelDepths
        localLevelMarker.transform.position = Level.position;
        localLevelMarker.transform.rotation = Level.rotation;

        for (int i = 0; i < maxPortalDepth; i++)
        {
            string nextLevelMarkerString = "localLevelMarker[" + i + "]";
            localLevelMarker = new GameObject(nextLevelMarkerString);
            Instantiate(LevelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }


    }


    // Update is called once per frame
    void Update()
    {
        //Set portalmarker as child
        localPortalMarker.transform.position = PortalOut.transform.position;
        localPortalMarker.transform.rotation = PortalOut.transform.rotation;

        localLevelMarker.transform.position = Level.position;
        localLevelMarker.transform.rotation = Level.rotation;

        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = playerCamera.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0)
            {
                //Get rotation
                Quaternion rotation = Quaternion.Euler(bodyCam.eulerAngles);                

                //Teleport velocity
                velocityMarker.transform.SetParent(PortalIn.transform);
                velocityMarker.transform.position = PortalIn.transform.position + player.GetComponent<Rigidbody>().velocity;
                Vector3 localVelocityIn = velocityMarker.transform.localPosition;
                velocityMarker.transform.SetParent(PortalOut.transform);
                velocityMarker.transform.localPosition = new Vector3 (-localVelocityIn.x, localVelocityIn.y, -localVelocityIn.z);
                Vector3 velocityOut = velocityMarker.transform.position - PortalOut.transform.position;
                
                //Teleport him!
                player.GetComponent<FirstPersonAIO>().portalRotation(rotation, velocityOut);
                player.transform.position = bodyCam.position;

                playerIsOverlapping = false;

                Debug.Log("teleported");

            }
        }
    }    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            playerIsOverlapping = false;
        }
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoving : MonoBehaviour
{
    [SerializeField] private List<GameObject> mapObjs;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.transform.position.x > 10)
        {
            if (camera.transform.position.x < 0)
            {
                mapObjs[2].transform.position = new Vector3(-10f, -10f, 0f);
                mapObjs[3].transform.position = new Vector3(-10f, 10f, 0f);
            }
            MapMoveRight();
            
        }
        else if(camera.transform.position.x < -10)
        {
            if (camera.transform.position.x < 0)
            {
                mapObjs[2].transform.position = new Vector3(-10f, -10f, 0f);
                mapObjs[3].transform.position = new Vector3(-10f, 10f, 0f);
            }
            MapMoveLeft();
        }
        else if(camera.transform.position.y > 10)
        {
            MapMoveUp();
        }
        else if(camera.transform.position.y < -10)
        {
            MapMoveDown();
        }
    }

    void MapMoveLeft()
    {        
        mapObjs[0].transform.position = new Vector3(mapObjs[3].transform.position.x - 20, mapObjs[3].transform.position.y, 0f);
        mapObjs[1].transform.position = new Vector3(mapObjs[2].transform.position.x - 20, mapObjs[2].transform.position.y, 0f);
    }

    void MapMoveRight()
    {
        mapObjs[2].transform.position = new Vector3(mapObjs[1].transform.position.x + 20, mapObjs[1].transform.position.y, 0f);
        mapObjs[3].transform.position = new Vector3(mapObjs[0].transform.position.x + 20, mapObjs[0].transform.position.y, 0f);        
    }

    void MapMoveUp()
    {
        mapObjs[1].transform.position = new Vector3(mapObjs[0].transform.position.x, mapObjs[0].transform.position.y + 20, 0f);
        mapObjs[2].transform.position = new Vector3(mapObjs[3].transform.position.x, mapObjs[3].transform.position.y + 20, 0f);
    }

    void MapMoveDown()
    {
        mapObjs[0].transform.position = new Vector3(mapObjs[1].transform.position.x, mapObjs[1].transform.position.y - 20, 0f);
        mapObjs[3].transform.position = new Vector3(mapObjs[2].transform.position.x, mapObjs[2].transform.position.y - 20, 0f);
    }
}

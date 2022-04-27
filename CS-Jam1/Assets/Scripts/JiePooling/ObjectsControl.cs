using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsControl : MonoBehaviour
{
    [SerializeField]
    private GameObject glimmWimmPrefab;

    // queue which holds reference to all the gameObjects
    [SerializeField]
    List<GameObject> glimmWimmPool = new List<GameObject>();

    // optional parameter, which helps to preload the object pool
    [SerializeField]
    private int poolStartSize = 5;
    private int poolMaxSize = 5;

    private float timeToSpawn = 5f;
    private float timeSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= timeToSpawn)
        {
            GameObject glimmWimm = Instantiate(glimmWimmPrefab);
            glimmWimm.transform.position = this.transform.position;
            timeSinceSpawn = 0f;
        }
    }
}

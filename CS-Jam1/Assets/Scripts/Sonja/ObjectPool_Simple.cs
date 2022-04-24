using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Simple : MonoBehaviour
{
    // prefab that's goona be pooled
    [SerializeField]
    private GameObject glimmWimmPrefab;

    // queue which holds reference to all the gameObjects
    [SerializeField]
    Queue<GameObject> glimmWimm = new Queue<GameObject>();

    // optional parameter, which helps to preload the object pool
    private int poolStartSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

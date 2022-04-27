using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUI : MonoBehaviour
{
    [SerializeField] private Rigidbody targetRb;
    [SerializeField] GameManager gameManagerTEST;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -6f;
    private float zRange = 0;

    public bool isGameActive;

    public int pointValue; // must be aligned with Elias typing!!

    private void Awake()
    {
        isGameActive = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); // get GlimmWimm
        gameManagerTEST = GameObject.Find("GameMangerTEST").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse); // add upwards force
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // apply rotation on objects, might not be needed
        transform.position = RandomSpawnPos(); // spawn GlimmWimms

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameManagerTEST)
        {
            Destroy(gameObject);
            // gameManagerTEST.UpdateScore(pointValue);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);         
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, zRange);
    }
}

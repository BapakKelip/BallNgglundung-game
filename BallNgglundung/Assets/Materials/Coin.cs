using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int score = 1;
    [SerializeField] private Vector3 rotateDelta;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateDelta);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager manager = FindObjectOfType<GameManager>();
            if (manager)
                manager.Score += score;
            Destroy(gameObject);
            
        }
                
    }

}

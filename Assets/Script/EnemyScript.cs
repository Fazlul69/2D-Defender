using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Transform[] wayPoints;
    public Transform ExitPoint;
    public int target;
    public float navigationTime;
    // Start is called before the first frame update
    void Start()
    {
        target = 0;
        navigationTime = 0;
}

// Update is called once per frame
void Update()
    {
    if (wayPoints.Length > target) {
            navigationTime = Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,wayPoints[target].position, navigationTime);
    }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "CheckPoint") {
            Debug.Log("Trigger");
            target += 1;
        }
        if (col.gameObject.tag == "ExitPoint")
        {
            Destroy(gameObject);
        }
    }
}

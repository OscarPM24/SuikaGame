using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nube : MonoBehaviour
{
    public Transform[] fruta;
    static public string spawned = "n"; 
    static public string fusioned = "n";
    static public Vector2 posNube;
    static public Vector2 posColision;
    static public int tagFrutaFusion; 
    static public string gameOver = "n";
    static public int colisiones = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameOver == "n") {
            spawnFruta();
            fusionFruta();

            if (Input.GetKey("a")) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0); 
            }

            if (Input.GetKey("d")) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            }

            if ((!Input.GetKey("d")) && (!Input.GetKey("a"))) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            if (((GetComponent<Rigidbody2D>().velocity.x < 0) && (transform.position.x < -7.5)) || ((GetComponent<Rigidbody2D>().velocity.x > 0) && (transform.position.x > 3.5))) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            posNube = transform.position;
        } else GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void spawnFruta() {
        if (spawned=="n") {
            StartCoroutine(spawnTimer());
            spawned = "y";
        }
    }

    void fusionFruta() {
        if (fusioned=="y") {
            fusioned = "n";

            Instantiate(fruta[tagFrutaFusion + 1], posColision, fruta[0].rotation);
        }
    }

    IEnumerator spawnTimer() {
        yield return new WaitForSeconds(.5f);
        Instantiate(fruta[Random.Range(0, 5)], transform.position, fruta[0].rotation);
    }
}

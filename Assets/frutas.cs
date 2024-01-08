using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class frutas : MonoBehaviour
{

    private string enNube = "y";
    private string fueraLimite = "n";

    void Start()
    {
        if (transform.position.y < 3.5) {
            enNube = "n";
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }

    void Update()
    {
        if (enNube=="y") GetComponent<Transform>().position = nube.posNube;

        if (Input.GetKeyDown("space") && enNube == "y") {
            GetComponent<Rigidbody2D>().gravityScale = 2;
            enNube = "n";
            nube.spawned = "n";
            StartCoroutine(checkFueraLimite());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == gameObject.tag) {
            nube.colisiones += 1;
            Debug.Log(nube.colisiones);
            if (int.Parse(gameObject.tag) == 10) {
                Destroy(gameObject);
            } else if (nube.colisiones < 3) {
                nube.posColision = transform.position;
                nube.fusioned = "y";
                nube.tagFrutaFusion = int.Parse(gameObject.tag);
                Destroy(gameObject);
            }

                nube.colisiones = 0;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if ((collider.gameObject.name == "limite") && (fueraLimite == "y")) {
            nube.gameOver = "y";
        }
    }

    IEnumerator checkFueraLimite() {
        yield return new WaitForSeconds(1f);
        fueraLimite = "y";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleInimigo : MonoBehaviour
{
    private Rigidbody2D rig;
    private float mov = 1F;
    public GameObject sons;
    private int lives = 10;
    public Text txtLives;

    

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        txtLives.text = ""+lives;
    }
    void Update()  {
        if (mov>0) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (mov<0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        rig.velocity = new Vector2(mov, rig.velocity.y);
    }
  

      void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            if (col.gameObject.transform.position.y > gameObject.transform.position.y+1) {
                sons.GetComponents<AudioSource>()[2].Play();
                Destroy(gameObject);
            } else {
                sons.GetComponents<AudioSource>()[1].Play();

                if(lives > 0){
                    lives--;
                    txtLives.text = ""+lives;
                }
                else{
                    Destroy(col.gameObject);
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Single);


                }

                
            }
        } else if (col.gameObject.tag == "Fire") {
            sons.GetComponents<AudioSource>()[2].Play();
            Destroy(gameObject);
        } else {
            mov = mov * -1;
        }


    }
}
    
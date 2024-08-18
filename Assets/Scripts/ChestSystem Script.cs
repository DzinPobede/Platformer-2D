using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystemScript : MonoBehaviour
{
    public Animator animator;
    private bool isPlayerNear = false;
    private bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyDown(KeyCode.E))
        {
            animator.Play("Chest opening");
            isOpened = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            isPlayerNear = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isPlayerNear = false;
        }
    }
}

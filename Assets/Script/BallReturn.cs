using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour {

    private BallLauncher ballLauncher;
    private int returnCount = 0;

    private void Awake()
    {
        ballLauncher = FindObjectOfType<BallLauncher>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Block")
        {
            Debug.Log("End");
        }
        else
        {
            returnCount++;

            if (returnCount == ballLauncher.balls.Count)
            {
                ballLauncher.isLaunch = false;
                returnCount = 0;
            }
            ballLauncher.ReturnBall();
            ballLauncher.transform.position = new Vector3(collision.collider.gameObject.transform.position.x, -4.5f, 0);
            collision.collider.gameObject.SetActive(false);
        }
    }
}

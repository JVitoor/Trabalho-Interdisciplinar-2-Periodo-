using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [Header("Controllers")]
    private GameManager gameManager;
    private LogController logController;
    public PlayerController playerController;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //logController = new LogController();
    }

    [System.Obsolete]
    // Player colidindo com obstáculo
    private void OnTriggerEnter(Collider other)
    {      
        if (other.CompareTag(Tags.Obstacle.ToString()))
        {
            //logController.PlayerHitObstacle();
            gameManager.GameOver();
        }

        if (other.CompareTag(Tags.PowerUp.ToString()))
        {
            playerController.DoubleSpeed();
            Destroy(other.gameObject);
            AudioController.instance.TocarSFX(1);
            //logController.PlayerHitObstacle();

        }
    }
}

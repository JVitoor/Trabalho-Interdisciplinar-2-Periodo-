using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PlayerController playerController;

    public void DoubleSpeed()
    {
        playerController.DoubleSpeed();
    }
    

}

using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Vari�veis

    [Header("Camera")]
        public float moveSpeed = 10;
    
    [Header("Street")]
        public Transform player;    // Refer�ncia ao transform do jogador
        public Vector3 offset;      // Dist�ncia da c�mera em rela��o ao jogador
        public float smoothSpeed = 0.05f;  // DEFAULT: 0.125 // Velocidade de suaviza��o 

    #endregion

    #region M�todos

    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Posi��o desejada da c�mera com base na posi��o do jogador e o offset
        Vector3 desiredPosition = player.position + offset;

        // Movimenta a c�mera suavemente para a posi��o desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posi��o da c�mera
        transform.position = smoothedPosition;

        // C�mera sempre olhe para o jogador
        //transform.LookAt(player);
    }

    #endregion

}
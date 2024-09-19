using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variáveis

    [Header("Camera")]
        public float moveSpeed = 10;
    
    [Header("Street")]
        public Transform player;    // Referência ao transform do jogador
        public Vector3 offset;      // Distância da câmera em relação ao jogador
        public float smoothSpeed = 0.05f;  // DEFAULT: 0.125 // Velocidade de suavização 

    #endregion

    #region Métodos

    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Posição desejada da câmera com base na posição do jogador e o offset
        Vector3 desiredPosition = player.position + offset;

        // Movimenta a câmera suavemente para a posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;

        // Câmera sempre olhe para o jogador
        //transform.LookAt(player);
    }

    #endregion

}
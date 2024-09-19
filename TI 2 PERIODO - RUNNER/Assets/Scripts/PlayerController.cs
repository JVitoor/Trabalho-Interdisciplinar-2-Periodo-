using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Vari�veis

    [Header("Player")]
        private float moveSpeed = 10f;          // Velocidade do personagem
        private int points = 0;

    [Header("Street")]
        private float streetDistance = 5f;          // Dist�ncia entre as ruas (eixo X)
        private float streetSwitchSpeed = 10f;      // Velocidade de mudan�a de rua
        private int desiredStreet = 1;              // 0 = Esquerda, 1 = Centro, 2 = Direita

    [Header("Canvas Elements")]
        public Text pointsText;
        public float pointIncreaseInterval = 1f;    // Intervalo em segundos para aumentar os pontos
        private float timeSinceLastPoint = 0f;      // Contador de tempo
   
    #endregion

    #region M�todos

    private void Update()
    {
        // Movimenta��o do jogador

            MoveFoward();

            timeSinceLastPoint += Time.deltaTime * moveSpeed; // Incrementa o tempo com o deltaTime e a velocidade do jogador

            // Verifica se o intervalo definido foi atingido
            if (timeSinceLastPoint >= pointIncreaseInterval)
            {
                IncreasePoints();       // Aumenta pontua��o do jogador
                timeSinceLastPoint = 0f;  // Reinicia o contador de tempo
            }
    }

    private void MoveFoward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);    
    }
    public void DoubleSpeed()
    {
        moveSpeed *= 2;
    }

    public void Move(Vector2 swipeDirection)
    {
        // Captura de inputs para mudan�a de faixa
        Debug.Log($"Swipe direction: {swipeDirection.x}");

        AudioController.instance.TocarSFX(2);

        // Determina a pista com base no swipe (esquerda ou direita)
        if (swipeDirection.x < 0)
        {
            // Move para a faixa � esquerda (m�nimo 0)
            if (desiredStreet > 0)
            {
                desiredStreet--;
            }
        }

        if (swipeDirection.x > 0)
        {
            // Move para a faixa � direita (m�ximo 2)
            if (desiredStreet < 2)
            {
                desiredStreet++;
            }
        }

        // Calcula a posi��o alvo no eixo X com base na faixa desejada
        Vector3 targetPosition = transform.position.z * Vector3.forward;

        switch (desiredStreet)
        {
            case 0:
                targetPosition.x = -5;  // Faixa da esquerda
                break;
            case 1:
                targetPosition.x = 0;   // Faixa do meio
                break;
            case 2:
                targetPosition.x = 5;   // Faixa da direita
                break;
        }

        targetPosition.y = transform.position.y;  // Mant�m a posi��o Y atual

        // Movimenta o personagem instantaneamente ou suavemente para a posi��o da faixa desejada
        this.transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);

        // Se quiser movimento instant�neo, substitua a linha acima por:
        // this.transform.position = targetPosition;
    }

    private void IncreasePoints()
    {
        points++;       
        UpdateInterface();
    }

    private void UpdateInterface()
    {
        // Altera a interface atualizando a pontua��o do jogador
        pointsText.text = points.ToString();
    }

    #endregion
}

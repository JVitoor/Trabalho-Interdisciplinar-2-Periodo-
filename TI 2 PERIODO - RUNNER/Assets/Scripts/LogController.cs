using UnityEngine;

public class LogController : MonoBehaviour
{
    #region Métodos

    // Gerando Obstáculos
    public void PlayerHitObstacle()
    {
        Debug.Log($"Jogador bateu.");
    }

    // Ativação de painel
    public void PanelActivite(Panels panel, bool activated)
    {
        if (activated)
        {
            Debug.Log($"{panel} foi ativado.");
        }
        else
        {
            Debug.Log($"{panel} foi desativado.");
        }
    }

    // Gerando Obstáculos
    public void SpawningObstacles(Obstacles obstacle)
    {
        Debug.Log($"{obstacle} foi gerada.");
    }
    
    // Gerando Obstáculos
    public void SpawningScenario(Scenario scenario)
    {
        Debug.Log($"{scenario} foi gerada.");
    }

    #endregion
}

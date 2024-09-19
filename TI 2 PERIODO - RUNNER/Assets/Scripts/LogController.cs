using UnityEngine;

public class LogController : MonoBehaviour
{
    #region M�todos

    // Gerando Obst�culos
    public void PlayerHitObstacle()
    {
        Debug.Log($"Jogador bateu.");
    }

    // Ativa��o de painel
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

    // Gerando Obst�culos
    public void SpawningObstacles(Obstacles obstacle)
    {
        Debug.Log($"{obstacle} foi gerada.");
    }
    
    // Gerando Obst�culos
    public void SpawningScenario(Scenario scenario)
    {
        Debug.Log($"{scenario} foi gerada.");
    }

    #endregion
}

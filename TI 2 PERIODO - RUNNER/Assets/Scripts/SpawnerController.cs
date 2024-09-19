using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    #region Variáveis

    [Header("Controllers")]
        private LogController logController;

    [Header("Player")]
        public Transform player;

    [Header("Scenario")]
        public GameObject streetPrefab;
        private int contSpawnScenario = 0;
        private int[] streetSpaces = { -5, 0, 5 };
        private int distanceToSpawnScenario = 100;
        private int streetSizeScenario = 500;

    [Header("Obstacles")]
        private GameObject wallPrefab;
        public GameObject downWallPrefab;
        public GameObject upWallPrefab;
        public GameObject bigWallPrefab;
        private int obstaclesSpace = 50;
    
    [Header("PowerUp")]
        public GameObject powerUpPrefab;
    #endregion

    #region Métodos

    private void Start()
    {
        //logController = new LogController();
        
        for (int i = 0; i < 10; i++)
        {
            SpawnObstacle();
        }
        SpawnPowerUp();
    }

    private void Update()
    {
        if (player.position.z >= distanceToSpawnScenario + (streetSizeScenario * contSpawnScenario))
        {
            contSpawnScenario++;
            SpawnStreet(contSpawnScenario);
            
            for (int i = 0; i < 10; i++)
            {
                SpawnObstacle();
            }
            SpawnPowerUp();
        }

        // TO-DO: destruir rua anterior
    }

    private void SpawnObstacle()
    {
        // Seleciona aleatoriamente um tamanho de parede
        int sizeWall = Random.Range(0, 3);     // 0: bigWall, 1: downWall, 2: upWall
          
        // Seleciona o obstáculo
        switch (sizeWall)
        {
            case 0:
                //logController.SpawningObstacles(Obstacles.bigWall);
                wallPrefab = bigWallPrefab;
                break;
            case 1:
                //logController.SpawningObstacles(Obstacles.downWall);
                wallPrefab = downWallPrefab;
                break;
            case 2:
                //logController.SpawningObstacles(Obstacles.upWall);
                wallPrefab = upWallPrefab;
                break;
            default:
                wallPrefab = bigWallPrefab;
                break;
        }
      
        // Instancia o obstáculo na rua
        Instantiate(wallPrefab, new Vector3(streetSpaces[Random.Range(0, 3)], wallPrefab.transform.position.y, player.transform.position.z + obstaclesSpace), Quaternion.identity);
        obstaclesSpace += 50;
    }

    private void SpawnStreet(int contSpawnScenario)
    {
        // Gerando rua para o player correr
        int streetSize = 500;
        Instantiate(streetPrefab, new Vector3(0f, 0f, (float)(streetSize * contSpawnScenario)), Quaternion.identity);
        //logController.SpawningScenario(Scenario.street);
    }

    private void SpawnPowerUp()
    {
        // Gerando PowerUp

        Instantiate(powerUpPrefab, new Vector3(streetSpaces[Random.Range(0, 3)], 1f, Random.Range(50, 450)), Quaternion.identity);
        //logController.SpawningScenario(Scenario.);
    }

    private void SpawnScenario()
    {
        // Gerando cenário (decoração)
    }

    #endregion

}

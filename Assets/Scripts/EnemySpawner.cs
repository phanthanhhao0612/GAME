using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] enemyWaves;

    private int currentWave;

    void Start() => SpawnEnemyWave();

    private void SpawnEnemyWave()
    {
        if (enemyWaves == null || enemyWaves.Length == 0) return;

        var waveInfo = enemyWaves[currentWave];
        var startPosition = waveInfo.flyPath[0];

        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            var enemy = Instantiate(
                waveInfo.enemyPrefab,
                startPosition,
                Quaternion.identity
            );

            var agent = enemy.GetComponent<FlyPathAgent>();
            if (agent != null)
            {
                agent.flyPath = waveInfo.flyPath;
                agent.flySpeed = waveInfo.speed;
            }

            startPosition += waveInfo.formationOffset;
        }

        currentWave++;

        if (currentWave < enemyWaves.Length)
        {
            Invoke(nameof(SpawnEnemyWave), waveInfo.nextWaveDelay);
        }
    }
}
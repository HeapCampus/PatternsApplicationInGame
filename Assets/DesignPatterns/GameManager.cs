using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    Normal,
    Ulti
}

public class GameManager : MonoBehaviour
{
    public static GameMode Mode = GameMode.Normal;
    public Player Player;
    public ObjectPool EnemyPool;
    public ObjectPool DestroyParticlePool;
    public float EnemySpawnPeriod = 3f;
    public float EnemySpawnRadius = 16f;

    public ImageFiller HealthImageFiller;
    public ImageFiller UltiImageFiller;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public Light DirectionalLight;
    public Color NormallightColor;
    public Color UltiLightColor;

    public ParameterConfig NormalParams;
    public ParameterConfig UltiParams;

    private GameObject Go;

    private float enemySpawnTimeCounter = 0;
    private int deadEnemyCounter = 0;
    private int totalDeadEnemy = 0;
    private float ultiTime = 15f;
    private float ultiPercentage = 1f;
    private int score;
    private int highestScore;

    private void Start()
    {
        Player.Speed = NormalParams.PlayerSpeed;
        Player.Shooter.BulletSpeed = NormalParams.BulletSpeed;
        Player.Shooter.Period = NormalParams.BulletPeriod;
        ScoreText.text = "0";

        if(PlayerPrefs.HasKey("highest_score"))
        {
            highestScore = PlayerPrefs.GetInt("highest_score");
        }
        else
        {
            highestScore = 0;
        }

        HighScoreText.text = highestScore.ToString();
    }

    private void Update()
    {
        enemySpawnTimeCounter += Time.deltaTime;

        if (enemySpawnTimeCounter >= EnemySpawnPeriod)
        {
            var enemy = EnemyPool.GetPoolObject();
            if (enemy != null)
            {

                Enemy enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.SetTarget(Player.transform);
                enemyScript.Config = Mode == GameMode.Normal ? NormalParams : UltiParams;

                float a = Random.Range(0, 2 * Mathf.PI);

                Vector3 spawnPos = Player.transform.position + new Vector3(Mathf.Cos(a), 0f, Mathf.Sin(a)) * EnemySpawnRadius;

                enemy.transform.position = spawnPos;
                enemy.SetActive(true);

  
                enemyScript.OnDied += OnEnemyDied;

            }
            enemySpawnTimeCounter = 0f;
        }

        HealthImageFiller.SetPercentage(Player.Health / 100f);

        if(Mode == GameMode.Ulti)
        {
            ultiPercentage -= Time.deltaTime / ultiTime;
            UltiImageFiller.SetPercentage(ultiPercentage);

            if(ultiPercentage <= 0)
            {
                Mode = GameMode.Normal;
                ultiPercentage = 1f;
                DirectionalLight.color = NormallightColor;
                Player.Speed = NormalParams.PlayerSpeed;
                Player.Shooter.BulletSpeed = NormalParams.BulletSpeed;
                Player.Shooter.Period = NormalParams.BulletPeriod;
            }

            Player.ClosestEnemyTr = GetClosestEnemy();
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        StartCoroutine(ShowParticle(enemy.transform.position));

        totalDeadEnemy++;
        score = totalDeadEnemy * 10;
        ScoreText.text = score.ToString();

        EnemyPool.ReturnPoolObject(enemy.gameObject);

        if(Mode == GameMode.Normal)
        {
            deadEnemyCounter++;

            //UltiImageFiller.FillTime = 0.1f;
            UltiImageFiller.SetPercentage(deadEnemyCounter / 5f);
        }

        if (deadEnemyCounter == 5)
        {
            Mode = GameMode.Ulti;
            //UltiImageFiller.FillTime = 10f;
            UltiImageFiller.SetPercentageHard(1f);
            DirectionalLight.color = UltiLightColor;
            deadEnemyCounter = 0;
            Player.Speed = UltiParams.PlayerSpeed;
            Player.Shooter.BulletSpeed = UltiParams.BulletSpeed;
            Player.Shooter.Period = UltiParams.BulletPeriod;
        }

        enemy.OnDied -= OnEnemyDied;
    }

    IEnumerator ShowParticle(Vector3 pos)
    {
        var particle = DestroyParticlePool.GetPoolObject();
        particle.transform.position = pos + Vector3.up;
        particle.SetActive(true);

        yield return new WaitForSeconds(0.55f);

        DestroyParticlePool.ReturnPoolObject(particle);
    }

    private Transform GetClosestEnemy()
    {
        float distance = 1000f;
        int index = -1;

        for (int i = 0; i < EnemyPool.ActivePoolObjects.Count; i++)
        {
            float dist = (EnemyPool.ActivePoolObjects[i].transform.position - Player.transform.position).magnitude;
            if (dist < distance)
            {
                index = i;
                distance = dist;
            }
        }

        if (index == -1)
            return null;

        return EnemyPool.ActivePoolObjects[index].transform;
    }

    private void OnApplicationQuit()
    {
        SaveHighestScore();
    }

    private void SaveHighestScore()
    {
        if (score > highestScore)
        {
            PlayerPrefs.SetInt("highest_score", score);
            PlayerPrefs.Save();
        }
    }
}

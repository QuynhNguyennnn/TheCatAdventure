using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{

    [SerializeField]
    private GameObject Slime;
    EnemyController EnemyController;
    private GameObject[] Slimes;
    private GameObject[] HomePosition;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Slimes = new GameObject[13];
        HomePosition = new GameObject[13];
        HomePosition[0] = new GameObject("home 1");
        HomePosition[1] = new GameObject("home 2");
        HomePosition[2] = new GameObject("home 3");
        HomePosition[3] = new GameObject("home 4");
        HomePosition[4] = new GameObject("home 5");
        HomePosition[5] = new GameObject("home 6");
        HomePosition[6] = new GameObject("home 7");
        HomePosition[7] = new GameObject("home 8");
        HomePosition[8] = new GameObject("home 9");
        HomePosition[9] = new GameObject("home 10");
        HomePosition[10] = new GameObject("home 11");
        HomePosition[11] = new GameObject("home 12");
        HomePosition[12] = new GameObject("home 13");

        HomePosition[0].transform.position = new Vector2(25.8f, 2.6f);
        HomePosition[1].transform.position = new Vector2(23.80753f, 17.19879f);
        HomePosition[2].transform.position = new Vector2(45.51665f, 091954);
        HomePosition[3].transform.position = new Vector2(55.8f, 7.1f);
        HomePosition[4].transform.position = new Vector2(39.20802f, 032485f);
        HomePosition[5].transform.position = new Vector2(58.7f, -3.2f);
        HomePosition[6].transform.position = new Vector2(2.1f, 0.3f);
        HomePosition[7].transform.position = new Vector2(-3.320178f, 15.20781f);
        HomePosition[8].transform.position = new Vector2(47.29737f, -45.06599f);
        HomePosition[9].transform.position = new Vector2(39.64725f, -53.06382f);
        HomePosition[10].transform.position = new Vector2(39.07f, -24.95541f);
        HomePosition[11].transform.position = new Vector2(67.63976f, -28.78047f);
        HomePosition[12].transform.position = new Vector2(58.59866f, -24.66568f);


        for (int i = 0; i < 13; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (Slime)
        {
            GameObject tmp = Instantiate(Slime, HomePosition[count].transform.position, Quaternion.identity);
            tmp.name = "Slime "+ (count+1);
            EnemyController = tmp.GetComponent<EnemyController>();
            EnemyController.SetHomePosition(HomePosition[count]);
            Slimes[count] = tmp;
            ++count;
        }
    }
}

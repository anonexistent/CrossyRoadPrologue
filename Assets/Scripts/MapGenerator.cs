using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    public int minDistance;

    [HideInInspector]
    Vector3 curPos = new Vector3 (0, 0, 0);

    [SerializeField]
    List<TerrainData> ters = new List<TerrainData>();

    [SerializeField]
    public int maxTerCount;

    List<GameObject> curTers = new List<GameObject>();

    [SerializeField]
    Transform mapHolder;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < maxTerCount; i++)
        {
            SpawnMap(true, new Vector3(0,0,0));

        }
        //maxTerCount = curTers.Count;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.W))
    //    {
    //        SpawnMap(false);
    //    }
    //}
    public void SpawnMap(bool isInitialization, Vector3 pos)
    {
        if(curPos.x - pos.x < minDistance)
        {
            int temp = Random.Range(0, ters.Count);
            int terOnMap = Random.Range(1, ters[temp].maxOnMap);

            for (int i = 0; i < terOnMap; i++)
            {
                GameObject t = Instantiate(ters[temp].ter, curPos, Quaternion.identity, mapHolder);

                curTers.Add(t);
                if (!isInitialization)
                {
                    if (curTers.Count > maxTerCount)
                    {
                        Destroy(curTers[0]);
                        curTers.RemoveAt(0);
                    }
                }

                curPos.x++;
            }
        }

        //GameObject t = Instantiate(ters[UnityEngine.Random.Range(0, ters.Count)], curPos, Quaternion.identity);
        //curTers.Add(t);
        //if (curTers.Count > maxTerCount)
        //{
        //    Destroy(curTers[0]);
        //    curTers.RemoveAt(0);
        //}
        //curPos.z++;
    }
}

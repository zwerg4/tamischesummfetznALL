using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class GhostManager : MonoBehaviour
{
    public GameObject Car;
    public GameObject Ghost;

    List<GhostData> newGhostDatas = new List<GhostData>();
    List<GhostData> oldGhostDatas = new List<GhostData>();

    int update = 1;

    // Start is called before the first frame update
    void Start()
    {
        var setting = new JsonSerializerSettings();
        setting.Formatting = Formatting.Indented;
        setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        var fileContent = System.IO.File.ReadAllText(Application.dataPath + "/ghost.json");
        oldGhostDatas = JsonConvert.DeserializeObject<List<GhostData>>(fileContent);
        //var oldGhostDatas = JsonConvert.SerializeObject(oldGhostDatasJson, setting);

        Debug.Log("oldghost data: " + oldGhostDatas.Count);
    }

    // Update is called once per frame
    void Update()
    {

        //move ghost

        if(update < oldGhostDatas.Count)
        {
            Ghost.transform.position = new Vector3((float)oldGhostDatas[update].pos_x, (float)oldGhostDatas[update].pos_y, (float)oldGhostDatas[update].pos_z);
            Ghost.transform.eulerAngles = new Vector3((float)oldGhostDatas[update].rot_x, (float)oldGhostDatas[update].rot_y, (float)oldGhostDatas[update].rot_z);
            //Ghost.transform.rotation = Quaternion.Euler((float)oldGhostDatas[update].rot_x, (float)oldGhostDatas[update].rot_y, (float)oldGhostDatas[update].rot_z);

        }

        // save ghost

        //Car.transform.rotation.x, Car.transform.rotation.y, Car.transform.rotation.x
        GhostData ghostData = new GhostData(Car.transform.position.x, Car.transform.position.y, Car.transform.position.z, Car.transform.eulerAngles.x, Car.transform.eulerAngles.y, Car.transform.eulerAngles.z);
        newGhostDatas.Add(ghostData);
        update += 1;
    }

    public void Stop()
    {

        var setting = new JsonSerializerSettings();
        setting.Formatting = Formatting.Indented;
        setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        var json = JsonConvert.SerializeObject(newGhostDatas, setting);

        Debug.Log("ghostdatajson : " + json);
        Save(json);
        this.gameObject.SetActive(false);
    }

    void Save(string json)
    {
        System.IO.File.WriteAllText(Application.dataPath + "/ghost.json", json);
        Debug.Log("Saved Ghost sucessfully");
    }
}

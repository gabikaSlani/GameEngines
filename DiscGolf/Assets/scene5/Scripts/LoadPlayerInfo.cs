using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine;

public class LoadPlayerInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/actualPlayer", FileMode.Open);
        Player player = (Player)bf.Deserialize(file);
        file.Close();
        Debug.Log(player.name);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

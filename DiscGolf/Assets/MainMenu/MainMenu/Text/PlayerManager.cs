using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public class PlayerManager : MonoBehaviour {

    public int clickedBtnOrder = 0;

    public void Start()
    {
        Debug.Log(clickedBtnOrder);

        for (int i = 1; i <= 8; i++)
        {
            string meno_suboru = i + ".dat";
            if (!(File.Exists(Application.persistentDataPath + "/" + meno_suboru)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/" + meno_suboru);
                Player player = new Player();
                player.name = "PLAYER" + i;
                player.score = new List<int>();
                for (int j = 0; j < 11; j++)
                {
                    player.score.Add(0);
                }
                bf.Serialize(file,player);
                file.Close();
            }
        }
        if (!(File.Exists(Application.persistentDataPath + "/actualPlayer")))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/actualPlayer");
            file.Close();
        }

    }


    public Player Load(int i)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + i + ".dat", FileMode.Open);
        Player player = (Player)bf.Deserialize(file);
        file.Close();
        return player;
    }

    public void ClickButton(int poradie)
    {
        clickedBtnOrder = poradie;   
        Debug.Log(poradie);
    }

    public void PlayGameReal()
    {
        if (clickedBtnOrder != 0)
        {
            Player player = Load(clickedBtnOrder);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/actualPlayer", FileMode.Open);
            bf.Serialize(file, player);
            file.Close();
            Application.LoadLevel("Scene5");
        }
    }

}

[Serializable]
public class Player
{
    public string name;
    public List<int> score; 
}

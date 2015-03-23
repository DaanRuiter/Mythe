using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public enum Harpoon
{
    Normal,
    Fancy,
    Golden
}

public enum Ship
{
    Normal,
    Speedboat,
    Cruiseship
}

public class PlayerEquipment : MonoBehaviour {

    private GameObject _playerObject;
    private GameObject _harpoonObject;

    private Harpoon _playerHarpoon;
    private Ship _playerShip;
    private PlayerData _playerData;

    private void Start()
    {
        _playerObject = transform.FindChild("Player").gameObject;
        _harpoonObject = transform.FindChild("Harpoon Object").gameObject;
        _playerData = new PlayerData();
        Load(_playerData);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            Save();
        }
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SavaData.dat");

        PlayerData save = new PlayerData();

        //save.gold = Game.instance.gold;
        //save.points = Game.instance.points;
        save.harpoon = _playerHarpoon;
        save.ship = _playerShip;

        binaryFormatter.Serialize(file, save);
        file.Close();

        Debug.Log("Stats saved.");
    }

    public void Load(PlayerData dataContainer)
    {
        if (File.Exists(Application.persistentDataPath + "/SavaData.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavaData.dat", FileMode.Open);

            PlayerData save = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();

            //Game.instance.SetStats(save.gold, save.points);
            _playerHarpoon = save.harpoon;
            _playerShip = save.ship;

            Debug.Log("Player data loaded");
        }
        else
        {
            Debug.Log("No save data found.");
            CreateNewSaveFile();
            Load(dataContainer);
        }
    }

    private void CreateNewSaveFile()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SavaData.dat");

        PlayerData save = new PlayerData();

        save.gold = 0;
        save.points = 0;
        save.harpoon = Harpoon.Normal;
        save.ship = Ship.Normal;

        binaryFormatter.Serialize(file, save);
        file.Close();

        Debug.Log("New Save File Created");
    }

}

[System.Serializable]
public class PlayerData
{
    public int gold;
    public int points;
    public Harpoon harpoon;
    public Ship ship;
}

using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadDataSerialized : MonoBehaviour 
{
	public Resources resources;

	private BinaryFormatter _binaryFormatter;
	private FileStream _file;
	private SaveData _saveData;

	void Start()
	{
		_binaryFormatter = new BinaryFormatter();
	}

	public void SaveData()
	{
		if(!File.Exists(Application.persistentDataPath + "/SaveData.dat"))
		{
			_file = File.Create(Application.persistentDataPath + "/SaveData.dat");

			_saveData = new SaveData();

			_binaryFormatter.Serialize(_file, _saveData);
			_file.Close();
			Debug.Log("File created and data saved");

		}else{
			_file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Create);

			_saveData = new SaveData();

			_binaryFormatter.Serialize(_file, _saveData);
			_file.Close();

			Debug.Log("Data saved");

		}
	}
	
	public void LoadData()
	{
		if(File.Exists(Application.persistentDataPath + "/SaveData.dat"))
		{
			_file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);

			_saveData = _binaryFormatter.Deserialize(_file) as SaveData;

			_file.Close();
			Debug.Log("Loaded");
		}else{
			Debug.Log("There is no existing save file");
		}
	}

	public void DeleteData()
	{
		if(File.Exists(Application.persistentDataPath + "/SaveData.dat"))
		{
			File.Delete(Application.persistentDataPath + "/SaveData.dat");

			Debug.Log("Save file deleted");
		}
	}
}

[System.Serializable]
public class SaveData
{
	
}


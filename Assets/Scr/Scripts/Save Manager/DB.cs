using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class DB
{
    private static DB _instance;
    public static DB Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DB();
            }
            return _instance;
        }
    }

    public Stages StagesData { get; private set; }
    private string path;

    private DB()
    {
        path = Application.persistentDataPath + "/db.json";
        Load();
    }

    public void Save()
    {
        try
        {
            string json = JsonUtility.ToJson(StagesData, true);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error saving data: " + ex.Message);
        }
    }

    private void Load()
    {
        try
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                StagesData = JsonUtility.FromJson<Stages>(json) ?? new Stages();
            }
            else
            {
                StagesData = new Stages();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error loading data: " + ex.Message);
            StagesData = new Stages(); // Inicializa la lista para evitar referencias nulas
        }
    }

    public void SetStage(Stage stage)
    {
        Stage existingStage = StagesData.stages.FirstOrDefault(s => s.lvl == stage.lvl);
        if (existingStage != null)
        {
            StagesData.stages.Remove(existingStage);
        }
        StagesData.stages.Add(stage);
        Save();
    }

    public Stage GetStage(int lvl)
    {
        Stage stage = StagesData.stages.FirstOrDefault(s => s.lvl == lvl);
        if (stage == null)
        {
            stage = new Stage { 
                lvl = lvl,
                unlock = false,
                complete = false,
                stars = 0,
                score = 0
            };
            StagesData.stages.Add(stage);
            Save();
        }
        return stage;
    }
}

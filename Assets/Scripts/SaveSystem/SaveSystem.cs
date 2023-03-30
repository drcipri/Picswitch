using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
   //Saving gems and puzzlesSolved
    public static void SaveGemsAndPuzzlesSolved(PuzzleFeaturesSO puzzleFeaturesSO)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Gems.cotuna";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(puzzleFeaturesSO);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }
    public static GameData LoadGemsAndPuzzlesSolved()
    {
        string path = Application.persistentDataPath + "/Gems.cotuna";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }

    //puzzles solvedData
    public static void SavePuzzlesSolvedData(PuzzlesSolvedDataSO puzzlesSolvedDataSO)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PuzzlesSolved.cotuna";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(puzzlesSolvedDataSO);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadPuzzlesSolvedData()
    {
        string path = Application.persistentDataPath + "/PuzzlesSolved.cotuna";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }






}

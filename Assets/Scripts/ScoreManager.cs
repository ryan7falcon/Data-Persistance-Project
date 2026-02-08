using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string bestScoreName;
    public int bestScore;
    public string currentPlayerName;
    public int currentScore;
    public TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore(); 
    }

    [System.Serializable]
    class SaveData
    {
        public string bestScoreName;
        public int bestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScoreName = bestScoreName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreName = data.bestScoreName;
            bestScore = data.bestScore;
        }
    }

    public void UpdateScore(int score)
    {
        currentScore = score;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreName = currentPlayerName;
            SaveBestScore();
        }
    }

    public void SetCurrentPlayerName(string name)
    {
        currentPlayerName = name;
    }
}

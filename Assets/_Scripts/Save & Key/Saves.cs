using UnityEngine;

public class Saves : MonoBehaviour
{
    private static Saves instance;

    public static Saves Get => instance ?? (instance = new Saves());

    public void AddInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public void AddFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    public void AddString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public void AddBool(string key, bool value)
    {
        int _bool = 0;
        _bool = value ? 1 : 0;

        AddString(key, _bool.ToString());
    }


    public int GetInt(string key)
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) : 0;
    }

    public float GetFloat(string key)
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetFloat(key) : 0f;
    }

    public string GetString(string key)
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : "";
    }

    public bool GetBool(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return int.Parse(PlayerPrefs.GetString(key)) == 1 ? true : false;
        }
        else
        {
            return false;
        }
    }

    public void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
    }

    public void RemoveCurrentSaves(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
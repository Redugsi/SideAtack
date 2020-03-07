using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    private const int STARTER_ENERGY = 25;
    private const int STARTER_COIN = 0;
    public static PrefsManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #region Coin Operations

    public void AddCoin(int value)
    {
        int currentCoin = GetCoin();
        SetCoin(currentCoin + value);
    }

    public void SetCoin(int coin)
    {
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.Save();
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt("coin", STARTER_COIN);
    }

    #endregion

    #region Energy Operations

    public void AddEnergy(int value) 
    {
        int currentEnergy = GetEnergy();
        SetEnergy(currentEnergy + value);
    }

    public void SetEnergy(int energy)
    {
        PlayerPrefs.SetInt("energy", energy);
        PlayerPrefs.Save();
    }

    public int GetEnergy()
    {
        return PlayerPrefs.GetInt("energy", STARTER_ENERGY);
    }

    #endregion

    #region Dagger Operations

    public void SetSelectedDaggerName(string daggerName)
    {
        PlayerPrefs.SetString("dagger", daggerName);
        PlayerPrefs.Save(); 
    }

    public string GetSelectedDaggerName() 
    {
        return PlayerPrefs.GetString("dagger","Dagger"); 
    }

    public void AddBoughtDagger(string daggerName)
    {
        var boughtDaggers = GetBoughtDaggers();
        var daggers = new string[boughtDaggers.Length + 1];

        for(int i = 0; i < boughtDaggers.Length; i++)
        {
            daggers[i] = boughtDaggers[i];
        }

        daggers[daggers.Length - 1] = daggerName;

        SetBoughtDaggers(daggers);
    }

    public void SetBoughtDaggers(string[] boughtDaggers)
    {
        if (boughtDaggers == null || boughtDaggers.Length == 0) 
        {
            boughtDaggers = new string[1];
            boughtDaggers[0] = "Dagger";
        }

        PlayerPrefsX.SetStringArray("bought_daggers", boughtDaggers);
        PlayerPrefs.Save();
    }

    public string[] GetBoughtDaggers()
    {
        var boughtDaggers = PlayerPrefsX.GetStringArray("bought_daggers");

        if(boughtDaggers == null || boughtDaggers.Length == 0) 
        {
            boughtDaggers = new string[1];
            boughtDaggers[0] = "Dagger";
        }

        return boughtDaggers;
    }

    #endregion
}

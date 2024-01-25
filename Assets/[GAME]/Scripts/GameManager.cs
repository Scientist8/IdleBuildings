using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // =========================================================================
    public delegate void OnResourcesChange();
    public event OnResourcesChange OnResourcesChanged;

    // =========================================================================

    public int gems = 0;
    public int gold = 0;

    // =========================================================================

    void Awake()
    {
        SingletonThisObject();
    }

    // =========================================================================

    void SingletonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Function to add gems
    public void AddGems(int amount)
    {
        gems += amount;

        ResourcesChanged();

        Debug.Log("Gems added: " + amount + ". Total gems: " + gems);
    }

    // Function to subtract gems
    public void SubtractGems(int amount)
    {
        if (gems >= amount)
        {
            gems -= amount;

            ResourcesChanged();

            Debug.Log("Gems subtracted: " + amount + ". Total gems: " + gems);
        }
        else
        {
            Debug.LogWarning("Not enough gems to subtract.");
        }
    }

    // Function to add gold
    public void AddGold(int amount)
    {
        gold += amount;

        ResourcesChanged();
        Debug.Log("Gold added: " + amount + ". Total gold: " + gold);
    }

    // Function to subtract gold
    public void SubtractGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;

            ResourcesChanged();
            Debug.Log("Gold subtracted: " + amount + ". Total gold: " + gold);
        }
        else
        {
            Debug.LogWarning("Not enough gold to subtract.");
        }
    }

    private void ResourcesChanged()
    {
        OnResourcesChanged?.Invoke();
    }
}
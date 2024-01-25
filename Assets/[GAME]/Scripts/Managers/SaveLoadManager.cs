using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{

    [System.Serializable]
    public class BuildingSaveData
    {
        public Vector3 position;
        public string buildingName;
    }

    // =========================================================================

    public static SaveLoadManager Instance { get; private set; }

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

    // =========================================================================

    void OnApplicationQuit()
    {
        SaveGameState();
    }

    // =========================================================================

    public static void SaveGameState()
    {
        // Save grid state
        SaveGridState();

        // Save building state
        SaveBuildingState();
    }

    // =========================================================================

    private static void SaveGridState()
    {
        // Iterate through the grid cells and save their state
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();

        for (int x = 0; x < gridGenerator.gridSize; x++)
        {
            for (int y = 0; y < gridGenerator.gridSize; y++)
            {
                string key = $"Cell_{x}_{y}";
                bool isOccupied = PlayerPrefs.GetInt(key, 0) == 1;

                // Save the state of the cell
                PlayerPrefs.SetInt(key, isOccupied ? 1 : 0);
            }
        }
    }

    // =========================================================================

    private static void SaveBuildingState()
    {
        // Iterate through the buildings and save their state
        BuildingController[] buildings = FindObjectsOfType<BuildingController>();
        foreach (BuildingController building in buildings)
        {
            // Create a data structure to store building information
            BuildingSaveData buildingData = new BuildingSaveData
            {
                position = building.transform.position,
                buildingName = building.buildingData.buildingName
            };

            // Convert the data to JSON
            string jsonData = JsonUtility.ToJson(buildingData);

            // Save building state with a unique key 
            PlayerPrefs.SetString($"Building_{building.name}", jsonData);
        }
    }

    // =========================================================================

    // ========================================================================================

    public static void LoadGameState()
    {
        // Load grid state
        LoadGridState();

        // Load building state
        LoadBuildingState();
    }

    // =========================================================================

    private static void LoadGridState()
    {
        GridGenerator gridGenerator = FindObjectOfType<GridGenerator>();

        for (int x = 0; x < gridGenerator.gridSize; x++)
        {
            for (int y = 0; y < gridGenerator.gridSize; y++)
            {
                string key = $"Cell_{x}_{y}";
                bool isOccupied = PlayerPrefs.GetInt(key, 0) == 1;

                // Retrieve the corresponding cell and update its state
                GameObject cell = GameObject.Find($"Cell_{x}_{y}"); // Make sure to set up GameObject names consistently
                if (cell != null)
                {
                    CellScript cellScript = cell.GetComponent<CellScript>();
                    if (cellScript != null)
                    {
                        // Update the state of the cell based on the loaded data
                        cellScript.isOccupied = isOccupied;
                    }
                    else
                    {
                        Debug.LogError($"Cell {key} is missing CellScript component.");
                    }
                }
                else
                {
                    Debug.LogError($"Cell {key} not found.");
                }
            }
        }
    }

    private static void LoadBuildingState()
    {
        BuildingController[] buildings = FindObjectsOfType<BuildingController>();
        foreach (BuildingController building in buildings)
        {
            string key = $"Building_{building.name}";
            string jsonData = PlayerPrefs.GetString(key, "");

            if (!string.IsNullOrEmpty(jsonData))
            {
                // Deserialize the JSON data into BuildingSaveData
                BuildingSaveData buildingData = JsonUtility.FromJson<BuildingSaveData>(jsonData);

                // Find all buildings with the same name
                BuildingController[] sameNameBuildings = System.Array.FindAll(buildings, b => b.name == building.name);

                // Apply the loaded data to each building with the same name
                foreach (BuildingController sameNameBuilding in sameNameBuildings)
                {
                    sameNameBuilding.transform.position = buildingData.position;
                }
            }
            else
            {
                Debug.LogWarning($"No saved data found for building {building.name}");
            }
        }
    }

    // =========================================================================

    public void DeleteAllSaveAndReload()
    {
        PlayerPrefs.DeleteAll();
    }
}
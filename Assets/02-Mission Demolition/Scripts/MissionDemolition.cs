using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; // A private Singleton

    [Header("Set in Inspector")]
    public TextMeshProUGUI uitLevel; // The UIText_Level Text
    public TextMeshProUGUI uitShots; // The UIText_Shots Text
    public TextMeshProUGUI uitButton; // The Text on UIButton_View
    public Vector3 castlePos; // The place to put castles
    public GameObject[] castles; // An Array of the castles

    [Header("Set in Inspector")]
    public int level; // The current level
    public int levelMax; // The number of levels
    public int shotsTaken; // The number of shots made
    public GameObject castle; // The current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; // FollowCam mode

    // Start is called before the first frame update
    void Start()
    {
        S = this; // Define the Singleton

        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    // Start a new level
    void StartLevel()
    {
        // Get rid of the old castle if one exists
        if(castle != null)
        {
            Destroy(castle);
        }

        // Destroy old projectiles if they exist
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        // Instantiate the new castle
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        // Reset the Camera 
        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        // Reset the goal
        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        // Check for level end
        if((mode == GameMode.playing) && Goal.goalMet)
        {
            // Change mode to stop checking for level end
            mode = GameMode.levelEnd;

            // zoom out
            SwitchView("Show Both");

            // Start the next level in 2 seconds
            Invoke("NextLevel", 3f);
        }
    }

    // Go to next level
    void NextLevel()
    {
        level++; // Increase level

        // If level is the level max, reset to level 0
        if(level == levelMax) {
            level = 0;
        }
        StartLevel();
    }

    public void SwitchView(string eView = "")
    {
        if(eView == "")
        {
            eView = uitButton.text;
        }

        showing = eView;
        switch(showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}

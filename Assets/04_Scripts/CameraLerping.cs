using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraLerping : MonoBehaviour
{
    public List<Transform> LevelPositions = new List<Transform>();
    public List<(string, string)> LevelInfo = new List<(string, string)>();
    public List<bool> LevelUnlocked = new List<bool>();
    public List<Animator> LevelAnimation = new List<Animator>();
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Description;


    public float Speed;
    public Button Play;
    public GameObject Slot;
    public Button Right;
    public Button Left;
    public int CurrentLevelIndex = 0;

    public bool ResetSaves;

    Camera _mainCamera;
    bool StartMoving;
    float nextTime;
    List<Vector3> StartPositionCharacter = new List<Vector3>();
    List<Quaternion> StartRotationCharacter = new List<Quaternion>();
    // Start is called before the first frame update
    void Start()
    {
        LevelInfo.Add(("Level 1", "Guide the character into a correct standing posture."));
        LevelInfo.Add(("Level 2", "It is time to take your first step towards better posture. You must carefully guide the character to execute a single step with the correct posture"));
        LevelInfo.Add(("Level 3", "You are faced with a more advanced challenge as you strive to perform a backflip with proper posture. This level pushes your skills and coordination to the limit"));

        for (int i = 0; i < LevelAnimation.Count; i++)
        {
            StartPositionCharacter.Add(LevelAnimation[i].gameObject.transform.position);
            StartRotationCharacter.Add(LevelAnimation[i].gameObject.transform.rotation);
        }
        int totalLevelsUnlocked = PlayerPrefs.GetInt("UnlockedLevel");
        for (int i = 0; i <= totalLevelsUnlocked; i++)
        {
            LevelUnlocked[i] = true;
        }

        _mainCamera = Camera.main;
        StartMoving = true;
        LerpTo(LevelPositions[0]);

    }

    // Update is called once per frame
    void Update()
    {
        //_mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, LevelPositions[CurrentLevelIndex], 0.01f);

        if (StartMoving)
        {
            LerpTo(LevelPositions[CurrentLevelIndex]);
        }
        else
        {
            if (Time.time >= nextTime)
            {
                StartAnimationLevel();
            }
        }

        if (CurrentLevelIndex == 0)
        {
            Left.interactable = false;
        }
        else if (CurrentLevelIndex == LevelPositions.Count - 1)
        {
            Right.interactable = false;
        }
        else
        {
            Left.interactable = true;
            Right.interactable = true;
        }

        if (ResetSaves)
        {
            ResetSaves = false;
            PlayerPrefs.DeleteKey("UnlockedLevel");
        }
    }

    void LerpTo(Transform to)
    {
        Title.text = LevelInfo[CurrentLevelIndex].Item1;
        Description.text = LevelInfo[CurrentLevelIndex].Item2;

        if (LevelUnlocked[CurrentLevelIndex])
        {
            Slot.SetActive(false);
            Play.interactable = true;
        }
        else
        {
            Slot.SetActive(true);
            Play.interactable = false;
        }

        Play.onClick.RemoveAllListeners();
        Play.onClick.AddListener(() => GoToLevel(CurrentLevelIndex + 1));

        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, to.position, Speed);
        _mainCamera.transform.rotation = Quaternion.Lerp(_mainCamera.transform.rotation, to.rotation, Speed);

        if (Vector3.Distance(_mainCamera.transform.position, to.position) < 0.1f)
        {
            StartAnimationLevel();
            StartMoving = false;
        }
    }
    void StartAnimationLevel()
    {
        nextTime = Time.time + 5f;
        LevelAnimation[CurrentLevelIndex].SetTrigger("Start");
        if (CurrentLevelIndex == 0)
        {
            LevelAnimation[CurrentLevelIndex].gameObject.transform.position = new Vector3(StartPositionCharacter[CurrentLevelIndex].x, 0.3f, StartPositionCharacter[CurrentLevelIndex].z);
            LevelAnimation[CurrentLevelIndex].gameObject.transform.rotation = StartRotationCharacter[CurrentLevelIndex];
            return;
        }
        else
        {
            LevelAnimation[CurrentLevelIndex].gameObject.transform.position = StartPositionCharacter[CurrentLevelIndex];
            LevelAnimation[CurrentLevelIndex].gameObject.transform.rotation = StartRotationCharacter[CurrentLevelIndex];
        }
    }

    public void GoToNextLevel()
    {
        CurrentLevelIndex++;
        StartMoving = true;
    }
    public void GoToPreviousLevel()
    {
        CurrentLevelIndex--;
        StartMoving = true;
    }
    public void GoToLevel(int levelNumber)
    {
        SceneManager.LoadScene("Level " + levelNumber.ToString());
    }

}

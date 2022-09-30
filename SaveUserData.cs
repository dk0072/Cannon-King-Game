using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LocalStorage;

public class SaveUserData : MonoBehaviour
{
    public static SaveUserData instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    { 
        if(getChapterName()==0 && getLevelName()==0)
        {
            setChapterName(1);
            setLevelName(1);
            Debug.Log("New User");
        }

        Debug.Log(getChapterName());
        Debug.Log(getLevelName());
    }













    //Getter
   public int getChapterName()
    {
        return PlayerPrefs.GetInt(Storage.CHAPTER_NAME);
    }
    public int getLevelName()
    {
        return PlayerPrefs.GetInt(Storage.LEVEL_NAME);
    }
    public float getLevelProgress()
    {
        return PlayerPrefs.GetFloat(Storage.CHAPTER_PROGRESS);
    }

    //Setter
    public void setChapterName(int chapter)
    {
        PlayerPrefs.SetInt(Storage.CHAPTER_NAME, chapter);
    }
    public void setLevelName(int level)
    {
        PlayerPrefs.SetInt(Storage.LEVEL_NAME, level);
    }
    public void setProgressValue(float value)
    {
        PlayerPrefs.SetFloat(Storage.CHAPTER_PROGRESS, PlayerPrefs.GetFloat(Storage.CHAPTER_PROGRESS)+value);
    }
}

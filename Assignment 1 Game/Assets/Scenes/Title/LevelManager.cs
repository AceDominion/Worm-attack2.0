using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {

    [System.Serializable]
    public class Level {
        public string LevelText;
        public Sprite LevelImg;
       /* unused so far
        public int Unlocked;
        public bool IsInteractable; 
        */

        public Button.ButtonClickedEvent OnClickEvent;
    }

    public List<Level> LevelList;
    public GameObject LevelButton;
    public Transform Spacer; //the parent panel that defines the layout of the grid containing the level buttons

    private void Start () {
        // PlayerPrefs.DeleteAll ();
        FillList ();
    }

    void FillList () {
        foreach (Level level in LevelList) {
            //initiate a new levelbutton
            GameObject newbtn = Instantiate (LevelButton) as GameObject;//get the game object
            LevelButton button = newbtn.GetComponent<LevelButton> ();//get the script binded on the object

            //assign the new levelbutton based on the values of Levellist set from the inspector 
            button.LevelText.text = level.LevelText;
            button.LevelImg.sprite = level.LevelImg;            

            /* unused so far
            if (PlayerPrefs.GetInt ("Level" + button.LevelText.text) == 1) {
                level.Unlocked = 1;
                level.IsInteractable = true;
            }
            //set for the locked and interactable state of the level button
            button.unlocked = level.Unlocked;
            button.GetComponent<Button> ().interactable = level.IsInteractable;
            */

            //bind event
            button.GetComponent<Button> ().onClick = level.OnClickEvent; //same as .onClick.AddListener (() =>  SceneManager.LoadScene ("name"));

            //set the display for the stars
            button.stars[1].GetComponent<Image> ().color = new Color(0,66,66,66) ;
            /*
            if (PlayerPrefs.GetInt ("。。。") > 0) {
                button.stars[0].SetActive (true);//待修改
            }*/

            //set the parent container for the new levelbutton
            newbtn.transform.SetParent (Spacer, false);//ensure the worldPositionStays Flase!!!!
        }
       // SaveAll ();
    }

    void SaveAll () {
       // if (!PlayerPrefs.HasKey ("Level1")) //only if the first level of the game hasn't been passed then save a session
        {

            GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
            foreach (GameObject button_gameobj in allButtons) {
                LevelButton button_script = button_gameobj.GetComponent<LevelButton> ();
             //   PlayerPrefs.SetInt ("Level" + button_script.LevelText.text, button_script.unlocked);
            }
        }
    }
}


public class CreditEntity {
    public int Level_One_Score; //the highest record of totems collected in level one
    public int Level_Two_Score; //the highest record of totems collected in level two
    public int HighScore; //the amount of totems collected in a session
    public string Nickname; //highscorer's kickname
}

public class Credit: UnitySingletonPersistent<Credit> {

    List<CreditEntity> CreditList;
    int Number = 5;//the number of entries supported

    public int Level_one_credit;
    public int Level_two_credit;
    public string listToString;
    
    void Start () {
        DontDestroyOnLoad (gameObject);

        CreditList = new List<CreditEntity> ();

        for (int i = 0; i < Number; i++) {
            CreditList.Add (GetEntity (i));
            Debug.Log (CreditList[i].Nickname +", high: " + CreditList[i].HighScore + ", l1: " + CreditList[i].Level_One_Score + ", l2: " + CreditList[i].Level_Two_Score);
        }
        
        Level_one_credit = GetLevelOneCredit ();
        Level_two_credit = GetLevelTwoCredit ();
        listToString = CreditListToString ();
    }

    CreditEntity GetEntity (int i) {
        var en = new CreditEntity ();
        en.Level_One_Score = PlayerPrefs.GetInt ("LevelOne" + i);
        en.Level_Two_Score = PlayerPrefs.GetInt ("LevelTwo" + i);
        en.Nickname = PlayerPrefs.GetString ("Nickname" + i);
        en.HighScore = PlayerPrefs.GetInt ("HighScore" + i);
        return en;
    }
      

    int GetLevelOneCredit () {
        CreditList.Sort (delegate (CreditEntity a, CreditEntity b) { return a.Level_One_Score.CompareTo (b.Level_One_Score); });//0, 1, -1
        return CreditList[0].Level_One_Score;
    }

    int GetLevelTwoCredit () {
        CreditList.Sort (delegate (CreditEntity a, CreditEntity b) { return a.Level_Two_Score.CompareTo (b.Level_Two_Score); });//0, 1, -1
        return CreditList[0].Level_Two_Score;
    }

    string CreditListToString () {
        CreditList.Sort (delegate (CreditEntity a, CreditEntity b) { return a.HighScore.CompareTo (b.HighScore); });//0, 1, -1

        for (int i = 0; i < CreditList.Count; i++) {
            listToString += "\n" + CreditList[i].Nickname + ": " + CreditList[i].HighScore;
        }
        return listToString.Substring (1);
    }

}
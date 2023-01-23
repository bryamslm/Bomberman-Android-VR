using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionManager : MonoBehaviour
{
    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    GameInfo gameInfo;

    // Start is called before the first frame update
    public void Start(){
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
    }
    public void loadMenu(){
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    public void loadGame(){
        SceneManager.LoadScene(2);
    }
    public void loadAbout(){
        SceneManager.LoadScene(1);
    }
    public void restartGame()
    {
        var dataFound =  LoadSystem.loadData<GameInfo>();

        if (dataFound != null)
        {
            gameInfo = dataFound;
            
            gameInfo.level = 1;
            gameInfo.rangeExplosion = 0.55f;
            gameInfo.speed = 1.7f;
            LoadSystem.saveData<GameInfo>(gameInfo);
            
        }
        else
        {
            gameInfo = new GameInfo(1, 1.7f, 0.55f);
            LoadSystem.saveData<GameInfo>(gameInfo);
        }

        SceneManager.LoadScene("Loading Screen");
    }

}

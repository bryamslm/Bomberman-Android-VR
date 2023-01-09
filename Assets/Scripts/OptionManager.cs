using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionManager : MonoBehaviour
{
    private Renderer _myRenderer;
    private Vector3 _startingPosition;
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
        SceneManager.LoadScene(1);
    }
    public void loadAbout(){
        SceneManager.LoadScene(2);
    }

}

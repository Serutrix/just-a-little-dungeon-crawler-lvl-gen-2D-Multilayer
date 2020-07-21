using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public int G;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame

    public void loadVoxel3D()
    {
        SceneManager.LoadScene("3DV", LoadSceneMode.Additive);
    }
    public void loadVoxel2D()
    {
        SceneManager.LoadScene("3DV", LoadSceneMode.Additive);
    }
    public void loadDCG()
    {
        SceneManager.LoadScene("3DV", LoadSceneMode.Additive);
    }
}

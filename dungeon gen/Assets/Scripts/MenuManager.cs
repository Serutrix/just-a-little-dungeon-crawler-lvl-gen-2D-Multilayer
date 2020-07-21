using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject C;
    public GameObject mc;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 144;
    }


    // Update is called once per frame

    public void loadVoxel3D()
    {
       

        SceneManager.LoadScene("3DV");
    }
    public void loadVoxel2D()
    {
        

        SceneManager.LoadScene("2DV");
    }
    public void loadDCG()
    {
        

        SceneManager.LoadScene("DCG");
    }
}

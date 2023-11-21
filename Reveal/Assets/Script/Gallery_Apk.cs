using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery_Apk : MonoBehaviour
{

    
    public GameObject MenuScreen;
    

    public GameObject Gallery_Operate;

    //public GameObject Album_Back;
    //public GameObject Secret_Album_Back;

    public GameObject DogAlbum;
    public GameObject CatAlbum;
    public GameObject SecretAlbum;
    public GameObject SecretAlbum_Image1;
    public GameObject SecretAlbum_Image2;
    public GameObject CameraAlbum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void Operate_Dog_Album()
    {
        DogAlbum.SetActive(true);
    }

    public void Operate_Camera_Album()
    {
        CameraAlbum.SetActive(true);
    }

    public void Operate_Cat_Album()
    {
        CatAlbum.SetActive(true);
    }
    public void AlbumBack()
    {
        SecretAlbum.SetActive(false);
        //Album_Back.SetActive(true);
        DogAlbum.SetActive(false);
        CameraAlbum.SetActive(false);
        CatAlbum.SetActive(false);
    } 
    public void SecretAlbumBack()
    {
        SecretAlbum_Image1.SetActive(false);
        SecretAlbum_Image2.SetActive(false);

    }

    public void Operate_Secret_Album()
    {
        SecretAlbum.SetActive(true);
    }
    public void Secret_Album_Image1()
    {
        SecretAlbum_Image1.SetActive(true);
    }
    public void Secret_Album_Image2()
    {
        SecretAlbum_Image2.SetActive(true);
    }

    public void Album_Apk()
    {
       Gallery_Operate.SetActive(true);
       //MenuScreen.SetActive(false);
    }
    public void Back()
    {
     
        Gallery_Operate.SetActive(false);
        MenuScreen.SetActive(true);
    }

   

    
}

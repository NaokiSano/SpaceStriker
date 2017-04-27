using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialImage : MonoBehaviour {

    Image image;
    int imageNum;
    public Sprite[] TutorialImages;
    public GameObject CanvasImage;

	// Use this for initialization
	void Start () {
        image = CanvasImage.GetComponent<Image>();
        imageNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(imageNum == 3)
        {
            Application.LoadLevel("Menu");
        }
	}

    public void ButtonPush()
    {
        if (imageNum <= 2)
        {
            imageNum++;

            if(imageNum <= 2)
            image.sprite = TutorialImages[imageNum];

        }

        if (imageNum == 2)
        {
            this.GetComponentInChildren<Text>().text = "Return";
        }
    }
}

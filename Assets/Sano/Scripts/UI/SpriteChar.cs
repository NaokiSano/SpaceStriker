using UnityEngine;
using System.Collections;

public class SpriteChar : MonoBehaviour {

    public void SetChar(int id)
    {
        string name = "Timer" + id;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprite/321");
        Sprite sp = System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(name));
        sr.sprite = sp;
    }

}

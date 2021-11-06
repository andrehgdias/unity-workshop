using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
{
    Image myImage;
    public EnemyController myEnemy;

    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        transform.parent.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(myEnemy.transform.position.x, myEnemy.transform.position.y + 3, myEnemy.transform.position.z);
        myImage.fillAmount = (float)myEnemy.vida / 10.0f;
    }
}

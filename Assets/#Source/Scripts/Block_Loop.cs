using UnityEngine;
using System.Collections;

public class Block_Loop : MonoBehaviour {

    public float Speed = 7f;

    public GameObject[] Blocks;

    public GameObject A_Zone;
    public GameObject B_Zone;

    public GameManager GM;

    void Update() { move();}

    void move() {

        Speed = 7 + (GM.meter / 40);
        A_Zone.transform.Translate(Vector3.left * Speed * Time.deltaTime);
        B_Zone.transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if(B_Zone.transform.position.x <= 0) {
            Destroy(A_Zone);
            A_Zone = B_Zone;
            make();
        }
    }

    void make() {

        int seed = Random.Range(0, Blocks.Length);

        B_Zone = Instantiate(Blocks[seed], new Vector3(B_Zone.transform.position.x+30, -5, 0), transform.rotation) as GameObject;
    }

}

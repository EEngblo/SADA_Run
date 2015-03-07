using UnityEngine;
using System.Collections;

public enum PlayerState {
    Run,
    Jump,
    DJump,
    Death
}

public class Player_Ctrl : MonoBehaviour {
	
    public PlayerState PS;
    public float Jump_Power = 600f;
    public AudioClip[] Sound;
    public Animator animator;

    public GameObject AnotherSpeaker;
    public GameManager GM;

    void Start () {
	
	}
	
	void Update () {

        rigidbody.WakeUp();

        if(Input.GetKeyDown(KeyCode.Space) && PS != PlayerState.Death) {

            if(PS == PlayerState.Run) {
                Jump();
            } else 
            if(PS == PlayerState.Jump) {
                DJump();
            }
        }

        if(Input.touchCount > 0) {
            if(Input.GetTouch(0).phase == TouchPhase.Began) {
                if(PS == PlayerState.Run) {
                    Jump();
                } else
                if(PS == PlayerState.Jump) {
                    DJump();
                }
            }
        }
        
    }

    void OnCollisionEnter(Collision collision) {

        if(PS != PlayerState.Run && PS != PlayerState.Death) {

            Run();
        }
    }

    void Jump() {
        PS = PlayerState.Jump;
        AnotherSpeaker.SendMessage("SoundPlay");
        rigidbody.AddForce(new Vector3(0,Jump_Power,0));
        animator.SetTrigger("Jump");
        animator.SetBool("Ground", false);
    }

    void DJump() {
        PS = PlayerState.DJump;
        AnotherSpeaker.SendMessage("SoundPlay");
        rigidbody.AddForce(new Vector3(0, Jump_Power/2, 0));
        animator.SetTrigger("DJump");
        animator.SetBool("Ground", false);
    }


    void OnTriggerEnter(Collider other) {

        rigidbody.WakeUp();

        if(other.gameObject.name == "Coin") {
            Destroy(other.gameObject);
            GetCoin();
        }

        if(other.gameObject.name == "DeathZone" && PS != PlayerState.Death) {
            GameOver();
        }
    }

    void Run() {
        PS = PlayerState.Run;
        animator.SetBool("Ground", true);
    }

    void GetCoin() {
        SoundPlay(0);
        GM.GetCoin();
    }

    void GameOver() {
        SoundPlay(1);
        PS = PlayerState.Death;

        GM.GameOver();
    }

    void SoundPlay(int num) {
        audio.clip = Sound[num];
        audio.Play();
    }


}

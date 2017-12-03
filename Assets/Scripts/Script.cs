using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour {

    public int[] targets;
    public Text pressesText;
    public Text targetPressesText;
    public AudioSource click;
    public float minClickPitch, maxClickPitch;

    private int presses;
    private int targetIndex;
    private bool gameOver;

    void Update() {
        if(gameOver) {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            presses += 1;
            click.pitch = Random.Range(minClickPitch, maxClickPitch);
            click.Play();
        }

        pressesText.text = "Presses: " + presses.ToString();
        targetPressesText.text = "Target Presses: " + targets[targetIndex].ToString();
        
        if(presses >= targets[targetIndex]) {
            targetIndex += 1;
            if(targetIndex >= targets.Length) {
                gameOver = true;
                pressesText.text = "Yay";
            }
        }
    }
}
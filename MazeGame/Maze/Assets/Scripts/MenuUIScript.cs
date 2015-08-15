using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuUIScript : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas singlePlayerMenu;
	public Button playText;
	public Button exitText;
	public Slider mazeSizeSlider;
	public Text mazeSizeText;

	void Start () {
		singlePlayerMenu = singlePlayerMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		playText = playText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		mazeSizeText = mazeSizeText.GetComponent<Text> ();
		singlePlayerMenu.enabled = false;
		quitMenu.enabled = false;

		mazeSizeSlider.value = (float)MazeGenerator.currentSize;
	}
	
	public void exitPressed() {
		quitMenu.enabled = true;
		playText.enabled = false;
		exitText.enabled = false;
	}

	public void noPressed() {
		quitMenu.enabled = false;
		playText.enabled = true;
		exitText.enabled = true;
	}

	public void singlePlayerPressed() {
		singlePlayerMenu.enabled = true;
		playText.enabled = false;
		exitText.enabled = false;
	}
	
	public void singlePlayerCancel() {
		singlePlayerMenu.enabled = false;
		playText.enabled = true;
		exitText.enabled = true;
	}

	public void sliderChanged() {
		int mazeSize = (int)mazeSizeSlider.value;
		mazeSizeText.text = "Size of Maze: " + mazeSize;
		MazeGenerator.resetMaze (mazeSize);
	}

	public void startlevel() {
		Application.LoadLevel (1);
	}

	public void exitGame() {
		Application.Quit ();
	}
}

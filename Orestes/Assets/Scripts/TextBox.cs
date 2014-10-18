using UnityEngine;
using System.Collections;

public class TextBox : MonoBehaviour {

	public string texto;
	public float delay = 0.02f;
	string output = "";
	int cont = 0;
	static int size = 25;
	int x = size;
	int y = Screen.height - 3*size;
	int w = Screen.width - 2*size;
	int h = 3*size;
	bool flag = true;

	void OnGUI() {
		//GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		//myStyle.alignment = TextAnchor.UpperLeft;

		//GUI.color = Color.yellow;

		//muda as configuracoes da GUI
		GUI.skin.box.fontSize = size;
		GUI.skin.box.normal.textColor = Color.yellow;
		GUI.skin.box.alignment = TextAnchor.UpperLeft;
		//cria a caixa de texto
		GUI.Box(new Rect(x, y, w, h), output);
	}

	IEnumerator TypeText() {
		foreach (char letra in texto.ToCharArray()){
			//quebra de linha
			if( (cont)*(size+1) >= 2*w && flag){
				output += '\n';
				cont = 0;
				flag = false;
			}
			//recomeca a linha
			else if((cont)*(size+1) >= 2*w && !flag){
				output = "";
				cont = 0;
				flag = true;
			}

			cont++;
			output += letra;

			//delay da impressao do texto
			yield return new WaitForSeconds (delay);
		}
	}

	void Start(){
		StartCoroutine(TypeText());
	}
}
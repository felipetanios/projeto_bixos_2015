using UnityEngine;
using System.Collections;

public class TextBox : MonoBehaviour {
	public string texto;
	public float delay = 0.02f;

	static int size = 25;
	
	int x = 5;
	int y = Screen.height - 3*size;
	int w = Screen.width - 3*size;
	int h = 3*size;
	
	int cont = 0;
	bool flag = true;
	string output = "";
	
	bool paused = false;
	
	void pause()
	{
		paused = !paused ;
		Time.timeScale = paused ? 0 : 1 ;
	}

	void OnGUI() {
		//GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		//myStyle.alignment = TextAnchor.UpperLeft;

		GUI.color = Color.yellow;
		
		//pausa/despausa o texto caso clique 
		if(!GUI.Button(new Rect(x+w+5, y, 2*size+10, h), "Click"))
		{
			pause();
		}

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
			//pausa antes de limpar
			else if((cont+1)*(size+1) >= 2*w && !flag){
				pause();
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
	
	void Update(){
		
	}
}
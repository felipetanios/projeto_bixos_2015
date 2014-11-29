using UnityEngine;
using System.Collections;

public class TextBox : MonoBehaviour {
	static string[] texto = {	"Texto1", "Texto2", "Texto3", "Texto4", "Texto5", 
		"Texto6", "Texto7", "Texto8", "Texto9", "Texto10"};
	int numDeTextos = 10;
	public float delay = 0.1f;
	
	static int size = 25;
	
	int x = 5;
	int y = Screen.height - 3*size;
	int w = Screen.width - 3*size;
	int h = 3*size;
	
	public int textNumber=0;
	
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
		
		//muda as configuracoes da GUI
		GUI.skin.box.fontSize = size;
		GUI.skin.box.normal.textColor = Color.yellow;
		GUI.skin.box.alignment = TextAnchor.UpperLeft;
		//cria a caixa de texto
		GUI.Box(new Rect(x, y, w, h), output);
		
		//pausa/despausa o texto caso clique 
		if(!GUI.Button(new Rect(x+w+5, y, 2*size+10, h), "Click"))
		{
			pause();
		}
		
	}
	
	IEnumerator TypeText() {
		char letra;
		int cont = 0;
		int i;
		
		for (i = 0; textNumber < numDeTextos; i++){
			//acabou o texto atual
			
			if(i+1 == texto[textNumber].Length )
				pause ();
			
			else if(i == texto[textNumber].Length)
			{
				textNumber++;

				output = "";
				flag = true;
				i = -1;
				cont = 0;
				
				continue;
			}
			
			letra = texto[textNumber][i];
			
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
			else if((cont+1)*(size+1) >= 2*w && !flag && !paused){
				pause ();
			}
			
			output += letra;
			cont++;
			
			//delay da impressao do texto
			yield return new WaitForSeconds (3*delay);
		}
	}
	
	void Start(){
		StartCoroutine(TypeText());
	}
	
	void Update(){
		
	}
}
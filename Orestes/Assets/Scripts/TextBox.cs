using UnityEngine;
using System.Collections;

public class TextBox : MonoBehaviour {
	public float delay = 0.05f;
	static int size = 25;
	
	int x = 2*size;
	int y = Screen.height - 3*size;
	int w = Screen.width - 4*size;
	int h = 3*size;
	
	public string texto;
	string output = "";
	int cont = 0;
	bool flag = true;
	
	void Start ()
	{
		StartCoroutine(TypeText());
	}
	
	IEnumerator TypeText () 
	{
		foreach (char letra in texto.ToCharArray()) 
		{
			//quebra a linha
			if(cont*(size) >= 2*w && flag)
			{
				cont = 0;
				output += '\n';
				flag = false;
			}//limpa e recomeca
			else if(cont*(size) >= 2*w && !flag)
			{
				cont = 1;
				output = "";
				flag = true;
			}
			
			cont++;
			output += letra;
			yield return new WaitForSeconds (delay);
		}
	}
	
	
	void OnGUI () {
		
		GUI.Box(new Rect(x, y, w, h), output);
	}
	
}
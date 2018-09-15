using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Xml;
using System.Xml.Serialization;
using SFB;
using System;
using Newtonsoft.Json;

public class UIFunctions : MonoBehaviour {
	// Use this for initialization
	string defpath;
	void Start()
	{
	defpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\openstone";
    Directory.CreateDirectory(defpath);
	//if(File.Exists(defpath + @"\normalloc.txt"))
	//{
	//	defpath = File.ReadAllText(defpath + @"\normalloc.txt");
	//}
	print(defpath);
	
	}
	private string _path;
	string sSelectedFile;
	void GoToGithub()
	{
    Process.Start("https://github.com/Kawarimi/openstone");
	}
	void ChangeToMatch()
	{
    SceneManager.LoadScene("Game");
	}
	void ChangeToDecks()
	{
    SceneManager.LoadScene("DeckManager");
	}
	void ChangeToSettings()
	{
	SceneManager.LoadScene("Settings");
	}
	void ImportCardsDeckManager(){       
	WriteResult(StandaloneFileBrowser.OpenFolderPanel("Select Pack Folder", "", false));
	//string infojson = File.ReadAllText(_path + @"\packinfo.json");
	string images = _path + @"\images";
	string scripts = _path + @"\scripts";
	string packs = _path + @"\packs";
	string json = packs + @"\cardpack.json";
    Cardjson card = JsonConvert.DeserializeObject<Cardjson>(json);
	print(card.atk);
	}
	void DefineSaveLocation(){
	//WriteResult(StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false));
	
	//try{File.Delete(defpath + @"\normalloc.txt");}
	//catch(Exception ex){print(ex);}
	
	//using (StreamWriter sw = File.CreateText(defpath + @"\normalloc.txt")){sw.Write(_path);}
	//defpath = File.ReadAllText(defpath + @"\normalloc.txt");
	//print(defpath);
	}
	public void WriteResult(string[] paths) {
        if (paths.Length == 0) {
            return;
        }

        _path = "";
        foreach (var p in paths) {
            _path += p + "\n";
        }
		print(_path);
    }
}
public class Cardjson
{
    public int atk;
	public int hp;
	public string name;
	public string img;
}
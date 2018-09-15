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
using TMPro;

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
	string infojson = File.ReadAllText(_path + @"\packinfo.json");
	string images = _path + @"\images";
	string cardjson = File.ReadAllText(_path + @"\packs\cardpack.json");
	List<Cardjson> card = JsonConvert.DeserializeObject<List<Cardjson>>(cardjson);
    PackInfo packinfo = JsonConvert.DeserializeObject<PackInfo>(infojson);
	print(card.atk);
    TextMeshProUGUI infotext = GameObject.Find("Info").GetComponent<TextMeshProUGUI>();
    infotext.text = packinfo.name+"\n"+packinfo.desc+"\n v"+packinfo.version;
	}
	void DefineSaveLocation(){
	//WriteResult(StandaloneFileBrowser.OpenFolderPanel("Select Save Folder", "", false));
	
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
            _path += p;
        }
		print(_path);
    }
}
public class Cardjson : IEquatable<Cardjson>
{
    public int atk{get;set;}
	public int hp{get;set;} 
	public string name{get;set;}
	public string description{get;set;} 
	public string img{get;set;}

    public bool Equals(Cardjson other)
    {
        throw new NotImplementedException();
    }
}
public class PackInfo
{
    public string name { get; set; }
    public string desc { get; set; }
    public string version { get; set; }
}
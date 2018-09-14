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

public class UIFunctions : MonoBehaviour {
	// Use this for initialization
	string defpath;
	void Start()
	{
	defpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\openstone";
    Directory.CreateDirectory(defpath);
	if(File.Exists(defpath + @"\normalloc.txt"))
	{
		defpath = File.ReadAllText(defpath + @"\normalloc.txt");
	}
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
	WriteResult(StandaloneFileBrowser.OpenFilePanel("Select File", "", "xml", true));   
	}
	void DefineSaveLocation(){
	WriteResult(StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", false));   
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

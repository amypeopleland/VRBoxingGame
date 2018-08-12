using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class IPStream{

    public string ReadIP()
    {
        FileStream _file = new FileStream(Application.persistentDataPath + "//IpAddress.info", FileMode.OpenOrCreate);
        Debug.Log(Application.persistentDataPath);
        StreamReader _sr = new StreamReader(_file);
        string _ip = _sr.ReadLine();
        _sr.Close();
        return _ip;
    }

    public void WriteIP(string _ip)
    {
        FileStream _file = new FileStream(Application.persistentDataPath + "//IpAddress.info", FileMode.OpenOrCreate);
        StreamWriter _sw = new StreamWriter(_file);
        _sw.WriteLine(_ip);
        _sw.Close();
    }
}

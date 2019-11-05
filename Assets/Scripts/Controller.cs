using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

public class Controller : MonoBehaviour
{
    //phases
    public GameObject sn_login;
    public GameObject sn_search;
    public GameObject sn_Menu1;
    public GameObject sn_Menu1_default;
    public GameObject sn_Menu1_record;
    public GameObject sn_Menu2;
    public GameObject sn_sp1;
    public GameObject sn_sp2;
    public GameObject sn_sp3;
    public GameObject sn_dis;
    public GameObject sn_jin;
    public GameObject sn_exc;
    public GameObject Pan_check;

    public InputField InputF_name;

	string filePath;
	string Metadata;
	int Meta_len;
    string[] Meta_records;


    public GameObject record_list;
    public GameObject prefabs_name_date;
    public GameObject[] obj_records;

    List<string[]> Meta_list;
    //login id
	string name_id;

    //personal
    public GameObject person_record_list;
    public GameObject prefabs_record;
    public GameObject[] obj_person_record;
    List<string> person_meta_list;
    int person_meta_len;

    //jindan id
    string jindan_id;

    public JindanData jdata = new JindanData();
    public JindanData jdata_prev = new JindanData();

    //사용자 입력값

    public void ReturnLogin()
    {
        for(int i = 0; i < Meta_len; i++)
        {
            Destroy(obj_records[i]);
        }
        Metadata = System.IO.File.ReadAllText(filePath + "/Metadata.txt", Encoding.Default);
        Metadata = Metadata.Remove(0, Metadata.IndexOf('\n') + 1);
        Meta_records = Metadata.Split('\n');
        Meta_len = Meta_records.Length - 1;
        Debug.Log(Metadata);

        Meta_list = new List<string[]>();

        for (int i = 0; i < Meta_len; i++)
        {
            obj_records[i] = Instantiate(prefabs_name_date);
            obj_records[i].transform.SetParent(record_list.transform);
            string[] record = Meta_records[i].Split(',');
            Meta_list.Add(record);
            Debug.Log(record);
            obj_records[i].GetComponent<Login_record>().SetNameDate(record[0], record[1]);

        }
        jdata_prev.Initailize("");
        jdata.Initailize("");
    }

	private void Start()
	{

		//메타데이터 로딩
		if (Application.platform == RuntimePlatform.Android)
		{
            filePath = Application.persistentDataPath + "/Data"; 
		}
		else
		{
            filePath = "Data";
		}
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        if(!File.Exists(filePath + "/Metadata.txt"))
        {
            System.IO.File.WriteAllText(filePath + "/Metadata.txt", "Metadata\n", Encoding.Default);
        }

        Metadata = System.IO.File.ReadAllText(filePath + "/Metadata.txt", Encoding.Default);
        Metadata = Metadata.Remove(0, Metadata.IndexOf('\n') + 1);
		Meta_records = Metadata.Split('\n');
		Meta_len = Meta_records.Length - 1;

        Meta_list = new List<string[]>();
        for (int i = 0; i < Meta_len; i++)
		{
            obj_records[i] = Instantiate(prefabs_name_date);
            obj_records[i].transform.SetParent(record_list.transform);
            string[] record = Meta_records[i].Split(',');
            Meta_list.Add(record);
            obj_records[i].GetComponent<Login_record>().SetNameDate(record[0], record[1]);

        }
        jdata_prev.Initailize("");
        jdata.Initailize("");

    }


    public void save()
    {
        int ishave = 0;
        string[] r = jindan_id.Split('_');
        savebinary(filePath + "/" + name_id + "/" + jindan_id, jdata);
        for(int i = 0; i< Meta_list.Count; i++)
        {
            Debug.Log(Meta_list[i][0]);
            if(Meta_list[i][0] == name_id)
            {
                List<string> temp = new List<string>();
                temp.Add(Meta_list[i][1]);
                temp.Add(r[1]);
                temp.Sort();
                Meta_list[i][1] = temp[1];
                ishave = 1;
                break;
            }
        }
        if(ishave == 0)
        {
            Meta_list.Add(r);
        }
        //Meta_list.Sort();
        string s = "Metadata\n";
        for(int i = 0; i < Meta_list.Count; i++)
        {
            s = s + Meta_list[i][0] + "," + Meta_list[i][1] + "\n";
        }
        System.IO.File.WriteAllText(filePath + "/Metadata.txt", s, Encoding.Default);
        Pan_check.gameObject.SetActive(true);
    }

    //진단 저장, 불러오기
    public void savebinary(string path, JindanData jd)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.OpenOrCreate);
        bf.Serialize(file, jd);
        file.Close();
        SavePersonMeta();

    }

    public void loadbinary(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);
        jdata = (JindanData)bf.Deserialize(file);
        file.Close();
    }

    public void loadprevbinary(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);
        jdata_prev = (JindanData)bf.Deserialize(file);
        file.Close();
    }

    public void SavePersonMeta()
    {
        if (!File.Exists(filePath + "/" + name_id + "/Metadata.txt"))
        {
            System.IO.File.WriteAllText(filePath + "/" + name_id + "/Metadata.txt", "", Encoding.Default);
        }
        string MetaString = "Metadata\n";

        for(int i =0; i < person_meta_list.Count; i++)
        {
            MetaString = MetaString + person_meta_list[i] + "\n";
        }

        System.IO.File.WriteAllText(filePath + "/" + name_id + "/Metadata.txt", MetaString);
    }

    //로그인

	public string get_name()
	{
		return name_id;
	}

    public void Login_by_name()
    {
        if(InputF_name.text == "")
        {
            return;
        }
        else
        {
            Login(InputF_name.text);
        }
    }


	public void Login(string s)
	{
        for(int i = 0;i < person_meta_len; i++)
        {
            Destroy(obj_person_record[i]);
        }
		name_id = s;
        if(name_id.Length < 2)
        {
            return;
        }
        if (!Directory.Exists(filePath + "/" + name_id))
        {
            Directory.CreateDirectory(filePath + "/" + name_id);
        }
        if (!File.Exists(filePath + "/" + name_id + "/Metadata.txt"))
        {
            System.IO.File.WriteAllText(filePath + "/" + name_id + "/Metadata.txt", "Metadata\n", Encoding.Default);
        }

        Metadata = System.IO.File.ReadAllText(filePath + "/" + name_id + "/Metadata.txt", Encoding.Default);
        Metadata = Metadata.Remove(0, Metadata.IndexOf('\n') + 1);
        Meta_records = Metadata.Split('\n');
        person_meta_len = Meta_records.Length - 1;

        person_meta_list = new List<string>();

        for(int i = 0; i < person_meta_len; i++)
        {
            person_meta_list.Add(Meta_records[i]);
        }
        person_meta_list.Sort();
        person_meta_list.Reverse();
        for(int i = 0; i < person_meta_len; i++)
        {
            obj_person_record[i] = Instantiate(prefabs_record);
            obj_person_record[i].transform.SetParent(person_record_list.transform);
            //obj_person_record[i].gameObject.SetActive(true);
            obj_person_record[i].GetComponent<Choose_by_person_record>().SetDate(person_meta_list[i]);
        }
        //최근 진단 기록 로드
        if(person_meta_len > 0)
        {
            //Debug.Log(person_meta_list[0]);
            loadprevbinary(filePath + "/" + name_id + "/" + person_meta_list[0]);
            //Debug.Log(jdata_prev.sh[0].main_harm);
        }
        else
        {
            //jdata_prev.Initailize("");
        }
        sn_search.gameObject.SetActive(false);
        sn_Menu1.gameObject.SetActive(true);
        sn_login.gameObject.SetActive(false);

    }

    public void ReLogin()
    {
        Login(name_id);
    }

    //진단서 선택

    public void Chojin()
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        //Debug.Log(time);
        string filename = name_id + "_" + time;
        //jdata_prev.Initailize(filename);
        SetJindan(filename);
    }

    public void SetJindan(string s)
    {
        jindan_id = s;
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(filePath + "/" + name_id + "/" + jindan_id))
        {
            person_meta_list.Add(jindan_id);
            jdata.Initailize(s);
            //jdata_prev.Initailize(s);
            //savebinary(filePath + "/" + name_id + "/" + s, jdata);
        }
        else
        {
            loadbinary(filePath + "/" + name_id + "/" + jindan_id);
        }

        sn_Menu1_record.SetActive(false);
        sn_Menu1_default.SetActive(true);
        sn_Menu1.SetActive(false);
        sn_Menu2.SetActive(true);

    }
    public void ReturnHome()
    {
        sn_login.SetActive(true);
        sn_Menu1.SetActive(false);
        sn_Menu2.SetActive(false);
        sn_sp1.SetActive(false);
        //sn_sp2.SetActive(false);
        //sn_sp3.SetActive(false);
        sn_dis.SetActive(false);
        sn_exc.SetActive(false);
        sn_jin.SetActive(false);
        Pan_check.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}

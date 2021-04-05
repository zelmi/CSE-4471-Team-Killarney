using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class EmployeeDataLoader : MonoBehaviour
{
    public GameObject employeeTransformParent;
    public GameObject employeeEntry;

    // Start is called before the first frame update
    void Start()
    {
        XmlSerializer serialize = new XmlSerializer(typeof(EmployeeData));
        FileStream file = new FileStream(Application.streamingAssetsPath + "/Data/employeedata.xml", FileMode.Open);
        EmployeeData data = (EmployeeData)serialize.Deserialize(file);

        //Add messages
        for (int i = 0; i < data.employeeList.Count; i++)
        {
            GameObject messageObj = Instantiate(employeeEntry, employeeTransformParent.transform);
            messageObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, - 15 * i, 0);
            messageObj.transform.GetChild(0).GetComponent<TMP_Text>().SetText(data.employeeList[i].name);
            messageObj.transform.GetChild(1).GetComponent<TMP_Text>().SetText(data.employeeList[i].email);
            messageObj.transform.GetChild(2).GetComponent<TMP_Text>().SetText(data.employeeList[i].role);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

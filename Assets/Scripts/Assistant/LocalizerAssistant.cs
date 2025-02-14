using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LocalizerAssistant : MonoBehaviour
{
    [SerializeField] private TextAsset _xmlFile;

    private static Dictionary<string, List<string>> _localization;

    private void Awake()
    {
        LoadLocalization();
    }

    public static string GetText(string key, int language = 0)
    {
        if (_localization.ContainsKey(key))
            return _localization[key][language];

        return key;
    }

    private void LoadLocalization()
    {
        _localization = new Dictionary<string, List<string>>();

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(_xmlFile.text);

        foreach (XmlNode key in xmlDocument["Keys"].ChildNodes)
        {
            string keyValue = key.Attributes["Name"].Value;

            var values = new List<string>();

            foreach (XmlNode translate in key["Translate"])
            {
                values.Add(translate.InnerText);
            }

            _localization[keyValue] = values;
        }
    }

}

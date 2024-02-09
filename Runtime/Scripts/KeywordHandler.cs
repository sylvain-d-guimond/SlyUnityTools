#if UNITY_WSA
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;
using System.Linq;

public class KeywordHandler : MonoBehaviour
{
    [SerializeField]
    private List<KeywordAction> _actions;

    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        var words = new List<string>();
        foreach (var action in _actions) { words.Add(action.Phrase); }
        m_Recognizer = new KeywordRecognizer(words.ToArray());
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());

        _actions.Where(x => args.text == x.Phrase).First().Event.Invoke();
    }
}

[Serializable]
public struct KeywordAction
{
    public string Phrase;
    public UnityEvent Event;
}
#endif
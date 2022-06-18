using System.Collections.Generic;
using UnityEngine;

namespace PITask.Stats
{
    [CreateAssetMenu(fileName = "Stats Dictionary")]
    public class StatsDictionary : ScriptableObject
    {
        [SerializeField] private List<Stat> Stats;

        public float GetStat(string stat) => Stats.Find(x => x.Name.Equals(stat)).Value;
    }

    [System.Serializable]
    public struct Stat
    {
        [SerializeField] private string _name;
        [SerializeField] private float _value;

        public readonly string Name => _name;
        public readonly float Value => _value;
    }
}

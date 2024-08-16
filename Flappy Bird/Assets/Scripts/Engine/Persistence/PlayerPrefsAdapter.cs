using UnityEngine;

namespace JGM.Engine
{
    public class PlayerPrefsAdapter : IPersistenceService
    {
        public int LoadInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }
}
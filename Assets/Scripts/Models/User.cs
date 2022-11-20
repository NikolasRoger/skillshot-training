using System;

namespace MTModels
{
    [Serializable]
    public class User
    {
        public int id;

        public string email;

        public string name;

        public DateTime created_at;
        public DateTime updated_at;

        public int bestScore;
        public int rank;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}


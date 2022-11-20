using System;

namespace MTModels
{
    [Serializable]
    public class Ranking
    {
        public int id;

        public int userId;

        public int score;

        public DateTime created_at;

        public DateTime updated_at;

        public User user;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}


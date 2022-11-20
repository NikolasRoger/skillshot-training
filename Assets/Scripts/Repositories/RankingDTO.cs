using System;
using MTModels;
namespace RankingDTO
{
    [Serializable]
    public class SaveRankingRequest
    {
        public int score;
    }

    [Serializable]
    public class SaveRankingResponse
    {
        public Ranking score;
        public Ranking best;
    }
}


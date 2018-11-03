using System;

namespace Repository.Schema
{
    public class GameLineModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        /// <summary>
        /// 1 for dunk
        /// 0 for miss
        /// </summary>
        public int Score { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
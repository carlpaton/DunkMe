using System;

namespace Repository.Schema
{
    public class GameModel
    {
        public int Id { get; set; }
        public int GameTypeId { get; set; }
        public DateTime InsertDate { get; set; }
    }

    public class GameLineModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        /// <summary>
        /// 1 if the ball goes in
        /// 0 if it misses
        /// verbose logging like this will make reporting easier and leave nothing to interpretation
        /// </summary>
        public int Score { get; set; }
        public DateTime InsertDate { get; set; }
    }
}

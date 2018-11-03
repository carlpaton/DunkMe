using System;

namespace Repository.Schema
{
    public class GameModel
    {
        public int Id { get; set; }
        public int GameTypeId { get; set; }
        public int PlayerId { get; set; }
        public DateTime InsertDate { get; set; }
    }
}

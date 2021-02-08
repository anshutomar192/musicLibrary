using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroMusic.BOL.Model
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string Language { get; set; }
        public string SingerName { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
    }
}

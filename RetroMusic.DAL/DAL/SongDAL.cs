
using RetroMusic.Entity.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace RetroMusic.DAL.DAL
{
   public class SongDAL
    {
        RetroDatabaseEntities1 objRetroDbEntity = new RetroDatabaseEntities1();
        public SongDAL()
        {
            objRetroDbEntity = new RetroDatabaseEntities1();

        }
        public List<RetroMusic.BOL.Model.Song> GetLibraries()
        {
            var songsList= (from songItems in objRetroDbEntity.Songs
                           select new RetroMusic.BOL.Model.Song
                           {
                               SongName = songItems.SongName,
                               SongId = songItems.SongId,
                               Language = songItems.Language,
                               Description = songItems.Description,
                               Year = songItems.Year,
                               AlbumName = songItems.AlbumName,
                               SingerName = songItems.Artist,
                           });
            return songsList.ToList();
        }

        public RetroMusic.BOL.Model.Song GetLibraryDetail(int SongId)
        {
            var detail = (from songItems in objRetroDbEntity.Songs
                          where songItems.SongId.Equals(SongId)
                          select new RetroMusic.BOL.Model.Song
                          {
                              SongName = songItems.SongName,
                              SongId = songItems.SongId,
                              Language = songItems.Language,
                              Description = songItems.Description,
                              Year = songItems.Year,
                              AlbumName = songItems.AlbumName,
                              SingerName = songItems.Artist,
                          });

            RetroMusic.BOL.Model.Song objSong = detail.FirstOrDefault();
             return objSong;
        }

        public void UpdatePurchase(string songName, string email)
        {
            PurchasedSong objPurchasedSong = new PurchasedSong()
            {
                SongName = songName,
                Email = email
            };
            objRetroDbEntity.PurchasedSongs.Add(objPurchasedSong);
            objRetroDbEntity.SaveChanges();
           
        }
      
    }
}

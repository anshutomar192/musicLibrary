using RetroMusic.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace RetroMusic.BAL.Song
{
   public class SongBuilder
       
    {
        HttpContext httpContext = HttpContext.Current;
        public DataTable GetViewedLibraries()
        {
            DataTable table = httpContext.ApplicationInstance.Session["VisitedSong"] as DataTable;
            if (table != null)
            {
                table = table.AsEnumerable()
            .GroupBy(r => new { SongName = r.Field<string>("SongName") })
            .Select(g => g.First())
            .CopyToDataTable();
                return table;
            }
            else
                return new DataTable();
        }

        public List<RetroMusic.BOL.Model.Song> GetLibraries()
        {
            return new SongDAL().GetLibraries();
        }

        public void UpdatePurchase(string songName, string email)
        {
            new SongDAL().UpdatePurchase(songName, email);
           
        }

        public RetroMusic.BOL.Model.Song GetLibraryDetail(int SongId)
        {
            RetroMusic.BOL.Model.Song detail= new SongDAL().GetLibraryDetail(SongId);
            
            if (httpContext.ApplicationInstance.Session["VisitedSong"] != null)
            {
                DataTable datatable = (DataTable)httpContext.ApplicationInstance.Session["VisitedSong"];
                datatable.Rows.Add(detail.SongName);
            }
            else
            {
                DataTable datatable = new DataTable();
                datatable.Columns.Add(new DataColumn("SongName"));
                datatable.Rows.Add(detail.SongName);
                httpContext.ApplicationInstance.Session["VisitedSong"] = datatable;
            }
            return detail;
        }

    }
}

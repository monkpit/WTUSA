using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Dapper;
using DapperExtensions;
using WTCOMPLib;
using WinToolAG.Base;

namespace WTUSA
{
    public class WTPicture : IWTItem
    {
        private WinToolAG.Base.WTComp wtc;
        private IWTItem _parentItem;
        //private string _filename;

        public WTPicture(IWTItem parent)
        {
            if (parent != null)
            {
                _parentItem = parent;
                var wtreg = new WTRegistry();
                wtc = WTUSA.WTUSA_WTComp.GetComponentDrawing((int)_parentItem.PKID);
                var wtcon = WTConnection.GetConnection();
                //_filename = wtcon.Query("select partpics.dxffullfilename from partpics inner join parts on partpics.id = parts.partpicid where parts.id = @partId", new { partId = _parentItem.PKID }).First();

                Filename = wtcon.Query<string>("select partpics.dxffullfilename from partpics inner join parts on partpics.[id] = parts.partpicid where parts.[id] = @partsID", new { partsID = _parentItem.PKID }).Single();
            }
            else
            {
                _parentItem = null;
            }
        }

        public string Filename
        {
            get; set;
        }

        ~WTPicture()
        {
            //Marshal.ReleaseComObject(wtc);
        }

        public void WritePictureFromDXF(string filename)
        {
            var wtreg = new WTRegistry();
            WTUSA.WTUSA_WTComp.WriteDXFToComponent(filename,(string)_parentItem.PKID);
        }

        
        public override string IdOrNr()
        {
            //PartPic uses "ID"
            return "ID";
        }

        public override void Show()
        {
            //show the picture window
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}

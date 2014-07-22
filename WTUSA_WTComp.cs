using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Dapper;
using DapperExtensions;

namespace WTUSA
{
    public static class WTUSA_WTComp
    {
        public static WinToolAG.Base.WTComp GetComponentDrawing(string componentIDString)
        {
            return GetComponentDrawing(Int32.Parse(componentIDString));
        }

        public static WinToolAG.Base.WTComp GetComponentDrawing(int componentID)
        {
            var returnWTComp = new WinToolAG.Base.WTComp();
            returnWTComp.set_bin_data(GetPic(componentID));
            return returnWTComp;
        }

        private static byte[] GetPic(int componentID)
        {
            return WTConnection.GetConnection().Query<byte[]>(
                "select partpics.picdetail from partpics inner join parts on partpics.id = parts.partpicid where parts.id = @partsID",
                new { partsID = componentID }).Single();
            
            //select partpics.picdetail from partpics inner join parts on partpics.id = parts.partpicid where parts.id = @componentID
        }

        public static void WriteDXFToComponent(string dxfFileName, string componentID, string wtCompXML = null, WinToolAG.Base.DXFMetaFileGeometry mfg = null)
        {
            WinToolAG.Base.WTComp wtc = new WinToolAG.Base.WTComp();

            if (wtCompXML == null)
                wtCompXML = new WTRegistry() + "WTComp.xml";
            if (mfg == null)
                mfg = new WinToolAG.Base.DXFMetaFileGeometry(0, 0, 0, 0);

            dynamic byteArray = wtc.read_dxf(dxfFileName, WinToolAG.Base.DXFViewConfig.PicDetail, wtCompXML);
            

            //update partpics set partpics.picdetail = [byte stream] where partpics.id = (select partpics.id from partpics inner join parts on partpics.id = parts.partpicid where parts.id = [selected component id])
            dynamic results = WTConnection.GetConnection().Execute("update partpics set partpics.picdetail = @picBytes where partpics.id = " +
                "(select partpics.id from partpics inner join parts on partpics.id = parts.partpicid where parts.id = @partID)", new { picBytes = byteArray, partID = componentID });
            if (results == 0)
            {
                throw new ArgumentException("No rows were updated while trying to write new DXF.");
            }
        }
    }
}

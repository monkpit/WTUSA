using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Dapper;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace WTUSA
{
    
    public class WTRegistry
    {
        //private wtVersionSpecificRegistryInfo = @"Software\Datos\WinTool"; //2013
        public const string wtVersionSpecificRegistryInfo = @"Software\WinTool\WinTool"; //2014
        private RegistryKey pRegKey;
        public enum RegistryItem
        {
            WTGUID,
            UserName,
            WTIsReady,
            CNCIsReady,
            LVal,
            SentinelSerial,
            LValCNC,
            ActiveCutDataNrT,
            ActiveMaskNr,
            SelFilter,
            ActivePartPicID,
            ActiveActionTypeNr,
            ActiveActionNr,
            ActiveCutDataNrP,
            ActiveMatchCodeID,
            ActiveNCObjectFileNr,
            ActiveMachineNr,
            ActiveJobMasterId,
            ActiveNCFolderNr,
            ActiveCommissionNr,
            ActiveRoleActionAccountNr,
            ActiveToolListNr,
            ActivePartID,
            ActiveGroupTreeID,
            ActiveToolListEntryNr,
            ActiveToolNr,
            Connection
        };
        
        public object this[RegistryItem item]
        {
            get
            {
                string tempName = Enum.GetName(typeof(RegistryItem), item);
                return pRegKey.GetValue(tempName);
            }
            set
            {
                pRegKey.SetValue((string)Enum.GetName(typeof(RegistryItem), item), value);
            } 
        }

        public WTRegistry()
        {
            pRegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(wtVersionSpecificRegistryInfo + @"\Settings\Temp", true);
        }
        
        public byte[] GetBytesFromRegistry()
        {
            var bFromArray = (byte[])pRegKey.GetValue("Connection");
            bFromArray = Encryption.AES_Decrypt(bFromArray);
            return bFromArray;
        }

        public void WriteBytesToRegistry(SqlConnectionStringBuilder csbuilder)
        {
            byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(csbuilder.ConnectionString);
            bytes = Encryption.AES_Encrypt(bytes);
            (new WTRegistry())[RegistryItem.Connection] = bytes;
        }

        //    WriteBytesToRegistry(csbuilder As SqlConnectionStringBuilder)
        //    Dim bytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(csbuilder.ConnectionString)
        //    bytes = WTLicense.AES_Encrypt(bytes, password)
        //    TempSetting(RegistryItem.Connection) = bytes

        public string WinToolAppPath()
        {
            return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(wtVersionSpecificRegistryInfo, false).GetValue("WTAppPath").ToString();
        }
    }

    public static class WTRefresh
    {
        private static RegistryKey WinReqRegistryKey = Registry.CurrentUser.OpenSubKey(WTRegistry.wtVersionSpecificRegistryInfo + @"\WindowReq", true);

        public static void RefreshPart()
        {
            WinReqRegistryKey.SetValue("PartFrame",1);
        }

        public static void RefreshTool()
        {
            WinReqRegistryKey.SetValue("ToolFrame", 1);
        }

        public static void RefreshList()
        {
            WinReqRegistryKey.SetValue("ToolListFrame",1);
        }

        public static void RefreshNCFolder()
        {
            WinReqRegistryKey.SetValue("NCFolderFrame", 1);
        }
    }
}

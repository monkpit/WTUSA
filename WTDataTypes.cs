using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;

using System.Web.Script.Serialization;
using Microsoft.Win32;

using WTUSA;

namespace WTUSA
{
    namespace WTDataTypes
    {
        public class PartsMapper : ClassMapper<Parts>
        {
            public PartsMapper()
            {
                Table("Parts");
                Map(m => m.mcMachineSide).Ignore();
                Map(m => m.mcCutterSide1).Ignore();
                Map(m => m.mcCutterSide2).Ignore();
                Map(m => m.mcCutterSide3).Ignore();
                AutoMap();
            }
        }
        [Serializable()]
        public class Parts  : IWTItem
        {
            private WTRegistry.RegistryItem _registryItemType = WTRegistry.RegistryItem.ActivePartID;
            #region "Fields"
            //private Int16 pOwnerNr;
            //private Int16 pNr;
            //private Int32 pID;
            //private Int32 pGroupID;
            //private Int32? pPartPicID;
            //private Int16 pMaskNr;
            //private Int32? pUClass;
            //private Int32? pUNr;
            //private String pMID;
            //private String pKeyWord;
            //private String pDescript;
            //private String pSort;
            //private String pDesign;
            //private String pAdapt;
            //private String pDINNorm;
            //private String pRem1;
            //private String pRem2;
            //private Double pOPrice;
            //private String pOStock;
            //private Boolean pOStandard;
            //private String pOUnit;
            //private Int16 pOQuant;
            //private String pOText;
            //private String pUID;
            //private String pURem;
            //private DateTime pUMDate;
            //private String pUSign;
            //private Boolean pUNorm;
            //private Boolean pUActiv;
            //private Double pUPrice;
            //private Int16 pUStock;
            //private Int16 pUDisp;
            //private Int16 pUMin;
            //private Int16 pUQuant;
            //private String pUPlace;
            //private Boolean pStandard;
            //private Boolean pCutter;
            //private Boolean pAddOn;
            //private Boolean pNameGiving;
            //private Boolean pAdapter;
            //private Boolean pClutch;
            //private Boolean pMultiC;
            //private Boolean pMeasurePoint;
            //private Int32? pMatchC1;
            //private Int16 pMatchCMode1;
            //private Single pMatchCMin1;
            //private Single pMatchCMax1;
            //private Int32? pMatchC2;
            //private Int16 pMatchCMode2;
            //private Single pMatchCMin2;
            //private Single pMatchCMax2;
            //private Int32? pMatchC3;
            //private Int16 pMatchCMode3;
            //private Single pMatchCMin3;
            //private Single pMatchCMax3;
            //private Int16 pFollowing;
            //private Int32? pMatchM1;
            //private Int16 pMatchMMode1;
            //private Single pMatchSize1;
            //private String pISONorm;
            //private Boolean pNonMetric;
            //private Single pDMC;
            //private String pHow;
            //private Boolean pAdjDM;
            //private Boolean pDMChange;
            //private Single pDMMin;
            //private Single pDMMax;
            //private Single pCLength;
            //private Single pLength;
            //private Single pZInfluence;
            //private Boolean pAdjZ;
            //private Single pZMin;
            //private Single pZMax;
            //private Single pCWidth;
            //private Single pXInfluence;
            //private Boolean pAdjArc;
            //private Single pCMainArc;
            //private Single pCFreeArc;
            //private Single pCRadius;
            //private Single pCArc;
            //private Int16 pArcInfluence;
            //private Single pDMConflict;
            //private Single pZConflict;
            //private Single pDMNose;
            //private Single pZNose;
            //private Int16 pTeeth;
            //private Single pWeight;
            //private Int16 pSense;
            //private Boolean pCoolent;
            //private Boolean pCenterCut;
            //private String pU1;
            //private String pU2;
            //private String pU3;
            //private String pU4;
            //private String pU5;
            //private String pU6;
            //private String pU7;
            //private String pU8;
            //private String pU9;
            //private Single pO1;
            //private Single pO2;
            //private Single pO3;
            //private Single pO4;
            //private Single pO5;
            //private String pO6;
            //private String pO7;
            //private String pO8;
            //private String pO9;
            //private Single? pSpinArc;
            //private Int16? pSpinDir;
            //private Single? pNeckDia;
            //private Single? pUseLength;
            //private String pInfoLink1;
            //private String pInfoLink2;
            //private Boolean pWearPart;
            //private Int16? pPackageSize;
            //private Boolean pIsUnique;
            //private Single? pYInfluence;
            //private Int16? pArcInfluenceX;
            //private Int16? pArcInfluenceZ;
            //private Int16? pMasksSubNr;
            //private String pInfoLink;
            //private DateTime pGDate;
            //private String pGSign;
            #endregion
            private Int32 _ID;

            private Matchcodes pMcMachineSide;
            private Matchcodes pMcCutterSide1;
            private Matchcodes pMcCutterSide2;
            private Matchcodes pMcCutterSide3;
            public Matchcodes mcMachineSide 
            {
                get
                {
                    return pMcMachineSide;
                }
                set
                {
                    pMcMachineSide = value;
                    //update Parts values here
                    MatchM1 = value.ID;
                }
            }
            public Matchcodes mcCutterSide1 
            {
                get
                {
                    return pMcCutterSide1;
                }
                set
                {
                    pMcCutterSide1 = value;
                    //update Parts values here
                    MatchC1 = value.ID;
                }
            }
            public Matchcodes mcCutterSide2 
            {
                get
                {
                    return pMcCutterSide2;
                }
                set
                {
                    pMcCutterSide2 = value;
                    //update Parts values here
                    this.MatchC2 = value.ID;
                }
            }
            public Matchcodes mcCutterSide3 
            {
                get
                {
                    return pMcCutterSide3;
                }
                set
                {
                    pMcCutterSide3 = value;
                    //update Parts values here
                    this.MatchC3 = value.ID;
                }
            }

            #region "Properties"
            public Int16 OwnerNr { get; set; }
            public Int16 Nr { get; set; }
            public Int32 ID { get { return _ID; } set { base.PKID = value; _ID = value; } }
            public Int32 GroupID { get; set; }
            public Int32? PartPicID { get; set; }
            public Int16 MaskNr { get; set; }
            public Int32? UClass { get; set; }
            public Int32? UNr { get; set; }
            public String MID { get; set; }
            public String KeyWord { get; set; }
            public String Descript { get; set; }
            public String Sort { get; set; }
            public String Design { get; set; }
            public String Adapt { get; set; }
            public String DINNorm { get; set; }
            public String Rem1 { get; set; }
            public String Rem2 { get; set; }
            public Double OPrice { get; set; }
            public String OStock { get; set; }
            public Boolean OStandard { get; set; }
            public String OUnit { get; set; }
            public Int16 OQuant { get; set; }
            public String OText { get; set; }
            public String UID { get; set; }
            public String URem { get; set; }
            public DateTime UMDate { get; set; }
            public String USign { get; set; }
            public Boolean UNorm { get; set; }
            public Boolean UActiv { get; set; }
            public Double UPrice { get; set; }
            public Int16 UStock { get; set; }
            public Int16 UDisp { get; set; }
            public Int16 UMin { get; set; }
            public Int16 UQuant { get; set; }
            public String UPlace { get; set; }
            public Boolean Standard { get; set; }
            public Boolean Cutter { get; set; }
            public Boolean AddOn { get; set; }
            public Boolean NameGiving { get; set; }
            public Boolean Adapter { get; set; }
            public Boolean Clutch { get; set; }
            public Boolean MultiC { get; set; }
            public Boolean MeasurePoint { get; set; }
            private Int32? matchC1;
            [Description("Matchcode")]
            public Int32? MatchC1
            {
                get
                {
                    return matchC1;
                }
                set
                {
                    matchC1 = value;
                    mcCutterSide1.SetID(value);
                }
            }
            public Int16 MatchCMode1 { get; set; }
            [Description("Measurement")]
            public Single MatchCMin1 { get; set; }
            [Description("Measurement")]
            public Single MatchCMax1 { get; set; }
            private Int32? matchC2;
            [Description("Matchcode")]
            public Int32? MatchC2 
            {
                get
                {
                    return matchC2;
                }
                set
                {
                    matchC2 = value;
                    mcCutterSide2.SetID(value);
                }
            }
            public Int16 MatchCMode2 { get; set; }
            [Description("Measurement")]
            public Single MatchCMin2 { get; set; }
            [Description("Measurement")]
            public Single MatchCMax2 { get; set; }
            private Int32? matchC3;
            [Description("Matchcode")]
            public Int32? MatchC3 
            {
                get
                {
                    return matchC3;
                }
                set
                {
                    matchC3 = value;
                    mcCutterSide3.SetID(value);
                }
            }
            public Int16 MatchCMode3 { get; set; }
            [Description("Measurement")]
            public Single MatchCMin3 { get; set; }
            [Description("Measurement")]
            public Single MatchCMax3 { get; set; }
            public Int16 Following { get; set; }
            private Int32? matchM1;
            [Description("Matchcode")]
            public Int32? MatchM1
            {
                get 
                {
                    return matchM1;
                }
                set
                {
                    matchM1 = value;
                    mcMachineSide.SetID(value);
                }
            }
            private Int16 matchMMode1;
            public Int16 MatchMMode1 
            {
                get 
                { 
                    return matchMMode1;
                }
                set
                {
                    matchMMode1 = value;
                }
            }
            [Description("Measurement")]
            public Single MatchSize1 { get; set; }
            public String ISONorm { get; set; }
            public Boolean NonMetric { get; set; }
            [Description("Measurement")]
            public Single DMC { get; set; }
            public String How { get; set; }
            public Boolean AdjDM { get; set; }
            public Boolean DMChange { get; set; }
            [Description("Measurement")]
            public Single DMMin { get; set; }
            [Description("Measurement")]
            public Single DMMax { get; set; }
            [Description("Measurement")]
            public Single CLength { get; set; }
            [Description("Measurement")]
            public Single Length { get; set; }
            [Description("Measurement")]
            public Single ZInfluence { get; set; }
            public Boolean AdjZ { get; set; }
            [Description("Measurement")]
            public Single ZMin { get; set; }
            [Description("Measurement")]
            public Single ZMax { get; set; }
            [Description("Measurement")]
            public Single CWidth { get; set; }
            [Description("Measurement")]
            public Single XInfluence { get; set; }
            public Boolean AdjArc { get; set; }
            [Description("AngularMeasurement")]
            public Single CMainArc { get; set; }
            [Description("AngularMeasurement")]
            public Single CFreeArc { get; set; }
            [Description("Measurement")]
            public Single CRadius { get; set; }
            [Description("AngularMeasurement")]
            public Single CArc { get; set; }
            [Description("AngularMeasurement")]
            public Int16 ArcInfluence { get; set; }
            [Description("Measurement")]
            public Single DMConflict { get; set; }
            [Description("Measurement")]
            public Single ZConflict { get; set; }
            [Description("Measurement")]
            public Single DMNose { get; set; }
            [Description("Measurement")]
            public Single ZNose { get; set; }
            public Int16 Teeth { get; set; }
            public Single Weight { get; set; }
            public Int16 Sense { get; set; }
            public Boolean Coolent { get; set; }
            public Boolean CenterCut { get; set; }
            [Description("UserField")]
            public String U1 { get; set; }
            [Description("UserField")]
            public String U2 { get; set; }
            [Description("UserField")]
            public String U3 { get; set; }
            [Description("UserField")]
            public String U4 { get; set; }
            [Description("UserField")]
            public String U5 { get; set; }
            [Description("UserField")]
            public String U6 { get; set; }
            [Description("UserField")]
            public String U7 { get; set; }
            [Description("UserField")]
            public String U8 { get; set; }
            [Description("UserField")]
            public String U9 { get; set; }
            public Single O1 { get; set; }
            public Single O2 { get; set; }
            public Single O3 { get; set; }
            public Single O4 { get; set; }
            public Single O5 { get; set; }
            public String O6 { get; set; }
            public String O7 { get; set; }
            public String O8 { get; set; }
            public String O9 { get; set; }
            [Description("AngularMeasurement")]
            public Single? SpinArc { get; set; }
            public Int16? SpinDir { get; set; }
            [Description("Measurement")]
            public Single? NeckDia { get; set; }
            [Description("Measurement")]
            public Single? UseLength { get; set; }
            public String InfoLink1 { get; set; }
            public String InfoLink2 { get; set; }
            public Boolean WearPart { get; set; }
            public Int16? PackageSize { get; set; }
            public Boolean IsUnique { get; set; }
            [Description("Measurement")]
            public Single? YInfluence { get; set; }
            [Description("AngularMeasurement")]
            public Int16? ArcInfluenceX { get; set; }
            [Description("AngularMeasurement")]
            public Int16? ArcInfluenceZ { get; set; }
            public Int16? MasksSubNr { get; set; }
            public String InfoLink { get; set; }
            public DateTime GDate { get; set; }
            public String GSign { get; set; }
            #endregion

            public Parts()
            {
                //this = wtc;
                this.GDate = DateTime.Now;
                GiveCurrentTime();
                mcMachineSide = new Matchcodes();
                mcCutterSide1 = new Matchcodes();
                mcCutterSide2 = new Matchcodes();
                mcCutterSide3 = new Matchcodes();
            }
            
            public override string IdOrNr()
            {
                //parts.ID is Primary Key in WTData
                return "ID";
            }

            public override void Show()
            {
                var wtreg = new WTRegistry();
                wtreg[_registryItemType] = this.ID;
                WTRefresh.RefreshPart();
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }

            public void GiveNextIDs()
            {
                //give this part the next NR, ID and Item # by asking wtdata for current max #s
                //		        set @IdNext = ((select max(ID) from parts where ownernr = 0) + 1)
                //		        set @NrNext = ((select max(Nr) from parts where ownernr = 0) + 1)
                //		        set @ItemNoNext = ((select max(UNr) from parts where ownernr = 0) + 1)
                var connection = WTUSA.WTConnection.GetConnection();
                //this.ID = connection.Query<int>(@"select max(ID) from parts where ownernr = 0", new object { }).Single() + 1;
                this.Nr = (Int16)(connection.Query<short>(@"select max(Nr) from parts where ownernr = 0", new object { }).Single() + 1);
                this.UNr = connection.Query<int>(@"select max(UNr) from parts where ownernr = 0", new object { }).Single() + 1;
                this.GroupID = connection.Query<int>(@"select groups.id from groups where ownernr = 0", new object { }).Single();
            }

            public void GiveCurrentTime()
            {
                this.UMDate = DateTime.Now;
            }

            public void GiveUniqueMID()
            {
                this.MID = (this.MID + "*" + Guid.NewGuid().ToString()).Substring(0,30);
            }
        }
        public class MatchcodesMapper : ClassMapper<Matchcodes>
        {
            public MatchcodesMapper()
            {
                Table("Matchcodes");
                Map(m => m.ID).Key(KeyType.Identity);
                AutoMap();
            }
        }
        public class Matchcodes
        {
            
            public string Text { get; set; }
            private Int32? pID;
            public Int32? ID { get { return pID; } set { pID = value; } }
            private Int16 pNr;
            public Int16 Nr { get { return pNr; } set { pNr = value; } }
            private string pCode;
            public string Code { get { return pCode; } set { pCode = value; } }
            private Int16 pOwnerNr;
            public Int16 OwnerNr 
            {
                get
                {
                    return pOwnerNr;
                }
                set
                {
                    if (WTConnection.GetConnection().Query<Int16>("select owner.nr from owner where nr = @NR", new { NR = value }).Single() == value)
                    {
                        int nextnr = WTConnection.GetConnection().Query<int>("select max(nr)+1 from matchcodes where ownernr = @ONR", new { ONR = value }).First();
                        this.pOwnerNr = value;
                        this.pNr = (Int16)nextnr;
                        this.pID = this.pOwnerNr * 65536 + this.pNr;
                    }
                    else
                    {
                        throw new ArgumentException("The specified OwnerNr does not exist in the table Owners: " + value.ToString(), "value");
                    }
                }
            }
            //for reference, ID = ownernr * 65536 + Nr

            public void SetID(Int32? value)
            {
                if (value!= null)
                {
                    var result = (WTConnection.GetConnection().Query<Matchcodes>("select matchcodes.* from matchcodes where matchcodes.ID = @inputID", new { inputID = value })).Single();
                    Matchcodes tempMC = (Matchcodes)result;
                    this.pID = tempMC.ID;
                    this.pNr = tempMC.Nr;
                    this.pCode = tempMC.Code;
                    this.Text = tempMC.Text;
                    this.pOwnerNr = tempMC.OwnerNr;
                }
                pID = value;
            }
            public void SetCode(string value)
            {
                try
                {
                    Matchcodes tempMC = (WTConnection.GetConnection().Query<Matchcodes>("select matchcodes.* from matchcodes where matchcodes.code = @inputCode", new { inputCode = value })).Single<Matchcodes>();
                    this.pID = tempMC.ID;
                    this.pNr = tempMC.Nr;
                    this.pCode = tempMC.Code;
                    this.Text = tempMC.Text;
                }
                catch (Exception e)
                {
                    //CreateNewMatchcode(value);
                    throw new ArgumentException("Invalid matchcode: " + value, "value", e);
                }
            }

            public Matchcodes(Int32 value)
            {
                SetID(value);
            }
            public Matchcodes(string value)
            {
                SetCode(value);
            }
            public Matchcodes()
            {
                //id will be null until code or id setter is used
            }

            //this gives a no nulls allowed error on ID column when the ID is not null. I can't figure out why so it can't get implemented.
            /*public void CreateNewMatchcode(string newCode)
            {
                this.pCode = newCode;
                this.OwnerNr = 0;
                if (this.ID.HasValue)
                {
                    WTConnection.GetConnection().Insert(this);
                }
            }*/
        }
    }
}

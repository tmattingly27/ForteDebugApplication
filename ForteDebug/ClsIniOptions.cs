using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForteDebug;

internal class ClsIniOptions
{
    private string strFileName = "WetLayer.ini";
    private string strFilePath = @"C:\Fortesystem\Realtime";

    public string[]? IniDatLines;

    private enum IniGroup
    {
        Data,
        Movement,
        Port,
        Restoring,
        Simulation,
        Decision,
        Query,
        System,
        Device1,
        Photoeye,
        Unknown
    }
    private IniGroup iDatgroup;

    public List<string>? DataGroupList;
    public List<string>? MovementGroupList;
    public List<string>? PortGroupList;
    public List<string>? RestoringList;
    public List<string>? SimulationList;
    public List<string>? DecisionList;
    public List<string>? QueryList;
    public List<string>? SystemList;
    public List<string>? Device1List;
    public List<string>? PhotoeyeList;

    //[data]
    public int? iMaxSamples=0;
    public int? iBalesInGrid=0;
    public int? iLogMessages=0;
    public int? iLogFileSize=0;
    public int? iHeadLen=0;
    public int? iTailLen=0;
    public string? sUseASCIISampleFile=string.Empty;
    public int? iRecordsInASCIIFile=0;
    public int? iASCIIRecordCount=0;

    //[Movement]
    public int? iSensorDistanceMM;
    public double? iCycleMSec;
    public int? iBaleSpeedMaxMMPerSec;
    public int? iBaleSpeedMinMMPerSec;
    public int? iMaxSpeedVar;
    public int? iBaleLengthMaxMM;
    public int? iBaleLengthMinMM;
    public int? iZeroConst;
    public int? iScaleConst;
    public int? iWLProcessTO;
    public int? iSensorTConstMSec;
    public int? iRTRequestTO;

    //[Port]
    public int? iComPort;
    public string? sBaud;
    public int? iBits;
    public int? iStopBit;
    public string? sParity;
    public string? sUseExpProtocol;

    //[Restoring]
    public int? FilterConstant=0;
    public double? dSourceDerivLimit=0;
    public double? dRestoreDerivLimit=0;
    public double? dSourceCorrMax=0;
    public double? dRestoreCorrMax=0;
    public double? dFilterConstantVar=0;
    public int? iNoiseFilter=0;
    public int? iNumberOfIterations=0;
    public double? dMultCoef = 0;
    public double? dAddCoef = 0;
    public int? iCautionStep = 0;
    public double? dCautionCoef = 0;
    public int? iAfterRestoreFilter = 0;
    public string? bAutoRestore = string.Empty; //bool
    public double? dDiveCoef = 0;
    public double? dDiveFilter = 0;
    public int? iFilterType = 0;
    public int? iRestoreLayers = 0;
    public int? iFilterConstIterations = 0;
    public int? iValuesIterations = 0;
    public int? iFilterConstApprMult = 0;
    public int? iValuesApprMult = 0;
    public int? iSpeedCorrLevel = 0;
    public int? iPartOfLayerChoppedAtEnds = 0;
    public int? iLayersForFCCalc = 0;
    public int? iBinaryPartitions=0;
    public string? bUseRatioForEqual= string.Empty; //bool
    public int? iLayersToChopStart=0;
    public int? iLayersToChopEnd=0;
    public double? dFilterConstLimitRatio=0;
    public int? iMaxSpike=0;
    public string? bUseSpikeFilter= string.Empty; //bool
    public double? dSpikeFilter=0;

    //[Simulation]
    public int? iSimSamples=0;
    public int? iSimAmplitude=0;
    public int? iSimTailsPrc=0;
    public int? iSimWetCenter1Prc=0;
    public int? SimWetCenter2Prc = 0;
    public int? iSimWetcenter3Prc = 0;
    public int? iSimWetWidth1Prc = 0;
    public int? iSimWetWidth2Prc = 0;
    public int? iSimWetWidth3Prc = 0;
    public int? iSimWetAmp1Prc =0;
    public int? iSimWetAmp2Prc = 0;
    public int? iSimWetAmp3Prc = 0;
    public int? iSimTestFilter = 0;
    public double? dSimRestoreFilter = 0;
    public int? iSimNoisePrc = 0;
    public double? dSimNoiseFilter = 0;
    public int? iSimCreateFilter = 0;
    public int? iSimFilterType = 0;
    public int? iSimAverMoisture = 0;

    //[Decision]
    public int? iMaxDeviation = 0;
    public int? iMaxValue=0;
    public int? iNumbOfSpots = 0;
    public int? iMinSpotValue = 0;
    public int   iMinSpotLenth = 0;
    public string? bUseDeviation= string.Empty; //bool
    public string? bUseValue = string.Empty; //bool
    public string? bUseSpots = string.Empty; //bool
    public string? sMode = string.Empty;
    public int? iHeadSamples = 0;
    public int? iEdge = 0;
    public int? iExclSpotValue = 0;
    public int? iExclSpotLength = 0;
    public int? iHighColor = 0;
    public int? iLowColor = 0;
    public int? iNormColor=0;
    public int? iAlarmColor = 0;
    public int? iOKColor = 0;

    //[Query]
    public double? dUpdatePeriod = 0;
    public string? bAutoUpdate=string.Empty; //bool

    //[System]
    public string? bStandAlone = string.Empty; //bool
    public string? bBeforeTC = string.Empty; //bool
    public string? bUseSQL = string.Empty; //bool
    public int? iNumberOfBalers = 0;
    public string? sBaler1Name = string.Empty;
    public string? sBaler2Name = string.Empty;

    //[Device1]
    //public int iComPort;

    //[Photoeye]
    public int iCalCyclemSec=0;
    //public int iHeadSamples;

    public ClsIniOptions()
    {

        DataGroupList = new List<string>();
        MovementGroupList = new List<string>();
        PortGroupList = new List<string>();
        RestoringList = new List<string>();
        SimulationList = new List<string>();
        DecisionList = new List<string>();
        QueryList = new List<string>();
        SystemList = new List<string>();
        Device1List = new List<string>();
        PhotoeyeList = new List<string>();


    }

    /// <summary>
    /// Read INI fille into string
    /// </summary>
    /// <returns></returns>
    public bool readinifile()
    {
        String FileLocation = Path.Combine(strFilePath, strFileName);

        try
        {
            if (File.Exists(FileLocation))
            {
                using (StreamReader sr = new StreamReader(FileLocation))
                {
                    GetLinesItems(sr?.ReadToEnd());
                }
            }
            else
            {
                Console.WriteLine("File does not excist");
            }
            return true;
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error in readinifile-> " + ex);
            return false;
        }
    }

    /// <summary>
    /// Split String into lines with <CR><LF>
    /// So do not have problem with string all over the place in the file.
    /// </summary>
    /// <param name="strLine"></param>
    private void GetLinesItems(string? strLine)
    {
        string[] stringSeparators = { "\r\n" };
        string[]? IniLines = strLine?.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

        IniDatLines = IniLines;

        if (IniLines == null) return;

        try
        {
            if (strLine != null)
            {
                foreach (string? sLine in IniLines)
                {
                    if ((!sLine.Contains(":")) & (sLine != null) & (sLine != string.Empty))
                    {
                        GetGroupHeader(sLine);
                        GetDataInGroup(iDatgroup, sLine);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in ProcessLine-> " + ex);
        }
    }

    private void GetGroupHeader(string? strLinedat)
    {
        // Console.WriteLine(strLinedat.Trim());

        if(strLinedat==null) return;

        if (strLinedat.Contains("[Data]"))
            iDatgroup = IniGroup.Data;

        if (strLinedat.Contains("[Movement]"))
            iDatgroup = IniGroup.Movement;

        if (strLinedat.Contains("[Port]"))
            iDatgroup = IniGroup.Port;

        if (strLinedat.Contains("[Restoring]"))
            iDatgroup = IniGroup.Restoring;

        if (strLinedat.Contains("[Simulation]"))
            iDatgroup = IniGroup.Simulation;

        if (strLinedat.Contains("[Decision]"))
            iDatgroup = IniGroup.Decision;

        if (strLinedat.Contains("[Query]"))
            iDatgroup = IniGroup.Query;

        if (strLinedat.Contains("[System]"))
            iDatgroup = IniGroup.System;

        if (strLinedat.Contains("[Device1]"))
            iDatgroup = IniGroup.Device1;

        if (strLinedat.Contains("[Photoeye]"))
            iDatgroup = IniGroup.Photoeye;
    }


    private void GetDataInGroup(IniGroup? strLineData, string? strIniLineDat)
    {
        if (strIniLineDat == null) { return; }

        switch (strLineData)
        {
            case IniGroup.Data:
                if ((!strIniLineDat.Contains("[Data]")) & (strIniLineDat != string.Empty))
                    DataGroupList?.Add(strIniLineDat.Trim());

                if (strIniLineDat.Contains("MaxSamples"))
                    iMaxSamples = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("BalesInGrid"))
                    iBalesInGrid = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("LogMessages"))
                    iLogMessages = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("LogFileSize"))
                    iLogFileSize = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("HeadSamples"))
                    iHeadLen = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("TailSamples"))
                    iTailLen = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("UseASCIISampleFile"))
                    sUseASCIISampleFile = StrIniItem(strIniLineDat).ToString();

                if (strIniLineDat.Contains("RecordsInASCIIFile"))
                    iRecordsInASCIIFile = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("ASCIIRecordCount"))
                    iASCIIRecordCount = Convert.ToInt32(StrIniItem(strIniLineDat));

                break;

            case IniGroup.Movement:
                if ((!strIniLineDat.Contains("[Movement]")) & (strIniLineDat != string.Empty))
                    MovementGroupList?.Add(strIniLineDat.Trim());

                if (strIniLineDat.Contains("SensorDistanceMM"))
                    iSensorDistanceMM = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("CycleMSec"))
                    iCycleMSec = Convert.ToDouble(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("BaleSpeedMaxMMPerSec"))
                    iBaleSpeedMaxMMPerSec = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("BaleSpeedMinMMPerSec"))
                    iBaleSpeedMinMMPerSec = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("MaxSpeedVar"))
                    iMaxSpeedVar = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("BaleLengthMaxMM"))
                    iBaleLengthMaxMM = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("BaleLengthMinMM"))
                    iBaleLengthMinMM = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("ZeroConst"))
                    iZeroConst = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("ScaleConst"))
                    iScaleConst = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("WLProcessTO"))
                    iWLProcessTO = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("SensorTConstMSec"))
                    iSensorTConstMSec = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("RTRequestTO"))
                    iRTRequestTO = Convert.ToInt32(StrIniItem(strIniLineDat));

                break;

            case IniGroup.Port:
                if ((!strIniLineDat.Contains("[Port]")) & (strIniLineDat != string.Empty))
                    PortGroupList?.Add(strIniLineDat.Trim());

                if (strIniLineDat.Contains("ComPort"))
                    iComPort = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("Baud"))
                    sBaud = StrIniItem(strIniLineDat);

                if (strIniLineDat.Contains("Bits"))
                    iBits = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("StopBit"))
                    iStopBit = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("Parity"))
                    sParity = StrIniItem(strIniLineDat);

                if (strIniLineDat.Contains("UseExpProtocol"))
                    sUseExpProtocol = StrIniItem(strIniLineDat);

                break;

            case IniGroup.Restoring:

                if ((!strIniLineDat.Contains("[Restoring]")) & (strIniLineDat != string.Empty))
                    RestoringList?.Add(strIniLineDat.Trim());

                if (strIniLineDat.Contains("RestoreLayers"))
                    iRestoreLayers = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("LayersToChopStart"))
                    iLayersToChopStart = Convert.ToInt32(StrIniItem(strIniLineDat));

                if (strIniLineDat.Contains("LayersToChopEnd"))
                    iLayersToChopEnd = Convert.ToInt32(StrIniItem(strIniLineDat));

                break;


            case IniGroup.Simulation:
                if ((!strIniLineDat.Contains("[Simulation]")) & (strIniLineDat != string.Empty))
                    SimulationList?.Add(strIniLineDat.Trim());
                break;


            case IniGroup.Decision:
                if ((!strIniLineDat.Contains("[Decision]")) & (strIniLineDat != string.Empty))
                    DecisionList?.Add(strIniLineDat.Trim());
                break;


            case IniGroup.Query:
                if ((!strIniLineDat.Contains("[Query]")) & (strIniLineDat != string.Empty))
                    QueryList?.Add(strIniLineDat.Trim());
                break;

            case IniGroup.System:
                if ((!strIniLineDat.Contains("[System]")) & (strIniLineDat != string.Empty))
                    SystemList?.Add(strIniLineDat.Trim());
                break;

            case IniGroup.Device1:
                if ((!strIniLineDat.Contains("[Device1]")) & (strIniLineDat != string.Empty))
                    Device1List?.Add(strIniLineDat.Trim());
                break;

            case IniGroup.Photoeye:
                if ((!strIniLineDat.Contains("[Photoeye]")) & (strIniLineDat != string.Empty))
                    PhotoeyeList?.Add(strIniLineDat.Trim());
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Get value from string after =
    /// </summary>
    /// <param name="strData"></param>
    /// <returns> string value </returns>
    private string StrIniItem(string strData)
    {
        string strRet = string.Empty;
        string[] stringSeparators = { "=" };

        try
        {
            string[] words = strData.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length > 1) { strRet = words[1]; }
            else strRet = string.Empty;

            return strRet;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in StrIniItem-> " + ex);
            return strRet;
        }
    }


}

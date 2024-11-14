// See https://aka.ms/new-console-template for more information

/*

Added some comments to the top of this file...

*/


using ForteDebug;
using System.IO.Compression;

internal class Program
{

   internal static void Main(string[] args)
   {
        string WetLayeriniFilePath = @"C:\Fortesystem\Realtime\WetLayer.ini";
        string StrFileName = $"WetLayerIni.csv";
        string StrPathFile = string.Empty;
        string[]? IniDatLines;
        string ZipFileLocation = @"c:\temp";
        string Debugpath = @"c:\ForteDebug\";

        bool bGood = false;

        ClsIniOptions? WetLayerini = new();
        WetLayerini?.readinifile();
        IniDatLines = WetLayerini?.IniDatLines;

        if (!Directory.Exists(Debugpath))
        {
            DirectoryInfo di = Directory.CreateDirectory(Debugpath);
        }

        //Delete all files from the target directory first. 
        System.IO.DirectoryInfo dy = new DirectoryInfo(Debugpath);

        foreach (FileInfo file in dy.GetFiles())
        {
            file.Delete();
        }
        foreach (DirectoryInfo dir in dy.GetDirectories())
        {
            dir.Delete(true);
        }

        if (File.Exists(WetLayeriniFilePath))
        {
            StrPathFile = Debugpath + @"\" + StrFileName;
            SaveArrayAsCSV(IniDatLines, StrPathFile);
            //Console.WriteLine($"Write ini file {StrPathFile}");
        }
        else
            Console.WriteLine("Wet Layer Does not excist!");

        if (CopyLogFiles()) bGood = true;
        if (CopyBackUpfiles()) bGood = true;

        if (File.Exists(ZipFileLocation + @"\ForteDebug.zip"))
        {
            File.Delete(ZipFileLocation + @"\ForteDebug.zip");
        }

        if (IsDirectoryEmpty(@"c:\ForteDebug") != true)
        {
            ZipFile.CreateFromDirectory(@"c:\ForteDebug", ZipFileLocation + @"\ForteDebug.zip");
            if (bGood) Console.WriteLine($"Create Zip file Done. in {ZipFileLocation} folder");
            else Console.WriteLine("Zip file was not created, folder is empty.");
        }

        Console.WriteLine();
        Console.WriteLine("Type anykey to exit the app.");
        string? readlinetext = Console.ReadLine();
    }

    public static bool IsDirectoryEmpty(string path)
    {
        return !Directory.EnumerateFileSystemEntries(path).Any();
    }

    private static bool CopyLogFiles()
    {
        bool bCopy = false;
        string LogPath = @"c:\ForteSystem\Realtime\ASCIILog\";
        string Debugpath = @"c:\ForteDebug\";
        try
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(LogPath);
            FileInfo[] files = di.GetFiles().OrderByDescending(p => p.LastWriteTime).ToArray();
            List<FileInfo> logFiles = new List<FileInfo>();

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.Contains("RealTime"))
                {
                    logFiles.Add(files[i]);

                    if (logFiles.Count < 5)
                    {
                        File.Copy(files[i].ToString(), Debugpath + Path.GetFileName(files[i].ToString()));
                    }
                }
            }
            bCopy = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in CopyLogFiles " + ex);
        }
        return bCopy;
    }

    private static bool CopyBackUpfiles()
    {
        bool bDone = false;
        string Debugpath = @"c:\ForteDebug\";
        string basePath = @"c:\ForteSystem\";

        string archivePath = basePath + @"\Archives\";
        string calPath = basePath + @"\Calibrations\";
        string gradePath = basePath + @"\Grades\";
        string realtimePath = basePath + @"\Realtime\";
        string reportsPath = basePath + @"\Reports\";
        string SystemPath = basePath + @"\System\";
        string SecurityPath = basePath + @"\Security\";

        try
        {

            File.Copy(archivePath + @"\OutputSys.mdb", Debugpath + Path.GetFileName(archivePath + @"\OutputSys.mdb"));

            File.Copy(calPath + @"\Calibrate.mdb", Debugpath + Path.GetFileName(calPath + @"\Calibrate.mdb"));

            File.Copy(gradePath + @"\PulpGrade.mdb", Debugpath + Path.GetFileName(gradePath + @"\PulpGrade.mdb"));

            File.Copy(realtimePath + @"\7760.mdb", Debugpath + Path.GetFileName(realtimePath + @"\7760.mdb"));
            File.Copy(realtimePath + @"\Cfg7760.mdb", Debugpath + Path.GetFileName(realtimePath + @"\Cfg7760.mdb"));
            File.Copy(realtimePath + @"\CustomConfig.mdb", Debugpath + Path.GetFileName(realtimePath + @"\CustomConfig.mdb"));

            File.Copy(reportsPath + @"\LVFormats.mdb", Debugpath + Path.GetFileName(reportsPath + @"\LVFormats.mdb"));
            File.Copy(reportsPath + @"\MarkerFormats.mdb", Debugpath + Path.GetFileName(reportsPath + @"\MarkerFormats.mdb"));
            File.Copy(reportsPath + @"\PrinterFormats.mdb", Debugpath + Path.GetFileName(reportsPath + @"\PrinterFormats.mdb"));
            File.Copy(reportsPath + @"\ReportsJ4.mdb", Debugpath + Path.GetFileName(reportsPath + @"\ReportsJ4.mdb"));

            File.Copy(SystemPath + @"\FSys.ini", Debugpath + Path.GetFileName(SystemPath + @"\FSys.ini"));
            File.Copy(SecurityPath + @"\UPG.DAT", Debugpath + Path.GetFileName(SecurityPath + @"\UPG.DAT"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in CopyBackUpfiles " + ex);
        }
        return bDone;
    }

    static void SaveArrayAsCSV<T>(T[]? arrayToSave, string fileName)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {

            if (arrayToSave != null) 
            { 
                foreach (T item in arrayToSave)
                {
                    file.WriteLine(item + ",");
                }
            }
        }
    }
}
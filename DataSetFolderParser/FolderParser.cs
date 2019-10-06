using System;
using System.Collections;
using System.IO;

namespace DataSetFolderParser
{
    public static class FolderParser
    { 
        // Write paths to your dataset folders
       private static string pathToDataSet = "C:\\img_align_celeba\\img_align_celeba\\";
       private static string pathTotxtFile = "C:\\С#_projects\\DataSetFolderParser\\DataSetFolderParser\\txt\\text.txt";
       private static string pathToTrainDataForZeros = "C:\\train\\0\\"; 
       private static string pathToTrainDataForOnes = "C:\\train\\1\\"; 
       private static string pathToTestDataForZeros = "C:\\test\\0\\"; 
       private static string pathToTestDataForOnes = "C:\\test\\1\\"; 
       private static string pathToValidationDataForZeros = "C:\\validation\\0\\"; 
       private static string pathToValidationDataForOnes = "C:\\validation\\1\\"; 
       
       private static ArrayList WithoutGlassesArrayList = null;
       private static ArrayList WithGlassesArrayList = null;
       public static void ParseDataSetToFolders()
       {
           using (StreamReader sr = new StreamReader(pathTotxtFile, System.Text.Encoding.Default))
           {
               string line;
               WithGlassesArrayList = new ArrayList();
               WithoutGlassesArrayList = new ArrayList();
               while ((line = sr.ReadLine()) != null)
               {
                   if (line.IndexOf(", -1", StringComparison.Ordinal) != -1)
                   {
                       WithoutGlassesArrayList.Add(line.Substring(0, 
                           line.IndexOf(", -1", StringComparison.Ordinal)));
                   }
                   
                   if (line.IndexOf(", 1", StringComparison.Ordinal) != -1)
                   {
                       WithGlassesArrayList.Add(line.Substring(0, 
                           line.IndexOf(", 1", StringComparison.Ordinal)));
                   }
               }
               
               ParseDataToTrainFolders(WithGlassesArrayList, WithoutGlassesArrayList);
               ParseDataToTestFolders(WithGlassesArrayList, WithoutGlassesArrayList);
               ParseDataToValidationFolders(WithGlassesArrayList, WithoutGlassesArrayList);
           }
       }

       private static void ParseDataToTrainFolders(ArrayList WithGlassesArrayList, ArrayList WithoutGlassesArrayList)
       {
            // Датасет для обучения
           
           for (int i = 0; i < 10000; i++) 
           {
               Console.WriteLine("Copying " + WithoutGlassesArrayList[i]);
               File.Copy(pathToDataSet + WithoutGlassesArrayList[i], 
                   pathToTrainDataForZeros + WithoutGlassesArrayList[i], true);
           }
           
           for (int i = 0; i < 10000; i++)
           {
               Console.WriteLine("Copying " + WithGlassesArrayList[i]);
               File.Copy(pathToDataSet + WithGlassesArrayList[i], 
                   pathToTrainDataForOnes + WithGlassesArrayList[i], true);
           }
       }

       private static void ParseDataToTestFolders(ArrayList WithGlassesArrayList, ArrayList WithoutGlassesArrayList)
       {
           // Датасет для теста
           
           for (int i = 10000; i < 12000; i++) 
           {
               Console.WriteLine("Copying " + WithoutGlassesArrayList[i]);
               File.Copy(pathToDataSet + WithoutGlassesArrayList[i], 
                   pathToTestDataForZeros + WithoutGlassesArrayList[i], true);
           }
           
           for (int i = 10000; i < 12000; i++) 
           {
               Console.WriteLine("Copying " + WithGlassesArrayList[i]);
               File.Copy(pathToDataSet + WithGlassesArrayList[i], 
                   pathToTestDataForOnes + WithGlassesArrayList[i], true);
           }
       }
       
       private static void ParseDataToValidationFolders(ArrayList WithGlassesArrayList, ArrayList WithoutGlassesArrayList)
       {
           // Датасет для валидации
           
           for (int i = 12000; i < 13000; i++) 
           {
               Console.WriteLine("Copying " + WithoutGlassesArrayList[i]);
               File.Copy(pathToDataSet + WithoutGlassesArrayList[i], 
                   pathToValidationDataForZeros + WithoutGlassesArrayList[i], true);
           }

           for (int i = 12000; i < 13000; i++) 
           {
               Console.WriteLine("Copying " + WithGlassesArrayList[i]);
               File.Copy(pathToDataSet + WithGlassesArrayList[i], 
                   pathToValidationDataForOnes + WithGlassesArrayList[i], true);
           }
       }
    }
}
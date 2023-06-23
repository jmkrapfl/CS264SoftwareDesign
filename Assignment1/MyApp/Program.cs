/*Hello demonstraitor! 
below is my assignment 1. the program can convert between csv and html both ways.
it cannot convert from json to the others but you CAN convert into json FROM html or csv. i just couldnt
figure out how to extract the info from json files into a string array i could work with. other than that
everything but verbose works mainly bc i didnt quite understand what it was supposed to do.

*/
//ALL THE DIFF CONVERSIONS I CAN MAKE
//test.csv -o test1.html
//test.csv -o test1.json
//test.html -o test1.csv
//test.html -o tes1.json

using System.Text;
using HtmlAgilityPack;
//**********VARIABLES**********
String command = Console.ReadLine();
String[] commandArr = command.Split(' ');
String helpStr =@"-v, -verbose                Verbose mode (debugging output to STDOUT)
-o, <file>, -output=<file>  Output specified by <file>
-l, -list-formats           List formats
-h -help                    Show usage message
-i, -info                   Show version info";
String formatList =@".json
.csv
.html";
string origFile, newFile;

//**************FLAG CATCHING***************
for(int i =0;i<commandArr.Length;i++)//run through the command and pick out the information
{
    //Console.WriteLine("searching through command");//testing
    switch (commandArr[i])
    {
        case "-v": Console.WriteLine("verbose"); break;
        case "-o": 
            origFile=commandArr[i-1];
            newFile=commandArr[i+1];
            oFlag(origFile); 
            convertToNew(newFile,oFlag(origFile));
            break;//
        case "-l": Console.WriteLine(formatList); break;//done
        case "-h": Console.WriteLine(helpStr); break;//done
        case "-i": Console.WriteLine("version 1.0"); break;//done
        default: break;
    }
}

//********** FILE READING/OPENING AND INPUT TO TABLE CLASS *************
static Table oFlag(string origFile)
{
    // string path = @"/Users/jessicakrapfl/Desktop/Files/Maynooth/CS264/Hello/MyApp/"+origFile;  // Linux and MacOS
    string path = @"./"+origFile;
    string type="";
    StringBuilder contents = new StringBuilder(); //using a string builder as it is a mutable string that could be as long as i want
    // Open the file to read from.
    using (StreamReader sr = File.OpenText(path))
    {
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            contents.Append(s +"\n");
            //Console.WriteLine(s);
        }
    }
    //Console.WriteLine(contents);//testing
    string filetxt = contents.ToString();//after the text file is all read into the string builder make it a string
    type = origFile.Substring(origFile.LastIndexOf('.'));
    //Console.WriteLine(type);//testing
    switch(type)//finds the type of file it is originally
    {
        case ".csv": 
            String[] txtArr = filetxt.Split("\n");
            int rowNum = txtArr.Length;//find #of cols
            String[] findColNum = txtArr[0].Split(",");//splits up one part of the array to find num of cols
            int colNum = findColNum.Length;
            Table newTab = new Table(rowNum-1, colNum, txtArr,"csv");
            //newTab.printTable();
            return newTab;
        case ".html": 
            string[]temp = htmlToStrArr(filetxt);
            Table htmlTab = new Table(htmlNum.htmlRow,htmlNum.htmlCol,temp,"html");
            //htmlTab.printTable();
            return htmlTab; 
        case ".json": 
            jsonToStrArr(filetxt);
            return null; 
        default: Console.WriteLine("input file not reconized"); return null;
    }
}

//************ CONVERT TO NEW FILE **********
static void convertToNew(string newFile, Table table)
{
    string type="";
    type = newFile.Substring(newFile.LastIndexOf('.'));
    switch(type)
    {
        case ".csv": Console.WriteLine(table.convertTocsv());
            WriteToFile(table.convertTocsv(),newFile);
            break;
        case ".html": Console.WriteLine(table.convertTohtml());
            WriteToFile(table.convertTohtml(),newFile);
            break;
        case ".json": Console.WriteLine(table.convertTojson());
            WriteToFile(table.convertTojson(),newFile);
            break;
        default: Console.WriteLine("output file not reconized"); break;
    }
}

//*********** WRITING THE CONVERSION TO NEW FILE*************
static void WriteToFile(string str, string newFile)
{
    string path = @"./"+newFile;
    if (!File.Exists(path))
    {
        // Create a file to write to if there isnt one.
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(str);
        }
    }
    else
    {
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(str);
        }
    }
}

//######################################### FILE TO STRING ARRAY METHODS #######################
//********** METHOD TO TURN A JSON TO A STRING ARRAY ********* 
//i cant figure out how to get the table info when wew dont know what the json table is going to contain
//ive watched all the lectures and searched around the internet if this method was done i would be able to convert from it
static void jsonToStrArr(string filetxt)
{
    char[] charsToTrim2 = { '[', ']', '{', '}', ',','\t' };
    filetxt.Trim(charsToTrim2);//funny it never even trimmed 
    //Console.WriteLine("did i get here?");//testing
    Console.WriteLine(filetxt);
}

//********** METHOD TO TURN HTML INTO STRING ARRAY *******
static string[] htmlToStrArr(string filetxt)
{
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(filetxt);
    HtmlNode[] cols = doc.DocumentNode.SelectNodes("//th").ToArray();//use this to find the #of cols
    htmlNum.htmlCol=cols.Length;
    HtmlNode[] rows = doc.DocumentNode.SelectNodes("//td").ToArray();//find the num of elements in the rest of the table
    htmlNum.htmlRow=rows.Length/htmlNum.htmlCol+1;//finds the number of rows including the heading lenOfAllelements/numcols+1= numrows
    HtmlNode[] table = doc.DocumentNode.SelectNodes("//th|//td").ToArray();//everything in one 
    
    string[] tabStrArr = new string[table.Length];
    
    for(int i=0;i<table.Length;i++)
    {
        tabStrArr[i] = table[i].InnerHtml.ToString();
        //Console.WriteLine(tabStrArr[i]);
    }
    //Console.WriteLine("uhghghghgh");
    //Console.WriteLine(htmlNum.htmlRow+" "+htmlNum.htmlCol);
    
    return tabStrArr;
}

//*************************************TABLE CLASS**********************************
public class Table
{
    //~~~~~~~~VARS~~~~~~~~~
   public int rowNum { get; }
   public int colNum { get; }

   public string[,] myTable;

//~~~~~~~~~~~~~~~~ CREATING THE DOUBLE ARRAY~~~~~~~~~~~~~~~~
   public Table(int rowNum, int colNum, String[] StrArr, String type)
   {
        this.rowNum = rowNum;
        this.colNum = colNum;

        if(type=="csv")
        {
            String[,] plsWork = new string[rowNum,colNum];
            myTable = plsWork;//idk i just needed to not have an error

            for(int i = 0; i < rowNum; i++)
            {
                String[] temp = StrArr[i].Split(",");//split by space for now this will need to be changed
                for(int j = 0; j < colNum; j++)
                {
                    myTable[i,j] = temp[j];//put the info into thr table class
                }
            }
        }
        else if(type=="html")
        {
            String[,] plsWork = new string[rowNum,colNum];
            myTable = plsWork;//idk i just needed to not have an error
            int count=0;
            for(int i=0;i<rowNum;i++)
            {
                for(int j=0;j<colNum;j++)
                {
                    myTable[i,j]=StrArr[count];
                    count++;
                }
            }
        }
   }

   //~~~~~~~~~~~~ TABLE METHODS ~~~~~~~~~~~~~~
   public String[,] getTable()
   {
       return myTable;
   }

   public void printTable()
   {
       //Console.WriteLine("I am about to print!");//tessting
      for(int i = 0; i < rowNum; i++)
      {
         for(int j = 0; j < colNum; j++)
         {
            Console.WriteLine(myTable[i,j]);
         }
      }
   }

    //************METHODS TO CONVERT (results in a string)**********
   public string convertTocsv()//take info from myTable and use a string builder to make it into a csv
   {
       StringBuilder csvSB = new StringBuilder();
       for(int i = 0; i < rowNum; i++)
      {
        for(int j = 0; j < colNum; j++)
        {
            // Console.WriteLine(myTable[i,j]);
            if(j!=colNum-1)
            {
                csvSB.Append(myTable[i,j]+",");
            }
            else
            {
                csvSB.Append(myTable[i,j]);
            }
        }
        csvSB.Append("\n");
      }
      string csvtxt = csvSB.ToString();
      return csvtxt;
   }

   public string convertTojson()//take info from myTable and use a string builder to make it into a json
   {
       StringBuilder jsonSB = new StringBuilder();
       jsonSB.Append("[");
       jsonSB.Append("\n");
       for(int i=0;i<rowNum;i++)
       {
           jsonSB.Append("\t{");
           jsonSB.Append("\n");
           for(int j=0;j<colNum;j++)
           {
               if(j!=colNum-1)
                {
                    jsonSB.Append("\t\t"+myTable[0,j]+": "+myTable[i,j]+",\n");
                }
                else
                {
                    jsonSB.Append("\t\t"+myTable[0,j]+": "+myTable[i,j]+"\n");
                }
               //jsonSB.Append("\t\t"+myTable[0,j]+": "+myTable[i,j]+",\n");
           }
           jsonSB.Append("\t},");
           jsonSB.Append("\n");
       }
       jsonSB.Append("]");
       string jsonTxt = jsonSB.ToString();
       return jsonTxt;
   }

    public string convertTohtml()//take info from myTable and use a string builder to make it into a html
    {
        StringBuilder htmlSB = new StringBuilder();
        htmlSB.Append("<table>\n");
        for(int i=0;i<rowNum;i++)
        {
            htmlSB.Append("\t<tr>\n");
            for(int j=0;j<colNum;j++)
            {
                if(i==0)//for the first row
                {
                    htmlSB.Append("\t\t<th>"+myTable[i,j]+"</th>\n");
                }
                else
                {
                    htmlSB.Append("\t\t<td>"+myTable[i,j]+"</td>\n");
                }
            }
            htmlSB.Append("\t</tr>\n");
        }
        htmlSB.Append("</table>\n");
        string htmlTxt = htmlSB.ToString();
        return htmlTxt;
    }
}

//~WANTED TO MAKE A GLOBAL VAR FOR MY HTML ROWS AND COLS SO THATS WHY THIS IS HERE~
static class htmlNum
{
    public static int htmlCol;
    public static int htmlRow;
}

//******THINGS IVE TRIED BUT DIDNT WORK***********("if at first you try but you dont suceed....")
//Console.WriteLine(command);
/*
String origFile = commandArr[1];//gets the origional file name
String[] tempOrig = commandArr[1].split(".");
String origFileType = tempOrig[1];//gets the last few charectors to see what file type it is

String newFile = commandArr[3];//gets the new file name
String[] tempNew = commandArr[3].split(".");
String newFileType = tempNew[1];//gets the last few chars to see what the new file will be
    if (!File.Exists(path))
    {
        // Create a file to write to if there isnt one.
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Hello");
            sw.WriteLine("World!");
        }
    }
*/
//tried to use substings to find the file names but for whatever reason it did not like LastIndexOf
//String oFileName = command.Substring(command.IndexOf("-")+3, command.IndexOf(".")-3);
//Console.WriteLine(oFileName);
//String oFileType;
//String nFileName = command.Substring(command.LastIndexOf("-")+3, command.LastIndexOf("."));
//Console.WriteLine(nFileName);
//String nFileType 
/*
string path = @"/Users/jessicakrapfl/Desktop/Files/Maynooth/CS264/Hello/MyApp/test.txt";  // Linux and MacOS
StringBuilder contents = new StringBuilder(); //using a string builder as it is a mutable string that could be as long as i want
if (!File.Exists(path))
{
    // Create a file to write to if there isnt one.
    using (StreamWriter sw = File.CreateText(path))
    {
        sw.WriteLine("Hello");
        sw.WriteLine("World!");
    }
}

// Open the file to read from.
 using (StreamReader sr = File.OpenText(path))
{
    string s;
    while ((s = sr.ReadLine()) != null)
    {
        contents.Append(s +"\n");
        //Console.WriteLine(s);
    }
}
//Console.WriteLine(contents);//testing
String filetxt = contents.ToString();//after the text file is all read into the string builder make it a string
*/
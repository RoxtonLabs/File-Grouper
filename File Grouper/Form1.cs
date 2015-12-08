using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;    //For directory and file handling

namespace File_Grouper
{
    public partial class Form1 : Form
    {
        Boolean running = false;
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.ToolTip helpTT1 = new System.Windows.Forms.ToolTip();
            helpTT1.SetToolTip(this.patternBox,"If you only want to group certain files, enter a matching pattern here." + Environment.NewLine + "For example, to match only .rtf files, enter \"*.rtf\"." + Environment.NewLine + "To group all files, leave this field blank.");
        }

        private void browseButton_Click(object sender, EventArgs e)
        {   //Choose the folder containing the files to divide
            DialogResult result = folderBrowser.ShowDialog();
            if (result==DialogResult.OK)
            {
                dirBox.Text = folderBrowser.SelectedPath;
            }
        }

        private void groupButton_Click(object sender, EventArgs e)
        {
            //So some basic checks before we start
            if (!running)
            {
                if (string.IsNullOrWhiteSpace(dirBox.Text))
                {
                    MessageBox.Show("Please enter a directory containing files to group.");
                }
                else if (!Directory.Exists(dirBox.Text))
                {
                    MessageBox.Show("Could not find " + dirBox.Text + ". Please enter a valid directory and try again.");
                }
                else
                {   //Get the search pattern (if it exists
                    string pattern;
                    if (string.IsNullOrWhiteSpace(patternBox.Text))
                    {   //If there's no search pattern then get all files
                        pattern = "*";
                    }
                    else
                    {
                        pattern = patternBox.Text;
                    }
                    //Don't think we need to validate this; if we get it wrong it just won't group any files

                    //First, disable the button and start running
                    running = true;
                    groupButton.Text = "Calculating...";
                    groupButton.Enabled = false;
                    browseButton.Enabled = false;
                    dirBox.Enabled = false;
                    groupUpdown.Enabled = false;

                    //Now gather the files we're going to group
                    string[] fileNames = Directory.GetFiles(dirBox.Text, pattern);
                    int numFiles = fileNames.Length;

                    int numGroups = Convert.ToInt16(groupUpdown.Value);

                    //Set a default sort
                    var sort = from fileName in fileNames select fileName;

                    //Create some variables to hold group metadata
                    string[,] groupContents = new string[numGroups + 1, numFiles];  //This array will hold the file names for each group
                        //Some explanation for that line: [g,f]
                        //g = group number
                        //f = file number in that group (starts at 1)
                    Int64[] orderedSizes = new Int64[numGroups];    //A list of the sizes of each group with no reference to group number
                    Int64[] groupSizes = new Int64[numGroups + 1];  //How large each group is (index is group number)
                    int[] numGroupFiles = new int[numGroups + 1];   //The index that links group names to the number of files in the group
                    
                    //Now sort by size (largest to smallest)
                    sort = from fileName in fileNames
                           orderby new FileInfo(fileName).Length descending
                           select fileName;

                    //Put the largest file into the smallest group

                    //First intialize our arrays
                    for (int i = 1; i <= numGroups; i++)
                    {
                        groupSizes[i] = 0;
                    }

                    //Now sort each string into a different group
                    foreach (string s in sort)
                    {   //Find the smallest group
                        Array.Sort<Int64>(orderedSizes);    //By default sorts smallest to largest, which is what we want

                        //Find the group that owns the smallest value (if there are two with the same value it doesn't matter which we choose)
                        int littlestGroup = 0;
                        for (int i=1; i<=numGroups; i++)
                        {   //Search the groupSizes array for a group with a matching file size
                            if (groupSizes[i]==orderedSizes[0])
                            {
                                littlestGroup = i;  //We've found it so we can leave now
                                break;
                            }
                        }

                        //Add the largest file to the smallest group
                        numGroupFiles[littlestGroup]++; //Increase the number of files in that group
                        groupContents[littlestGroup, numGroupFiles[littlestGroup]] = s; //Add the file name to the group
                        groupSizes[littlestGroup] += new FileInfo(s).Length;    //Add the file size to the array that tracks group sizes
                        for (int i = 1; i <= numGroups; i++)
                        {
                            orderedSizes[i - 1] = groupSizes[i];
                        }
                    }

                    //So now all that's done we can actually move the files around
                    
                    //Some visual faffery
                    groupButton.Enabled = true;
                    groupButton.Text = "Grouping...";
                    groupButton.Enabled = false;
                    copyProgress.Minimum = 0;
                    copyProgress.Maximum = numFiles;
                    copyProgress.Value = 0;
                    copyProgress.Step = 1;
                     
                    //Create the folders (if they don't already exist)
                    for (int i = 1; i <= numGroups; i++)
                    {
                        if(!Directory.Exists(dirBox.Text + @"\Group " + i.ToString()))
                        {
                            Directory.CreateDirectory(dirBox.Text + @"\Group " + i.ToString());
                        }
                        //Then copy the files into the folders
                        for (int j = 1; j<=numGroupFiles[i]; j++)
                        {   //For each file in the group...
                            string justName = new FileInfo(groupContents[i, j]).Name;
                            File.Copy(groupContents[i, j], dirBox.Text + @"\Group " + i.ToString() + "\\" + justName, true);    //Allow overwriting
                            //maybe it would be better not to allow silent overwriting? Nah, what could possibly go wrong?
                            copyProgress.PerformStep(); //Move the progress bar along
                        }
                    }

                    //When we're finally done, display a message
                    groupButton.Enabled = true;
                    groupButton.Text = "Group";
                    browseButton.Enabled = true;
                    dirBox.Enabled = true;
                    groupUpdown.Enabled = true;
                    running = false;
                    MessageBox.Show("Grouping completed! Copied " + numFiles.ToString() + " files into " + numGroups + " groups.");
                }
            }
        }
    }
}

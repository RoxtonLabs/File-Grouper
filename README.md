# File-Grouper
Copies files into groups of roughly equal size and number. Useful for dividing large numbers of files for distributed processing, etc..

Created in Visual Studio as a Windows Forms Application, hence all the designer gubbins. The action is all over in File-Grouper/File Grouper/Form1.cs.

Creates a list of the files in the specified folder that match the specified pattern (if no pattern is specified, uses all the files in the folder). Creates a user-specified number of sub-folders. Copies the largest file in the list into the smallest sub-folder. Repeats until all files are sorted. This sorting is all done in arrays before the files are actually copied into the folders.

This tends to produce sub-folders that are not only similar in size, but also contain similar numbers of files. I have found that this produces a more even load because of the overheads associated with reading/saving individual files.

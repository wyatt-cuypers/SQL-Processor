# SQL-Processor
The SQL Processor program is a windows forms application written in Visual Basic .NET. The purpose of this program is to pick up files written by other programs, read them and if they are valid, store them into a database. 

# Startup
Upon starting, the program checks to see if settings for a database connection have been set. If they have not, a settings form is popped up. Users have the option of making a connection by either SQL Server authentication or Windows authentication. A source path as well as seconds to wait are also specified here.

# Main function
After setup, the program then looks at the source path that was specified by the user and looks for files to process. A timer for the number of seconds specified by the user counts down and everytime it hits zero its looks for new files. 

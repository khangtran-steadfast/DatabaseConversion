# BOA - Data conversion tool

## 1. Introduction
This tool is used for mapping data from Eclipse database to BOALedger database (Version 1.39) .

## 2. Development

#### 2.1 Setting up your Development Environment
1. Fork this repository to your own GitHub account and clone it to your local PC in the `C:\Dev\Boa-data-conversion` directory.

2. [Setup Visual Studio to always run as Administrator] (http://stackoverflow.com/questions/9654833/how-to-run-visual-studio-as-administrator-by-default)

3. Open `C:\Dev\Boa-data-conversion\DataConversion.sln`.

4. Right-click on the `Solution` and select `Enable NuGet Package Restore`.

5. Rebuild. Check that there are no compile errors.

6. In order for each developer to maintain their own database connection string, each project's `connectionStrings` entry is 
   set to:
   
   ```xml
   <connectionStrings configSource="CustomConnectionStrings.config" />
   ```
   
   This causes the connection string to be loaded from a separate file which is excluded from source control.

   Create a file called `CustomConnectionStrings.config` in the same location as the `App.config` in DataConversionTool project.

7. Add a `\<connectionStrings>` block to the `CustomConnectionStrings.config` files created in the previous step:

   ```xml
   <connectionStrings>
  <add name="BOALedgerEntities" connectionString="metadata=res://*/BOALedgerDatabase.csdl|res://*/BOALedgerDatabase.ssdl|res://*/BOALedgerDatabase.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\sqlexpress;initial catalog=BOALedger;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  <add name="EclipseDatabaseEntities" connectionString="metadata=res://*/EclipseDatabase.csdl|res://*/EclipseDatabase.ssdl|res://*/EclipseDatabase.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\sqlexpress;initial catalog=EclipseDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
   ```
   
   The two connection strings will be for the `EclipseDatabase` and `BOALedger` databases.

8. Check that the `Build Action` for the `CustomConnectionStrings.config` files is set to `Content` and the `Copy to Output Directory` property is set to `Copy always`.

9. Debug the project and check that there are no errors.

## 3. DataConversionTool parameters

1. To report data error in source database, please add this parameter : 

   ```xml
   \export-data-errors
   ```

2. To export migration script, which adds data from source to destination database, please add this parameter :
   
   ```xml
   \export-script:output
   ```

   Which, `\export-script` is command for conversion tool know that it needs to export SQL script.
   And `output` is folder name to store extracted script.
   
3. By default, conversion tool extracts SQL script to `Output` folder. If you want to run SQL script immediately, please add this parameter :

   ```xml
   \run-sql
   ```
   
## 4. DataConversionTool document

Document about DataConversionTool : [Document](https://steadfastgroup-my.sharepoint.com/personal/nguyen_anh_dao_steadfasttech_com_au/_layouts/15/guestaccess.aspx?guestaccesstoken=wagbu5vOS9jZsAOKCQYT%2fXobIiLWRyzqFnWNGCXOhxs%3d&docid=1bb99c7e3a5004eedb3bf43351bed4441)

## 5. Third party library

1. This project using FastMember library : https://www.nuget.org/packages/FastMember/ . This library allows us to access variable's property faster than .NET Reflection.

2. AutoMapper library : https://www.nuget.org/packages/AutoMapper/

3. Log4Net library : https://www.nuget.org/packages/log4net/
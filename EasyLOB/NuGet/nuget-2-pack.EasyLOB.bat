rem 4.0.0 C
if "%~1" == "" goto end
if "%~2" == "" goto end
nuget pack EasyLOB.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.AuditTrail.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.DIAutofac.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.EnvironmentDesktop.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.EnvironmentWeb.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.Extensions.Edm.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.Extensions.Mail.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.LogNLog.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.PersistenceEntityFramework.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
nuget pack EasyLOB.Security.nuspec -OutputDirectory %2:\NuGet\EasyLOB -Properties propertyVersion="%1"
:end
@pause
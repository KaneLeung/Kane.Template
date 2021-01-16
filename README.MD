> 生成模版
```CMD
nuget pack X:\XXX\Kane.Template\Furion.Mvc\Furion.Mvc.nuspec -NoDefaultExcludes
```

> 安装模版
```CMD
dotnet new -i X:\XXX\Kane.Template\Furion.Mvc.1.0.0.nupkg
```

> 卸载模版
```CMD
dotnet new -u Furion.Mvc
```
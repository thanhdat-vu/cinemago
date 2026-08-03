var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CinemaGo_WebServer>("cinemago-webserver");

builder.Build().Run();

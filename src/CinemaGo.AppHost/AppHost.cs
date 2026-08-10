var builder = DistributedApplication.CreateBuilder(args);
var postgresUser = builder.AddParameter(
    "postgres-user",
    "postgres",
    publishValueAsDefault: true,
    secret: false);
var postgresPassword = builder.AddParameter(
    "postgres-password",
    "postgres",
    publishValueAsDefault: false,
    secret: true);

var postgres = builder.AddPostgres(
        "postgres",
        userName: postgresUser,
        password: postgresPassword)
    .WithPgWeb(pg => pg.WithHostPort(5050));

var cinemagodb = postgres.AddDatabase("cinemagodb");

var redis = builder.AddRedis("redis");

builder.AddProject<Projects.CinemaGo_WebServer>("cinemago-webserver")
    .WithReference(cinemagodb)
    .WithReference(redis)
    .WaitFor(cinemagodb)
    .WaitFor(redis);

builder.Build().Run();

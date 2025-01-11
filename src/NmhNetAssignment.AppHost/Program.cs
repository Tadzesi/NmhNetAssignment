
var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("nmhnetassignment-postgress");

builder.AddProject<Projects.NmhNetAssignment_Api>("nmhnetassignment-api")
.WithReference(postgres)
.WaitFor(postgres);

await builder.Build().RunAsync();

/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.OrderItem.created = function (entity) {
    // Write code here.
    entity.c_Date = new Date();

    

    myapp.activeDataWorkspace.DeskData.User.top(1).execute().then(function (result) {
        entity.UserOwner = result.results[0];
    });

 
    myapp.activeDataWorkspace.DeskData.Status.top(1).execute().then(function (result) {
        entity.Status = result.results[0];
    });
    
};

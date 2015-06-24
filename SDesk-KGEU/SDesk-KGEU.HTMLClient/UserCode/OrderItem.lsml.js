/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.OrderItem.created = function (entity) {
    entity.IdOrder = 0;
    entity.c_Date = new Date();
    myapp.activeDataWorkspace.DeskData.Status.top(1).execute().then(function (result) {
        entity.Status = result.results[0];
    });   
};

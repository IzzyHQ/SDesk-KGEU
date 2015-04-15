/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.BrowseOrder.created = function (screen) {
    // Write code here.


};

myapp.BrowseOrder.Status1_postRender = function (element, contentItem) {
    // Write code here.

};
myapp.BrowseOrder.ShowAll_execute = function (screen) {
    // Write code here.
    
};
myapp.BrowseOrder.Filter_execute = function (screen) {
    // Write code here.
    if (screen.OrderItemparamSort == "All")
    {
        screen.OrderItemparamSort = "New";
        screen.Order.load();
        screen.Filter = "New";
    }
    else
    {
        screen.OrderItemparamSort = "All";
        screen.Order.load();
        screen.Filter = "All";
    }
};

myapp.BrowseOrder.Filter_postRender = function (element, contentItem) {
    contentItem.dataBind("value.details.screen.OrderItemparamSort", function (sortValue) {
        if (sortValue !== 'undefined' && sortValue !== null) {
            if (sortValue == "All") {
                element.innerHTML = "<u>Показать новые</u>";
            } else {
                element.innerHTML = "<u>Показать все</u>";
            }
        }
    });
};